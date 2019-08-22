using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public abstract class ProjectAttachmentsDetail : TypedWebPartialViewPage<ProjectAttachmentsDetailViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectAttachmentsDetailViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectAttachmentsDetail, ProjectAttachmentsDetailViewData>(viewData);
        }
    }
}
