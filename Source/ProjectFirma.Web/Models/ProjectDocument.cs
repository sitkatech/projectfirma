namespace ProjectFirma.Web.Models
{
    public partial class ProjectDocument : IAuditableEntity
    {
        public string AuditDescriptionString => $"Project \" {Project?.ProjectName ?? "<Not Found>"}\" document \"{DisplayName ?? "<Not Found>"}\"";
    }
}
