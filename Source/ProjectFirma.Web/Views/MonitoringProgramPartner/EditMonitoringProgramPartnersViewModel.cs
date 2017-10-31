/*-----------------------------------------------------------------------
<copyright file="EditMonitoringProgramPartnersViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
