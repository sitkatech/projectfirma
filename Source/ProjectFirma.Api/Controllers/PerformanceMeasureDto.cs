using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureDto
    {
        public PerformanceMeasureDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            PerformanceMeasureDisplayName = performanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureDefinition = performanceMeasure.PerformanceMeasureDefinition;
            CriticalDefinitions = performanceMeasure.CriticalDefinitions;
            ProjectReporting = performanceMeasure.ProjectReporting;
        }

        public PerformanceMeasureDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string CriticalDefinitions { get; set; }
        public string ProjectReporting { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Performance Measure Display Name")]
        public string PerformanceMeasureDisplayName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public int PerformanceMeasureTypeID { get; set; }
        public string PerformanceMeasureDefinition { get; set; }
        public string DataSourceText { get; set; }
        public string ExternalDataSourceUrl { get; set; }
        public string ChartCaption { get; set; }
        public bool SwapChartAxes { get; set; }
        public bool CanCalculateTotal { get; set; }
        public int? PerformanceMeasureSortOrder { get; set; }
        public bool IsAggregatable { get; set; }
        public int PerformanceMeasureDataSourceTypeID { get; set; }
    }
}