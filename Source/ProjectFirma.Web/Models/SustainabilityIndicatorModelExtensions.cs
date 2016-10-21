using ProjectFirma.Web.Areas.Sustainability.Controllers;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class SustainabilityIndicatorModelExtensions
    {
        public readonly static UrlTemplate<string> SummaryUrlTemplate = new UrlTemplate<string>(SitkaRoute<AspectController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1String)));
        public static string GetSummaryUrl(this SustainabilityIndicator sustainabilityIndicator)
        {
            return SummaryUrlTemplate.ParameterReplace(sustainabilityIndicator.SustainabilityAspect.SustainabilityAspectName);
        }

        public static string GetEditReportedValuesUrl(this SustainabilityIndicator sustainabilityIndicator)
        {
            return SitkaRoute<AspectController>.BuildUrlFromExpression(x => x.EditSustainabilityIndicatorReporteds(sustainabilityIndicator.Indicator.IndicatorName));
        }

        public static string GetChartPopupUrl(this SustainabilityIndicator sustainabilityIndicator)
        {
            return SitkaRoute<IndicatorController>.BuildUrlFromExpression(x => x.IndicatorChartPopup(sustainabilityIndicator.IndicatorID));
        }
    }
}