using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTransportationProjectBudgetUpdate
        {
            public static TransportationProjectBudgetUpdate Create(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, TransportationProjectCostType transportationProjectCostType, int calendarYear, decimal budgetAmount)
            {
                var transportationProjectBudgetUpdate = new TransportationProjectBudgetUpdate(projectUpdateBatch, fundingSource, transportationProjectCostType, calendarYear){ BudgetedAmount = budgetAmount };
                return transportationProjectBudgetUpdate;
            }
        }
    }
}