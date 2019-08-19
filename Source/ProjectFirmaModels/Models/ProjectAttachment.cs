namespace ProjectFirmaModels.Models
{
    public partial class ProjectAttachment : IAuditableEntity
    {
        public string GetAuditDescriptionString() => DisplayName;
    }
}
