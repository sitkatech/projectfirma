using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls
{
    public abstract class EIPPerformanceMeasureReportedValuesGrouped : TypedWebPartialViewPage<EIPPerformanceMeasureReportedValuesGroupedViewData>
    {
        public static void RenderPartialView(HtmlHelper html, EIPPerformanceMeasureReportedValuesGroupedViewData viewData)
        {
            html.RenderRazorSitkaPartial<EIPPerformanceMeasureReportedValuesGrouped, EIPPerformanceMeasureReportedValuesGroupedViewData>(viewData);
        }
    }
}