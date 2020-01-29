using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureProjectReportingDto
    {
        public PerformanceMeasureProjectReportingDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            ProjectReporting = performanceMeasure.ProjectReporting;
        }

        public PerformanceMeasureProjectReportingDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string ProjectReporting { get; set; }
    }
}