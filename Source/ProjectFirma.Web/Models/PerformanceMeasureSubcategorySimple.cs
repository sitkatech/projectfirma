namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSubcategorySimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureSubcategorySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureSubcategorySimple(PerformanceMeasureSubcategory performanceMeasureSubcategory)
            : this()
        {
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            PerformanceMeasureID = performanceMeasureSubcategory.PerformanceMeasureID;
            PerformanceMeasureSubcategoryName = performanceMeasureSubcategory.PerformanceMeasureSubcategoryName;
            PerformanceMeasureSubcategoryDisplayName = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
            ShowOnChart = performanceMeasureSubcategory.ShowOnChart;
            SortOrder = performanceMeasureSubcategory.SortOrder;

        }


        public int PerformanceMeasureSubcategoryID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureSubcategoryName { get; set; }
        public string PerformanceMeasureSubcategoryDisplayName { get; set; }
        public bool ShowOnChart { get; set; }
        public int? SortOrder { get; set; }
    }
}