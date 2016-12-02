using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureExpectedSubcategoryOption
        {
            public static PerformanceMeasureExpectedSubcategoryOption Create(int performanceMeasureExpectedSubcategoryOptionID,
                PerformanceMeasureExpected performanceMeasureExpected,
                PerformanceMeasureSubcategory performanceMeasureSubcategory,
                PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption)
            {
                var performanceMeasureExpectedSubcategoryOption = new PerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpected,
                    performanceMeasureSubcategoryOption,
                    performanceMeasureExpected.PerformanceMeasure,
                    performanceMeasureSubcategory);
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureExpectedSubcategoryOptionID = performanceMeasureExpectedSubcategoryOptionID;
                return performanceMeasureExpectedSubcategoryOption;
            }
        }
    }
}