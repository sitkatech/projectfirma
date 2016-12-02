using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureSubcategory
        {
            public static PerformanceMeasureSubcategory Create(PerformanceMeasure performanceMeasure, string performanceMeasureSubcategoryName)
            {
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(performanceMeasure, performanceMeasureSubcategoryName, performanceMeasureSubcategoryName);
                performanceMeasure.PerformanceMeasureSubcategories.Add(performanceMeasureSubcategory);
                return performanceMeasureSubcategory;
            }

            public static PerformanceMeasureSubcategory CreateWithSubcategoryOptions(PerformanceMeasure performanceMeasure, int performanceMeasureSubcategoryID, string performanceMeasureSubcategoryName)
            {
                var performanceMeasureSubcategory = Create(performanceMeasure, performanceMeasureSubcategoryName);
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
                var subcategoryOptionIDBase = performanceMeasureSubcategoryID*10;
                var subcategoryOption1 = TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 1, performanceMeasureSubcategory, string.Format("{0}Option1", performanceMeasureSubcategoryName));
                var subcategoryOption2 = TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 2, performanceMeasureSubcategory, string.Format("{0}Option2", performanceMeasureSubcategoryName));
                var subcategoryOption3 = TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 3, performanceMeasureSubcategory, string.Format("{0}Option3", performanceMeasureSubcategoryName));
                return performanceMeasureSubcategory;
            }
        }
    }
}