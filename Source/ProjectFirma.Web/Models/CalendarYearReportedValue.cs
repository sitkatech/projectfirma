using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public class CalendarYearReportedValue
    {
        public readonly int CalendarYear;
        public readonly double? ReportedValue;

        public CalendarYearReportedValue(int calendarYear, double? reportedValue)
        {
            CalendarYear = calendarYear;
            ReportedValue = reportedValue;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", CalendarYear, (ReportedValue ?? 0).ToStringCurrency());
        }
    }
}