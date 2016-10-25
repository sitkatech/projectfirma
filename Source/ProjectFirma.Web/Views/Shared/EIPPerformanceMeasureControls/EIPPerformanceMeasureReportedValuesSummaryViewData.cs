using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls
{
    public class EIPPerformanceMeasureReportedValuesSummaryViewData : FirmaUserControlViewData
    {
        public readonly List<CalendarYearString> CalendarYearsForEIPPerformanceMeasures;
        public readonly List<int> ExemptReportingYears;
        public readonly string ExemptionExplanation;
        public readonly List<EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue> EIPPerformanceMeasureSubcategoriesCalendarYearReportedValues;

        public EIPPerformanceMeasureReportedValuesSummaryViewData(List<EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue> eipPerformanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<CalendarYearString> calendarYearsForEIPPerformanceMeasures)
        {
            CalendarYearsForEIPPerformanceMeasures = calendarYearsForEIPPerformanceMeasures;
            EIPPerformanceMeasureSubcategoriesCalendarYearReportedValues = eipPerformanceMeasureSubcategoriesCalendarYearReportedValues;
            ExemptReportingYears = exemptReportingYears;
            ExemptionExplanation = exemptionExplanation;
        }
    }
}