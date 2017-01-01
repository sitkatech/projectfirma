using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.MonitoringProgram
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.MonitoringProgram MonitoringProgram;
        public readonly string EditMonitoringProgramUrl;
        public readonly string EditMonitoringProgramPartnersUrl;
        public readonly string IndexUrl;

        public readonly bool UserHasMonitoringProgramManagePermissions;

        public DetailViewData(Person currentPerson, Models.MonitoringProgram monitoringProgram) : base(currentPerson)
        {
            MonitoringProgram = monitoringProgram;
            PageTitle = monitoringProgram.MonitoringProgramName;
            EntityName = "Monitoring Program";
            
            EditMonitoringProgramUrl = SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(c => c.Edit(monitoringProgram.MonitoringProgramID));
            EditMonitoringProgramPartnersUrl = SitkaRoute<MonitoringProgramPartnerController>.BuildUrlFromExpression(c => c.Edit(monitoringProgram.MonitoringProgramID));
            IndexUrl = SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(c => c.Index());

            UserHasMonitoringProgramManagePermissions = new MonitoringProgramManageFeature().HasPermissionByPerson(currentPerson);
        }
    }
}