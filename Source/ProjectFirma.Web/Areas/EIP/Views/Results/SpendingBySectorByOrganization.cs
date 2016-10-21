using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public abstract class SpendingBySectorByOrganization : LtInfo.Common.Mvc.TypedWebPartialViewPage<SpendingBySectorByOrganizationViewData>
    {
        public static void RenderPartialView(HtmlHelper html, SpendingBySectorByOrganizationViewData viewData)
        {
            html.RenderRazorSitkaPartial<SpendingBySectorByOrganization, SpendingBySectorByOrganizationViewData>(viewData);
        }
    }
}