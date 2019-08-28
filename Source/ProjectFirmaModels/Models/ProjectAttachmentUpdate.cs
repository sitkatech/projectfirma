namespace ProjectFirmaModels.Models
{
    public partial class ProjectAttachmentUpdate : IAuditableEntity
    {
        public string GetAuditDescriptionString() => DisplayName;
    }
}