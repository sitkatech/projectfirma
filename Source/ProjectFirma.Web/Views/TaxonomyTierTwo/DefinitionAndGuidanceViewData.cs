namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class DefinitionAndGuidanceViewData : FirmaUserControlViewData
    {
        public readonly Models.TaxonomyTierTwo TaxonomyTierTwo;

        public DefinitionAndGuidanceViewData(Models.TaxonomyTierTwo taxonomyTierTwo)
        {
            TaxonomyTierTwo = taxonomyTierTwo;
        }
    }
}