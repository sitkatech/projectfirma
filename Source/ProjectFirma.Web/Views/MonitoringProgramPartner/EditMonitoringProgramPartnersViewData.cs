using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.MonitoringProgramPartner
{
    public class EditMonitoringProgramPartnersViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<OrganizationSimple> AllOrganizations;
        public readonly int MonitoringProgramID;

        public EditMonitoringProgramPartnersViewData(Models.MonitoringProgram monitoringProgram, List<OrganizationSimple> allOrganizations)
        {
            AllOrganizations = allOrganizations;
            MonitoringProgramID = monitoringProgram.MonitoringProgramID;
        }
    }
}