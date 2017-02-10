using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTaxonomyTierTwo
        {
            public static TaxonomyTierTwo Create()
            {
                var taxonomyTierThree = TestTaxonomyTierThree.Create();
                var taxonomyTierTwo = TaxonomyTierTwo.CreateNewBlank(taxonomyTierThree);
                taxonomyTierTwo.ThemeColor = "#FFFFFF";
                return taxonomyTierTwo;
            }

            public static TaxonomyTierTwo Create(DatabaseEntities dbContext)
            {
                var taxonomyTierThree = TestTaxonomyTierThree.Create(dbContext);
                var taxonomyTierTwo = new TaxonomyTierTwo(taxonomyTierThree,
                    MakeTestName("Test Taxonomy Tier Two Name", TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName));
                dbContext.AllTaxonomyTierTwos.Add(taxonomyTierTwo);
                return taxonomyTierTwo;
            }
        }
    }
}