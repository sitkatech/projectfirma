namespace ProjectFirmaModels.Models
{
    public partial class ProjectProjectStatus : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var projectStatusProjectStatusDisplayName =
                ProjectStatus.ProjectStatusDisplayName;
            var projectProjectName = ProjectID.ToString();
            return $"Project Status Update: Project Status - {projectStatusProjectStatusDisplayName}, Project - {projectProjectName}";
        }
    }
}