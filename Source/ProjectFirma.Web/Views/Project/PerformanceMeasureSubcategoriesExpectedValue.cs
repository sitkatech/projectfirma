using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class PerformanceMeasureSubcategoriesExpectedValue
    {
        private readonly ProjectFirmaModels.Models.PerformanceMeasure _performanceMeasure;
        public int PerformanceMeasureID => _performanceMeasure.PerformanceMeasureID;

        public HtmlString PerformanceMeasureDisplayNameAsUrl => _performanceMeasure.GetDisplayNameAsUrl();

        public string PerformanceMeasureDisplayName => _performanceMeasure.PerformanceMeasureDisplayName;

        public MeasurementUnitType MeasurementUnitType => _performanceMeasure.MeasurementUnitType;

        public List<PerformanceMeasureSubcategory> PerformanceMeasureSubcategories => _performanceMeasure.GetPerformanceMeasureSubcategories();

        public readonly List<SubcategoriesExpectedValue> SubcategoriesExpectedValues;
        public string DisplayCssClass;

        public PerformanceMeasureSubcategoriesExpectedValue(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, List<SubcategoriesExpectedValue> subcategoriesExpectedValues, string displayCssClass)            
        {
            _performanceMeasure = performanceMeasure;
            SubcategoriesExpectedValues = subcategoriesExpectedValues;
            DisplayCssClass = displayCssClass;
        }

        public static List<PerformanceMeasureSubcategoriesExpectedValue> CreateFromPerformanceMeasures(List<IPerformanceMeasureValue> performanceMeasureReportedValues)
        {
            var groupedByPerformanceMeasure = performanceMeasureReportedValues.GroupBy(x => x.PerformanceMeasure);
            var performanceMeasureExpectedValues = new List<PerformanceMeasureSubcategoriesExpectedValue>();
            foreach (var reportedValues in groupedByPerformanceMeasure)
            {
                var performanceMeasure = reportedValues.Key;
                var groupBy = reportedValues.GroupBy(x => x.GetPerformanceMeasureSubcategoriesAsString()).ToList();
                var subcategoriesExpectedValues =
                    groupBy
                        .Select(
                            subcategoriesExpectedValue =>
                            {
                                var expectedValues = subcategoriesExpectedValue.Select(x => x.GetReportedValue()).ToList();
                                var expectedValue = expectedValues.TrueForAll(x => !x.HasValue) ? null : expectedValues.Sum();
                                return new SubcategoriesExpectedValue(subcategoriesExpectedValue.Key, subcategoriesExpectedValue.First().GetPerformanceMeasureSubcategoryOptions(),
                                    expectedValue);
                            })                                
                        .ToList();
                var orderedSubcategoryExpectedValues = subcategoriesExpectedValues.OrderBy(srv =>
                    srv.PerformanceMeasureValueSubcategoryOptions
                        .OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName).FirstOrDefault()?
                        .PerformanceMeasureSubcategoryOption?.SortOrder).ToList();
                performanceMeasureExpectedValues.Add(new PerformanceMeasureSubcategoriesExpectedValue(performanceMeasure, orderedSubcategoryExpectedValues, null));
            }
            return performanceMeasureExpectedValues;
        }

        public static PerformanceMeasureSubcategoriesExpectedValue Clone(PerformanceMeasureSubcategoriesExpectedValue performanceMeasureSubcategoriesExpectedValue, string displayCssClass)
        {
            return new PerformanceMeasureSubcategoriesExpectedValue(performanceMeasureSubcategoriesExpectedValue._performanceMeasure, performanceMeasureSubcategoriesExpectedValue.SubcategoriesExpectedValues.Select(SubcategoriesExpectedValue.Clone).ToList(), displayCssClass);
        }
    }

    public class SubcategoriesExpectedValue
    {
        public readonly List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureValueSubcategoryOptions;
        public readonly double? ExpectedValue;
        public readonly string PerformanceMeasureSubcategories;
        public readonly List<string> SubcategoryNames;

        public SubcategoriesExpectedValue(string subcategories, List<IPerformanceMeasureValueSubcategoryOption> performanceMeasureValueSubcategoryOptions, double? expectedValue)
        {
            PerformanceMeasureValueSubcategoryOptions = performanceMeasureValueSubcategoryOptions;
            PerformanceMeasureSubcategories = subcategories;
            ExpectedValue = expectedValue;
            SubcategoryNames = new List<string>(performanceMeasureValueSubcategoryOptions.Select(p => p.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName).OrderBy(p => p));
        }

        public static SubcategoriesExpectedValue Clone(SubcategoriesExpectedValue subcategoriesExpectedValue)
        {
            return new SubcategoriesExpectedValue(subcategoriesExpectedValue.PerformanceMeasureSubcategories,
                subcategoriesExpectedValue.PerformanceMeasureValueSubcategoryOptions, subcategoriesExpectedValue.ExpectedValue);
        }
    }

}