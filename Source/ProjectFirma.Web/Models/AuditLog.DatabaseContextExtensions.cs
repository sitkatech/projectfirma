/*-----------------------------------------------------------------------
<copyright file="AuditLog.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<AuditLog> GetAuditLogEntriesForProject(this IQueryable<AuditLog> auditLogs, Project project)
        {
            return auditLogs.Where(al => al.ProjectID == project.ProjectID && al.ColumnName != "FileResourceID").OrderByDescending(x => x.AuditLogDate).ToList();
        }

        public static List<AuditLog> GetAuditLogEntriesForProposedProject(this IQueryable<AuditLog> auditLogs, ProposedProject proposedProject)
        {
            return auditLogs.Where(al => al.ProposedProjectID == proposedProject.ProposedProjectID && al.ColumnName != "FileResourceID").OrderByDescending(x => x.AuditLogDate).ToList();
        }
    }
}
