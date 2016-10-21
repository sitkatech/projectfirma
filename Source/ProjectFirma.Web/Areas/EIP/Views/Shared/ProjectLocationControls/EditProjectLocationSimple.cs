using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public abstract class EditProjectLocationSimple : TypedWebPartialViewPage<EditProjectLocationSimpleViewData, EditProjectLocationSimpleViewModel>
    {
        public static void RenderPartialView(HtmlHelper html, EditProjectLocationSimpleViewData viewData, EditProjectLocationSimpleViewModel viewModel)
        {
            html.RenderRazorSitkaPartial<EditProjectLocationSimple, EditProjectLocationSimpleViewData, EditProjectLocationSimpleViewModel>(viewData, viewModel);
        }
    }
}