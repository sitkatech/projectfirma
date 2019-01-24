//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AuditLog]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AuditLog GetAuditLog(this IQueryable<AuditLog> auditLogs, int auditLogID)
        {
            var auditLog = auditLogs.SingleOrDefault(x => x.AuditLogID == auditLogID);
            Check.RequireNotNullThrowNotFound(auditLog, "AuditLog", auditLogID);
            return auditLog;
        }

    }
}