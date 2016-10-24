using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectFirmaPage
{
    public class IndexViewData : EIPViewData
    {
        public readonly ProjectFirmaPageGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string ProjectFirmaPageUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Manage Page Content";

            GridSpec = new ProjectFirmaPageGridSpec(new ProjectFirmaPageViewListFeature().HasPermissionByPerson(currentPerson))
            {
                ObjectNameSingular = "Page",
                ObjectNamePlural = "Pages",
                SaveFiltersInCookie = true
            };
            GridName = "projectFirmaPagesGrid";
            GridDataUrl = SitkaRoute<ProjectFirmaPageController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            ProjectFirmaPageUrl = SitkaRoute<ProjectFirmaPageController>.BuildUrlFromExpression(x => x.ProjectFirmaPageDetails(UrlTemplate.Parameter1Int));
        }
    }
}