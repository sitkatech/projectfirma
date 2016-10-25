using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class TransportationProjectBudgetSummaryViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYears;
        public readonly List<TransportationProjectBudgetAmount> TransportationProjectBudgetAmounts;

        public TransportationProjectBudgetSummaryViewData(List<TransportationProjectBudgetAmount> transportationProjectBudgetAmounts, List<int> calendarYears)
        {
            TransportationProjectBudgetAmounts = transportationProjectBudgetAmounts;
            CalendarYears = calendarYears;
        }
    }
}