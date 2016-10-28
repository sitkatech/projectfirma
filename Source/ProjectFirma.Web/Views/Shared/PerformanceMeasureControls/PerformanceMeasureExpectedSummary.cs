using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public abstract class PerformanceMeasureExpectedSummary : TypedWebPartialViewPage<PerformanceMeasureExpectedSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, PerformanceMeasureExpectedSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<PerformanceMeasureExpectedSummary, PerformanceMeasureExpectedSummaryViewData>(viewData);
        }
    }
}