using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectExemptReportingYear
        {
            public static ProjectExemptReportingYear Create(Project project, int calendarYear)
            {
                var projectExemptReportingYear = new ProjectExemptReportingYear(project, calendarYear);
                return projectExemptReportingYear;
            }
        }
    }
}