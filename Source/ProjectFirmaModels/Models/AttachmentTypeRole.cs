namespace ProjectFirmaModels.Models
{
    public partial class AttachmentTypeRole : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Attachment Type ID: {AttachmentTypeID}, Role ID: {RoleID}";
    }
}