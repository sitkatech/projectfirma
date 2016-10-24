using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls
{
    public abstract class EIPPerformanceMeasureExpectedSummary : TypedWebPartialViewPage<EIPPerformanceMeasureExpectedSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, EIPPerformanceMeasureExpectedSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<EIPPerformanceMeasureExpectedSummary, EIPPerformanceMeasureExpectedSummaryViewData>(viewData);
        }
    }
}