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
            ProjectBudgetDetailViewData projectBudgetDetailViewData, UpdateStatus updateStatus)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Budgets, updateStatus)
        {
            ViewDataForAngular = viewDataForAngularEditor;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshBudgets(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffBudgets(projectUpdateBatch.Project));
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
            public readonly IEnumerable<int> ProjectFundingOrganizationFundingSourceIDs;
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularEditor(Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<ProjectCostTypeSimple> allProjectCostTypes,
                List<int> calendarYearRange,
                IEnumerable<int> projectFundingOrganizationFundingSourceIDs,
                BudgetsValidationResult budgetsValidationResult)
            {
                CalendarYearRange = calendarYearRange;
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                AllProjectCostTypes = allProjectCostTypes;
                ProjectFundingOrganizationFundingSourceIDs = projectFundingOrganizationFundingSourceIDs;
                ValidationWarnings = budgetsValidationResult.GetWarningMessages();
            }
        }
    }
}