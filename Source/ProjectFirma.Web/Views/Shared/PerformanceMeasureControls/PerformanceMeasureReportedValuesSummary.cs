using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public abstract class PerformanceMeasureReportedValuesSummary : TypedWebPartialViewPage<PerformanceMeasureReportedValuesSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, PerformanceMeasureReportedValuesSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<PerformanceMeasureReportedValuesSummary, PerformanceMeasureReportedValuesSummaryViewData>(viewData);
        }
    }
}