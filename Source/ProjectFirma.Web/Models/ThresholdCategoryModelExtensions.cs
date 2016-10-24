using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ThresholdCategoryModelExtensions
    {
        public static string GetEditUrl(this ThresholdCategory thresholdCategory)
        {
            return SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(t => t.Edit(thresholdCategory));
        }

        public static string GetSummaryUrl(this ThresholdCategory thresholdCategory)
        {
            return SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(t => t.Summary(thresholdCategory.ThresholdCategoryName));
        }

        public static HtmlString GetDisplayNameAsUrl(this ThresholdCategory thresholdCategory)
        {
            return UrlTemplate.MakeHrefString(GetSummaryUrl(thresholdCategory), thresholdCategory.DisplayName);
        }
    }
}