using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestCostParameterSet
        {
            public static CostParameterSet Create()
            {
                var costParameterSet = CostParameterSet.CreateNewBlank();
                return costParameterSet;
            }
        }
    }
}