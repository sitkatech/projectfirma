using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    /// <summary>
    /// Use this for returning a more lightweight PerformanceMeasure record via the APIs
    /// </summary>
    public class PerformanceMeasureSimpleDto
    {
        public PerformanceMeasureSimpleDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            PerformanceMeasureDisplayName = performanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureTypeName = performanceMeasure.PerformanceMeasureType.PerformanceMeasureTypeDisplayName;
            PerformanceMeasureDataSourceTypeName = performanceMeasure.PerformanceMeasureDataSourceType.PerformanceMeasureDataSourceTypeDisplayName;
            MeasurementUnitTypeName = performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName;
        }

        public PerformanceMeasureSimpleDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureDisplayName { get; set; }
        public string MeasurementUnitTypeName { get; set; }
        public string PerformanceMeasureTypeName { get; set; }
        public string PerformanceMeasureDataSourceTypeName { get; set; }
    }
}