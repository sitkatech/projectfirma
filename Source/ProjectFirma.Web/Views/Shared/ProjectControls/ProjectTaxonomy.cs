using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class ProjectTaxonomy : TypedWebPartialViewPage<ProjectTaxonomyViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectTaxonomyViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectTaxonomy, ProjectTaxonomyViewData>(viewData);
        }
    }
}