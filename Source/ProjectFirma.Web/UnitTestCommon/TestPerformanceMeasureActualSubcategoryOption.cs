using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureActualSubcategoryOption
        {
            public static PerformanceMeasureActualSubcategoryOption Create(int performanceMeasureActualSubcategoryOptionID,
                PerformanceMeasureActual performanceMeasureActual,
                PerformanceMeasureSubcategory performanceMeasureSubcategory,
                PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption)
            {
                var performanceMeasureActualSubcategoryOption = new PerformanceMeasureActualSubcategoryOption(performanceMeasureActual,
                    performanceMeasureSubcategoryOption,
                    performanceMeasureActual.PerformanceMeasure,
                    performanceMeasureSubcategory);
                performanceMeasureActualSubcategoryOption.PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOptionID;
                return performanceMeasureActualSubcategoryOption;
            }
        }
    }
}