//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AuditLog]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AuditLog GetAuditLog(this IQueryable<AuditLog> auditLogs, int auditLogID)
        {
            var auditLog = auditLogs.SingleOrDefault(x => x.AuditLogID == auditLogID);
            Check.RequireNotNullThrowNotFound(auditLog, "AuditLog", auditLogID);
            return auditLog;
        }

        public static void DeleteAuditLog(this List<int> auditLogIDList)
        {
            if(auditLogIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAuditLogs.RemoveRange(HttpRequestStorage.DatabaseEntities.AuditLogs.Where(x => auditLogIDList.Contains(x.AuditLogID)));
            }
        }

        public static void DeleteAuditLog(this ICollection<AuditLog> auditLogsToDelete)
        {
            if(auditLogsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAuditLogs.RemoveRange(auditLogsToDelete);
            }
        }

        public static void DeleteAuditLog(this int auditLogID)
        {
            DeleteAuditLog(new List<int> { auditLogID });
        }

        public static void DeleteAuditLog(this AuditLog auditLogToDelete)
        {
            DeleteAuditLog(new List<AuditLog> { auditLogToDelete });
        }
    }
}