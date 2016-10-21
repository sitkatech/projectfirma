using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public abstract class EntityNotes : TypedWebPartialViewPage<EntityNotesViewData>
    {
        public static void RenderPartialView(HtmlHelper html, EntityNotesViewData viewData)
        {
            html.RenderRazorSitkaPartial<EntityNotes, EntityNotesViewData>(viewData);
        }
    }
}