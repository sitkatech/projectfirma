using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureImportanceDto
    {
        public PerformanceMeasureImportanceDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            Importance = performanceMeasure.Importance;
        }

        public PerformanceMeasureImportanceDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string Importance { get; set; }
    }
}