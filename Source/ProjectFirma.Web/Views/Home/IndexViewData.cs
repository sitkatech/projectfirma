using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : FirmaViewData
    {
        public readonly bool ShowEditButton;
        public readonly string EditUrl;

        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly string FullMapUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage, ProjectLocationsMapViewData projectLocationsMapViewData, ProjectLocationsMapInitJson projectLocationsMapInitJson) : base(currentPerson, firmaPage, false)
        {
            PageTitle =  string.Format("{0} Project Tracker", MultiTenantHelpers.GetTenantDisplayName());

            var permissionCheckResult = new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage);
            ShowEditButton = permissionCheckResult.HasPermission;
            EditUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.EditPageContent(FirmaPageTypeEnum.HomePage));

            FullMapUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectMap());
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
        }
    }
}