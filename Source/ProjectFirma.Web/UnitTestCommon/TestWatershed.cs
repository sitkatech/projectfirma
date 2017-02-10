using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestWatershed
        {
            public static Watershed Create()
            {
                var watershed = Watershed.CreateNewBlank();
                watershed.WatershedName = MakeTestWatershedName();
                return watershed;
            }

            public static Watershed Create(DatabaseEntities dbContext)
            {
                var watershed = Create();
                dbContext.AllWatersheds.Add(watershed);
                return watershed;
            }

            private static string MakeTestWatershedName()
            {
                return TestFramework.MakeTestName("Test Watershed Name", Watershed.FieldLengths.WatershedName);
            }
        }
    }
}