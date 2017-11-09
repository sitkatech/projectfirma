/*-----------------------------------------------------------------------
<copyright file="BudgetsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BudgetsViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly ProjectBudgetDetailViewData ProjectBudgetDetailViewData;
        public readonly string RequestFundingSourceUrl;
        public readonly ViewDataForAngularEditor ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly decimal InflationRate;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public BudgetsViewData(Person currentPerson,
            ProjectUpdateBatch projectUpdateBatch,
            ViewDataForAngularEditor viewDataForAngularEditor,
            ProjectBudgetDetailViewData projectBudgetDetailViewData, UpdateStatus updateStatus, BudgetsValidationResult budgetsValidationResult)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Budgets, updateStatus, budgetsValidationResult.GetWarningMessages())
        {
            ViewDataForAngular = viewDataForAngularEditor;
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshBudgets(projectUpdateBatch.Project));
            //DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffBudgets(projectUpdateBatch.Project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectBudgetDetailViewData = projectBudgetDetailViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.BudgetsComment, projectUpdateBatch.IsReturned);
            TotalOperatingCostInYearOfExpenditure = Models.CostParameterSet.CalculateTotalRemainingOperatingCost(ProjectUpdateBatch.ProjectUpdate);
            InflationRate = Models.CostParameterSet.GetLatestInflationRate();
            StartYearForTotalOperatingCostCalculation = Models.CostParameterSet.StartYearForTotalCostCalculations(projectUpdateBatch.ProjectUpdate);
        }

        public class ViewDataForAngularEditor
        {
            public readonly List<int> CalendarYearRange;
            public readonly List<FundingSourceSimple> AllFundingSources;
            public readonly List<ProjectCostTypeSimple> AllProjectCostTypes;
            public readonly int ProjectID;
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularEditor(Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<ProjectCostTypeSimple> allProjectCostTypes,
                List<int> calendarYearRange,
                BudgetsValidationResult budgetsValidationResult)
            {
                CalendarYearRange = calendarYearRange;
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                AllProjectCostTypes = allProjectCostTypes;
                ValidationWarnings = budgetsValidationResult.GetWarningMessages();
            }
        }
    }
}
