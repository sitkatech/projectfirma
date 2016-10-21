namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureExpectedSubcategoryOptionSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOptionSimple(int eipPerformanceMeasureExpectedSubcategoryOptionID, int eipPerformanceMeasureExpectedID, int indicatorSubcategoryOptionID, int eipPerformanceMeasureID, int indicatorSubcategoryID)
            : this()
        {
            EIPPerformanceMeasureExpectedSubcategoryOptionID = eipPerformanceMeasureExpectedSubcategoryOptionID;
            EIPPerformanceMeasureExpectedID = eipPerformanceMeasureExpectedID;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EIPPerformanceMeasureExpectedSubcategoryOptionSimple(EIPPerformanceMeasureExpectedSubcategoryOption eipPerformanceMeasureExpectedSubcategoryOption)
            : this()
        {
            EIPPerformanceMeasureExpectedSubcategoryOptionID = eipPerformanceMeasureExpectedSubcategoryOption.EIPPerformanceMeasureExpectedSubcategoryOptionID;
            EIPPerformanceMeasureExpectedID = eipPerformanceMeasureExpectedSubcategoryOption.EIPPerformanceMeasureExpectedID;
            IndicatorSubcategoryOptionID = eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOptionID;
            EIPPerformanceMeasureID = eipPerformanceMeasureExpectedSubcategoryOption.EIPPerformanceMeasureID;
            IndicatorSubcategoryID = eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID;
        }

        public EIPPerformanceMeasureExpectedSubcategoryOptionSimple(EIPPerformanceMeasureValueSubcategoryOption eipPerformanceMeasureExpectedSubcategoryOption,
            EIPPerformanceMeasureExpected eipPerformanceMeasureExpected)
            : this(
                eipPerformanceMeasureExpectedSubcategoryOption.PrimaryKey,
                eipPerformanceMeasureExpected.EIPPerformanceMeasureExpectedID,
                eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOptionID,
                eipPerformanceMeasureExpectedSubcategoryOption.EIPPerformanceMeasureID,
                eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID)
        {
        }

        public EIPPerformanceMeasureExpectedSubcategoryOptionSimple(EIPPerformanceMeasureValueSubcategoryOption eipPerformanceMeasureExpectedSubcategoryOption,
            EIPPerformanceMeasureExpectedProposed eipPerformanceMeasureExpectedProposed)
            : this(
                eipPerformanceMeasureExpectedSubcategoryOption.PrimaryKey,
                eipPerformanceMeasureExpectedProposed.EIPPerformanceMeasureExpectedProposedID,
                eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOptionID,
                eipPerformanceMeasureExpectedSubcategoryOption.EIPPerformanceMeasureID,
                eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryID)
        {
        }

        public int EIPPerformanceMeasureExpectedSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureExpectedID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
    }
}