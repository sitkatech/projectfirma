using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestEIPPerformanceMeasureExpectedSubcategoryOption
        {
            public static EIPPerformanceMeasureExpectedSubcategoryOption Create(int eipPerformanceMeasureExpectedSubcategoryOptionID,
                EIPPerformanceMeasureExpected eipPerformanceMeasureExpected,
                IndicatorSubcategory indicatorSubcategory,
                IndicatorSubcategoryOption indicatorSubcategoryOption)
            {
                var eipPerformanceMeasureExpectedSubcategoryOption = new EIPPerformanceMeasureExpectedSubcategoryOption(eipPerformanceMeasureExpected,
                    indicatorSubcategoryOption,
                    eipPerformanceMeasureExpected.EIPPerformanceMeasure,
                    indicatorSubcategory);
                eipPerformanceMeasureExpectedSubcategoryOption.EIPPerformanceMeasureExpectedSubcategoryOptionID = eipPerformanceMeasureExpectedSubcategoryOptionID;
                return eipPerformanceMeasureExpectedSubcategoryOption;
            }
        }
    }
}