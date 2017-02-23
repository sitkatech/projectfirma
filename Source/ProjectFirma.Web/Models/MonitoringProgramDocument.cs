/*-----------------------------------------------------------------------
<copyright file="MonitoringProgramDocument.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class MonitoringProgramDocument : IAuditableEntity
    {
        public MonitoringProgramDocument(MonitoringProgram monitoringProgram)
            : this(ModelObjectHelpers.NotYetAssignedID, monitoringProgram.MonitoringProgramID, string.Empty, DateTime.Now)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            MonitoringProgram = monitoringProgram;   
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

        }

        public string AuditDescriptionString { get; private set; }

        public string DeleteMonitoringProgramDocumentUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.DeleteMonitoringProgramDocument(MonitoringProgramDocumentID)); }
        }

    }
}
