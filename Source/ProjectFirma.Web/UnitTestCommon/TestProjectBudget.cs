using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectBudget
        {
            public static ProjectBudget Create()
            {
                var project = TestProject.Create();
                var fundingSource = TestFundingSource.Create();
                return Create(project, fundingSource);
            }

            public static ProjectBudget Create(Project project, FundingSource fundingSource)
            {
                var projectBudget = ProjectBudget.CreateNewBlank(project, fundingSource, ProjectCostType.Construction);
                return projectBudget;
            }

            public static ProjectBudget Create(Project project, FundingSource fundingSource, int calendarYear)
            {
                var projectBudget = Create(project, fundingSource);
                projectBudget.CalendarYear = calendarYear;
                return projectBudget;
            }

            public static ProjectBudget Create(Project project, FundingSource fundingSource, int calendarYear, decimal expenditureAmount)
            {
                var projectBudget = Create(project, fundingSource, calendarYear);
                projectBudget.BudgetedAmount = expenditureAmount;
                return projectBudget;
            }
        }
    }
}