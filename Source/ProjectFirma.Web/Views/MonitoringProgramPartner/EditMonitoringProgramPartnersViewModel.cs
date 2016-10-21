using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.MonitoringProgramPartner
{
    public class EditMonitoringProgramPartnersViewModel : FormViewModel
    {
        public List<MonitoringProgramPartnerSimple> MonitoringProgramPartners { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditMonitoringProgramPartnersViewModel()
        {
        }

        public EditMonitoringProgramPartnersViewModel(List<MonitoringProgramPartnerSimple> monitoringProgramPartners)
        {
            MonitoringProgramPartners = monitoringProgramPartners;
        }

        public void UpdateModel(List<Models.MonitoringProgramPartner> currentMonitoringProgramPartners, IList<Models.MonitoringProgramPartner> allMonitoringProgramPartners)
        {
            var monitoringProgramPartnersUpdated = new List<Models.MonitoringProgramPartner>();
            if (MonitoringProgramPartners != null)
            {
                // Completely rebuild the list
                monitoringProgramPartnersUpdated = MonitoringProgramPartners.Select(x => new Models.MonitoringProgramPartner(x.MonitoringProgramID, x.OrganizationID)).ToList();
            }
            currentMonitoringProgramPartners.Merge(monitoringProgramPartnersUpdated, allMonitoringProgramPartners, (x, y) => x.MonitoringProgramID == y.MonitoringProgramID && x.OrganizationID == y.OrganizationID);
        }
    }
}