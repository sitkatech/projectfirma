using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualSimple
    {
        public int? EIPPerformanceMeasureActualID { get; set; }        
        [Required]
        public int? ProjectID { get; set; }
        [Required]
        public int? EIPPerformanceMeasureID { get; set; }
        [Required]
        [DisplayName("Calendar Year")]
        public int? CalendarYear { get; set; }
        [Required]
        [DisplayName("Reported Value")]
        public double? ActualValue { get; set; }
        public List<EIPPerformanceMeasureActualSubcategoryOptionSimple> EIPPerformanceMeasureActualSubcategoryOptions { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EIPPerformanceMeasureActualSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualSimple(int eipPerformanceMeasureActualID, int projectID, int eipPerformanceMeasureID, int calendarYear, double actualValue)
            : this()
        {
            EIPPerformanceMeasureActualID = eipPerformanceMeasureActualID;
            ProjectID = projectID;
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            CalendarYear = calendarYear;
            ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EIPPerformanceMeasureActualSimple(EIPPerformanceMeasureActual eipPerformanceMeasureActual)
            : this()
        {
            EIPPerformanceMeasureActualID = eipPerformanceMeasureActual.EIPPerformanceMeasureActualID;
            ProjectID = eipPerformanceMeasureActual.ProjectID;
            EIPPerformanceMeasureID = eipPerformanceMeasureActual.EIPPerformanceMeasureID;
            CalendarYear = eipPerformanceMeasureActual.CalendarYear;
            ActualValue = eipPerformanceMeasureActual.ActualValue;
            EIPPerformanceMeasureActualSubcategoryOptions = EIPPerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(eipPerformanceMeasureActual);
        }        
    }
}