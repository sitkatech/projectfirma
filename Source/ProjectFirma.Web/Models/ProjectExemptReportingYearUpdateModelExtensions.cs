using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirmaModels.Models
{
    public static class ProjectExemptReportingYearUpdateModelExtensions
    {
        public static void CreatePerformanceMeasuresExemptReportingYearsFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            foreach (var projectExemptReportingYearUpdate in project.GetPerformanceMeasuresExemptReportingYears()
                .Select(projectExemptReportingYear => new ProjectExemptReportingYearUpdate(projectUpdateBatch,
                    projectExemptReportingYear.CalendarYear, projectExemptReportingYear.ProjectExemptReportingType))
                .ToList())
            {
                projectUpdateBatch.ProjectExemptReportingYearUpdates.Add(projectExemptReportingYearUpdate);
            }
        }

        public static void CreateExpendituresExemptReportingYearsFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            foreach (var projectExemptReportingYearUpdate in project.GetExpendituresExemptReportingYears()
                .Select(projectExemptReportingYear => new ProjectExemptReportingYearUpdate(projectUpdateBatch,
                    projectExemptReportingYear.CalendarYear, projectExemptReportingYear.ProjectExemptReportingType))
                .ToList())
            {
                projectUpdateBatch.ProjectExemptReportingYearUpdates.Add(projectExemptReportingYearUpdate);
            }
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectExemptReportingYear> projectExemptReportingYears)
        {
            var project = projectUpdateBatch.Project;
            var projectExemptReportingYearsFromProjectUpdate =
                projectUpdateBatch.ProjectExemptReportingYearUpdates.Select(x => new ProjectExemptReportingYear(project.ProjectID, x.CalendarYear, x.ProjectExemptReportingTypeID)).ToList();
            project.ProjectExemptReportingYears.Merge(projectExemptReportingYearsFromProjectUpdate,
                projectExemptReportingYears,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID, HttpRequestStorage.DatabaseEntities);
        }
    }
}