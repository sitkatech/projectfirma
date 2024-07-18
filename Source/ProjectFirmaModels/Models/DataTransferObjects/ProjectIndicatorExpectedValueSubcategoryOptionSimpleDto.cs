

namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class ProjectIndicatorExpectedValueSubcategoryOptionSimpleDto
    {
        public int ProjectIndicatorExpectedValueSubcategoryOptionID { get; set; }
        public int ProjectIndicatorExpectedValueID { get; set; }
        public int IndicatorSubcategoryOptionID { get; set; }
        public int IndicatorID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public IndicatorSubcategorySimpleDto IndicatorSubcategory { get; set; }
        public IndicatorSubcategoryOptionSimpleDto IndicatorSubcategoryOption { get; set; }
    }

}