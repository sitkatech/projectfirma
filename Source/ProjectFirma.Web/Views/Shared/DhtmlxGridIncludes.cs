using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Views.Shared
{
    public abstract class DhtmlxGridIncludes : WebViewPage
    {
        public static void RenderPartialView(HtmlHelper html)
        {
            html.RenderRazorSitkaPartial<DhtmlxGridIncludes>();
        }
    }
}