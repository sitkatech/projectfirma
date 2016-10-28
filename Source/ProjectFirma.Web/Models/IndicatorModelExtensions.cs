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
            if (indicator.PerformanceMeasure != null)
            {
                infoSheetUrl = indicator.GetInfoSheetUrl();
            }
            return UrlTemplate.MakeHrefString(infoSheetUrl, indicator.IndicatorDisplayName);    
        }

        public static string GetInfoSheetUrl(this Indicator indicator)
        {
            return indicator.PerformanceMeasure != null ? indicator.PerformanceMeasure.GetInfoSheetUrl() : string.Empty;
        }

        private static readonly UrlTemplate<int> DefinitionAndGuidanceUrlTemplate = new UrlTemplate<int>(SitkaRoute<IndicatorController>.BuildUrlFromExpression(t => t.DefinitionAndGuidance(UrlTemplate.Parameter1Int)));
        public static string GetDefinitionAndGuidanceUrl(this Indicator indicator)
        {
            return DefinitionAndGuidanceUrlTemplate.ParameterReplace(indicator.IndicatorID);
        }

        public static string GetEditReportedValuesUrl(this Indicator indicator)
        {
            if (indicator.PerformanceMeasure != null)
            {
                return null;
            }
            throw new NotImplementedException("Indicator {0} is not reported in the Project Tracker!  No way to edit reported values!");
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