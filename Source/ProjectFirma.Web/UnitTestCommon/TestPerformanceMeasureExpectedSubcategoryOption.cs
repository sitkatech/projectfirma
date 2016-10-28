using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureExpectedSubcategoryOption
        {
            public static PerformanceMeasureExpectedSubcategoryOption Create(int performanceMeasureExpectedSubcategoryOptionID,
                PerformanceMeasureExpected performanceMeasureExpected,
                IndicatorSubcategory indicatorSubcategory,
                IndicatorSubcategoryOption indicatorSubcategoryOption)
            {
                var performanceMeasureExpectedSubcategoryOption = new PerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpected,
                    indicatorSubcategoryOption,
                    performanceMeasureExpected.PerformanceMeasure,
                    indicatorSubcategory);
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureExpectedSubcategoryOptionID = performanceMeasureExpectedSubcategoryOptionID;
                return performanceMeasureExpectedSubcategoryOption;
            }
        }
    }
}