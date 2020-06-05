using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ProjectFirma.Api.Models
{
    public class PerformanceMeasureBasicsDto
    {
        public PerformanceMeasureBasicsDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            PerformanceMeasureDisplayName = performanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureDefinition = performanceMeasure.PerformanceMeasureDefinition;
            PerformanceMeasureTypeName = performanceMeasure.PerformanceMeasureType.PerformanceMeasureTypeDisplayName;
            PerformanceMeasureDataSourceTypeName = performanceMeasure.PerformanceMeasureDataSourceType.PerformanceMeasureDataSourceTypeDisplayName;
            MeasurementUnitTypeName = performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName;
            IsSummable = performanceMeasure.IsSummable;
        }

        public PerformanceMeasureBasicsDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        [DisplayName("Performance Measure Display Name")]
        public string PerformanceMeasureDisplayName { get; set; }
        public string MeasurementUnitTypeName { get; set; }
        public string PerformanceMeasureTypeName { get; set; }
        public string PerformanceMeasureDefinition { get; set; }
        public bool IsSummable { get; set; }
        public string PerformanceMeasureDataSourceTypeName { get; set; }

    }
}