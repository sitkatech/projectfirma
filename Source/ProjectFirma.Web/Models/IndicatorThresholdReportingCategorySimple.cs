using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class IndicatorThresholdReportingCategorySimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorThresholdReportingCategorySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorThresholdReportingCategorySimple(int indicatorRelationshipID, int indicatorID, int thresholdReportingCategoryID, int indicatorRelationshipTypeID)
            : this()
        {
            IndicatorRelationshipID = indicatorRelationshipID;
            IndicatorID = indicatorID;
            ThresholdReportingCategoryID = thresholdReportingCategoryID;
            IndicatorRelationshipTypeID = indicatorRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorThresholdReportingCategorySimple(int indicatorID, int thresholdReportingCategoryID, int indicatorRelationshipTypeID)
            : this()
        {
            IndicatorID = indicatorID;
            ThresholdReportingCategoryID = thresholdReportingCategoryID;
            IndicatorRelationshipTypeID = indicatorRelationshipTypeID;
        }

        public int IndicatorRelationshipID { get; set; }
        public int IndicatorID { get; set; }
        public int ThresholdReportingCategoryID { get; set; }
        [Required]
        public int IndicatorRelationshipTypeID { get; set; }
    }
}