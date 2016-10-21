using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectExemptReportingYearUpdate
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectExemptReportingYearUpdates =
                project.ProjectExemptReportingYears.Select(projectExemptReportingYear => new ProjectExemptReportingYearUpdate(projectUpdateBatch, projectExemptReportingYear.CalendarYear)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectExemptReportingYear> projectExemptReportingYears)
        {
            var project = projectUpdateBatch.Project;
            var projectExemptReportingYearsFromProjectUpdate =
                projectUpdateBatch.ProjectExemptReportingYearUpdates.Select(x => new ProjectExemptReportingYear(project.ProjectID, x.CalendarYear)).ToList();
            project.ProjectExemptReportingYears.Merge(projectExemptReportingYearsFromProjectUpdate,
                projectExemptReportingYears,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear);
        }
    }
}