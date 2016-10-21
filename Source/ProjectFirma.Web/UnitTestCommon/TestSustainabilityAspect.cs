using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestSustainabilityAspect
        {
            public static SustainabilityAspect Create()
            {
                var sus = TestSustainabilityPillar.Create();
                var sustainabilityAspectName = MakeTestName("Sustainability Aspect Name");
                var sustainabilityAspect = new SustainabilityAspect(sus, sustainabilityAspectName, sustainabilityAspectName, 1, null, null)
                {
                    SustainabilityIndicators = new List<SustainabilityIndicator>()
                };
                return sustainabilityAspect;
            }
        }
    }
}