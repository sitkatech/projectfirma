using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Funding Sources";

            var hasFundingSourceManagePermissions = new FundingSourceManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasFundingSourceManagePermissions)
            {
                ObjectNameSingular = "Funding Source",
                ObjectNamePlural = "Funding Sources",
                SaveFiltersInCookie = true
            };

            if (hasFundingSourceManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<FundingSourceController>.BuildUrlFromExpression(t => t.New()), "Create a new Funding Source");
            }

            GridName = "fundingSourcesGrid";
            GridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}