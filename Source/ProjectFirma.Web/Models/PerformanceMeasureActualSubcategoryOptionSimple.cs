using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSubcategoryOptionSimple
    {
        public int PerformanceMeasureActualSubcategoryOptionID { get; set; }
        public int PerformanceMeasureActualID { get; set; }
        [Required]
        [DisplayName("Subcategory Option")]
        public int? IndicatorSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple(int performanceMeasureActualSubcategoryOptionID, int performanceMeasureActualID, int indicatorSubcategoryOptionID, int performanceMeasureID, int indicatorSubcategoryID) : this()
        {
            PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOptionID;
            PerformanceMeasureActualID = performanceMeasureActualID;
            IndicatorSubcategoryOptionID = indicatorSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureActualSubcategoryOption performanceMeasureActualSubcategoryOption) : this()
        {
            PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOption.PerformanceMeasureActualSubcategoryOptionID;
            PerformanceMeasureActualID = performanceMeasureActualSubcategoryOption.PerformanceMeasureActualID;
            IndicatorSubcategoryOptionID = performanceMeasureActualSubcategoryOption.IndicatorSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureActualSubcategoryOption.PerformanceMeasureID;
            IndicatorSubcategoryID = performanceMeasureActualSubcategoryOption.IndicatorSubcategoryID;
        }

        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption, PerformanceMeasureActual performanceMeasureActual)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActual.PerformanceMeasureActualID,
                performanceMeasureActualSubcategoryOption.IndicatorSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.IndicatorSubcategoryID)
        {
        }
    }
}