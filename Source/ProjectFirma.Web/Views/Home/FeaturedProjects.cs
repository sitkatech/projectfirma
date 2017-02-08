using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Home
{
    public abstract class FeaturedProjects : TypedWebPartialViewPage<FeaturedProjectsViewData>
    {
        public static void RenderPartialView(HtmlHelper html, FeaturedProjectsViewData viewData)
        {
            html.RenderRazorSitkaPartial<FeaturedProjects, FeaturedProjectsViewData>(viewData);
        }
    }
}