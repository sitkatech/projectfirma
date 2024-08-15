
namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class ProjectLocationSimpleDto
    {
        public int ProjectLocationID { get; set; }
        public int ProjectID { get; set; }
        public string Annotation { get; set; }
        public string ProjectLocationGeoJson { get; set; }
    }

}