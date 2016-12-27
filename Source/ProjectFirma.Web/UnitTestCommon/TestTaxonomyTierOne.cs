using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTaxonomyTierOne
        {
            public static TaxonomyTierOne Create()
            {
                var taxonomyTierTwo = TestTaxonomyTierTwo.Create();
                var taxonomyTierOne = TaxonomyTierOne.CreateNewBlank(taxonomyTierTwo);
                return taxonomyTierOne;
            }

            /// <summary>
            /// Create new TaxonomyTierOne and attach it to the given context
            /// </summary>
            public static TaxonomyTierOne Create(DatabaseEntities dbContext)
            {
                var taxonomyTierTwo = TestTaxonomyTierTwo.Create(dbContext);
                var taxonomyTierOne = new TaxonomyTierOne(taxonomyTierTwo, MakeTestName("Test Taxonomy Tier One", TaxonomyTierOne.FieldLengths.TaxonomyTierOneName));
                var newTaxonomyTierOne = taxonomyTierOne;
                dbContext.TaxonomyTierOnes.Add(newTaxonomyTierOne);
                return newTaxonomyTierOne;
            }
        }
    }
}