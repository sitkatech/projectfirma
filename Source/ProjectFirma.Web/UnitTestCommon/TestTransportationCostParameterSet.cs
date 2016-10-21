using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTransportationCostParameterSet
        {
            public static TransportationCostParameterSet Create()
            {
                var transportationCostParameterSet = TransportationCostParameterSet.CreateNewBlank();
                return transportationCostParameterSet;
            }
        }
    }
}