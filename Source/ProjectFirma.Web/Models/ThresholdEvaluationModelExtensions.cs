using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public static class ThresholdEvaluationModelExtensions
    {
        public enum IconSize
        {
            Small,
            Medium,
            Large
        }

        public static readonly UrlTemplate<string> InfoSheetUrlTemplate =
            new UrlTemplate<string>(SitkaRoute<ThresholdIndicatorController>.BuildUrlFromExpression(t => t.InfoSheet(UrlTemplate.Parameter1String)));
        public static string GetInfoSheetUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return InfoSheetUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdIndicator.Indicator.IndicatorName);
        }

        public static readonly UrlTemplate<int> EditThresholdEvaluationStatusUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.EditStatus(UrlTemplate.Parameter1Int)));
        public static string GetEditThresholdEvaluationStatusUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return EditThresholdEvaluationStatusUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> EditThresholdEvaluationStatusDetailsUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.EditStatusDetails(UrlTemplate.Parameter1Int)));
        public static string GetEditThresholdEvaluationStatusDetailsUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return EditThresholdEvaluationStatusDetailsUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> EditThresholdEvaluationManagementStatusUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.EditManagementStatus(UrlTemplate.Parameter1Int)));
        public static string GetEditThresholdEvaluationManagementStatusUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return EditThresholdEvaluationManagementStatusUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> EditImplementationAndEffectivenessUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.EditImplementationAndEffectiveness(UrlTemplate.Parameter1Int)));
        public static string GetEditImplementationAndEffectivenessUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return EditImplementationAndEffectivenessUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> EditThresholdEvaluationRecommendationsUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.EditRecommendations(UrlTemplate.Parameter1Int)));
        public static string GetEditThresholdEvaluationRecommendationsUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return EditThresholdEvaluationRecommendationsUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> EditThresholdEvaluationMapAndCaptionUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.EditMapAndCaption(UrlTemplate.Parameter1Int)));
        public static string GetEditThresholdEvaluationMapAndCaptionUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return EditThresholdEvaluationMapAndCaptionUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> DeleteMapImageUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.DeleteMapImage(UrlTemplate.Parameter1Int)));
        public static string GetDeleteMapImageUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return DeleteMapImageUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> NewHistoricEvaluationPdfFileResourceUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.NewHistoricEvaluationPdfFileResource(UrlTemplate.Parameter1Int)));
        public static string GetNewHistoricEvaluationPdfFileResourceUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return NewHistoricEvaluationPdfFileResourceUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        public static readonly UrlTemplate<int> DeleteHistoricEvaluationPdfFileResourceUrlTemplate = new UrlTemplate<int>(SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(t => t.DeleteHistoricEvaluationPdfFileResource(UrlTemplate.Parameter1Int)));
        public static string GetDeleteHistoricEvaluationPdfFileResourceUrl(this ThresholdEvaluation thresholdEvaluation)
        {
            return DeleteHistoricEvaluationPdfFileResourceUrlTemplate.ParameterReplace(thresholdEvaluation.ThresholdEvaluationID);
        }

        /// <summary>
        /// e.g. <div class="statusTrendConfidence status-considerablyWorse confidence-low"><span class="glyphicon trend-moderateImprovement"></span></div>
        /// </summary>
        private static HtmlString GenerateStatusTrendConfidenceIcon(this ThresholdEvaluation thresholdEvaluation, IconSize iconSize)
        {
            if (thresholdEvaluation.ThresholdEvaluationStatusType == null && thresholdEvaluation.ThresholdEvaluationTrendType == null &&
                thresholdEvaluation.ThresholdEvaluationConfidenceType == null)
            {
                return new HtmlString(iconSize == IconSize.Small ? "<span class='smallNotSetText'>Not Set</span>" : "Incomplete rating");
            }
            var hoverText = new List<string>();
            var divTag = new TagBuilder("div");
            divTag.AddCssClass("statusTrendConfidence");
            divTag.AddCssClass(iconSize.ToString());
            if (thresholdEvaluation.ThresholdEvaluationStatusType != null)
            {
                divTag.AddCssClass(string.Format("status-{0}", thresholdEvaluation.ThresholdEvaluationStatusType.ThresholdEvaluationStatusTypeName));
                hoverText.Add(string.Format("Status: {0}", thresholdEvaluation.ThresholdEvaluationStatusType.ThresholdEvaluationStatusTypeDisplayName));
            }
            var anchorTag = new TagBuilder("a");
            anchorTag.AddCssClass("trend");
            var italicsTag = new TagBuilder("i");
            italicsTag.AddCssClass("glyphicon");
            if (thresholdEvaluation.ThresholdEvaluationTrendType != null)
            {
                italicsTag.AddCssClass(thresholdEvaluation.ThresholdEvaluationTrendType.ThresholdEvaluationTrendTypeName);
                hoverText.Add(string.Format("Trend: {0}", thresholdEvaluation.ThresholdEvaluationTrendType.ThresholdEvaluationTrendTypeDisplayName));
            }

            AssignHref(thresholdEvaluation, anchorTag);

            anchorTag.InnerHtml = italicsTag.ToString(TagRenderMode.Normal);
            divTag.AddCssClass("confidence-Moderate");
            if (thresholdEvaluation.ThresholdEvaluationConfidenceType != null)
            {
                hoverText.Add(string.Format("Confidence: {0}", thresholdEvaluation.ThresholdEvaluationConfidenceType.ThresholdEvaluationConfidenceTypeDisplayName));
            }
            anchorTag.Attributes.Add("title", string.Join("\r\n", hoverText));

            divTag.InnerHtml = anchorTag.ToString(TagRenderMode.Normal);
            return new HtmlString(divTag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// e.g. <div class="statusTrendConfidence status-considerablyWorse confidence-low"><span class="glyphicon trend-moderateImprovement"></span></div>
        /// </summary>
        private static HtmlString GenerateManagementStatusIcon(this ThresholdEvaluation thresholdEvaluation, IconSize iconSize)
        {
            if (thresholdEvaluation.ThresholdEvaluationManagementStatusType == null)
            {
                return new HtmlString(iconSize == IconSize.Small ? "<span class='smallNotSetText'>Not Set</span>" : "Incomplete rating");
            }
            var anchorTag = new TagBuilder("a");
            anchorTag.AddCssClass("managementStatus");
            anchorTag.AddCssClass(iconSize.ToString());
            anchorTag.AddCssClass(thresholdEvaluation.ThresholdEvaluationManagementStatusType.ThresholdEvaluationManagementStatusTypeName);

            AssignHref(thresholdEvaluation, anchorTag);

            anchorTag.InnerHtml = thresholdEvaluation.ThresholdEvaluationManagementStatusType.ThresholdEvaluationManagementStatusTypeAbbreviation;
            anchorTag.Attributes.Add("title", string.Format("Status: {0}", thresholdEvaluation.ThresholdEvaluationManagementStatusType.ThresholdEvaluationManagementStatusTypeDisplayName));
            return new HtmlString(anchorTag.ToString(TagRenderMode.Normal));
        }

        public static HtmlString GenerateStatusIcon(this ThresholdEvaluation thresholdEvaluation, IconSize iconSize)
        {
            if (thresholdEvaluation == null)
            {
                return new HtmlString(string.Empty);
            }
            if (thresholdEvaluation.ThresholdIndicator.IsManagementOrPolicyStatement)
            {
                return thresholdEvaluation.GenerateManagementStatusIcon(iconSize);
            }
            return thresholdEvaluation.GenerateStatusTrendConfidenceIcon(iconSize);
        }

        private static void AssignHref(ThresholdEvaluation thresholdEvaluation, TagBuilder anchorTag)
        {
            if (thresholdEvaluation.ThresholdEvaluationPeriod.ThresholdEvaluationYear == ThresholdEvaluation.HistoricThresholdEvaluationYear)
            {
                if (thresholdEvaluation.HistoricEvaluationPdfFileResource != null)
                {
                    anchorTag.Attributes.Add("href", thresholdEvaluation.HistoricEvaluationPdfFileResource.FileResourceUrl);
                }
                else
                {
                    anchorTag.Attributes.Add("onclick", string.Format("createBootstrapAlert('{0}', '{1}', '{2}')", "Historic evaluation report unavailable or not yet uploaded.", "&nbsp", "OK"));
                }
            }
            else
            {
                anchorTag.Attributes.Add("href", thresholdEvaluation.GetInfoSheetUrl());
            }
        }

    }
}