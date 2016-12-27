using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTaxonomyTierTwoPerformanceMeasure
        {
            public static TaxonomyTierTwoPerformanceMeasure Create()
            {
                var taxonomyTierTwo = TestTaxonomyTierTwo.Create();
                var performanceMeasure = TestPerformanceMeasure.Create();
                return Create(taxonomyTierTwo, performanceMeasure);
            }

            public static TaxonomyTierTwoPerformanceMeasure Create(TaxonomyTierTwo taxonomyTierTwo, PerformanceMeasure performanceMeasure)
            {
                var taxonomyTierTwoPerformanceMeasure = TaxonomyTierTwoPerformanceMeasure.CreateNewBlank(taxonomyTierTwo, performanceMeasure);
                return taxonomyTierTwoPerformanceMeasure;
            }
        }
    }
}