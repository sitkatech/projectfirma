using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.MonitoringProgram
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Monitoring Programs";

            var userHasMonitoringProgramEditPermissions = new MonitoringProgramManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(userHasMonitoringProgramEditPermissions)
            {
                ObjectNameSingular = "Monitoring Program",
                ObjectNamePlural = "Monitoring Programs",
                SaveFiltersInCookie = true
            };

            if (userHasMonitoringProgramEditPermissions)
            {
                var createNewMonitoringProgramUrl = SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.New());
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(createNewMonitoringProgramUrl, "Create a new Monitoring Program");
            }

            GridName = "monitoringProgramsGrid";
            GridDataUrl = SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}