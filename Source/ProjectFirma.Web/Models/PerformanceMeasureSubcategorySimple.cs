namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSubcategorySimple
    {
        public PerformanceMeasureSubcategorySimple(IndicatorSubcategory indicatorSubcategory) : this(indicatorSubcategory.PerformanceMeasureID.Value, indicatorSubcategory.IndicatorSubcategoryID, indicatorSubcategory.SortOrder)
        {
        }

        public PerformanceMeasureSubcategorySimple(int performanceMeasureID, int indicatorSubcategoryID, int? sortOrder)
        {
            PerformanceMeasureID = performanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
            SortOrder = sortOrder;
        }

        public int PerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int? SortOrder { get; set; }
    }
}