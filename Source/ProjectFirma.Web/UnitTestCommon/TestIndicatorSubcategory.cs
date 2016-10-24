using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestIndicatorSubcategory
        {
            public static IndicatorSubcategory Create(EIPPerformanceMeasure eipPerformanceMeasure, string indicatorSubcategoryName)
            {
                var indicatorSubcategory = new IndicatorSubcategory(eipPerformanceMeasure.Indicator, indicatorSubcategoryName, indicatorSubcategoryName) { EIPPerformanceMeasure = eipPerformanceMeasure};
                eipPerformanceMeasure.Indicator.IndicatorSubcategories.Add(indicatorSubcategory);
                eipPerformanceMeasure.IndicatorSubcategories.Add(indicatorSubcategory);
                return indicatorSubcategory;
            }

            public static IndicatorSubcategory CreateWithSubcategoryOptions(EIPPerformanceMeasure eipPerformanceMeasure, int indicatorSubcategoryID, string indicatorSubcategoryName)
            {
                var indicatorSubcategory = Create(eipPerformanceMeasure, indicatorSubcategoryName);
                indicatorSubcategory.IndicatorSubcategoryID = indicatorSubcategoryID;
                var subcategoryOptionIDBase = indicatorSubcategoryID*10;
                var subcategoryOption1 = TestIndicatorSubcategoryOption.Create(subcategoryOptionIDBase + 1, indicatorSubcategory, string.Format("{0}Option1", indicatorSubcategoryName));
                var subcategoryOption2 = TestIndicatorSubcategoryOption.Create(subcategoryOptionIDBase + 2, indicatorSubcategory, string.Format("{0}Option2", indicatorSubcategoryName));
                var subcategoryOption3 = TestIndicatorSubcategoryOption.Create(subcategoryOptionIDBase + 3, indicatorSubcategory, string.Format("{0}Option3", indicatorSubcategoryName));
                return indicatorSubcategory;
            }
        }
    }
}