namespace ProjectFirma.Web.Models
{
    public class ReportingCategoryForDisplay
    {
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public double ReportedValue { get; set; }
        public string DisplayName { get; set; }
        public int SortOrder { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReportingCategoryForDisplay()
        {
        }

        public ReportingCategoryForDisplay(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureSubcategoryOptionID = null;
            DisplayName = performanceMeasure.PerformanceMeasureDisplayName;
            SortOrder = 1;
        }

        public ReportingCategoryForDisplay(PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption)
        {
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            DisplayName = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
            SortOrder = performanceMeasureSubcategoryOption.SortOrder ?? 0;
        }
    }
}