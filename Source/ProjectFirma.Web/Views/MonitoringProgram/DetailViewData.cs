/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using ProjectFirma.Web.Common;

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
            EntityName = $"{Models.FieldDefinition.MonitoringProgram.GetFieldDefinitionLabel()}";
            
            EditMonitoringProgramUrl = SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(c => c.Edit(monitoringProgram.MonitoringProgramID));
            EditMonitoringProgramPartnersUrl = SitkaRoute<MonitoringProgramPartnerController>.BuildUrlFromExpression(c => c.Edit(monitoringProgram.MonitoringProgramID));
            IndexUrl = SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(c => c.Index());

            UserHasMonitoringProgramManagePermissions = new MonitoringProgramManageFeature().HasPermissionByPerson(currentPerson);
        }
    }
}
