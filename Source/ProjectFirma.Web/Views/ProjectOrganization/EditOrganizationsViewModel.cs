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
using FluentValidation.Attributes;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
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

        public EditOrganizationsViewModel(List<Models.ProjectOrganization> projectOrganizations, Models.Project project)
        {
            var projectOrganizationJsons = projectOrganizations.GroupBy(po => po.Organization).Select(o => new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(o.Key, o.ToList())).ToList();

            var leadOrganization = project.LeadImplementerOrganization;
            var leadOrganizationID = leadOrganization?.OrganizationID;

            ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(leadOrganizationID, projectOrganizationJsons);
        }

        public void UpdateModel(Models.Project project, ICollection<Models.ProjectOrganization> allProjectOrganizations)
        {            
            project.LeadImplementerOrganizationID = ProjectOrganizationsViewModelJson.LeadOrganizationID;

            var projectOrganizationViewModelJsons =
                ProjectOrganizationsViewModelJson.ProjectOrganizations.ToList();

            var projectOrganizationsUpdated = projectOrganizationViewModelJsons.SelectMany(
                    orgBeingAdded =>
                    {
                        var projectOrgsToAdd = new List<Models.ProjectOrganization>();
                        foreach (var relationshipType in orgBeingAdded.RelationshipTypes)
                        {
                            projectOrgsToAdd.Add(new Models.ProjectOrganization(project.ProjectID, orgBeingAdded.OrganizationID.Value, relationshipType.RelationshipTypeID));
                        }
                        return projectOrgsToAdd;
                    }).ToList();

            project.ProjectOrganizations.Merge(projectOrganizationsUpdated,
                allProjectOrganizations,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID && x.RelationshipTypeID == y.RelationshipTypeID);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (ProjectOrganizationsViewModelJson.LeadOrganizationID == null)
            {
                errors.Add(new ValidationResult($"{Models.FieldDefinition.LeadImplementer.GetFieldDefinitionLabel()} Organization is required."));
                return errors;
            }
            if (ProjectOrganizationsViewModelJson.ProjectOrganizations.Any(x => x.OrganizationID == null))
            {
                errors.Add(new ValidationResult("Organization must be specfied."));
                return errors;
            }

            var leadOrg = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(ProjectOrganizationsViewModelJson.LeadOrganizationID.Value);
            if (leadOrg.PrimaryContactPerson == null)
            {
                errors.Add(new ValidationResult($"{Models.FieldDefinition.LeadImplementer.GetFieldDefinitionLabel()} Organization must have a {Models.FieldDefinition.PrimaryContact.GetFieldDefinitionLabel()} set."));
            }
            if (ProjectOrganizationsViewModelJson.ProjectOrganizations.Count != ProjectOrganizationsViewModelJson.ProjectOrganizations.Select(x => x.OrganizationID).Distinct().Count())
            {
                errors.Add(new ValidationResult("Cannot have the same organization listed multiple times."));
            }
            if (ProjectOrganizationsViewModelJson.ProjectOrganizations.Any(x => x.RelationshipTypes.Count != x.RelationshipTypes.Select(y => y.RelationshipTypeID).Distinct().Count()))
            {
                errors.Add(new ValidationResult("Cannot have the same relationship type listed for the same organization multiple times."));
            }
            var allValidRelationshipTypes = ProjectOrganizationsViewModelJson.ProjectOrganizations.All(x =>
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(x.OrganizationID.Value);
                var validRelationshipTypes = organization.OrganizationType.OrganizationTypeRelationshipTypes
                    .Select(t => t.RelationshipType)
                    .ToList();
                
                return x.RelationshipTypes.All(y => validRelationshipTypes.Select(i => i.RelationshipTypeID).Contains(y.RelationshipTypeID));
            });
            if (!allValidRelationshipTypes)
            {
                errors.Add(new ValidationResult("One or more relationship types are invalid."));
            }
            
           
            return errors;
        }
    }
}
