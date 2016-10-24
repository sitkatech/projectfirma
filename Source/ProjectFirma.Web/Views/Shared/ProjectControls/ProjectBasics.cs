using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class ProjectBasics : TypedWebPartialViewPage<ProjectBasicsViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectBasicsViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectBasics, ProjectBasicsViewData>(viewData);
        }
    }
}