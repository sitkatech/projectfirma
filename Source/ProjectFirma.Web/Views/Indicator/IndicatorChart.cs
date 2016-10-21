using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Views.Indicator
{
    public abstract class IndicatorChart : LtInfo.Common.Mvc.TypedWebPartialViewPage<IndicatorChartViewData>
    {
        public static void RenderPartialView(HtmlHelper html, IndicatorChartViewData viewData)
        {
            html.RenderRazorSitkaPartial<IndicatorChart, IndicatorChartViewData>(viewData);
        }
    }
}