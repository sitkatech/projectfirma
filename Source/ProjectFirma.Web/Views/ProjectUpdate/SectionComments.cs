using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public abstract class SectionComments : LtInfo.Common.Mvc.TypedWebPartialViewPage<SectionCommentsViewData>
    {
        public static void RenderPartialView(HtmlHelper html, SectionCommentsViewData viewData)
        {
            html.RenderRazorSitkaPartial<SectionComments, SectionCommentsViewData>(viewData);
        }
    }
}