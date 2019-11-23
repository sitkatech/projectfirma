namespace ProjectFirmaModels.Models
{
    public partial class ProjectProjectStatus : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var projectStatusProjectStatusDisplayName = ProjectStatus != null ? ProjectStatus.ProjectStatusDisplayName : "NO PROJECT STATUS FOUND";
            var projectProjectName = ProjectID.ToString();
            return $"Project Status Update: Project Status - {projectStatusProjectStatusDisplayName}, Project - {projectProjectName}";
        }
    }
}