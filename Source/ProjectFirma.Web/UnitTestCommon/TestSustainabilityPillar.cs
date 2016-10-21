using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestSustainabilityPillar
        {
            public static SustainabilityPillar Create()
            {
                var sustainabilityPillar = new SustainabilityPillar(MakeTestName("Sustainability Pillar Name"), null, 1, null, null) {SustainabilityAspects = new List<SustainabilityAspect>()};
                return sustainabilityPillar;
            }
        }
    }
}