namespace ProjectFirma.Web.Models
{
    public class IndicatorSubcategorySimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorSubcategorySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public IndicatorSubcategorySimple(IndicatorSubcategory indicatorSubcategory)
            : this()
        {
            IndicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            IndicatorSubcategoryName = indicatorSubcategory.IndicatorSubcategoryName;
            IndicatorSubcategoryDisplayName = indicatorSubcategory.IndicatorSubcategoryDisplayName;
            ShowOnChart = indicatorSubcategory.ShowOnChart;
            IndicatorID = indicatorSubcategory.IndicatorID;
            PerformanceMeasureID = indicatorSubcategory.PerformanceMeasureID;
        }

        public int IndicatorSubcategoryID { get; set; }
        public string IndicatorSubcategoryName { get; set; }
        public string IndicatorSubcategoryDisplayName { get; set; }
        public bool ShowOnChart { get; set; }
        public int IndicatorID { get; set; }
        public int? PerformanceMeasureID { get; set; }
    }
}