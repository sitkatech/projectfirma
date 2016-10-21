using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory
{
    public abstract class ThresholdTaxonomy : TypedWebPartialViewPage<ThresholdTaxonomyViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ThresholdTaxonomyViewData viewData)
        {
            html.RenderRazorSitkaPartial<ThresholdTaxonomy, ThresholdTaxonomyViewData>(viewData);
        }
    }
}