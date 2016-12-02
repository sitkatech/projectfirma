using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ReportedValueForDisplay
    {
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public double? ReportedValue { get; set; }
        public int SortOrder { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReportedValueForDisplay()
        {
        }

        public ReportedValueForDisplay(IPerformanceMeasureReported sustainabilityPerformanceMeasureReported)
        {
            var irviso = sustainabilityPerformanceMeasureReported.PerformanceMeasureReportedSubcategoryOptions.SingleOrDefault();
            PerformanceMeasureSubcategoryOptionID = irviso != null ? irviso.PerformanceMeasureSubcategoryOptionID : (int?) null;
            ReportedValue = sustainabilityPerformanceMeasureReported.ReportedValue;
            SortOrder = sustainabilityPerformanceMeasureReported.SortOrder;
        }
    }
}