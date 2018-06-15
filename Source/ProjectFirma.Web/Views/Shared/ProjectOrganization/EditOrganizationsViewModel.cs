/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectOrganization
{
    public class EditOrganizationsViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectPrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }
        public List<ProjectOrganizationSimple> ProjectOrganizationSimples { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditOrganizationsViewModel()
        {
        }

        public EditOrganizationsViewModel(Models.Project project, List<Models.ProjectOrganization> projectOrganizations,
            Person currentPerson)
        {           
            PrimaryContactPersonID = project.PrimaryContactPersonID;
            
            ProjectOrganizationSimples = projectOrganizations.Select(x => new ProjectOrganizationSimple(x)).ToList();

            // If the current person belongs to a primary contact organization, and the current project has no primary contact organization set, prepopulate.
            if (currentPerson != null && currentPerson.Organization.CanBeAPrimaryContactOrganization())
            {
                var primaryContactRelationshipTypeIDs = HttpRequestStorage.DatabaseEntities.RelationshipTypes
                    .Where(x => x.IsPrimaryContact).Select(x => x.RelationshipTypeID).ToList();
                if (!projectOrganizations.Any(x => primaryContactRelationshipTypeIDs.Contains(x.RelationshipTypeID)))
                {
                    ProjectOrganizationSimples.AddRange(primaryContactRelationshipTypeIDs.Select(x =>
                        new ProjectOrganizationSimple(currentPerson.OrganizationID, x)));
                }
            }
        }

        public void UpdateModel(Models.Project project, ICollection<Models.ProjectOrganization> allProjectOrganizations)
        {
            project.PrimaryContactPersonID = PrimaryContactPersonID;

            var projectOrganizationsUpdated = ProjectOrganizationSimples.Select(x =>
                new Models.ProjectOrganization(project.ProjectID, x.OrganizationID, x.RelationshipTypeID)).ToList();

            project.ProjectOrganizations.Merge(projectOrganizationsUpdated,
                allProjectOrganizations,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID && x.RelationshipTypeID == y.RelationshipTypeID);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (ProjectOrganizationSimples == null)
            {
                ProjectOrganizationSimples = new List<ProjectOrganizationSimple>();
            }

            if (ProjectOrganizationSimples.GroupBy(x => new { x.RelationshipTypeID, x.OrganizationID }).Any(x => x.Count() > 1))
            {
                errors.Add(new ValidationResult($"Cannot have the same relationship type listed for the same {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()} multiple times."));
            }
            
            var relationshipTypeThatMustBeRelatedOnceToAProject = HttpRequestStorage.DatabaseEntities.RelationshipTypes.Where(x => x.CanOnlyBeRelatedOnceToAProject).ToList();

            var projectOrganizationsGroupedByRelationshipTypeID =
                ProjectOrganizationSimples.GroupBy(x => x.RelationshipTypeID).ToList();

            errors.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectOrganizationsGroupedByRelationshipTypeID.Count(po => po.Key == rt.RelationshipTypeID) > 1)
                .Select(relationshipType => new ValidationResult(
                    $"Cannot have more than one {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()} with a {Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} set to \"{relationshipType.RelationshipTypeName}\".")));

            errors.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectOrganizationsGroupedByRelationshipTypeID.Count(po => po.Key == rt.RelationshipTypeID) == 0)
                .Select(relationshipType => new ValidationResult(
                    $"Must have one {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()} with a {Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} set to \"{relationshipType.RelationshipTypeName}\".")));

            var allValidRelationshipTypes = ProjectOrganizationSimples.All(x =>
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(x.OrganizationID);
                var organizationType = organization.OrganizationType;

                if (organizationType != null)
                {
                    var organizationTypeRelationshipTypeIDs =
                        organizationType.OrganizationTypeRelationshipTypes.Select(y => y.RelationshipTypeID);

                    return organizationTypeRelationshipTypeIDs.Contains(x.RelationshipTypeID);
                }
                return false;
            });

            if (!allValidRelationshipTypes)
            {
                errors.Add(new ValidationResult("One or more relationship types are invalid."));
            }

            return errors;
        }
    }
}
