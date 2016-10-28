using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSimple
    {
        public int? PerformanceMeasureActualID { get; set; }        
        [Required]
        public int? ProjectID { get; set; }
        [Required]
        public int? PerformanceMeasureID { get; set; }
        [Required]
        [DisplayName("Calendar Year")]
        public int? CalendarYear { get; set; }
        [Required]
        [DisplayName("Reported Value")]
        public double? ActualValue { get; set; }
        public List<PerformanceMeasureActualSubcategoryOptionSimple> PerformanceMeasureActualSubcategoryOptions { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSimple(int performanceMeasureActualID, int projectID, int performanceMeasureID, int calendarYear, double actualValue)
            : this()
        {
            PerformanceMeasureActualID = performanceMeasureActualID;
            ProjectID = projectID;
            PerformanceMeasureID = performanceMeasureID;
            CalendarYear = calendarYear;
            ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualSimple(PerformanceMeasureActual performanceMeasureActual)
            : this()
        {
            PerformanceMeasureActualID = performanceMeasureActual.PerformanceMeasureActualID;
            ProjectID = performanceMeasureActual.ProjectID;
            PerformanceMeasureID = performanceMeasureActual.PerformanceMeasureID;
            CalendarYear = performanceMeasureActual.CalendarYear;
            ActualValue = performanceMeasureActual.ActualValue;
            PerformanceMeasureActualSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureActual);
        }        
    }
}