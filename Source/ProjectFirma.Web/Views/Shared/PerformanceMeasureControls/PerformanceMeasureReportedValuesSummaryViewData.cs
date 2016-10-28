using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class PerformanceMeasureReportedValuesSummaryViewData : FirmaUserControlViewData
    {
        public readonly List<CalendarYearString> CalendarYearsForPerformanceMeasures;
        public readonly List<int> ExemptReportingYears;
        public readonly string ExemptionExplanation;
        public readonly List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> PerformanceMeasureSubcategoriesCalendarYearReportedValues;

        public PerformanceMeasureReportedValuesSummaryViewData(List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> performanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<CalendarYearString> calendarYearsForPerformanceMeasures)
        {
            CalendarYearsForPerformanceMeasures = calendarYearsForPerformanceMeasures;
            PerformanceMeasureSubcategoriesCalendarYearReportedValues = performanceMeasureSubcategoriesCalendarYearReportedValues;
            ExemptReportingYears = exemptReportingYears;
            ExemptionExplanation = exemptionExplanation;
        }
    }
}