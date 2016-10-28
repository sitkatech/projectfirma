using System.ComponentModel;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSubcategoryOptionUpdateSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdateSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdateSimple(int performanceMeasureActualSubcategoryOptionUpdateID,
            int performanceMeasureActualUpdateID,
            int? indicatorSubcategoryOptionID,
            int performanceMeasureID,
            int indicatorSubcategoryID) : this()
        {
            PerformanceMeasureActualSubcategoryOptionUpdateID = performanceMeasureActualSubcategoryOptionUpdateID;
            PerformanceMeasureActualUpdateID = performanceMeasureActualUpdateID;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdateSimple(PerformanceMeasureActualSubcategoryOptionUpdate performanceMeasureActualSubcategoryOptionUpdate) : this()
        {
            PerformanceMeasureActualSubcategoryOptionUpdateID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureActualSubcategoryOptionUpdateID;
            PerformanceMeasureActualUpdateID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureActualUpdateID;
            IndicatorSubcategoryOptionID = performanceMeasureActualSubcategoryOptionUpdate.IndicatorSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureID;
            IndicatorSubcategoryID = performanceMeasureActualSubcategoryOptionUpdate.IndicatorSubcategoryID;
        }

        public PerformanceMeasureActualSubcategoryOptionUpdateSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption,
            PerformanceMeasureActualUpdate performanceMeasureActualUpdate)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActualUpdate.PerformanceMeasureActualUpdateID,
                performanceMeasureActualSubcategoryOption.IndicatorSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.IndicatorSubcategoryID)
        {
        }

        public int PerformanceMeasureActualSubcategoryOptionUpdateID { get; set; }
        public int PerformanceMeasureActualUpdateID { get; set; }
        [DisplayName("IndicatorSubcategory Option")]
        public int? IndicatorSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
    }
}