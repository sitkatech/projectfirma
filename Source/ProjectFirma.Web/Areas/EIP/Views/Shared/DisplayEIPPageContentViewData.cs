using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared
{
    public class DisplayEIPPageContentViewData : EIPViewData
    {
        public readonly bool ShowEditButton;
        public readonly string EditUrl;

        public DisplayEIPPageContentViewData(Person currentPerson, ProjectFirmaPageType projectFirmaPageType) : base(currentPerson, ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType))
        {
            PageTitle = projectFirmaPageType.ProjectFirmaPageTypeDisplayName;
            ShowEditButton = new ProjectFirmaPageManageFeature().HasPermission(currentPerson, ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType)).HasPermission;
            EditUrl = SitkaRoute<Controllers.HomeController>.BuildUrlFromExpression(x => x.EditPageContent(projectFirmaPageType.ToEnum));
        }
    }
}