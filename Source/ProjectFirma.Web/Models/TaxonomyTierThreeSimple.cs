namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierThreeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTierThreeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierThreeSimple(int taxonomyTierThreeID, string taxonomyTierThreeName, string taxonomyTierThreeDescription, string taxonomyTierThreeColor)
            : this()
        {
            TaxonomyTierThreeID = taxonomyTierThreeID;
            TaxonomyTierThreeName = taxonomyTierThreeName;
            TaxonomyTierThreeDescription = taxonomyTierThreeDescription;
            TaxonomyTierThreeColor = taxonomyTierThreeColor;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTierThreeSimple(TaxonomyTierThree taxonomyTierThree)
            : this()
        {
            TaxonomyTierThreeID = taxonomyTierThree.TaxonomyTierThreeID;
            TaxonomyTierThreeName = taxonomyTierThree.TaxonomyTierThreeName;
            TaxonomyTierThreeDescription = taxonomyTierThree.TaxonomyTierThreeDescriptionHtmlString == null ? null : taxonomyTierThree.TaxonomyTierThreeDescriptionHtmlString.ToString();
            TaxonomyTierThreeColor = taxonomyTierThree.ThemeColor;
            DisplayName = taxonomyTierThree.DisplayName;
        }

        public int TaxonomyTierThreeID { get; set; }
        public string TaxonomyTierThreeName { get; set; }
        public string TaxonomyTierThreeDescription { get; set; }
        public string TaxonomyTierThreeColor { get; set; }
        public string DisplayName { get; set; }
    }
}