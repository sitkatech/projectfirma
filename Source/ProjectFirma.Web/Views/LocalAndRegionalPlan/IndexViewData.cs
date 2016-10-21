using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.LocalAndRegionalPlan
{
    public class IndexViewData : SiteLayoutViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, false, projectFirmaPage, true)
        {
            PageTitle = "Local and Regional Plans";

            var userHasLocalAndRegionalPlanEditPermissions = new LocalAndRegionalPlanManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(userHasLocalAndRegionalPlanEditPermissions)
            {
                ObjectNameSingular = "Local and Regional Plan",
                ObjectNamePlural = "Local and Regional Plans",
                SaveFiltersInCookie = true
            };

            if (userHasLocalAndRegionalPlanEditPermissions)
            {
                var createNewLocalAndRegionalPlanUrl = SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(t => t.New());
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(createNewLocalAndRegionalPlanUrl, "Create a new Local and Regional Plan");
            }

            GridName = "localAndRegionalPlansGrid";
            GridDataUrl = SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}