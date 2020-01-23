namespace ProjectFirmaModels.Models
{
    public class ProjectStageSimple
    {
        public int ProjectStageID { get; set; }
        public string DisplayName { get; set; }

        public ProjectStageSimple(ProjectStage projectStage)
        {
            ProjectStageID = projectStage.ProjectStageID;
            DisplayName = projectStage.ProjectStageDisplayName;
        }

        public ProjectStageSimple(int projectStageID, string displayName)
        {
            ProjectStageID = projectStageID;
            DisplayName = displayName;
        }
    }
}