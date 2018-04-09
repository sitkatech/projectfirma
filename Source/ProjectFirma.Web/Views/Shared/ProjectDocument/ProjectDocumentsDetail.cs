using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectDocument
{
    public abstract class ProjectDocumentsDetail : TypedWebPartialViewPage<ProjectDocumentsDetailViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectDocumentsDetailViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectDocumentsDetail, ProjectDocumentsDetailViewData>(viewData);
        }
    }
}
