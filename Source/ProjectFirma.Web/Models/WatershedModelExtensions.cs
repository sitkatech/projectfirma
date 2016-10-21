using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class WatershedModelExtensions
    {
        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<WatershedController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1Int)));

        public static string GetSummaryUrl(this Watershed watershed)
        {
            return SummaryUrlTemplate.ParameterReplace(watershed.WatershedID);
        }

        public static HtmlString GetDisplayNameAsUrl(this Watershed watershed)
        {
            return UrlTemplate.MakeHrefString(watershed.GetSummaryUrl(), watershed.DisplayName);
        }
    }
}