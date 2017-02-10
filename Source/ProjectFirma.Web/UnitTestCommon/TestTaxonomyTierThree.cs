using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTaxonomyTierThree
        {
            public static TaxonomyTierThree Create()
            {
                var taxonomyTierThree = TaxonomyTierThree.CreateNewBlank();
                taxonomyTierThree.ThemeColor = "#FFFFFF";
                return taxonomyTierThree;
            }

            /// <summary>
            /// Create new TaxonomyTierThree and attach it to the given context
            /// </summary>
            public static TaxonomyTierThree Create(DatabaseEntities dbContext)
            {
                var taxonomyTierThree = new TaxonomyTierThree(MakeTestName("Taxonomy Tier Three", TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName));
                dbContext.AllTaxonomyTierThrees.Add(taxonomyTierThree);
                return taxonomyTierThree;
            }
        }
    }
}