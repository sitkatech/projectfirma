using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectExemptReportingYearSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectExemptReportingYearSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYearSimple(int projectExemptReportingYearID, int projectID, int calendarYear)
            : this()
        {
            ProjectExemptReportingYearID = projectExemptReportingYearID;
            ProjectID = projectID;
            CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectExemptReportingYearSimple(ProjectExemptReportingYear projectExemptReportingYear)
            : this()
        {
            ProjectExemptReportingYearID = projectExemptReportingYear.ProjectExemptReportingYearID;
            ProjectID = projectExemptReportingYear.ProjectID;
            CalendarYear = projectExemptReportingYear.CalendarYear;
            IsExempt = ModelObjectHelpers.IsRealPrimaryKeyValue(projectExemptReportingYear.ProjectExemptReportingYearID);
        }

        public int ProjectExemptReportingYearID { get; set; }
        public int ProjectID { get; set; }
        public int CalendarYear { get; set; }
        public bool IsExempt { get; set; }
    }
}