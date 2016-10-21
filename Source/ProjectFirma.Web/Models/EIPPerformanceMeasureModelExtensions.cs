using System.Web;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class EIPPerformanceMeasureModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return UrlTemplate.MakeHrefString(eipPerformanceMeasure.GetSummaryUrl(), eipPerformanceMeasure.DisplayName);
        }

        public static readonly UrlTemplate<string> SummaryUrlTemplate = new UrlTemplate<string>(SitkaRoute<IndicatorController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1String, SummaryViewData.IndicatorSummaryTab.EIP)));
        public static string GetSummaryUrl(this EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return SummaryUrlTemplate.ParameterReplace(eipPerformanceMeasure.Indicator.IndicatorName);
        }

        public static readonly UrlTemplate<int> InfoSheetUrlTemplate = new UrlTemplate<int>(SitkaRoute<EIPPerformanceMeasureController>.BuildUrlFromExpression(t => t.InfoSheet(UrlTemplate.Parameter1Int)));
        public static string GetInfoSheetUrl(this EIPPerformanceMeasure eipPerformanceMeasure)
        {
            return InfoSheetUrlTemplate.ParameterReplace(eipPerformanceMeasure.EIPPerformanceMeasureID);
        }
    }
}