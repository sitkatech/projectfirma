using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Views.Shared
{
    public abstract class ImageGallery : LtInfo.Common.Mvc.TypedWebPartialViewPage<ImageGalleryViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ImageGalleryViewData viewData)
        {
            html.RenderRazorSitkaPartial<ImageGallery, ImageGalleryViewData>(viewData);
        }
    }
}