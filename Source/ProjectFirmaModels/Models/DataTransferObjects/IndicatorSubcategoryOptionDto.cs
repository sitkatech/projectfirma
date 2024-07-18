
namespace ProjectFirmaModels.Models.DataTransferObjects
{   
    public class IndicatorSubcategoryOptionSimpleDto
    {
        public int IndicatorSubcategoryOptionID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public string IndicatorSubcategoryOptionName { get; set; }
        public int SortOrder { get; set; }
        public string ShortName { get; set; }
    }

}