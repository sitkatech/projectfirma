
namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class ProjectIndicatorReportedValueSubcategoryOptionSimpleDto
    {
        public int ProjectIndicatorReportedValueSubcategoryOptionID { get; set; }
        public int ProjectIndicatorReportedValueID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int IndicatorID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public IndicatorSubcategoryOptionSimpleDto IndicatorSubcategoryOption { get; set; }
        public IndicatorSubcategorySimpleDto IndicatorSubcategory { get; set; }
        public IndicatorSimpleDto Indicator { get; set; }
    }

}