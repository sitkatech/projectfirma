using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory
{
    public class SummaryViewData : ThresholdViewData
    {
        public readonly Models.ThresholdCategory ThresholdCategory;
        public readonly string EditThresholdCategoryUrl;
        public readonly string IndexUrl;
        public readonly bool UserHasThresholdCategoryManagePermissions;

        public readonly ThresholdTaxonomyViewData ThresholdTaxonomyViewData;
        public readonly string FullThresholdCategoryTaxonomyUrl;
        public readonly IndicatorRelationshipsViewData IndicatorRelationshipsViewData;

        public SummaryViewData(Person currentPerson, Models.ThresholdCategory thresholdCategory, ThresholdTaxonomyViewData thresholdTaxonomyViewData, IndicatorRelationshipsViewData indicatorRelationshipsViewData)
            : base(currentPerson)
        {
            PageTitle = thresholdCategory.DisplayName;
            ThresholdCategory = thresholdCategory;
            EditThresholdCategoryUrl = SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(c => c.Edit(thresholdCategory));
            IndexUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            UserHasThresholdCategoryManagePermissions = new ThresholdIndicatorManageFeature().HasPermissionByPerson(currentPerson);

            ThresholdTaxonomyViewData = thresholdTaxonomyViewData;
            IndicatorRelationshipsViewData = indicatorRelationshipsViewData;
            FullThresholdCategoryTaxonomyUrl = SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}