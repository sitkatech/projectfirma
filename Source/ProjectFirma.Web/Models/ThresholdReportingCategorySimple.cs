namespace ProjectFirma.Web.Models
{
    public class ThresholdReportingCategorySimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ThresholdReportingCategorySimple()
        {
        }

        public ThresholdReportingCategorySimple(ThresholdReportingCategory thresholdReportingCategory)
            : this()
        {
            ThresholdReportingCategoryID = thresholdReportingCategory.ThresholdReportingCategoryID;
            ThresholdCategoryID = thresholdReportingCategory.ThresholdCategoryID;
            DisplayName = thresholdReportingCategory.FullDisplayName;
        }

        public int ThresholdReportingCategoryID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public string DisplayName { get; set; }
    }
}