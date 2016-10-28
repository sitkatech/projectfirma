using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureActualSubcategoryOption
        {
            public static PerformanceMeasureActualSubcategoryOption Create(int performanceMeasureActualSubcategoryOptionID,
                PerformanceMeasureActual performanceMeasureActual,
                IndicatorSubcategory indicatorSubcategory,
                IndicatorSubcategoryOption indicatorSubcategoryOption)
            {
                var performanceMeasureActualSubcategoryOption = new PerformanceMeasureActualSubcategoryOption(performanceMeasureActual,
                    indicatorSubcategoryOption,
                    performanceMeasureActual.PerformanceMeasure,
                    indicatorSubcategory);
                performanceMeasureActualSubcategoryOption.PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOptionID;
                return performanceMeasureActualSubcategoryOption;
            }
        }
    }
}