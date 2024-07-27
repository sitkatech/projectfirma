
namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class IndicatorSubcategorySimpleDto
    {
        public int IndicatorSubcategoryID { get; set; }
        public int IndicatorID { get; set; }
        public string IndicatorSubcategoryDisplayName { get; set; }
        public int? SortOrder { get; set; }
        public string ChartConfigurationJson { get; set; }
        public int? GoogleChartTypeID { get; set; }
        public bool ShowOnChart { get; set; }
        public string CumulativeChartConfigurationJson { get; set; }
        public int? CumulativeGoogleChartTypeID { get; set; }
        public bool CumulativeShowOnChart { get; set; }
        public IndicatorSimpleDto Indicator { get; set; }
    }

}