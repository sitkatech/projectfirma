using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public abstract class PerformanceMeasureChart : LtInfo.Common.Mvc.TypedWebPartialViewPage<PerformanceMeasureChartViewData>
    {
        public static void RenderPartialView(HtmlHelper html, PerformanceMeasureChartViewData viewData)
        {
            html.RenderRazorSitkaPartial<PerformanceMeasureChart, PerformanceMeasureChartViewData>(viewData);
        }
    }
}