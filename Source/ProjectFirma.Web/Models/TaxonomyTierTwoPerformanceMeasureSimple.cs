namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoPerformanceMeasureSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasureSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasureSimple(int taxonomyTierTwoPerformanceMeasureID, int taxonomyTierTwoID, int performanceMeasureID, bool isPrimaryTaxonomyTierTwo)
            : this()
        {
            TaxonomyTierTwoPerformanceMeasureID = taxonomyTierTwoPerformanceMeasureID;
            TaxonomyTierTwoID = taxonomyTierTwoID;
            PerformanceMeasureID = performanceMeasureID;
            IsPrimaryTaxonomyTierTwo = isPrimaryTaxonomyTierTwo;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasureSimple(TaxonomyTierTwoPerformanceMeasure programPerformanceMeasure)
            : this()
        {
            TaxonomyTierTwoPerformanceMeasureID = programPerformanceMeasure.TaxonomyTierTwoPerformanceMeasureID;
            TaxonomyTierTwoID = programPerformanceMeasure.TaxonomyTierTwoID;
            PerformanceMeasureID = programPerformanceMeasure.PerformanceMeasureID;
            IsPrimaryTaxonomyTierTwo = programPerformanceMeasure.IsPrimaryTaxonomyTierTwo;
        }

        public int TaxonomyTierTwoPerformanceMeasureID { get; set; }
        public int TaxonomyTierTwoID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryTaxonomyTierTwo { get; set; }
    }
}