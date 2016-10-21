using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<int> CalculateCalendarYearRangeForBudgets(this IList<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates, ProjectUpdate projectUpdate)
        {
            if (projectUpdate.CompletionYear < projectUpdate.ImplementationStartYear) return new List<int>();
            if (projectUpdate.CompletionYear < projectUpdate.PlanningDesignStartYear) return new List<int>();

            var existingYears = transportationProjectBudgetUpdates.Select(x => x.CalendarYear).ToList();
            return ProjectFirmaDateUtilities.CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(existingYears, projectUpdate, ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting());
        }
    }
}