using System.ComponentModel;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple(int eipPerformanceMeasureActualSubcategoryOptionUpdateID,
            int eipPerformanceMeasureActualUpdateID,
            int? indicatorSubcategoryOptionID,
            int eipPerformanceMeasureID,
            int indicatorSubcategoryID) : this()
        {
            EIPPerformanceMeasureActualSubcategoryOptionUpdateID = eipPerformanceMeasureActualSubcategoryOptionUpdateID;
            EIPPerformanceMeasureActualUpdateID = eipPerformanceMeasureActualUpdateID;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple(EIPPerformanceMeasureActualSubcategoryOptionUpdate eipPerformanceMeasureActualSubcategoryOptionUpdate) : this()
        {
            EIPPerformanceMeasureActualSubcategoryOptionUpdateID = eipPerformanceMeasureActualSubcategoryOptionUpdate.EIPPerformanceMeasureActualSubcategoryOptionUpdateID;
            EIPPerformanceMeasureActualUpdateID = eipPerformanceMeasureActualSubcategoryOptionUpdate.EIPPerformanceMeasureActualUpdateID;
            IndicatorSubcategoryOptionID = eipPerformanceMeasureActualSubcategoryOptionUpdate.IndicatorSubcategoryOptionID;
            EIPPerformanceMeasureID = eipPerformanceMeasureActualSubcategoryOptionUpdate.EIPPerformanceMeasureID;
            IndicatorSubcategoryID = eipPerformanceMeasureActualSubcategoryOptionUpdate.IndicatorSubcategoryID;
        }

        public EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple(EIPPerformanceMeasureValueSubcategoryOption eipPerformanceMeasureActualSubcategoryOption,
            EIPPerformanceMeasureActualUpdate eipPerformanceMeasureActualUpdate)
            : this(
                eipPerformanceMeasureActualSubcategoryOption.PrimaryKey,
                eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualUpdateID,
                eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryOptionID,
                eipPerformanceMeasureActualSubcategoryOption.EIPPerformanceMeasureID,
                eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryID)
        {
        }

        public int EIPPerformanceMeasureActualSubcategoryOptionUpdateID { get; set; }
        public int EIPPerformanceMeasureActualUpdateID { get; set; }
        [DisplayName("IndicatorSubcategory Option")]
        public int? IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
    }
}