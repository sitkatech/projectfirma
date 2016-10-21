using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ReportedValueForDisplay
    {
        public int? IndicatorSubcategoryOptionID { get; set; }
        public double? ReportedValue { get; set; }
        public int SortOrder { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReportedValueForDisplay()
        {
        }

        public ReportedValueForDisplay(IIndicatorReported sustainabilityIndicatorReported)
        {
            var irviso = sustainabilityIndicatorReported.IndicatorReportedSubcategoryOptions.SingleOrDefault();
            IndicatorSubcategoryOptionID = irviso != null ? irviso.IndicatorSubcategoryOptionID : (int?) null;
            ReportedValue = sustainabilityIndicatorReported.ReportedValue;
            SortOrder = sustainabilityIndicatorReported.SortOrder;
        }
    }
}