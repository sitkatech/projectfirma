using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public abstract class PerformanceMeasureReportedValuesGrouped : TypedWebPartialViewPage<PerformanceMeasureReportedValuesGroupedViewData>
    {
        public static void RenderPartialView(HtmlHelper html, PerformanceMeasureReportedValuesGroupedViewData viewData)
        {
            html.RenderRazorSitkaPartial<PerformanceMeasureReportedValuesGrouped, PerformanceMeasureReportedValuesGroupedViewData>(viewData);
        }
    }
}