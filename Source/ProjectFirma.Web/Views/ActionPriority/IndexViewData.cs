using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.ActionPriority
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Action Priorities";

            var hasActionPriorityManagePermissions = new ActionPriorityManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasActionPriorityManagePermissions)
            {
                ObjectNameSingular = "Action Priority",
                ObjectNamePlural = "Action Priorities",
                SaveFiltersInCookie = true
            };

            if (hasActionPriorityManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(t => t.New()), "Create a new Action Priority");
            }

            GridName = "actionPrioritiesGrid";
            GridDataUrl = SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}