/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    public class EditOrganizationsViewModel : FormViewModel, IValidatableObject
    {
        public ProjectOrganizationsViewModelJson ProjectOrganizationsViewModelJson { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditOrganizationsViewModel()
        {
        }

        public EditOrganizationsViewModel(List<Models.ProjectOrganization> projectOrganizations)
        {
            var projectOrganizationJsons = projectOrganizations.GroupBy(po => po.Organization).Select(o => new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(o.Key, o.ToList())).ToList();

            ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(projectOrganizationJsons);
        }

        public void UpdateModel(Models.Project project, ICollection<Models.ProjectOrganization> allProjectOrganizations)
        {
            var projectOrganizationViewModelJsons =
                ProjectOrganizationsViewModelJson.ProjectOrganizations.ToList();

            var projectOrganizationsUpdated = projectOrganizationViewModelJsons.SelectMany(
                orgBeingAdded => orgBeingAdded.RelationshipTypes.Select(
                    relationshipType => new Models.ProjectOrganization(project.ProjectID,
                        orgBeingAdded.OrganizationID.Value, relationshipType.RelationshipTypeID))).ToList();

            project.ProjectOrganizations.Merge(projectOrganizationsUpdated,
                allProjectOrganizations,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID && x.RelationshipTypeID == y.RelationshipTypeID);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            
            if (ProjectOrganizationsViewModelJson.ProjectOrganizations.Any(x => x.OrganizationID == null))
            {
                errors.Add(new ValidationResult($"{Models.FieldDefinition.Organization.GetFieldDefinitionLabel()} must be specfied."));
                return errors;
            }
           
            if (ProjectOrganizationsViewModelJson.ProjectOrganizations.Count != ProjectOrganizationsViewModelJson.ProjectOrganizations.Select(x => x.OrganizationID).Distinct().Count())
            {
                errors.Add(new ValidationResult($"Cannot have the same {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()} listed multiple times."));
            }

            if (ProjectOrganizationsViewModelJson.ProjectOrganizations.Any(x => x.RelationshipTypes.Count != x.RelationshipTypes.Select(y => y.RelationshipTypeID).Distinct().Count()))
            {
                errors.Add(new ValidationResult($"Cannot have the same relationship type listed for the same {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()} multiple times."));
            }

            var relationshipTypeThatCanApprove = HttpRequestStorage.DatabaseEntities.RelationshipTypes.SingleOrDefault(x => x.CanApproveProjects);
            if (relationshipTypeThatCanApprove != null && ProjectOrganizationsViewModelJson.ProjectOrganizations
                    .SelectMany(x => x.RelationshipTypes).Count(x => x.RelationshipTypeID == relationshipTypeThatCanApprove.RelationshipTypeID) > 1)
            {
                errors.Add(new ValidationResult($"Cannot have more than one {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()} with a {Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} set to \"{relationshipTypeThatCanApprove.RelationshipTypeName}\"."));
            }

            var allValidRelationshipTypes = ProjectOrganizationsViewModelJson.ProjectOrganizations.All(x =>
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(x.OrganizationID.Value);
                var organizationType = organization.OrganizationType;
                if (organizationType != null)
                {
                    var validRelationshipTypes = organizationType.OrganizationTypeRelationshipTypes
                        .Select(t => t.RelationshipType)
                        .ToList();

                    return x.RelationshipTypes.All(y => validRelationshipTypes.Select(i => i.RelationshipTypeID)
                        .Contains(y.RelationshipTypeID));
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
