using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class TransportationBudgetsViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly TransportationProjectBudgetSummaryViewData TransportationProjectBudgetSummaryViewData;
        public readonly string RequestFundingSourceUrl;
        public readonly ViewDataForAngularEditor ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly decimal InflationRate;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public TransportationBudgetsViewData(Person currentPerson,
            ProjectUpdateBatch projectUpdateBatch,
            ViewDataForAngularEditor viewDataForAngularEditor,
            TransportationProjectBudgetSummaryViewData transportationProjectBudgetSummaryViewData, UpdateStatus updateStatus)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.TransportationBudgets, updateStatus)
        {
            ViewDataForAngular = viewDataForAngularEditor;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshTransportationBudgets(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffTransportationBudgets(projectUpdateBatch.Project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            TransportationProjectBudgetSummaryViewData = transportationProjectBudgetSummaryViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.TransportationBudgetsComment, projectUpdateBatch.IsReturned);
            TotalOperatingCostInYearOfExpenditure = Models.TransportationCostParameterSet.CalculateTotalRemainingOperatingCost(ProjectUpdateBatch.ProjectUpdate);
            InflationRate = Models.TransportationCostParameterSet.GetLatestInflationRate();
            StartYearForTotalOperatingCostCalculation = Models.TransportationCostParameterSet.StartYearForTotalCostCalculations(projectUpdateBatch.ProjectUpdate);
        }

        public class ViewDataForAngularEditor
        {
            public readonly List<int> CalendarYearRange;
            public readonly List<FundingSourceSimple> AllFundingSources;
            public readonly List<TransportationProjectCostTypeSimple> AllTransportationProjectCostTypes;
            public readonly int ProjectID;
            public readonly IEnumerable<int> ProjectFundingOrganizationFundingSourceIDs;
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularEditor(Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<TransportationProjectCostTypeSimple> allTransportationProjectCostTypes,
                List<int> calendarYearRange,
                IEnumerable<int> projectFundingOrganizationFundingSourceIDs,
                TransportationBudgetsValidationResult transportationBudgetsValidationResult)
            {
                CalendarYearRange = calendarYearRange;
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                AllTransportationProjectCostTypes = allTransportationProjectCostTypes;
                ProjectFundingOrganizationFundingSourceIDs = projectFundingOrganizationFundingSourceIDs;
                ValidationWarnings = transportationBudgetsValidationResult.GetWarningMessages();
            }
        }
    }
}