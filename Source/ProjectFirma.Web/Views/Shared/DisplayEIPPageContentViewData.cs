using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class DisplayEIPPageContentViewData : EIPViewData
    {
        public readonly bool ShowEditButton;
        public readonly string EditUrl;

        public DisplayEIPPageContentViewData(Person currentPerson, ProjectFirmaPageType projectFirmaPageType) : base(currentPerson, Models.ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType))
        {
            PageTitle = projectFirmaPageType.ProjectFirmaPageTypeDisplayName;
            ShowEditButton = new ProjectFirmaPageManageFeature().HasPermission(currentPerson, Models.ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType)).HasPermission;
            EditUrl = SitkaRoute<Controllers.HomeController>.BuildUrlFromExpression(x => x.EditPageContent(projectFirmaPageType.ToEnum));
        }
    }
}