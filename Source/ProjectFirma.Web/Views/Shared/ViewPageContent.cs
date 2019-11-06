
using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared
{
   
    public abstract class ViewPageContent : TypedWebPartialViewPage<ViewPageContentViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ViewPageContentViewData viewData)
        {
            html.RenderRazorSitkaPartial<ViewPageContent, ViewPageContentViewData>(viewData);
        }

        public static void RenderPartialView(HtmlHelper<object> html, GeospatialAreaType geospatialAreaType, FirmaSession firmaSession)
        {
            html.RenderRazorSitkaPartial<ViewPageContent, ViewPageContentViewData>(new ViewPageContentViewData(geospatialAreaType, firmaSession));
        }
    }
}
