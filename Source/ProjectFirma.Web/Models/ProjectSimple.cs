namespace ProjectFirma.Web.Models
{
    public class ProjectSimple
    {
        public int ProjectID { get; set; }
        public string DisplayName { get; set; }

        public ProjectSimple(Project project)
        {
            ProjectID = project.ProjectID;
            DisplayName = project.DisplayName;
        }

        public ProjectSimple(ProposedProject proposedProject)
        {
            ProjectID = proposedProject.ProposedProjectID;
            DisplayName = proposedProject.DisplayName;
        }

        public ProjectSimple(int projectID, string displayName)
        {
            ProjectID = projectID;
            DisplayName = displayName;
        }
    }
}