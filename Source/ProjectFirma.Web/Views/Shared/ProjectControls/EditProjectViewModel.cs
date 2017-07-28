/*-----------------------------------------------------------------------
<copyright file="EditProjectViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        [StringLength(Models.Project.FieldLengths.ProjectName)]
        [Required]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        [StringLength(Models.Project.FieldLengths.ProjectDescription)]
        [Required]
        public string ProjectDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStage)]
        [Required]
        public int ProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        [Required]
        public int FundingTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        public int? ImplementationStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PlanningDesignStartYear)]
        public int? PlanningDesignStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CompletionYear)]
        public int? CompletionYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierOne)]
        [Required(ErrorMessage = "This field is required.")]
        public int? TaxonomyTierOneID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedTotalCost)]
        public Money? EstimatedTotalCost { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedAnnualOperatingCost)]
        public Money? EstimatedAnnualOperatingCost { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.SecuredFunding)]
        public Money? SecuredFunding { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.LeadImplementer)]
        public int? LeadImplementerOrganizationID { get; set; }

        public bool HasExistingProjectUpdate { get; set; }
        public int? OldProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectViewModel()
        {
        }

        public EditProjectViewModel(Models.Project project, bool hasExistingProjectUpdate)
        {
            TaxonomyTierOneID = project.TaxonomyTierOneID;
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            ProjectStageID = project.ProjectStageID;
            OldProjectStageID = project.ProjectStageID;
            FundingTypeID = project.FundingTypeID;
            ImplementationStartYear = project.ImplementationStartYear;
            PlanningDesignStartYear = project.PlanningDesignStartYear;
            CompletionYear = project.CompletionYear;
            EstimatedTotalCost = project.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost;
            SecuredFunding = project.SecuredFunding;
            LeadImplementerOrganizationID = project.LeadImplementerOrganizationID;
            HasExistingProjectUpdate = hasExistingProjectUpdate;
            PrimaryContactPersonID = project.PrimaryContactPersonID;
        }

        public EditProjectViewModel(Models.ProposedProject proposedProject)
        {
            TaxonomyTierOneID = proposedProject.TaxonomyTierOneID.Value;
            ProjectName = proposedProject.ProjectName;
            ProjectDescription = proposedProject.ProjectDescription;
            ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            OldProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            FundingTypeID = proposedProject.FundingTypeID;
            ImplementationStartYear = proposedProject.ImplementationStartYear;
            PlanningDesignStartYear = proposedProject.PlanningDesignStartYear;
            CompletionYear = proposedProject.CompletionYear;
            EstimatedTotalCost = proposedProject.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = proposedProject.EstimatedAnnualOperatingCost;
            SecuredFunding = proposedProject.SecuredFunding;
            LeadImplementerOrganizationID = proposedProject.LeadImplementerOrganizationID;
            HasExistingProjectUpdate = false;
        }

        public void UpdateModel(Models.Project project)
        {
            project.ProjectName = ProjectName;
            project.ProjectDescription = ProjectDescription;
            project.TaxonomyTierOneID = TaxonomyTierOneID.Value;
            project.ProjectStageID = ProjectStageID;
            project.FundingTypeID = FundingTypeID;
            project.ImplementationStartYear = ImplementationStartYear;
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.CompletionYear = CompletionYear;
            project.PrimaryContactPersonID = PrimaryContactPersonID;

            if (FundingTypeID == FundingType.Capital.FundingTypeID)
            {
                project.EstimatedTotalCost = EstimatedTotalCost;
                project.SecuredFunding = SecuredFunding;
                project.EstimatedAnnualOperatingCost = null;
                
            }
            else if (FundingTypeID == FundingType.OperationsAndMaintenance.FundingTypeID)
            {
                project.EstimatedTotalCost = null;
                project.SecuredFunding = null;
                project.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost; 
            }

            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(project.ProjectID))
            {
                Check.RequireNotNull(LeadImplementerOrganizationID, $"{Models.FieldDefinition.LeadImplementer.GetFieldDefinitionLabel()} must be specified");
                if (LeadImplementerOrganizationID != null)
                {
                    project.LeadImplementerOrganizationID = LeadImplementerOrganizationID.Value;
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            if (!Models.Project.IsProjectNameUnique(projects, ProjectName, ProjectID))
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, string>(FirmaValidationMessages.ProjectNameUnique, m => m.ProjectName));
            }

            if (ImplementationStartYear < PlanningDesignStartYear)
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, int?>(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear, m => m.ImplementationStartYear));
            }

            if (CompletionYear < ImplementationStartYear)
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, int?>(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear, m => m.CompletionYear));
            }

            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(ProjectID) && !LeadImplementerOrganizationID.HasValue)
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, int?>($"{Models.FieldDefinition.LeadImplementer.GetFieldDefinitionLabel()} must be specified", m => m.LeadImplementerOrganizationID));
            }

            var isCompletedOrPostImplementation = ProjectStageID == ProjectStage.Completed.ProjectStageID || ProjectStageID == ProjectStage.PostImplementation.ProjectStageID;
            if (isCompletedOrPostImplementation && CompletionYear > DateTime.Now.Year)
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, int?>($"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} is in the Completed or Post-Implementation stage: the {Models.FieldDefinition.CompletionYear.GetFieldDefinitionLabel()} must be less than or equal to the current year", m => m.CompletionYear));    
            }

            if (HasExistingProjectUpdate && OldProjectStageID != ProjectStageID)
            {
                errors.Add(
                    new SitkaValidationResult<EditProjectViewModel, int>(
                        $"There are updates to this {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} that have not been submitted.<br />Making this change can potentially affect that update in process.<br />Please delete the update if you want to change this {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}'s stage.",
                        m => m.ProjectStageID));
            }

            return errors;
        }
    }
}
