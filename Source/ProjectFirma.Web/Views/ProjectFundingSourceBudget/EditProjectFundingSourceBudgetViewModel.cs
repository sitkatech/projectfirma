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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public class EditProjectFundingSourceBudgetViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        [Required]
        public int FundingTypeID { get; set; }

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
            FundingTypeID = project.FundingTypeID;
            EstimatedTotalCost = project.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost;
            ViewModelForAngular = new ViewModelForAngularEditor(projectFundingSourceBudgets);

        }

        public class ViewModelForAngularEditor
        {
            public List<ProjectFundingSourceBudgetSimple> ProjectFundingSourceBudgets { get; set; }

            public ViewModelForAngularEditor()
            {
            }

            public ViewModelForAngularEditor(List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> projectFundingSourceBudgets)
            {
                ProjectFundingSourceBudgets = projectFundingSourceBudgets
                    .Select(x => new ProjectFundingSourceBudgetSimple(x)).ToList();
            }

        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> currentProjectFundingSourceBudgets,
            IList<ProjectFirmaModels.Models.ProjectFundingSourceBudget> allProjectFundingSourceBudgets)
        {
            project.FundingTypeID = FundingTypeID;
            if (FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID)
            {
                project.EstimatedTotalCost = EstimatedTotalCost;
                project.EstimatedAnnualOperatingCost = null;

            }
            else if (FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID)
            {
                project.EstimatedTotalCost = null;
                project.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost;
            }

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
            if (ViewModelForAngular?.ProjectFundingSourceBudgets == null)
            {
                yield break;
            }


            if (ViewModelForAngular.ProjectFundingSourceBudgets.GroupBy(x => x.FundingSourceID).Any(x => x.Count() > 1))
            {
                yield return new ValidationResult("Each funding source can only be used once.");
            }

            // Add validation for conditionally-required fields

            foreach (var projectFundingSourceBudget in ViewModelForAngular.ProjectFundingSourceBudgets)
            {
                if (projectFundingSourceBudget.AreBothValuesZero())
                {
                    var fundingSource =
                        HttpRequestStorage.DatabaseEntities.FundingSources.Single(x =>
                            x.FundingSourceID == projectFundingSourceBudget.FundingSourceID);
                    yield return new ValidationResult(
                        $"Secured Funding and {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} cannot both be zero for funding source: {fundingSource.GetDisplayName()}. If the amount of Secured or {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} is unknown, you can leave the amounts blank.");
                }
            }
        }
    }
}