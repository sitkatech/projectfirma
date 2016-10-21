using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectUpdateDiffControls
{
    public class TransportationProjectBudgetSummaryViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<CalendarYearString> CalendarYears;
        public readonly List<TransportationProjectBudgetAmount2> TransportationProjectBudgetAmounts;
        public readonly List<TransportationProjectCostType> TransportationProjectCostTypes;

        public TransportationProjectBudgetSummaryViewData(List<TransportationProjectBudgetAmount2> transportationProjectBudgetAmounts, List<CalendarYearString> calendarYears)
        {
            TransportationProjectCostTypes = TransportationProjectCostType.All.ToList();
            TransportationProjectBudgetAmounts = transportationProjectBudgetAmounts;
            CalendarYears = calendarYears;
        }
    }
}