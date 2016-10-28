using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class PerformanceMeasureReportedValuesGroupedViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYearsForPerformanceMeasures;
        public readonly List<int> ExemptReportingYears;
        public readonly string ExemptionExplanation;
        public readonly List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> PerformanceMeasureSubcategoriesCalendarYearReportedValues;
        public readonly bool HideByDefault;

        public PerformanceMeasureReportedValuesGroupedViewData(List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> performanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<int> calendarYearsForPerformanceMeasures)
            : this(performanceMeasureSubcategoriesCalendarYearReportedValues, exemptReportingYears, exemptionExplanation, calendarYearsForPerformanceMeasures, false)
        {
        }

        public PerformanceMeasureReportedValuesGroupedViewData(List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> performanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<int> calendarYearsForPerformanceMeasures,
            bool hideByDefault)
        {
            CalendarYearsForPerformanceMeasures = calendarYearsForPerformanceMeasures;
            PerformanceMeasureSubcategoriesCalendarYearReportedValues = performanceMeasureSubcategoriesCalendarYearReportedValues;
            ExemptReportingYears = exemptReportingYears;
            ExemptionExplanation = exemptionExplanation;
            HideByDefault = hideByDefault;
        }

        public string HideByDefaultStyle()
        {
            return string.Format("display: {0};", HideByDefault ? "none" : "table");
        }
    }
}