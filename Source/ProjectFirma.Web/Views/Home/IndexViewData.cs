using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : FirmaViewData
    {
        public readonly bool ShowEditButton;
        public readonly string EditUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle =  string.Format("{0} Project Tracker", MultiTenantHelpers.GetTenantDisplayName());

            var permissionCheckResult = new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage);
            ShowEditButton = permissionCheckResult.HasPermission;
            EditUrl = SitkaRoute<Controllers.HomeController>.BuildUrlFromExpression(x => x.EditPageContent(FirmaPageTypeEnum.HomePage));
        }
    }
}