/*-----------------------------------------------------------------------
<copyright file="EditContactsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectContact
{
    public class EditContactsViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectPrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }
        public List<ProjectContactSimple> ProjectContactSimples { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditContactsViewModel()
        {
        }

        public EditContactsViewModel(ProjectFirmaModels.Models.Project project, List<ProjectFirmaModels.Models.ProjectOrganization> projectOrganizations,
            Person currentPerson)
        {           
            PrimaryContactPersonID = project.PrimaryContactPersonID;
            
            ProjectContactSimples = projectOrganizations.Select(x => new ProjectOrganizationSimple(x)).ToList();

            // If the current person belongs to a primary contact organization, and the current project has no primary contact organization set, prepopulate.
            if (currentPerson != null && currentPerson.Organization.CanBeAPrimaryContactOrganization())
            {
                var primaryContactOrganizationRelationshipTypeIDs = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes
                    .Where(x => x.IsPrimaryContact).Select(x => x.OrganizationRelationshipTypeID).ToList();
                if (!projectOrganizations.Any(x => primaryContactOrganizationRelationshipTypeIDs.Contains(x.OrganizationRelationshipTypeID)))
                {
                    ProjectContactSimples.AddRange(primaryContactOrganizationRelationshipTypeIDs.Select(x =>
                        new ProjectOrganizationSimple(currentPerson.OrganizationID, x)));
                }
            }
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, ICollection<ProjectFirmaModels.Models.ProjectOrganization> allProjectOrganizations)
        {
            project.PrimaryContactPersonID = PrimaryContactPersonID;

            var projectOrganizationsUpdated = ProjectContactSimples.Where(x => ModelObjectHelpers.IsRealPrimaryKeyValue(x.ContactID)).Select(x =>
                new ProjectFirmaModels.Models.ProjectOrganization(project.ProjectID, x.ContactID, x.ContactRelationshipTypeID)).ToList();

            project.ProjectOrganizations.Merge(projectOrganizationsUpdated,
                allProjectOrganizations,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID && x.OrganizationRelationshipTypeID == y.OrganizationRelationshipTypeID, HttpRequestStorage.DatabaseEntities);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (ProjectContactSimples == null)
            {
                ProjectContactSimples = new List<ProjectOrganizationSimple>();
            }

            if (ProjectContactSimples.GroupBy(x => new { RelationshipTypeID = x.ContactRelationshipTypeID, OrganizationID = x.ContactID }).Any(x => x.Count() > 1))
            {
                errors.Add(new ValidationResult($"Cannot have the same relationship type listed for the same {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} multiple times."));
            }
            
            var relationshipTypeThatMustBeRelatedOnceToAProject = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.Where(x => x.CanOnlyBeRelatedOnceToAProject).ToList();

            var projectOrganizationsGroupedByRelationshipTypeID =
                ProjectContactSimples.GroupBy(x => x.ContactRelationshipTypeID).ToList();

            errors.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectOrganizationsGroupedByRelationshipTypeID.Count(po => po.Key == rt.OrganizationRelationshipTypeID) > 1)
                .Select(relationshipType => new ValidationResult(
                    $"Cannot have more than one {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} with a {FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.OrganizationRelationshipTypeName}\".")));

            errors.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectOrganizationsGroupedByRelationshipTypeID.Count(po => po.Key == rt.OrganizationRelationshipTypeID) == 0)
                .Select(relationshipType => new ValidationResult(
                    $"Must have one {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} with a {FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.OrganizationRelationshipTypeName}\".")));

            var allValidRelationshipTypes = ProjectContactSimples.All(x =>
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(x.ContactID);
                var organizationType = organization.OrganizationType;

                if (organizationType != null)
                {
                    var organizationTypeOrganizationRelationshipTypeIDs =
                        organizationType.OrganizationTypeOrganizationRelationshipTypes.Select(y => y.OrganizationRelationshipTypeID);

                    return organizationTypeOrganizationRelationshipTypeIDs.Contains(x.ContactRelationshipTypeID);
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
