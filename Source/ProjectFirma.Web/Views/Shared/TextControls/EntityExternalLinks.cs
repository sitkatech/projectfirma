using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public abstract class EntityExternalLinks : TypedWebPartialViewPage<EntityExternalLinksViewData>
    {
        public static void RenderPartialView(HtmlHelper html, EntityExternalLinksViewData viewData)
        {
            html.RenderRazorSitkaPartial<EntityExternalLinks, EntityExternalLinksViewData>(viewData);
        }
    }
}