using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ClassificationModelExtensions
    {
        public static string GetEditUrl(this Classification classification)
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(t => t.Edit(classification));
        }

        public static string GetSummaryUrl(this Classification classification)
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(t => t.Detail(classification));
        }

        public static HtmlString GetDisplayNameAsUrl(this Classification classification)
        {
            return UrlTemplate.MakeHrefString(GetSummaryUrl(classification), classification.DisplayName);
        }
    }
}