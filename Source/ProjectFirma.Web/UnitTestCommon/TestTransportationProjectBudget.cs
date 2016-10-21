using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTransportationProjectBudget
        {
            public static TransportationProjectBudget Create()
            {
                var project = TestProject.Create();
                var fundingSource = TestFundingSource.Create();
                return Create(project, fundingSource);
            }

            public static TransportationProjectBudget Create(Project project, FundingSource fundingSource)
            {
                var transportationProjectBudget = TransportationProjectBudget.CreateNewBlank(project, fundingSource, TransportationProjectCostType.Construction);
                return transportationProjectBudget;
            }

            public static TransportationProjectBudget Create(Project project, FundingSource fundingSource, int calendarYear)
            {
                var transportationProjectBudget = Create(project, fundingSource);
                transportationProjectBudget.CalendarYear = calendarYear;
                return transportationProjectBudget;
            }

            public static TransportationProjectBudget Create(Project project, FundingSource fundingSource, int calendarYear, decimal expenditureAmount)
            {
                var transportationProjectBudget = Create(project, fundingSource, calendarYear);
                transportationProjectBudget.BudgetedAmount = expenditureAmount;
                return transportationProjectBudget;
            }
        }
    }
}