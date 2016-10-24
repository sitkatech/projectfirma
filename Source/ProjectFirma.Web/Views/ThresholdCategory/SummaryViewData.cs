using LtInfo.Common;
using ProjectFirma.Web.Areas.EIP.Views;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ThresholdCategory
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.ThresholdCategory ThresholdCategory;
        public readonly string EditThresholdCategoryUrl;
        public readonly string IndexUrl;
        public readonly bool UserHasThresholdCategoryManagePermissions;

        public SummaryViewData(Person currentPerson, Models.ThresholdCategory thresholdCategory)
            : base(currentPerson)
        {
            PageTitle = thresholdCategory.DisplayName;
            ThresholdCategory = thresholdCategory;
            EditThresholdCategoryUrl = SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(c => c.Edit(thresholdCategory));
            IndexUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            UserHasThresholdCategoryManagePermissions = new IndicatorManageFeature().HasPermissionByPerson(currentPerson);
        }
    }
}