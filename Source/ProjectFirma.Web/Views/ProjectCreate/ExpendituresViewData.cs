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

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpendituresViewData : ProjectCreateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly ProjectExpendituresDetailViewData ProjectExpendituresDetailViewData;
        public readonly string RequestFundingSourceUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;
        
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly decimal InflationRate;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public ExpendituresViewData(Person currentPerson, ProjectFirmaModels.Models.Project project, ViewDataForAngularClass viewDataForAngularClass, ProjectExpendituresDetailViewData projectExpendituresDetailViewData, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentPerson, project, ProjectCreateSection.ReportedExpenditures.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpenditures(project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpenditures(project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectExpendituresDetailViewData = projectExpendituresDetailViewData;
            
            TotalOperatingCostInYearOfExpenditure = CostParameterSetModelExtensions.CalculateTotalRemainingOperatingCost(project);
            InflationRate = CostParameterSetModelExtensions.GetLatestInflationRate();
            StartYearForTotalOperatingCostCalculation = CostParameterSetModelExtensions.StartYearForTotalCostCalculations(project);
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
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
                UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
                ShowNoExpendituresExplanation = showNoExpendituresExplanation;
            }
        }
    }
}
