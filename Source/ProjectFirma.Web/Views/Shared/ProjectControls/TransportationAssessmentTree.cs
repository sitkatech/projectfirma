using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public abstract class TransportationAssessmentTree : TypedWebPartialViewPage<TransportationAssessmentTreeViewData>
    {
        public static void RenderPartialView(HtmlHelper html, TransportationAssessmentTreeViewData viewData)
        {
            html.RenderRazorSitkaPartial<TransportationAssessmentTree, TransportationAssessmentTreeViewData>(viewData);
        }
    }
}