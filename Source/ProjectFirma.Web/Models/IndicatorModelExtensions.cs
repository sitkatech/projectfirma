using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class IndicatorModelExtensions
    {
        public static readonly UrlTemplate<string> SummaryUrlTemplate = new UrlTemplate<string>(SitkaRoute<IndicatorController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1String, SummaryViewData.IndicatorSummaryTab.Overview)));
        public static string GetSummaryUrl(this Indicator indicator)
        {
            return SummaryUrlTemplate.ParameterReplace(indicator.IndicatorName);
        }

        public static HtmlString GetDisplayNameAsInfoSheetUrl(this Indicator indicator)
        {
            string infoSheetUrl = string.Empty;
            if (indicator.EIPPerformanceMeasure != null)
            {
                infoSheetUrl = indicator.GetEIPInfoSheetUrl();
            }
            else if (indicator.ThresholdIndicator != null)
            {
                infoSheetUrl = indicator.GetThresholdInfoSheetUrl();
            }
            else if (indicator.SustainabilityIndicator != null)
            {
                infoSheetUrl = indicator.GetSustainabilitySummaryUrl();
            }
            return UrlTemplate.MakeHrefString(infoSheetUrl, indicator.IndicatorDisplayName);    
        }

        public static string GetEIPInfoSheetUrl(this Indicator indicator)
        {
            return indicator.EIPPerformanceMeasure != null ? indicator.EIPPerformanceMeasure.GetInfoSheetUrl() : string.Empty;
        }

        public static string GetSustainabilitySummaryUrl(this Indicator indicator)
        {
            return indicator.SustainabilityIndicator != null ? indicator.SustainabilityIndicator.GetSummaryUrl() : string.Empty;
        }

        public static string GetThresholdInfoSheetUrl(this Indicator indicator)
        {
            return indicator.ThresholdIndicator != null ? indicator.ThresholdIndicator.GetInfoSheetUrl() : string.Empty;
        }

        private static readonly UrlTemplate<int> DefinitionAndGuidanceUrlTemplate = new UrlTemplate<int>(SitkaRoute<IndicatorController>.BuildUrlFromExpression(t => t.DefinitionAndGuidance(UrlTemplate.Parameter1Int)));
        public static string GetDefinitionAndGuidanceUrl(this Indicator indicator)
        {
            return DefinitionAndGuidanceUrlTemplate.ParameterReplace(indicator.IndicatorID);
        }

        public static string GetEditReportedValuesUrl(this Indicator indicator)
        {
            if (indicator.SustainabilityIndicator != null)
            {
                return indicator.SustainabilityIndicator.GetEditReportedValuesUrl();
            }
            if (indicator.ThresholdIndicator != null)
            {
                return indicator.ThresholdIndicator.GetEditReportedValuesUrl();
            }
            if (indicator.EIPPerformanceMeasure != null)
            {
                return null;
            }
            throw new NotImplementedException("Indicator {0} is not reported in the EIP Project Tracker, Sustainability Dashboard, or the Threshold Dashboard!  No way to edit reported values!");
        }

        public static bool IsIndicatorNameUnique(IEnumerable<Indicator> indicators, string indicatorName, int currentIndicatorID)
        {
            var indicator =
                indicators.SingleOrDefault(
                    x => x.IndicatorID != currentIndicatorID && string.Equals(x.IndicatorDisplayName, indicatorName, StringComparison.InvariantCultureIgnoreCase));
            return indicator == null;
        }
    }
}