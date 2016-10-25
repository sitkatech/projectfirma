using ProjectFirma.Web.Security;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.Organization
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage)
            : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Organizations";

            var hasOrganizationManagePermissions = new OrganizationManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(currentPerson, hasOrganizationManagePermissions)
            {
                ObjectNameSingular = "Organization",
                ObjectNamePlural = "Organizations",
                SaveFiltersInCookie = true
            };

            if (hasOrganizationManagePermissions)
            {
                var contentUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.New());
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(contentUrl, "Create a new Organization");
            }

            GridName = "organizationsGrid";
            GridDataUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}