using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public abstract class ProjectLocationsMap : TypedWebPartialViewPage<ProjectLocationsMapViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectLocationsMapViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectLocationsMap, ProjectLocationsMapViewData>(viewData);
        }
    }
}