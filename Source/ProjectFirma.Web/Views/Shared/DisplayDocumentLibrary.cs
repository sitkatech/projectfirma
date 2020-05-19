
using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared
{
   
    public abstract class DisplayDocumentLibrary : TypedWebPartialViewPage<DisplayDocumentLibraryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, DisplayDocumentLibraryViewData viewData)
        {
            html.RenderRazorSitkaPartial<DisplayDocumentLibrary, DisplayDocumentLibraryViewData>(viewData);
        }
    }
}
