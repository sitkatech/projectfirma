using ProjectFirma.Web.Common;

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