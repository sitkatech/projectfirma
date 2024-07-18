namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class ProjectStageSimpleDto
    {
        public int ProjectStageID { get; set; }
        public string ProjectStageName { get; set; }
        public string ProjectStageDisplayName { get; set; }
        public int SortOrder { get; set; }
        public string ProjectStageColor { get; set; }
    }

}