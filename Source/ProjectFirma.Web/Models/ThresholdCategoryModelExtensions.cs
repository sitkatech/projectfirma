using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class ThresholdCategoryModelExtensions
    {
        public static string GetEditUrl(this ThresholdCategory thresholdCategory)
        {
            return SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(t => t.Edit(thresholdCategory));
        }

        public static string GetSummaryUrl(this ThresholdCategory thresholdCategory)
        {
            return SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(t => t.Summary(thresholdCategory.ThresholdCategoryName));
        }

        public static HtmlString GetDisplayNameAsUrl(this ThresholdCategory thresholdCategory)
        {
            return UrlTemplate.MakeHrefString(GetSummaryUrl(thresholdCategory), thresholdCategory.DisplayName);
        }

        public static FancyTreeNode ToFancyTreeNode(this ThresholdCategory thresholdCategory, List<ThresholdEvaluationPeriod> thresholdEvaluationPeriods)
        {
            var fancyTreeNode = new FancyTreeNode(thresholdCategory.GetDisplayNameAsUrl(), thresholdCategory.ThresholdCategoryID.ToString(), true)
            {
                ThemeColor = thresholdCategory.ThemeColor,
                Children = thresholdCategory.ThresholdReportingCategories.Select(x => x.ToFancyTreeNode(thresholdEvaluationPeriods)).ToList()
            };
            return fancyTreeNode;
        }
    }
}