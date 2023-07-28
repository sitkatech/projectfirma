﻿/*-----------------------------------------------------------------------
<copyright file="BasicsViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class BasicsViewModel : FormViewModel, IValidatableObject
    {
        public int? ProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyLeaf)]
        [Required]
        public int? TaxonomyLeafID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf)]
        public IEnumerable<int> SecondaryProjectTaxonomyLeafIDs { get; set; } = new List<int>();

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ProjectName)]
        [Required]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        [StringLength(ProjectModelExtensions.MaxLengthForProjectDescription)]
        [Required]
        public string ProjectDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStage)]
        [Required]
        public int? ProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PlanningDesignStartYear)]
        [Required]
        public int? PlanningDesignStartYear { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        [Required]
        public int? ImplementationStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CompletionYear)]
        public int? CompletionYear { get; set; }

        public int? ImportExternalProjectStagingID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectCategory)]
        public ProjectCategoryEnum ProjectCategoryEnum { get; set; }


        [FieldDefinitionDisplay(FieldDefinitionEnum.Solicitation)]
        public int? SolicitationID { get; set; }

        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.BasicsComment)]
        public string Comments { get; set; }    

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public BasicsViewModel()
        {
        }

        public BasicsViewModel(ProjectFirmaModels.Models.Project project)
        {
            TaxonomyLeafID = project.TaxonomyLeafID;
            SecondaryProjectTaxonomyLeafIDs = project.SecondaryProjectTaxonomyLeafs.Select(x => x.TaxonomyLeafID);
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            ProjectStageID = project.ProjectStageID;            
            PlanningDesignStartYear = project.PlanningDesignStartYear;
            ImplementationStartYear = project.ImplementationStartYear;
            CompletionYear = project.CompletionYear;
            ProjectCategoryEnum = project.ProjectCategory.ToEnum;
            Comments = project.BasicsComment;
            SolicitationID = project.SolicitationID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            if (ImportExternalProjectStagingID.HasValue)
            {
                var importExternalProjectStagingToDelete = HttpRequestStorage.DatabaseEntities.ImportExternalProjectStagings.Single(x =>
                    x.ImportExternalProjectStagingID == ImportExternalProjectStagingID);
                HttpRequestStorage.DatabaseEntities.AllImportExternalProjectStagings.Remove(importExternalProjectStagingToDelete);
            }

            project.SolicitationID = SolicitationID;
            if (!project.ProposingPersonID.HasValue)
            {
                project.ProposingPersonID = currentFirmaSession.PersonID;
            }
            project.TaxonomyLeafID = TaxonomyLeafID ?? ModelObjectHelpers.NotYetAssignedID;
            project.ProjectID = ProjectID ?? ModelObjectHelpers.NotYetAssignedID;
            project.ProjectName = ProjectName;
            project.ProjectDescription = ProjectDescription;
            project.ProjectStageID = ProjectStageID ?? ModelObjectHelpers.NotYetAssignedID;          
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.ImplementationStartYear = ImplementationStartYear;
            project.CompletionYear = CompletionYear;
            project.ProjectCategoryID = (int) ProjectCategoryEnum;
            if (project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval)
            {
                project.BasicsComment = Comments;
            }

            var secondaryProjectTaxonomyLeavesToUpdate = SecondaryProjectTaxonomyLeafIDs
                .Select(x => new SecondaryProjectTaxonomyLeaf(project.ProjectID, x) { TenantID = HttpRequestStorage.Tenant.TenantID })
                .ToList();
            project.SecondaryProjectTaxonomyLeafs.Merge(
                secondaryProjectTaxonomyLeavesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllSecondaryProjectTaxonomyLeafs.Local,
                (a, b) => a.TaxonomyLeafID == b.TaxonomyLeafID && a.ProjectID == b.ProjectID,
                HttpRequestStorage.DatabaseEntities);

            // If this is the first time saving the project, and if the current person belongs to a primary contact organization, prepopulate.
            if (project.ProjectID == ModelObjectHelpers.NotYetAssignedID && !currentFirmaSession.IsAnonymousUser() && currentFirmaSession.Person.Organization.CanBeAPrimaryContactOrganization())
            {
                var primaryContactRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes
                    .Where(x => x.IsPrimaryContact).ToList();
                var primaryContactOrganizationRelationshipTypeIDs = primaryContactRelationshipTypes.Select(x => x.OrganizationRelationshipTypeID).ToList();

                project.PrimaryContactPersonID = currentFirmaSession.Person.Organization.PrimaryContactPersonID;
                project.ProjectOrganizations = primaryContactOrganizationRelationshipTypeIDs.Select(x =>
                    new ProjectOrganization(project.ProjectID, currentFirmaSession.Person.OrganizationID, x)).ToList();
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();

            if (!Enum.IsDefined(typeof(ProjectCategoryEnum), ProjectCategoryEnum))
            {
                yield return new SitkaValidationResult<BasicsViewModel, ProjectCategoryEnum>($"A valid value for {FieldDefinitionEnum.ProjectCategory.ToType().GetFieldDefinitionLabel()} is required.", m => m.ProjectCategoryEnum);
            }

            if (TaxonomyLeafID == -1)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>($"{MultiTenantHelpers.GetTaxonomyLeafDisplayNameForProject()} is required.", m => m.TaxonomyLeafID);
            }

            if (!ProjectModelExtensions.IsProjectNameUnique(projects, ProjectName, ProjectID))
            {
                yield return new SitkaValidationResult<BasicsViewModel, string>(FirmaValidationMessages.ProjectNameUnique, m => m.ProjectName);
            }

            if (ImplementationStartYear < PlanningDesignStartYear)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear, m => m.ImplementationStartYear);
            }

            if (CompletionYear < ImplementationStartYear)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear, m => m.CompletionYear);
            }

            if (CompletionYear < PlanningDesignStartYear)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(FirmaValidationMessages.CompletionYearGreaterThanEqualToPlanningDesignStartYear, m => m.CompletionYear);
            }

            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
            if (ProjectStageID == ProjectStage.Implementation.ProjectStageID)
            {
                if (ImplementationStartYear > currentYear)
                {
                    yield return new SitkaValidationResult<BasicsViewModel, int?>(
                        FirmaValidationMessages.ImplementationYearMustBePastOrPresentForImplementationProjects,
                        m => m.ImplementationStartYear);
                }
            }
            
            if (ImplementationStartYear == null && ProjectStageID != ProjectStage.Terminated.ProjectStageID && ProjectStageID != ProjectStage.Deferred.ProjectStageID)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(
                    $"Implementation year is required when the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} stage is not {ProjectStage.Deferred.GetProjectStageDisplayName()} or {ProjectStage.Terminated.GetProjectStageDisplayName()}",
                    m => m.ImplementationStartYear);
            }

            if (ProjectStageID == ProjectStage.Completed.ProjectStageID && !CompletionYear.HasValue)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>($"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the {ProjectStage.Completed.GetProjectStageDisplayName()} stage, the {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} is required", m => m.CompletionYear);
            }

            if (ProjectStageID == ProjectStage.PostImplementation.ProjectStageID && !CompletionYear.HasValue)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>($"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the {ProjectStage.PostImplementation.GetProjectStageDisplayName()} stage, the {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} is required", m => m.CompletionYear);
            }

            if ((ProjectStageID == ProjectStage.Completed.ProjectStageID || ProjectStageID == ProjectStage.PostImplementation.ProjectStageID) && CompletionYear > currentYear)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(FirmaValidationMessages.CompletionYearMustBePastOrPresentForCompletedProjects, m => m.CompletionYear);
            }

            if (ProjectStageID == ProjectStage.PlanningDesign.ProjectStageID && PlanningDesignStartYear > currentYear)
            {
                yield return new SitkaValidationResult<BasicsViewModel, int?>(
                    $"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the {ProjectStage.PlanningDesign.GetProjectStageDisplayName()} stage, the {FieldDefinitionEnum.PlanningDesignStartYear.ToType().GetFieldDefinitionLabel()} must be less than or equal to the current year",
                    m => m.PlanningDesignStartYear);
            }

            if (TaxonomyLeafID != null && SecondaryProjectTaxonomyLeafIDs.ToList().Contains(TaxonomyLeafID.Value))
            {
                yield return new SitkaValidationResult<BasicsViewModel, IEnumerable<int>>(
                    $"Cannot have a {FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf.ToType().GetFieldDefinitionLabel()} " +
                    $"that is the same as the Primary {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel()}.",
                    m => m.SecondaryProjectTaxonomyLeafIDs);
            }
        }
    }
}
