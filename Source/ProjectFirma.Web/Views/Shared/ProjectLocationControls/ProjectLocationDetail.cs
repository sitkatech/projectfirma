using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public abstract class ProjectLocationDetail : TypedWebPartialViewPage<ProjectLocationDetailViewData, ProjectLocationDetailViewModel>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectLocationDetailViewData viewData, ProjectLocationDetailViewModel viewModel)
        {
            html.RenderRazorSitkaPartial<ProjectLocationDetail, ProjectLocationDetailViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }
    }
}