/*-----------------------------------------------------------------------
<copyright file="ExpendituresViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpendituresViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly ProjectExpendituresDetailViewData ProjectExpendituresDetailViewData;
        public readonly string RequestFundingSourceUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly decimal InflationRate;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public ExpendituresViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ViewDataForAngularClass viewDataForAngularClass, ProjectExpendituresDetailViewData projectExpendituresDetailViewData, ProjectUpdateStatus projectUpdateStatus, List<string> expendituresValidationErrors)
            : base(currentPerson, projectUpdateBatch, projectUpdateStatus, expendituresValidationErrors, ProjectUpdateSection.Expenditures.ProjectUpdateSectionDisplayName)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpenditures(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpenditures(projectUpdateBatch.Project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectExpendituresDetailViewData = projectExpendituresDetailViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpendituresComment, projectUpdateBatch.IsReturned());
            TotalOperatingCostInYearOfExpenditure = CostParameterSetModelExtensions.CalculateTotalRemainingOperatingCost(ProjectUpdateBatch.ProjectUpdate);
            InflationRate = CostParameterSetModelExtensions.GetLatestInflationRate();
            StartYearForTotalOperatingCostCalculation = CostParameterSetModelExtensions.StartYearForTotalCostCalculations(projectUpdateBatch.ProjectUpdate);
        }

        public class ViewDataForAngularClass
        {
            public readonly List<int> CalendarYearRange;
            public readonly List<FundingSourceSimple> AllFundingSources;
            public readonly int ProjectID;
            public readonly int MaxYear;
            public readonly bool UseFiscalYears;
            public readonly bool ShowNoExpendituresExplanation;

            public ViewDataForAngularClass(ProjectFirmaModels.Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<int> calendarYearRange, bool showNoExpendituresExplanation)
            {
                CalendarYearRange = calendarYearRange;
                ShowNoExpendituresExplanation = showNoExpendituresExplanation;
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
                UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
            }
        }
    }
}
