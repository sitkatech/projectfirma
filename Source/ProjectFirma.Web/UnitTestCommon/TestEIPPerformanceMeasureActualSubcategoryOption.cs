using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestEIPPerformanceMeasureActualSubcategoryOption
        {
            public static EIPPerformanceMeasureActualSubcategoryOption Create(int eipPerformanceMeasureActualSubcategoryOptionID,
                EIPPerformanceMeasureActual eipPerformanceMeasureActual,
                IndicatorSubcategory indicatorSubcategory,
                IndicatorSubcategoryOption indicatorSubcategoryOption)
            {
                var eipPerformanceMeasureActualSubcategoryOption = new EIPPerformanceMeasureActualSubcategoryOption(eipPerformanceMeasureActual,
                    indicatorSubcategoryOption,
                    eipPerformanceMeasureActual.EIPPerformanceMeasure,
                    indicatorSubcategory);
                eipPerformanceMeasureActualSubcategoryOption.EIPPerformanceMeasureActualSubcategoryOptionID = eipPerformanceMeasureActualSubcategoryOptionID;
                return eipPerformanceMeasureActualSubcategoryOption;
            }
        }
    }
}