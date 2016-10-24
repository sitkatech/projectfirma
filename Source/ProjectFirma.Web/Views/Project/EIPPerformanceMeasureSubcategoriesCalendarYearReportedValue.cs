using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue
    {
        private readonly Models.EIPPerformanceMeasure _eipPerformanceMeasure;
        public int EIPPerformanceMeasureID
        {
            get { return _eipPerformanceMeasure.EIPPerformanceMeasureID; }
        }
        public bool HasRealSubcategories
        {
            get { return IndicatorSubcategories.Any(x => x.IndicatorSubcategoryOptions.Count > 1); }
        }
        public HtmlString EIPPerformanceMeasureDisplayNameAsUrl
        {
            get { return _eipPerformanceMeasure.GetDisplayNameAsUrl(); }
        }
        public MeasurementUnitType MeasurementUnitType
        {
            get { return _eipPerformanceMeasure.Indicator.MeasurementUnitType; }
        }
        public List<IndicatorSubcategory> IndicatorSubcategories
        {
            get { return _eipPerformanceMeasure.GetIndicatorSubcategories(); }
        }
        public readonly List<SubcategoriesReportedValue> SubcategoriesReportedValues;
        public string DisplayCssClass;

        public EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue(Models.EIPPerformanceMeasure eipPerformanceMeasure, List<SubcategoriesReportedValue> subcategoriesReportedValues, string displayCssClass)            
        {
            _eipPerformanceMeasure = eipPerformanceMeasure;
            SubcategoriesReportedValues = subcategoriesReportedValues;
            DisplayCssClass = displayCssClass;
        }

        public static List<EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue> CreateFromEIPPerformanceMeasuresAndCalendarYears(List<IEIPPerformanceMeasureReportedValue> eipPerformanceMeasureReportedValues)
        {
            var groupedByEIPPerformanceMeasure = eipPerformanceMeasureReportedValues.GroupBy(x => x.EIPPerformanceMeasure);
            var eipPerformanceMeasureCalendarYearReportedValues = new List<EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue>();
            foreach (var reportedValues in groupedByEIPPerformanceMeasure)
            {
                var eipPerformanceMeasure = reportedValues.Key;
                var subcategoriesReportedValues =
                    reportedValues.GroupBy(x => x.IndicatorSubcategoriesAsString)
                        .Select(
                            subcategoriesReportedValue =>
                                new SubcategoriesReportedValue(subcategoriesReportedValue.Key, subcategoriesReportedValue.First().IndicatorSubcategoryOptions,
                                    subcategoriesReportedValue.GroupBy(scrv => scrv.CalendarYear).ToDictionary(scrv => scrv.Key, scrv => scrv.Sum(rv => rv.ReportedValue))))
                        .ToList();
                eipPerformanceMeasureCalendarYearReportedValues.Add(new EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue(eipPerformanceMeasure, subcategoriesReportedValues, null));
            }
            return eipPerformanceMeasureCalendarYearReportedValues;
        }

        public static EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue Clone(EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue eipPerformanceMeasureSubcategoriesCalendarYearReportedValue, string displayCssClass)
        {
            return new EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue(eipPerformanceMeasureSubcategoriesCalendarYearReportedValue._eipPerformanceMeasure, eipPerformanceMeasureSubcategoriesCalendarYearReportedValue.SubcategoriesReportedValues.Select(SubcategoriesReportedValue.Clone).ToList(), displayCssClass);
        }
    }

    public class SubcategoriesReportedValue
    {
        public readonly List<IEIPPerformanceMeasureValueSubcategoryOption> EIPPerformanceMeasureValueSubcategoryOptions;
        public readonly Dictionary<int, double?> CalendarYearReportedValue;
        public readonly string IndicatorSubcategories;         
        public readonly List<string> SubcategoryNames;
        
        public SubcategoriesReportedValue(string subcategories, List<IEIPPerformanceMeasureValueSubcategoryOption> eipPerformanceMeasureValueSubcategoryOptions, Dictionary<int, double?> calendarYearReportedValue)
        {
            EIPPerformanceMeasureValueSubcategoryOptions = eipPerformanceMeasureValueSubcategoryOptions;
            IndicatorSubcategories = subcategories;
            CalendarYearReportedValue = calendarYearReportedValue;            
            SubcategoryNames = new List<string>(eipPerformanceMeasureValueSubcategoryOptions.Select(p => p.IndicatorSubcategory.IndicatorSubcategoryDisplayName).OrderBy(p => p));
        }

        public static SubcategoriesReportedValue Clone(SubcategoriesReportedValue subcategoriesReportedValue)
        {
            return new SubcategoriesReportedValue(subcategoriesReportedValue.IndicatorSubcategories,
                subcategoriesReportedValue.EIPPerformanceMeasureValueSubcategoryOptions,
                subcategoriesReportedValue.CalendarYearReportedValue.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}