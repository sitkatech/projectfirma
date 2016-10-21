using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls
{
    public abstract class EIPPerformanceMeasureReportedValuesSummary : TypedWebPartialViewPage<EIPPerformanceMeasureReportedValuesSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, EIPPerformanceMeasureReportedValuesSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<EIPPerformanceMeasureReportedValuesSummary, EIPPerformanceMeasureReportedValuesSummaryViewData>(viewData);
        }
    }
}