using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static class ProjectUpdateBatchModelExtensions
    {
        public static List<ProjectExemptReportingYearUpdate> GetPerformanceMeasuresExemptReportingYears(this ProjectUpdateBatch project)
        {
            return project.ProjectExemptReportingYearUpdates
                .Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.PerformanceMeasures)
                .OrderBy(x => x.CalendarYear).ToList();
        }
        public static List<ProjectExemptReportingYearUpdate> GetExpendituresExemptReportingYears(this ProjectUpdateBatch project)
        {
            return project.ProjectExemptReportingYearUpdates
                .Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.Expenditures)
                .OrderBy(x => x.CalendarYear).ToList();
        }

    }
}