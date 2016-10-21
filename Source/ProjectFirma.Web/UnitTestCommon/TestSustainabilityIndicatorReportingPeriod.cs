using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestSustainabilityIndicatorReportingPeriod
        {
            public static SustainabilityIndicatorReportingPeriod Create(SustainabilityIndicator sustainabilityIndicator, DateTime sustainabilityIndicatorReportingPeriodBeginDate)
            {
                return Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriodBeginDate, sustainabilityIndicatorReportingPeriodBeginDate.Year.ToString());
            }

            public static SustainabilityIndicatorReportingPeriod Create(SustainabilityIndicator sustainabilityIndicator, DateTime sustainabilityIndicatorReportingPeriodBeginDate, string sustainabilityIndicatorReportingPeriodLabel)
            {
                var sustainabilityIndicatorReportingPeriod = new SustainabilityIndicatorReportingPeriod(sustainabilityIndicator,
                    sustainabilityIndicatorReportingPeriodBeginDate,
                    sustainabilityIndicatorReportingPeriodLabel) {SustainabilityIndicatorReporteds = new List<SustainabilityIndicatorReported>()};
                return sustainabilityIndicatorReportingPeriod;
            }
        }
    }
}