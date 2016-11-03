using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class AssessmentTree : TypedWebPartialViewPage<AssessmentTreeViewData>
    {
        public static void RenderPartialView(HtmlHelper html, AssessmentTreeViewData viewData)
        {
            html.RenderRazorSitkaPartial<AssessmentTree, AssessmentTreeViewData>(viewData);
        }
    }
}