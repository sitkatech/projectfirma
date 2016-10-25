using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpendituresViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly ProjectExpendituresSummaryViewData ProjectExpendituresSummaryViewData;
        public readonly string RequestFundingSourceUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly decimal InflationRate;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public ExpendituresViewData(Person currentPerson,
            ProjectUpdateBatch projectUpdateBatch,
            ViewDataForAngularClass viewDataForAngularClass,
            ProjectExpendituresSummaryViewData projectExpendituresSummaryViewData, UpdateStatus updateStatus) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Expenditures, updateStatus)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpenditures(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpenditures(projectUpdateBatch.Project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectExpendituresSummaryViewData = projectExpendituresSummaryViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpendituresComment, projectUpdateBatch.IsReturned);
            TotalOperatingCostInYearOfExpenditure = Models.TransportationCostParameterSet.CalculateTotalRemainingOperatingCost(ProjectUpdateBatch.ProjectUpdate);
            InflationRate = Models.TransportationCostParameterSet.GetLatestInflationRate();
            StartYearForTotalOperatingCostCalculation = Models.TransportationCostParameterSet.StartYearForTotalCostCalculations(projectUpdateBatch.ProjectUpdate);
        }

        public class ViewDataForAngularClass
        {
            public readonly List<int> CalendarYearRange;
            public readonly List<FundingSourceSimple> AllFundingSources;
            public readonly int ProjectID;
            public readonly IEnumerable<int> ProjectFundingOrganizationFundingSourceIDs;
            public readonly List<string> ValidationWarnings;
            public readonly int MaxYear;

            public ViewDataForAngularClass(Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<int> calendarYearRange,
                IEnumerable<int> projectFundingOrganizationFundingSourceIDs,
                ExpendituresValidationResult expendituresValidationResult)
            {
                CalendarYearRange = calendarYearRange;
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                ProjectFundingOrganizationFundingSourceIDs = projectFundingOrganizationFundingSourceIDs;
                ValidationWarnings = expendituresValidationResult.GetWarningMessages();
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            }
        }
    }
}