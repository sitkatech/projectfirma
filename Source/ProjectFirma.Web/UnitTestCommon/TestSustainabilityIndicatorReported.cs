using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestSustainabilityIndicatorReported
        {
            public static SustainabilityIndicatorReported Create(SustainabilityIndicator sustainabilityIndicator, SustainabilityIndicatorReportingPeriod sustainabilityIndicatorReportingPeriod, double reportedValue)
            {
                var sustainabilityIndicatorReported = new SustainabilityIndicatorReported(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod, reportedValue)
                {
                    SustainabilityIndicatorReportedSubcategoryOptions =  new List<SustainabilityIndicatorReportedSubcategoryOption>()
                };
                return sustainabilityIndicatorReported;
            }
        }
    }
}