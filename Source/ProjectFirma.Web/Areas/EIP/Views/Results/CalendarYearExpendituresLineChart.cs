using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public abstract class CalendarYearExpendituresLineChart : LtInfo.Common.Mvc.TypedWebPartialViewPage<CalendarYearExpendituresLineChartViewData>
    {
        public static void RenderPartialView(HtmlHelper html, CalendarYearExpendituresLineChartViewData viewData)
        {
            html.RenderRazorSitkaPartial<CalendarYearExpendituresLineChart, CalendarYearExpendituresLineChartViewData>(viewData);
        }
    }
}