using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class PerformanceMeasureCriticalDefinitionsDto
    {
        public PerformanceMeasureCriticalDefinitionsDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            CriticalDefinitions = performanceMeasure.CriticalDefinitions;
        }

        public PerformanceMeasureCriticalDefinitionsDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string CriticalDefinitions { get; set; }
    }
}