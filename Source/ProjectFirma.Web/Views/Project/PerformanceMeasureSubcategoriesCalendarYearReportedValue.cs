using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class PerformanceMeasureSubcategoriesCalendarYearReportedValue
    {
        private readonly Models.PerformanceMeasure _performanceMeasure;
        public int PerformanceMeasureID
        {
            get { return _performanceMeasure.PerformanceMeasureID; }
        }
        public bool HasRealSubcategories
        {
            get { return IndicatorSubcategories.Any(x => x.IndicatorSubcategoryOptions.Count > 1); }
        }
        public HtmlString PerformanceMeasureDisplayNameAsUrl
        {
            get { return _performanceMeasure.GetDisplayNameAsUrl(); }
        }
        public MeasurementUnitType MeasurementUnitType
        {
            get { return _performanceMeasure.Indicator.MeasurementUnitType; }
        }
        public List<IndicatorSubcategory> IndicatorSubcategories
        {
            get { return _performanceMeasure.GetIndicatorSubcategories(); }
        }
        public readonly List<SubcategoriesReportedValue> SubcategoriesReportedValues;
        public string DisplayCssClass;

        public PerformanceMeasureSubcategoriesCalendarYearReportedValue(Models.PerformanceMeasure performanceMeasure, List<SubcategoriesReportedValue> subcategoriesReportedValues, string displayCssClass)            
        {
            _performanceMeasure = performanceMeasure;
            SubcategoriesReportedValues = subcategoriesReportedValues;
            DisplayCssClass = displayCssClass;
        }

        public static List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> CreateFromPerformanceMeasuresAndCalendarYears(List<IPerformanceMeasureReportedValue> performanceMeasureReportedValues)
        {
            var groupedByPerformanceMeasure = performanceMeasureReportedValues.GroupBy(x => x.PerformanceMeasure);
            var performanceMeasureCalendarYearReportedValues = new List<PerformanceMeasureSubcategoriesCalendarYearReportedValue>();
            foreach (var reportedValues in groupedByPerformanceMeasure)
            {
                var performanceMeasure = reportedValues.Key;
                var subcategoriesReportedValues =
                    reportedValues.GroupBy(x => x.IndicatorSubcategoriesAsString)
                        .Select(
                            subcategoriesReportedValue =>
                                new SubcategoriesReportedValue(subcategoriesReportedValue.Key, subcategoriesReportedValue.First().IndicatorSubcategoryOptions,
                                    subcategoriesReportedValue.GroupBy(scrv => scrv.CalendarYear).ToDictionary(scrv => scrv.Key, scrv => scrv.Sum(rv => rv.ReportedValue))))
                        .ToList();
                performanceMeasureCalendarYearReportedValues.Add(new PerformanceMeasureSubcategoriesCalendarYearReportedValue(performanceMeasure, subcategoriesReportedValues, null));
            }
            return performanceMeasureCalendarYearReportedValues;
        }

        public static PerformanceMeasureSubcategoriesCalendarYearReportedValue Clone(PerformanceMeasureSubcategoriesCalendarYearReportedValue performanceMeasureSubcategoriesCalendarYearReportedValue, string displayCssClass)
        {
            return new PerformanceMeasureSubcategoriesCalendarYearReportedValue(performanceMeasureSubcategoriesCalendarYearReportedValue._performanceMeasure, performanceMeasureSubcategoriesCalendarYearReportedValue.SubcategoriesReportedValues.Select(SubcategoriesReportedValue.Clone).ToList(), displayCssClass);
        }
    }

    public class SubcategoriesReportedValue
    {
        public readonly List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureValueSubcategoryOptions;
        public readonly Dictionary<int, double?> CalendarYearReportedValue;
        public readonly string IndicatorSubcategories;         
        public readonly List<string> SubcategoryNames;
        
        public SubcategoriesReportedValue(string subcategories, List<IPerformanceMeasureValueSubcategoryOption> performanceMeasureValueSubcategoryOptions, Dictionary<int, double?> calendarYearReportedValue)
        {
            PerformanceMeasureValueSubcategoryOptions = performanceMeasureValueSubcategoryOptions;
            IndicatorSubcategories = subcategories;
            CalendarYearReportedValue = calendarYearReportedValue;            
            SubcategoryNames = new List<string>(performanceMeasureValueSubcategoryOptions.Select(p => p.IndicatorSubcategory.IndicatorSubcategoryDisplayName).OrderBy(p => p));
        }

        public static SubcategoriesReportedValue Clone(SubcategoriesReportedValue subcategoriesReportedValue)
        {
            return new SubcategoriesReportedValue(subcategoriesReportedValue.IndicatorSubcategories,
                subcategoriesReportedValue.PerformanceMeasureValueSubcategoryOptions,
                subcategoriesReportedValue.CalendarYearReportedValue.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}