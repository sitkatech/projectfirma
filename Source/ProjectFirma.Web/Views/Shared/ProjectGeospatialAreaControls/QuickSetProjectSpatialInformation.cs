using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public abstract class QuickSetProjectSpatialInformation : TypedWebPartialViewPage<QuickSetProjectSpatialInformationViewData, QuickSetProjectSpatialInformationViewModel>
    {
        public static void RenderPartialView(HtmlHelper html, QuickSetProjectSpatialInformationViewData viewData, QuickSetProjectSpatialInformationViewModel viewModel)
        {
            html.RenderRazorSitkaPartial<QuickSetProjectSpatialInformation, QuickSetProjectSpatialInformationViewData, QuickSetProjectSpatialInformationViewModel>(viewData, viewModel);
        }
    }
}
