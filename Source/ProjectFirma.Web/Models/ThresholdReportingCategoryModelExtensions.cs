using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class ThresholdReportingCategoryModelExtensions
    {
        public static string GetSummaryUrl(this ThresholdReportingCategory thresholdReportingCategory)
        {
            return SitkaRoute<ThresholdReportingCategoryController>.BuildUrlFromExpression(t => t.Summary(thresholdReportingCategory.ThresholdReportingCategoryName));
        }

        public static HtmlString GetDisplayNameAsUrl(this ThresholdReportingCategory thresholdReportingCategory)
        {
            return UrlTemplate.MakeHrefString(GetSummaryUrl(thresholdReportingCategory), thresholdReportingCategory.DisplayName);
        }

        public static HtmlString GetFullDisplayNameAsUrl(this ThresholdReportingCategory thresholdReportingCategory)
        {
            return UrlTemplate.MakeHrefString(GetSummaryUrl(thresholdReportingCategory), thresholdReportingCategory.FullDisplayName);
        }

        public static FancyTreeNode ToFancyTreeNode(this ThresholdReportingCategory thresholdReportingCategory, List<ThresholdEvaluationPeriod> thresholdEvaluationPeriods)
        {
            var fancyTreeNode = new FancyTreeNode(thresholdReportingCategory.GetDisplayNameAsUrl(), thresholdReportingCategory.ThresholdReportingCategoryID.ToString(), true)
            {
                ThemeColor = thresholdReportingCategory.ThresholdCategory.ThemeColor,
                Children = thresholdReportingCategory.ThresholdIndicators.Select(x => x.ToFancyTreeNode(thresholdEvaluationPeriods)).ToList()
            };
            return fancyTreeNode;
        }
    }
}