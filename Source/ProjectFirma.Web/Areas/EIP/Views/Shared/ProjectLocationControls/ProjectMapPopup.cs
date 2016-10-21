using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public abstract class ProjectMapPopup : TypedWebPartialViewPage<ProjectMapPopupViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectMapPopupViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectMapPopup, ProjectMapPopupViewData>(viewData);
        }
    }
}