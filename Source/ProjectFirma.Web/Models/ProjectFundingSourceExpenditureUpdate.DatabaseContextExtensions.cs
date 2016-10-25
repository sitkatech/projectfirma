using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<int> CalculateCalendarYearRangeForExpenditures(this IList<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, ProjectUpdate projectUpdate)
        {
            if (projectUpdate.CompletionYear < projectUpdate.ImplementationStartYear) return new List<int>();
            if (projectUpdate.CompletionYear < projectUpdate.PlanningDesignStartYear) return new List<int>();

            var existingYears = projectFundingSourceExpenditureUpdates.Select(x => x.CalendarYear).ToList();
            return FirmaDateUtilities.CalculateCalendarYearRangeForExpendituresAccountingForExistingYears(existingYears, projectUpdate, FirmaDateUtilities.CalculateCurrentYearToUseForReporting());
        }
    }
}