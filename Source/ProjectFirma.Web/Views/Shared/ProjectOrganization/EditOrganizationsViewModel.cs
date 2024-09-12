﻿/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectOrganization
{
    public class EditOrganizationsViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectPrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }
        public List<ProjectOrganizationSimple> ProjectOrganizationSimples { get; set; }
        public string OtherPartners { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditOrganizationsViewModel()
        {
        }

        public EditOrganizationsViewModel(ProjectFirmaModels.Models.Project project, 
                                          List<ProjectFirmaModels.Models.ProjectOrganization> projectOrganizations,
                                          FirmaSession currentFirmaSession)
        {
            // Preconditions
            Check.EnsureNotNull(project);
            Check.EnsureNotNull(projectOrganizations);
            Check.EnsureNotNull(currentFirmaSession);

            PrimaryContactPersonID = project.PrimaryContactPersonID;
            ProjectOrganizationSimples = projectOrganizations.Select(x => new ProjectOrganizationSimple(x)).ToList();

            // If the current person belongs to a primary contact organization, and the current project has no primary contact organization set, prepopulate.
            if (!currentFirmaSession.IsAnonymousUser() && currentFirmaSession.Person.Organization.CanBeAPrimaryContactOrganization())
            {
                var primaryContactOrganizationRelationshipTypeIDs = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes
                    .Where(x => x.IsPrimaryContact).Select(x => x.OrganizationRelationshipTypeID).ToList();
                if (!projectOrganizations.Any(x => primaryContactOrganizationRelationshipTypeIDs.Contains(x.OrganizationRelationshipTypeID)))
                {
                    ProjectOrganizationSimples.AddRange(primaryContactOrganizationRelationshipTypeIDs.Select(x =>
                        new ProjectOrganizationSimple(currentFirmaSession.Person.OrganizationID, x)));
                    PrimaryContactPersonID = currentFirmaSession.Person.Organization.PrimaryContactPersonID;
                }
            }

            OtherPartners = project.OtherPartners;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, ICollection<ProjectFirmaModels.Models.ProjectOrganization> allProjectOrganizations)
        {
            project.PrimaryContactPersonID = PrimaryContactPersonID;

            var projectOrganizationsUpdated = ProjectOrganizationSimples.Where(x => ModelObjectHelpers.IsRealPrimaryKeyValue(x.OrganizationID)).Select(x =>
                new ProjectFirmaModels.Models.ProjectOrganization(project.ProjectID, x.OrganizationID, x.OrganizationRelationshipTypeID)).ToList();

            project.ProjectOrganizations.Merge(projectOrganizationsUpdated,
                allProjectOrganizations,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID && x.OrganizationRelationshipTypeID == y.OrganizationRelationshipTypeID, HttpRequestStorage.DatabaseEntities);

            project.OtherPartners = OtherPartners;
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

            if (ProjectOrganizationSimples.GroupBy(x => new { RelationshipTypeID = x.OrganizationRelationshipTypeID, x.OrganizationID }).Any(x => x.Count() > 1))
            {
                errors.Add(new ValidationResult($"Cannot have the same relationship type listed for the same {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} multiple times."));
            }
            
            var relationshipTypesThatAreRequired = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.Where(x => x.IsOrganizationRelationshipTypeRequired).ToList();

            var projectOrganizationsGroupedByRelationshipTypeID =
                ProjectOrganizationSimples.GroupBy(x => x.OrganizationRelationshipTypeID).ToList();

            errors.AddRange(relationshipTypesThatAreRequired
                .Where(rt => projectOrganizationsGroupedByRelationshipTypeID.Count(po => po.Key == rt.OrganizationRelationshipTypeID) > 1)
                .Select(relationshipType => new ValidationResult(
                    $"Cannot have more than one {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} with a {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.OrganizationRelationshipTypeName}\".")));

            errors.AddRange(relationshipTypesThatAreRequired
                .Where(rt => projectOrganizationsGroupedByRelationshipTypeID.Count(po => po.Key == rt.OrganizationRelationshipTypeID) == 0)
                .Select(relationshipType => new ValidationResult(
                    $"Must have one {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} with a {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.OrganizationRelationshipTypeName}\".")));

            var allValidRelationshipTypes = ProjectOrganizationSimples.Where(z => ModelObjectHelpers.IsRealPrimaryKeyValue(z.OrganizationID)).All(x =>
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(x.OrganizationID);
                var organizationType = organization.OrganizationType;

                if (organizationType != null)
                {
                    var organizationTypeOrganizationRelationshipTypeIDs =
                        organizationType.OrganizationTypeOrganizationRelationshipTypes.Select(y => y.OrganizationRelationshipTypeID);

                    return organizationTypeOrganizationRelationshipTypeIDs.Contains(x.OrganizationRelationshipTypeID);
                }
                return false;
            });

            if (!allValidRelationshipTypes)
            {
                errors.Add(new ValidationResult("One or more relationship types are invalid."));
            }

            if (OtherPartners != null &&
                OtherPartners.Length > ProjectFirmaModels.Models.Project.FieldLengths.OtherPartners)
            {
                errors.Add(new ValidationResult($"The field '{FieldDefinitionEnum.OtherPartners.ToType().GetFieldDefinitionLabel()}' must be a string with a maximum length of {ProjectFirmaModels.Models.Project.FieldLengths.OtherPartners}."));
            }

            return errors;
        }
    }
}
