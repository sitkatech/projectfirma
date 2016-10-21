using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory
{
    public class ThresholdTaxonomyViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<FancyTreeNode> ThresholdCategoriesAsFancyTreeNodes;
        public readonly List<ThresholdEvaluationPeriod> ThresholdEvaluationPeriods;
        public readonly bool UseThemeColor;

        public ThresholdTaxonomyViewData(List<FancyTreeNode> thresholdCategoriesAsFancyTreeNodes, List<ThresholdEvaluationPeriod> thresholdEvaluationPeriods, bool useThemeColor)
        {
            UseThemeColor = useThemeColor;
            ThresholdCategoriesAsFancyTreeNodes = thresholdCategoriesAsFancyTreeNodes;
            ThresholdEvaluationPeriods = thresholdEvaluationPeriods;
        }        
    }
}