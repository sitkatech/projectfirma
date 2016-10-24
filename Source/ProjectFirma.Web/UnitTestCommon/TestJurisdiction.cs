using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestJurisdiction
    {
        public static Jurisdiction Create()
        {
            var randomInMemoryOnlyUniqueID = TestFramework.RandomInMemoryOnlyUniqueID();
            var jurisdiction = new Jurisdiction(randomInMemoryOnlyUniqueID, 1110, null, null);
            return jurisdiction;
        }
    }
}