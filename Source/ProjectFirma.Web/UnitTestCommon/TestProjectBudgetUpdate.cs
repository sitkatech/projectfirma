using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectBudgetUpdate
        {
            public static ProjectBudgetUpdate Create(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, ProjectCostType ProjectCostType, int calendarYear, decimal budgetAmount)
            {
                var ProjectBudgetUpdate = new ProjectBudgetUpdate(projectUpdateBatch, fundingSource, ProjectCostType, calendarYear){ BudgetedAmount = budgetAmount };
                return ProjectBudgetUpdate;
            }
        }
    }
}