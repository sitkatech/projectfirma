using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualUpdateSimple
    {
        public int EIPPerformanceMeasureActualUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }

        [Required]
        [DisplayName("Year")]
        public int? CalendarYear { get; set; }

        [DisplayName("Reported Value")]
        public double? ActualValue { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EIPPerformanceMeasureActualUpdateSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EIPPerformanceMeasureActualUpdateSimple(EIPPerformanceMeasureActualUpdate eipPerformanceMeasureActualUpdate) : this()
        {
            EIPPerformanceMeasureActualUpdateID = eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureActualUpdateID;
            ProjectUpdateBatchID = eipPerformanceMeasureActualUpdate.ProjectUpdateBatchID;
            EIPPerformanceMeasureID = eipPerformanceMeasureActualUpdate.EIPPerformanceMeasureID;
            CalendarYear = eipPerformanceMeasureActualUpdate.CalendarYear;
            ActualValue = eipPerformanceMeasureActualUpdate.ActualValue;
            EIPPerformanceMeasureActualSubcategoryOptionUpdates = EIPPerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(eipPerformanceMeasureActualUpdate);
        }

        public List<EIPPerformanceMeasureActualSubcategoryOptionUpdateSimple> EIPPerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
    }
}