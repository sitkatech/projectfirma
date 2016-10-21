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