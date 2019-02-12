using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureSubcategoryDto
    {
        public PerformanceMeasureSubcategoryDto()
        {
        }

        public PerformanceMeasureSubcategoryDto(PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            PerformanceMeasureID = performanceMeasureSubcategory.PerformanceMeasureID;
            PerformanceMeasureSubcategoryName = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
            ChartConfigurationJson = performanceMeasureSubcategory.ChartConfigurationJson;
            GoogleChartTypeName = performanceMeasureSubcategory.GoogleChartType.GoogleChartTypeDisplayName;
            PerformanceMeasureSubcategoryOptions = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions
                .Select(x => new PerformanceMeasureSubcategoryOptionDto(x)).ToList();
        }

        public int PerformanceMeasureSubcategoryID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureSubcategoryName { get; set; }
        public string ChartConfigurationJson { get; set; }
        public string GoogleChartTypeName { get; set; }
        public List<PerformanceMeasureSubcategoryOptionDto> PerformanceMeasureSubcategoryOptions { get; set; }
    }
}