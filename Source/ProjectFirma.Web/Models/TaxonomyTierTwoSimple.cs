namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTierTwoSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoSimple(int taxonomyTierTwoID, int taxonomyTierThreeID, string taxonomyTierTwoName, string taxonomyTierTwoDescription)
            : this()
        {
            TaxonomyTierTwoID = taxonomyTierTwoID;
            TaxonomyTierThreeID = taxonomyTierThreeID;
            TaxonomyTierTwoName = taxonomyTierTwoName;
            TaxonomyTierTwoDescription = taxonomyTierTwoDescription;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTierTwoSimple(TaxonomyTierTwo taxonomyTierTwo)
            : this()
        {
            TaxonomyTierTwoID = taxonomyTierTwo.TaxonomyTierTwoID;
            TaxonomyTierThreeID = taxonomyTierTwo.TaxonomyTierThreeID;
            TaxonomyTierTwoName = taxonomyTierTwo.TaxonomyTierTwoName;
            TaxonomyTierTwoDescription = taxonomyTierTwo.TaxonomyTierTwoDescription;
            DisplayName = taxonomyTierTwo.DisplayName;
        }

        public int TaxonomyTierTwoID { get; set; }
        public int TaxonomyTierThreeID { get; set; }
        public string TaxonomyTierTwoName { get; set; }
        public string TaxonomyTierTwoDescription { get; set; }
        public string DisplayName { get; set; }
    }
}