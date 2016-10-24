using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class ProjectBasicsCalculatedCosts : TypedWebPartialViewPage<ProjectBasicsCalculatedCostsViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectBasicsCalculatedCostsViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectBasicsCalculatedCosts, ProjectBasicsCalculatedCostsViewData>(viewData);
        }
    }
}