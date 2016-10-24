using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public abstract class ProjectLocationSummary : TypedWebPartialViewPage<ProjectLocationSummaryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectLocationSummaryViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectLocationSummary, ProjectLocationSummaryViewData>(viewData);
        }
    }
}