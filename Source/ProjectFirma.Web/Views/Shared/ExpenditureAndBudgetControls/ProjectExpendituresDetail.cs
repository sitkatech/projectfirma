using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public abstract class ProjectExpendituresDetail : TypedWebPartialViewPage<ProjectExpendituresDetailViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectExpendituresDetailViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectExpendituresDetail, ProjectExpendituresDetailViewData>(viewData);
        }
    }
}