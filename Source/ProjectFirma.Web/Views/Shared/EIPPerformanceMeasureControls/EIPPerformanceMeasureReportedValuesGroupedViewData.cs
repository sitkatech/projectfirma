using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls
{
    public class EIPPerformanceMeasureReportedValuesGroupedViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYearsForEIPPerformanceMeasures;
        public readonly List<int> ExemptReportingYears;
        public readonly string ExemptionExplanation;
        public readonly List<EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue> EIPPerformanceMeasureSubcategoriesCalendarYearReportedValues;
        public readonly bool HideByDefault;

        public EIPPerformanceMeasureReportedValuesGroupedViewData(List<EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue> eipPerformanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<int> calendarYearsForEIPPerformanceMeasures)
            : this(eipPerformanceMeasureSubcategoriesCalendarYearReportedValues, exemptReportingYears, exemptionExplanation, calendarYearsForEIPPerformanceMeasures, false)
        {
        }

        public EIPPerformanceMeasureReportedValuesGroupedViewData(List<EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue> eipPerformanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<int> calendarYearsForEIPPerformanceMeasures,
            bool hideByDefault)
        {
            CalendarYearsForEIPPerformanceMeasures = calendarYearsForEIPPerformanceMeasures;
            EIPPerformanceMeasureSubcategoriesCalendarYearReportedValues = eipPerformanceMeasureSubcategoriesCalendarYearReportedValues;
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