using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public abstract class TransportationProjectBudgetSummary : TypedWebPartialViewPage<TransportationProjectBudgetSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, TransportationProjectBudgetSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<TransportationProjectBudgetSummary, TransportationProjectBudgetSummaryViewData>(viewData);
        }
    }
}