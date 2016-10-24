using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public abstract class ProjectExpendituresSummary : TypedWebPartialViewPage<ProjectExpendituresSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectExpendituresSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectExpendituresSummary, ProjectExpendituresSummaryViewData>(viewData);
        }
    }
}