namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class ProjectImageSimpleDto
    {
        public int ProjectImageID { get; set; }
        public int FileResourceInfoID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectImageTimingID { get; set; }
        public string Caption { get; set; }
        public string Credit { get; set; }
        public bool IsKeyPhoto { get; set; }
        public bool ExcludeFromFactSheet { get; set; }
        public int? SortOrder { get; set; }
        public FileResourceInfoSimpleDto FileResourceInfo { get; set; }
        public ProjectImageTimingSimpleDto ProjectImageTiming { get; set; }
    }

}