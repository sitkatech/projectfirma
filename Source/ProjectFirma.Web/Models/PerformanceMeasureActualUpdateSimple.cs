using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualUpdateSimple
    {
        public int PerformanceMeasureActualUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int PerformanceMeasureID { get; set; }

        [Required]
        [DisplayName("Year")]
        public int? CalendarYear { get; set; }

        [DisplayName("Reported Value")]
        public double? ActualValue { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualUpdateSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualUpdateSimple(PerformanceMeasureActualUpdate performanceMeasureActualUpdate) : this()
        {
            PerformanceMeasureActualUpdateID = performanceMeasureActualUpdate.PerformanceMeasureActualUpdateID;
            ProjectUpdateBatchID = performanceMeasureActualUpdate.ProjectUpdateBatchID;
            PerformanceMeasureID = performanceMeasureActualUpdate.PerformanceMeasureID;
            CalendarYear = performanceMeasureActualUpdate.CalendarYear;
            ActualValue = performanceMeasureActualUpdate.ActualValue;
            PerformanceMeasureActualSubcategoryOptionUpdates = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureActualUpdate);
        }

        public List<PerformanceMeasureActualSubcategoryOptionUpdateSimple> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
    }
}