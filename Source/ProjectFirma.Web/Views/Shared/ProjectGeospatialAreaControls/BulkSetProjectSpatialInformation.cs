using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public abstract class BulkSetProjectSpatialInformation : TypedWebPartialViewPage<BulkSetProjectSpatialInformationViewData, BulkSetProjectSpatialInformationViewModel>
    {
        public static void RenderPartialView(HtmlHelper html, BulkSetProjectSpatialInformationViewData viewData, BulkSetProjectSpatialInformationViewModel viewModel)
        {
            html.RenderRazorSitkaPartial<BulkSetProjectSpatialInformation, BulkSetProjectSpatialInformationViewData, BulkSetProjectSpatialInformationViewModel>(viewData, viewModel);
        }
    }
}
