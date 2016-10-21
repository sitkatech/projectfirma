using System;

namespace ProjectFirma.Web.Models
{
    public partial class AuditLogEventType
    {
        public abstract string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue);
    }

    public partial class AuditLogEventTypeAdded
    {
        public override string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue)
        {
            return String.Format("{0}: set to {1}", entityName, auditDescriptionStringForNewValue);
        }
    }

    public partial class AuditLogEventTypeModified
    {
        public override string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue)
        {
            return String.Format("{0}: {1} changed to {2}", entityName, auditDescriptionStringForOriginalValue, auditDescriptionStringForNewValue);
        }
    }

    public partial class AuditLogEventTypeDeleted
    {
        public override string GetAuditStringForOperationType(string entityName, string auditDescriptionStringForOriginalValue, string auditDescriptionStringForNewValue)
        {
            return String.Format("{0}: deleted {1}", entityName, auditDescriptionStringForNewValue);
        }
    }
}