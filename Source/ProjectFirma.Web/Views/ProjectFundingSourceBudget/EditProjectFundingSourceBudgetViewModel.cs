/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceBudgetsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public class EditProjectFundingSourceBudgetViewModel : FormViewModel, IValidatableObject
    {

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedTotalCost)]
        public Money? EstimatedTotalCost { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedAnnualOperatingCost)]
        public Money? EstimatedAnnualOperatingCost { get; set; }

        public ViewModelForAngularEditor ViewModelForAngular { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectFundingSourceBudgetViewModel()
        {
        }

        public EditProjectFundingSourceBudgetViewModel(ProjectFirmaModels.Models.Project project, 
            List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> projectFundingSourceBudgets)
        {
            var fundingTypeID = project.FundingTypeID ?? 0;
            EstimatedTotalCost = project.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost;
            ViewModelForAngular = new ViewModelForAngularEditor(fundingTypeID, projectFundingSourceBudgets);

        }

        public class ViewModelForAngularEditor
        {
            [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
            [Required]
            public int FundingTypeID { get; set; }
            public List<ProjectFundingSourceBudgetSimple> ProjectFundingSourceBudgets { get; set; }

            public ViewModelForAngularEditor()
            {
            }

            public ViewModelForAngularEditor(int fundingTypeId, List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> projectFundingSourceBudgets)
            {
                FundingTypeID = fundingTypeId;
                ProjectFundingSourceBudgets = projectFundingSourceBudgets
                    .Select(x => new ProjectFundingSourceBudgetSimple(x)).ToList();
            }

        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> currentProjectFundingSourceBudgets,
            IList<ProjectFirmaModels.Models.ProjectFundingSourceBudget> allProjectFundingSourceBudgets)
        {
            project.FundingTypeID = ViewModelForAngular.FundingTypeID;
            project.EstimatedTotalCost = EstimatedTotalCost;
            project.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost;


            var projectFundingSourceBudgetsUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceBudget>();
            if (ViewModelForAngular?.ProjectFundingSourceBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceBudgetsUpdated = ViewModelForAngular?.ProjectFundingSourceBudgets
                    .Select(x => x.ToProjectFundingSourceBudget()).ToList();
            }

            currentProjectFundingSourceBudgets.Merge(projectFundingSourceBudgetsUpdated,
                allProjectFundingSourceBudgets,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.TargetedAmount = y.TargetedAmount;
                }, HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (ViewModelForAngular.FundingTypeID == 0)
            {
                validationResults.Add(new ValidationResult($"Please select a  {FieldDefinitionEnum.FundingType.ToType().GetFieldDefinitionLabel()}."));
            }

            if (ViewModelForAngular.FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID && EstimatedTotalCost == null)
            {
                validationResults.Add(new ValidationResult($"Since this budget varies by year, an {FieldDefinitionEnum.EstimatedTotalCost.ToType().GetFieldDefinitionLabel()} must be entered."));
            }

            if (ViewModelForAngular.FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID && EstimatedAnnualOperatingCost == null)
            {
                validationResults.Add(new ValidationResult($"Since this budget is the same each year, an {FieldDefinitionEnum.EstimatedAnnualOperatingCost.ToType().GetFieldDefinitionLabel()} must be entered."));
            }

            // ViewModelForAngular will be null if no ProjectFundingSourceBudgets are entered, recreate it so model will be valid when returning with validation error
            ViewModelForAngular = ViewModelForAngular ?? new ViewModelForAngularEditor(0, new List<ProjectFirmaModels.Models.ProjectFundingSourceBudget>());

            if (ViewModelForAngular.ProjectFundingSourceBudgets == null)
            {
                return validationResults;
            }

            if (ViewModelForAngular.ProjectFundingSourceBudgets.GroupBy(x => x.FundingSourceID).Any(x => x.Count() > 1))
            {
                validationResults.Add(new ValidationResult("Each funding source can only be used once."));
            }

            foreach (var projectFundingSourceBudget in ViewModelForAngular.ProjectFundingSourceBudgets)
            {
                if (projectFundingSourceBudget.AreBothValuesZero())
                {
                    var fundingSource =
                        HttpRequestStorage.DatabaseEntities.FundingSources.Single(x =>
                            x.FundingSourceID == projectFundingSourceBudget.FundingSourceID);
                    validationResults.Add(new ValidationResult(
                        $"Secured Funding and {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} cannot both be zero for funding source: {fundingSource.GetDisplayName()}. If the amount of Secured or {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} is unknown, you can leave the amounts blank."));
                }
            }
            return validationResults;
        }
    }
}