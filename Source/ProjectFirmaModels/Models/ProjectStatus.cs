namespace ProjectFirmaModels.Models
{
    public partial class ProjectStatus : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var projectStatusProjectStatusDisplayName = ProjectStatusDisplayName;
            var tenantID = TenantID;
            return $"Project Status: Project Status - {projectStatusProjectStatusDisplayName}, Tenant - {tenantID}";
        }
    }
}