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
        public PerformanceMeasureExpectedSubcategoryOptionSimple(int performanceMeasureExpectedSubcategoryOptionID, int performanceMeasureExpectedID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID)
            : this()
        {
            PerformanceMeasureExpectedSubcategoryOptionID = performanceMeasureExpectedSubcategoryOptionID;
            PerformanceMeasureExpectedID = performanceMeasureExpectedID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureExpectedSubcategoryOptionSimple(PerformanceMeasureExpectedSubcategoryOption performanceMeasureExpectedSubcategoryOption)
            : this()
        {
            PerformanceMeasureExpectedSubcategoryOptionID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureExpectedSubcategoryOptionID;
            PerformanceMeasureExpectedID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureExpectedID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryID;
        }

        public PerformanceMeasureExpectedSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureExpectedSubcategoryOption,
            PerformanceMeasureExpected performanceMeasureExpected)
            : this(
                performanceMeasureExpectedSubcategoryOption.PrimaryKey,
                performanceMeasureExpected.PerformanceMeasureExpectedID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryID)
        {
        }

        public PerformanceMeasureExpectedSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureExpectedSubcategoryOption,
            PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed)
            : this(
                performanceMeasureExpectedSubcategoryOption.PrimaryKey,
                performanceMeasureExpectedProposed.PerformanceMeasureExpectedProposedID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureID,
                performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryID)
        {
        }

        public int PerformanceMeasureExpectedSubcategoryOptionID { get; set; }
        public int PerformanceMeasureExpectedID { get; set; }
        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
    }
}