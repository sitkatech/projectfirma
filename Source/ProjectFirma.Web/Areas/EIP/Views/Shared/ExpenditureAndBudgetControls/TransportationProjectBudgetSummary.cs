using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ExpenditureAndBudgetControls
{
    public abstract class TransportationProjectBudgetSummary : TypedWebPartialViewPage<TransportationProjectBudgetSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, TransportationProjectBudgetSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<TransportationProjectBudgetSummary, TransportationProjectBudgetSummaryViewData>(viewData);
        }
    }
}