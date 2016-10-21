using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectExemptReportingYearUpdateSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectExemptReportingYearUpdateSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYearUpdateSimple(int projectExemptReportingYearUpdateID, int projectUpdateBatchID, int calendarYear)
            : this()
        {
            ProjectExemptReportingYearUpdateID = projectExemptReportingYearUpdateID;
            ProjectUpdateBatchID = projectUpdateBatchID;
            CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectExemptReportingYearUpdateSimple(ProjectExemptReportingYearUpdate projectExemptReportingYearUpdate)
            : this()
        {
            ProjectExemptReportingYearUpdateID = projectExemptReportingYearUpdate.ProjectExemptReportingYearUpdateID;
            ProjectUpdateBatchID = projectExemptReportingYearUpdate.ProjectUpdateBatchID;
            CalendarYear = projectExemptReportingYearUpdate.CalendarYear;
            IsExempt = ModelObjectHelpers.IsRealPrimaryKeyValue(projectExemptReportingYearUpdate.ProjectExemptReportingYearUpdateID);
        }

        public int ProjectExemptReportingYearUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int CalendarYear { get; set; }
        public bool IsExempt { get; set; }
    }
}