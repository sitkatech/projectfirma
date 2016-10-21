using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class ThresholdIndicatorModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this ThresholdIndicator thresholdIndicator)
        {
            return UrlTemplate.MakeHrefString(GetInfoSheetUrl(thresholdIndicator), thresholdIndicator.Indicator.IndicatorDisplayName);
        }

        public static readonly UrlTemplate<string> InfoSheetUrlTemplate = new UrlTemplate<string>(SitkaRoute<ThresholdIndicatorController>.BuildUrlFromExpression(t => t.InfoSheet(UrlTemplate.Parameter1String)));
        public static string GetInfoSheetUrl(this ThresholdIndicator thresholdIndicator)
        {
            return InfoSheetUrlTemplate.ParameterReplace(thresholdIndicator.Indicator.IndicatorName);
        }

        public static string GetChartPopupUrl(this ThresholdIndicator thresholdIndicator)
        {
            return SitkaRoute<IndicatorController>.BuildUrlFromExpression(x => x.IndicatorChartPopup(thresholdIndicator.IndicatorID));
        }

        public static string GetNewOptionalChartImageFileResourceUrl(this ThresholdIndicator thresholdIndicator)
        {
            return SitkaRoute<ThresholdIndicatorController>.BuildUrlFromExpression(x => x.NewOptionalChartImageFileResource(thresholdIndicator.ThresholdIndicatorID));
        }

        public static string GetDeleteOptionalChartImageFileResourceUrl(this ThresholdIndicator thresholdIndicator)
        {
            return SitkaRoute<ThresholdIndicatorController>.BuildUrlFromExpression(x => x.DeleteOptionalChartImageFileResource(thresholdIndicator.ThresholdIndicatorID));
        }

        public static string GetEditReportedValuesUrl(this ThresholdIndicator thresholdIndicator)
        {
            return SitkaRoute<ThresholdIndicatorController>.BuildUrlFromExpression(x => x.EditIndicatorReporteds(thresholdIndicator.Indicator.IndicatorName));
        }

        public static FancyTreeNode ToFancyTreeNode(this ThresholdIndicator thresholdIndicator, List<ThresholdEvaluationPeriod> thresholdEvaluationPeriods)
        {
            var statusTrendConfidenceIcons = thresholdEvaluationPeriods.ToDictionary(x => x.ThresholdEvaluationYear,
                x =>
                {
                    var thresholdEvaluation =
                        thresholdIndicator.ThresholdEvaluations.SingleOrDefault(y => y.ThresholdEvaluationPeriod.ThresholdEvaluationYear == x.ThresholdEvaluationYear);
                    return thresholdEvaluation.GenerateStatusIcon(ThresholdEvaluationModelExtensions.IconSize.Small).ToString();
                });
            var fancyTreeNode = new FancyTreeNode(thresholdIndicator.GetDisplayNameAsUrl(), thresholdIndicator.ThresholdIndicatorID.ToString(), false)
            {
                ThemeColor = thresholdIndicator.ThresholdReportingCategory.ThresholdCategory.ThemeColor,
                StatusTrendConfidenceIcons = statusTrendConfidenceIcons
            };
            return fancyTreeNode;
        }
    }
}