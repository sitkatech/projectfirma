namespace ProjectFirmaModels.Models
{
    public partial class ProjectProjectStatus : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var projectStatusProjectStatusDisplayName =
                ProjectStatus.AllLookupDictionary[ProjectStatusID].ProjectStatusDisplayName;
            var projectProjectName = ProjectID.ToString();
            return $"Project Status Update: Project Status - {projectStatusProjectStatusDisplayName}, Project - {projectProjectName}";
        }
    }
}