/*-----------------------------------------------------------------------
<copyright file="MonitoringProgram.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class MonitoringProgram : IAuditableEntity
    {
        public string DeleteUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.DeleteMonitoringProgram(MonitoringProgramID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.Edit(MonitoringProgramID)); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(DetailUrl, DisplayName); }
        }

        public string DisplayName
        {
            get { return MonitoringProgramName; }
        }

        public string DetailUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(x => x.Detail(MonitoringProgramID)); }
        }

        public static bool IsMonitoringProgramNameUnique(IEnumerable<MonitoringProgram> monitoringPrograms, string monitoringProgramName, int currentMonitoringProgramID)
        {
            var monitoringProgram =
                monitoringPrograms.SingleOrDefault(
                    x => x.MonitoringProgramID != currentMonitoringProgramID && String.Equals(x.MonitoringProgramName, monitoringProgramName, StringComparison.InvariantCultureIgnoreCase));
            return monitoringProgram == null;
        }

        public string AuditDescriptionString
        {
            get { return MonitoringProgramName; }
        }
        public string NewMonitoringProgramDocumentUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.NewMonitoringProgramDocument(MonitoringProgramID)); }
        }
    }
}
