using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestEIPPerformanceMeasure
        {
            public static EIPPerformanceMeasure Create()
            {
                var indicator = TestIndicator.Create();
                var eipPerformanceMeasure = new EIPPerformanceMeasure(indicator, EIPPerformanceMeasureType.Normal) {IndicatorSubcategories = new List<IndicatorSubcategory>()};
                indicator.EIPPerformanceMeasure = eipPerformanceMeasure;
                return eipPerformanceMeasure;
            }

            public static EIPPerformanceMeasure CreateWithSubcategories(int eipPerformanceMeasureID, string eipPerformanceMeasureName)
            {
                var eipPerformanceMeasure = Create();
                var subcategoryIDBase = eipPerformanceMeasureID*10;
                var subcategory1 = TestIndicatorSubcategory.CreateWithSubcategoryOptions(eipPerformanceMeasure, subcategoryIDBase + 1, string.Format("{0}Subcategory1", eipPerformanceMeasureName));
                var subcategory2 = TestIndicatorSubcategory.CreateWithSubcategoryOptions(eipPerformanceMeasure, subcategoryIDBase + 2, string.Format("{0}Subcategory2", eipPerformanceMeasureName));
                var subcategory3 = TestIndicatorSubcategory.CreateWithSubcategoryOptions(eipPerformanceMeasure, subcategoryIDBase + 3, string.Format("{0}Subcategory3", eipPerformanceMeasureName));
                return eipPerformanceMeasure;
            }
        }
    }
}