using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureReportedValueModelExtensions
    {
        public static string GetCalendarYearDisplay(this PerformanceMeasureReportedValue performanceMeasureReportedValue)
        {
            return MultiTenantHelpers.FormatReportingYear(performanceMeasureReportedValue.CalendarYear);
        }
    }
}