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
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple(int performanceMeasureActualSubcategoryOptionID, int performanceMeasureActualID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOptionID;
            PerformanceMeasureActualID = performanceMeasureActualID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureActualSubcategoryOption performanceMeasureActualSubcategoryOption) : this()
        {
            PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOption.PerformanceMeasureActualSubcategoryOptionID;
            PerformanceMeasureActualID = performanceMeasureActualSubcategoryOption.PerformanceMeasureActualID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureActualSubcategoryOption.PerformanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryID;
        }

        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption, PerformanceMeasureActual performanceMeasureActual)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActual.PerformanceMeasureActualID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryID)
        {
        }
    }
}