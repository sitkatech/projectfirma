namespace ProjectFirmaModels.Models
{
    public partial class ProjectDocument : IAuditableEntity
    {
        public string GetAuditDescriptionString() => "Document updated";
    }
}
