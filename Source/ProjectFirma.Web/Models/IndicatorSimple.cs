namespace ProjectFirma.Web.Models
{
    public class IndicatorSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorSimple()
        {
        }

        public IndicatorSimple(Indicator indicator)
            : this()
        {
            IndicatorID = indicator.IndicatorID;
            DisplayName = indicator.IndicatorDisplayName;
            ThresholdReportingCategoryID = indicator.ThresholdIndicator != null ? indicator.ThresholdIndicator.ThresholdReportingCategoryID : (int?) null;
        }

        public int IndicatorID { get; set; }
        public string DisplayName { get; set; }
        public int? ThresholdReportingCategoryID { get; set; }
    }
}