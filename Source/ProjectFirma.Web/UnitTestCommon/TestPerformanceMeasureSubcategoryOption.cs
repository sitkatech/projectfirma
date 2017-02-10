using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureSubcategoryOption
        {
            public static PerformanceMeasureSubcategoryOption Create(int performanceMeasureSubcategoryOptionID, PerformanceMeasureSubcategory performanceMeasureSubcategory, string performanceMeasureSubcategoryOptionName)
            {
                var performanceMeasureSubcategoryOption = new PerformanceMeasureSubcategoryOption(performanceMeasureSubcategory, performanceMeasureSubcategoryOptionName);
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
                return performanceMeasureSubcategoryOption;
            }

            public static PerformanceMeasureSubcategoryOption Create(DatabaseEntities dbContext, int performanceMeasureSubcategoryOptionID, PerformanceMeasureSubcategory performanceMeasureSubcategory, string performanceMeasureSubcategoryOptionName)
            {
                var performanceMeasureSubcategoryOption = Create(performanceMeasureSubcategoryOptionID, performanceMeasureSubcategory, performanceMeasureSubcategoryOptionName);
                dbContext.AllPerformanceMeasureSubcategoryOptions.Add(performanceMeasureSubcategoryOption);
                return performanceMeasureSubcategoryOption;
            }
        }
    }
}