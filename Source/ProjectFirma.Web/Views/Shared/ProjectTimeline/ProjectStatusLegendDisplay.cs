using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectTimeline
{
    public abstract class ProjectStatusLegendDisplay : TypedWebPartialViewPage<ProjectStatusLegendDisplayViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectStatusLegendDisplayViewData displayViewData)
        {
            html.RenderRazorSitkaPartial<ProjectStatusLegendDisplay, ProjectStatusLegendDisplayViewData>(displayViewData);
        }
    }
}