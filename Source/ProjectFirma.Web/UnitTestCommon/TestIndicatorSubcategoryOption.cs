using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestIndicatorSubcategoryOption
        {
            public static IndicatorSubcategoryOption Create(int indicatorSubcategoryOptionID, IndicatorSubcategory indicatorSubcategory, string indicatorSubcategoryOptionName)
            {
                var indicatorSubcategoryOption = new IndicatorSubcategoryOption(indicatorSubcategory, indicatorSubcategoryOptionName);
                indicatorSubcategoryOption.IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
                return indicatorSubcategoryOption;
            }

            public static IndicatorSubcategoryOption Create(DatabaseEntities dbContext, int indicatorSubcategoryOptionID, IndicatorSubcategory indicatorSubcategory, string indicatorSubcategoryOptionName)
            {
                var indicatorSubcategoryOption = Create(indicatorSubcategoryOptionID, indicatorSubcategory, indicatorSubcategoryOptionName);
                dbContext.IndicatorSubcategoryOptions.Add(indicatorSubcategoryOption);
                return indicatorSubcategoryOption;
            }
        }
    }
}