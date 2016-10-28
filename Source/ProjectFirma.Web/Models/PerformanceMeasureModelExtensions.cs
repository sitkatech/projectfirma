using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this PerformanceMeasure performanceMeasure)
        {
            return UrlTemplate.MakeHrefString(performanceMeasure.GetSummaryUrl(), performanceMeasure.DisplayName);
        }

        public static readonly UrlTemplate<string> SummaryUrlTemplate = new UrlTemplate<string>(SitkaRoute<IndicatorController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1String, SummaryViewData.IndicatorSummaryTab.PerformanceMeasure)));
        public static string GetSummaryUrl(this PerformanceMeasure performanceMeasure)
        {
            return SummaryUrlTemplate.ParameterReplace(performanceMeasure.Indicator.IndicatorName);
        }

        public static readonly UrlTemplate<int> InfoSheetUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.InfoSheet(UrlTemplate.Parameter1Int)));
        public static string GetInfoSheetUrl(this PerformanceMeasure performanceMeasure)
        {
            return InfoSheetUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }
    }
}