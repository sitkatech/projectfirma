using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public abstract class ProjectBudgetSummary : TypedWebPartialViewPage<ProjectBudgetSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectBudgetSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectBudgetSummary, ProjectBudgetSummaryViewData>(viewData);
        }
    }
}