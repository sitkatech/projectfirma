namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureSubcategorySimple
    {
        public EIPPerformanceMeasureSubcategorySimple(IndicatorSubcategory indicatorSubcategory) : this(indicatorSubcategory.EIPPerformanceMeasureID.Value, indicatorSubcategory.IndicatorSubcategoryID, indicatorSubcategory.SortOrder)
        {
        }

        public EIPPerformanceMeasureSubcategorySimple(int eipPerformanceMeasureID, int indicatorSubcategoryID, int? sortOrder)
        {
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            IndicatorSubcategoryID = indicatorSubcategoryID;
            SortOrder = sortOrder;
        }

        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorSubcategoryID { get; set; }
        public int? SortOrder { get; set; }
    }
}