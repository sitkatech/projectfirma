namespace ProjectFirmaModels.Models
{
    public class TaxonomyTrunkSimple
    {
        public int TaxonomyTrunkID { get; set; }
        public string TaxonomyTrunkName { get; set; }
        public string TaxonomyTrunkDescription { get; set; }

        public TaxonomyTrunkSimple(TaxonomyTrunk taxonomyTrunk)
        {
            TaxonomyTrunkID = taxonomyTrunk.TaxonomyTrunkID;
            TaxonomyTrunkName = taxonomyTrunk.TaxonomyTrunkName;
            TaxonomyTrunkDescription = taxonomyTrunk.TaxonomyTrunkDescription;
        }
    }
}