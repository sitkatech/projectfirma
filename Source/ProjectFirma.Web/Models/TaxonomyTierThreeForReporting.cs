namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierThreeForReporting
    {
        public int TaxonomyTierThreeID
        {
            get { return _taxonomyTierThree.TaxonomyTierThreeID; }
        }
        public string DisplayName
        {
            get { return _taxonomyTierThree.DisplayName; }
        }
        private readonly TaxonomyTierThree _taxonomyTierThree;

        public TaxonomyTierThreeForReporting(TaxonomyTierThree taxonomyTierThree)
        {
            _taxonomyTierThree = taxonomyTierThree;
        }
    }
}