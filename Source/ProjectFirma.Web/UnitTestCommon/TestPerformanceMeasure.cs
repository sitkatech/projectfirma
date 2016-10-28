using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasure
        {
            public static PerformanceMeasure Create()
            {
                var indicator = TestIndicator.Create();
                var performanceMeasure = new PerformanceMeasure(indicator, PerformanceMeasureType.Normal) {IndicatorSubcategories = new List<IndicatorSubcategory>()};
                indicator.PerformanceMeasure = performanceMeasure;
                return performanceMeasure;
            }

            public static PerformanceMeasure CreateWithSubcategories(int performanceMeasureID, string performanceMeasureName)
            {
                var performanceMeasure = Create();
                var subcategoryIDBase = performanceMeasureID*10;
                var subcategory1 = TestIndicatorSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 1, string.Format("{0}Subcategory1", performanceMeasureName));
                var subcategory2 = TestIndicatorSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 2, string.Format("{0}Subcategory2", performanceMeasureName));
                var subcategory3 = TestIndicatorSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 3, string.Format("{0}Subcategory3", performanceMeasureName));
                return performanceMeasure;
            }
        }
    }
}