using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<int> CalculateCalendarYearRangeForBudgets(this IList<TransportationProjectBudget> transportationProjectBudgets, Project project)
        {
            var existingYears = transportationProjectBudgets.Select(x => x.CalendarYear).ToList();
            return FirmaDateUtilities.CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(existingYears, project, DateTime.Today.Year);
        }
    }
}