namespace ProjectFirma.Web.Models
{
    public partial class ProjectCreateSection
    {
        public bool IsComplete(Project project)
        {
            return ProjectCreateSectionModelExtensions.IsComplete(this, project);
        }

        public string GetSectionUrl(Project project)
        {
            return ProjectCreateSectionModelExtensions.GetSectionUrl(this, project);
        }
    }
}
