using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public abstract class ProjectBudgetDetail : TypedWebPartialViewPage<ProjectBudgetDetailViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectBudgetDetailViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectBudgetDetail, ProjectBudgetDetailViewData>(viewData);
        }
    }
}