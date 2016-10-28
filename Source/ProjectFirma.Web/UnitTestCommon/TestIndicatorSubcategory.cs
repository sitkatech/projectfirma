using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestIndicatorSubcategory
        {
            public static IndicatorSubcategory Create(PerformanceMeasure performanceMeasure, string indicatorSubcategoryName)
            {
                var indicatorSubcategory = new IndicatorSubcategory(performanceMeasure.Indicator, indicatorSubcategoryName, indicatorSubcategoryName) { PerformanceMeasure = performanceMeasure};
                performanceMeasure.Indicator.IndicatorSubcategories.Add(indicatorSubcategory);
                performanceMeasure.IndicatorSubcategories.Add(indicatorSubcategory);
                return indicatorSubcategory;
            }

            public static IndicatorSubcategory CreateWithSubcategoryOptions(PerformanceMeasure performanceMeasure, int indicatorSubcategoryID, string indicatorSubcategoryName)
            {
                var indicatorSubcategory = Create(performanceMeasure, indicatorSubcategoryName);
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