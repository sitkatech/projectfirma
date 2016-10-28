namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureExpectedSubcategoryOptionSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionSimple(int performanceMeasureExpectedSubcategoryOptionID, int performanceMeasureExpectedID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID)
            : this()
        {
            PerformanceMeasureExpectedSubcategoryOptionID = performanceMeasureExpectedSubcategoryOptionID;
            PerformanceMeasureExpectedID = performanceMeasureExpectedID;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionSimple(PerformanceMeasureExpectedSubcategoryOption performanceMeasureExpectedSubcategoryOption)
            : this()
        {
            PerformanceMeasureExpectedSubcategoryOptionID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureExpectedSubcategoryOptionID;
            PerformanceMeasureExpectedID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureExpectedID;
            IndicatorSubcategoryOptionID = performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureID;
            IndicatorSubcategoryID = performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID;
        }

        public PerformanceMeasureExpectedSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureExpectedSubcategoryOption,
            PerformanceMeasureExpected performanceMeasureExpected)
            : this(
                performanceMeasureExpectedSubcategoryOption.PrimaryKey,
                performanceMeasureExpected.PerformanceMeasureExpectedID,
                performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOptionID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureID,
                performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID)
        {
        }

        public PerformanceMeasureExpectedSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureExpectedSubcategoryOption,
            PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed)
            : this(
                performanceMeasureExpectedSubcategoryOption.PrimaryKey,
                performanceMeasureExpectedProposed.PerformanceMeasureExpectedProposedID,
                performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOptionID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureID,
                performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID)
        {
        }

        public int PerformanceMeasureExpectedSubcategoryOptionID { get; set; }
        public int PerformanceMeasureExpectedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
    }
}