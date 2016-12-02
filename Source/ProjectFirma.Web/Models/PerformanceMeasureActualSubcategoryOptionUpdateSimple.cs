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
            int? performanceMeasureSubcategoryOptionID,
            int performanceMeasureID,
            int performanceMeasureSubcategoryID) : this()
        {
            PerformanceMeasureActualSubcategoryOptionUpdateID = performanceMeasureActualSubcategoryOptionUpdateID;
            PerformanceMeasureActualUpdateID = performanceMeasureActualUpdateID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdateSimple(PerformanceMeasureActualSubcategoryOptionUpdate performanceMeasureActualSubcategoryOptionUpdate) : this()
        {
            PerformanceMeasureActualSubcategoryOptionUpdateID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureActualSubcategoryOptionUpdateID;
            PerformanceMeasureActualUpdateID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureActualUpdateID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureActualSubcategoryOptionUpdate.PerformanceMeasureSubcategoryID;
        }

        public PerformanceMeasureActualSubcategoryOptionUpdateSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption,
            PerformanceMeasureActualUpdate performanceMeasureActualUpdate)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActualUpdate.PerformanceMeasureActualUpdateID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryID)
        {
        }

        public int PerformanceMeasureActualSubcategoryOptionUpdateID { get; set; }
        public int PerformanceMeasureActualUpdateID { get; set; }
        [DisplayName("PerformanceMeasureSubcategory Option")]
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
    }
}