using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureThresholdReportingCategorySimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureThresholdReportingCategorySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureThresholdReportingCategorySimple(int performanceMeasureRelationshipID, int performanceMeasureID, int thresholdReportingCategoryID, int performanceMeasureRelationshipTypeID)
            : this()
        {
            PerformanceMeasureRelationshipID = performanceMeasureRelationshipID;
            PerformanceMeasureID = performanceMeasureID;
            ThresholdReportingCategoryID = thresholdReportingCategoryID;
            PerformanceMeasureRelationshipTypeID = performanceMeasureRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureThresholdReportingCategorySimple(int performanceMeasureID, int thresholdReportingCategoryID, int performanceMeasureRelationshipTypeID)
            : this()
        {
            PerformanceMeasureID = performanceMeasureID;
            ThresholdReportingCategoryID = thresholdReportingCategoryID;
            PerformanceMeasureRelationshipTypeID = performanceMeasureRelationshipTypeID;
        }

        public int PerformanceMeasureRelationshipID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int ThresholdReportingCategoryID { get; set; }
        [Required]
        public int PerformanceMeasureRelationshipTypeID { get; set; }
    }
}