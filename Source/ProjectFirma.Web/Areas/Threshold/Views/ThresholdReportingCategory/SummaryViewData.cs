using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdReportingCategory
{
    public class SummaryViewData : ThresholdViewData
    {
        public readonly Models.ThresholdReportingCategory ThresholdReportingCategory;
        public readonly IndicatorRelationshipsViewData IndicatorRelationshipsViewData;
        public readonly string EditNarrativeUrl;
        public readonly string IndexUrl;
        public readonly bool UserHasThresholdReportingCategoryManagePermissions;
        public readonly ThresholdTaxonomyViewData ThresholdTaxonomyViewData;
        public readonly string FullThresholdCategoryTaxonomyUrl;
        public readonly string EditIndicatorRelationshipsUrl;

        public SummaryViewData(Person currentPerson, Models.ThresholdReportingCategory thresholdReportingCategory, ThresholdTaxonomyViewData thresholdTaxonomyViewData, IndicatorRelationshipsViewData indicatorRelationshipsViewData)
            : base(currentPerson)
        {
            EntityName = "Reporting Category";
            ThresholdReportingCategory = thresholdReportingCategory;
            IndicatorRelationshipsViewData = indicatorRelationshipsViewData;
            ThresholdTaxonomyViewData = thresholdTaxonomyViewData;
            PageTitle = thresholdReportingCategory.DisplayName;
            EditNarrativeUrl = SitkaRoute<ThresholdReportingCategoryController>.BuildUrlFromExpression(c => c.Edit(thresholdReportingCategory));
            IndexUrl = SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(c => c.Index());
            UserHasThresholdReportingCategoryManagePermissions = new ThresholdIndicatorManageFeature().HasPermissionByPerson(currentPerson);
            FullThresholdCategoryTaxonomyUrl = SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(x => x.Index());
            EditIndicatorRelationshipsUrl = SitkaRoute<IndicatorRelationshipController>.BuildUrlFromExpression(x => x.EditFromThresholdReportingCategory(thresholdReportingCategory));
        }
    }
}