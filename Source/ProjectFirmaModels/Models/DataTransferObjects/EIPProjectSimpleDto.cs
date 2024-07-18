
namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class EIPProjectSimpleDto
    {
        public int EIPProjectID { get; set; }
        public int ProjectID { get; set; }
        public int EIPActionPriorityID { get; set; }
        public short? ProjectNumber { get; set; }
        public string OldEipNumber { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsEIPFocusAreaFeatured { get; set; }
        public EIPActionPrioritySimpleDto EIPActionPriority { get; set; }
    }

}