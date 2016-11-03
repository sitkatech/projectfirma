using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public abstract class ExpendituresBarChart : LtInfo.Common.Mvc.TypedWebPartialViewPage<ExpendituresBarChartViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ExpendituresBarChartViewData viewData)
        {
            html.RenderRazorSitkaPartial<ExpendituresBarChart, ExpendituresBarChartViewData>(viewData);
        }
    }
}