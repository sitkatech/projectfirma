//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AuditLog
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class AuditLogPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AuditLog>
    {
        public AuditLogPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AuditLogPrimaryKey(AuditLog auditLog) : base(auditLog){}

        public static implicit operator AuditLogPrimaryKey(int primaryKeyValue)
        {
            return new AuditLogPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AuditLogPrimaryKey(AuditLog auditLog)
        {
            return new AuditLogPrimaryKey(auditLog);
        }
    }
}