using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestSustainabilityIndicatorReportedSubcategoryOption
        {
            public static SustainabilityIndicatorReportedSubcategoryOption Create(SustainabilityIndicatorReported sustainabilityIndicatorReported, IndicatorSubcategoryOption indicatorSubcategoryOption)
            {
                var sustainabilityIndicatorReportedSubcategoryOption = new SustainabilityIndicatorReportedSubcategoryOption(sustainabilityIndicatorReported, indicatorSubcategoryOption, sustainabilityIndicatorReported.SustainabilityIndicator, indicatorSubcategoryOption.IndicatorSubcategory);
                return sustainabilityIndicatorReportedSubcategoryOption;
            }
        }
    }
}