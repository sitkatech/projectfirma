using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestCommodityPool
    {
        public static CommodityPool Create(Commodity commodity)
        {
            var commodityPoolName = TestFramework.MakeTestName("CommodityPoolName");
            var jurisdiction = TestJurisdiction.Create();
            return new CommodityPool(commodityPoolName, jurisdiction, true, commodity);
        }
    }
}