using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ExpenditureAndBudgetControls
{
    public abstract class TransportationExpendituresBarChart : LtInfo.Common.Mvc.TypedWebPartialViewPage<TransportationExpendituresBarChartViewData>
    {
        public static void RenderPartialView(HtmlHelper html, TransportationExpendituresBarChartViewData viewData)
        {
            html.RenderRazorSitkaPartial<TransportationExpendituresBarChart, TransportationExpendituresBarChartViewData>(viewData);
        }
    }
}