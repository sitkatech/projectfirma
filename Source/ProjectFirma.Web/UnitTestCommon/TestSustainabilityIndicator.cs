using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestSustainabilityIndicator
        {
            public static SustainabilityIndicator Create()
            {
                var sustainabilityAspect = TestSustainabilityAspect.Create();
                var indicator = TestIndicator.Create();
                var sustainabilityIndicator = new SustainabilityIndicator(indicator, sustainabilityAspect, false)
                {
                    IndicatorSubcategories = new List<IndicatorSubcategory>(),
                    SustainabilityIndicatorReporteds = new List<SustainabilityIndicatorReported>(),
                    SustainabilityIndicatorReportingPeriods = new List<SustainabilityIndicatorReportingPeriod>(),
                    SustainabilityIndicatorReportedSubcategoryOptions = new List<SustainabilityIndicatorReportedSubcategoryOption>()
                };
                indicator.SustainabilityIndicator = sustainabilityIndicator;
                return sustainabilityIndicator;
            }
        }
    }
}