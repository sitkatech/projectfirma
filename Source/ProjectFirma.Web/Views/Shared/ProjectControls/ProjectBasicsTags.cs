using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class ProjectBasicsTags : TypedWebPartialViewPage<ProjectBasicsTagsViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectBasicsTagsViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectBasicsTags, ProjectBasicsTagsViewData>(viewData);
        }

    }
}