namespace ProjectFirma.Web.Models
{
    public class ReportingCategoryForDisplay
    {
        public int? IndicatorSubcategoryOptionID { get; set; }
        public double ReportedValue { get; set; }
        public string DisplayName { get; set; }
        public int SortOrder { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReportingCategoryForDisplay()
        {
        }

        public ReportingCategoryForDisplay(Indicator indicator)
        {
            IndicatorSubcategoryOptionID = null;
            DisplayName = indicator.IndicatorDisplayName;
            SortOrder = 1;
        }

        public ReportingCategoryForDisplay(IndicatorSubcategoryOption indicatorSubcategoryOption)
        {
            IndicatorSubcategoryOptionID = indicatorSubcategoryOption.IndicatorSubcategoryOptionID;
            DisplayName = indicatorSubcategoryOption.IndicatorSubcategoryOptionName;
            SortOrder = indicatorSubcategoryOption.SortOrder ?? 0;
        }
    }
}