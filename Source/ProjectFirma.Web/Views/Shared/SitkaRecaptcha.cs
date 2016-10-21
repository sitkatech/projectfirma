using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared
{
    public abstract class SitkaRecaptcha : TypedWebPartialViewPage<SitkaRecaptchaViewData>
    {
        public static void RenderPartialView(HtmlHelper html)
        {
            html.RenderRazorSitkaPartial<SitkaRecaptcha, SitkaRecaptchaViewData>(new SitkaRecaptchaViewData());
        }
    }
}