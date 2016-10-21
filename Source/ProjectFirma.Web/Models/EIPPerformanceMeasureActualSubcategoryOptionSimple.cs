using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualSubcategoryOptionSimple
    {
        public int EIPPerformanceMeasureActualSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureActualID { get; set; }
        [Required]
        [DisplayName("Subcategory Option")]
        public int? IndicatorSubcategoryOptionID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionSimple(int eipPerformanceMeasureActualSubcategoryOptionID, int eipPerformanceMeasureActualID, int indicatorSubcategoryOptionID, int eipPerformanceMeasureID, int indicatorSubcategoryID) : this()
        {
            EIPPerformanceMeasureActualSubcategoryOptionID = eipPerformanceMeasureActualSubcategoryOptionID;
            EIPPerformanceMeasureActualID = eipPerformanceMeasureActualID;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EIPPerformanceMeasureActualSubcategoryOptionSimple(EIPPerformanceMeasureActualSubcategoryOption eipPerformanceMeasureActualSubcategoryOption) : this()
        {
            EIPPerformanceMeasureActualSubcategoryOptionID = eipPerformanceMeasureActualSubcategoryOption.EIPPerformanceMeasureActualSubcategoryOptionID;
            EIPPerformanceMeasureActualID = eipPerformanceMeasureActualSubcategoryOption.EIPPerformanceMeasureActualID;
            IndicatorSubcategoryOptionID = eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryOptionID;
            EIPPerformanceMeasureID = eipPerformanceMeasureActualSubcategoryOption.EIPPerformanceMeasureID;
            IndicatorSubcategoryID = eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryID;
        }

        public EIPPerformanceMeasureActualSubcategoryOptionSimple(EIPPerformanceMeasureValueSubcategoryOption eipPerformanceMeasureActualSubcategoryOption, EIPPerformanceMeasureActual eipPerformanceMeasureActual)
            : this(
                eipPerformanceMeasureActualSubcategoryOption.PrimaryKey,
                eipPerformanceMeasureActual.EIPPerformanceMeasureActualID,
                eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryOptionID,
                eipPerformanceMeasureActualSubcategoryOption.EIPPerformanceMeasureID,
                eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryID)
        {
        }
    }
}