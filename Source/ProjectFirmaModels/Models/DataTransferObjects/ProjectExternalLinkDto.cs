
namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class ProjectExternalLinkSimpleDto
    {
        public int ProjectExternalLinkID { get; set; }
        public int ProjectID { get; set; }
        public string ExternalLinkLabel { get; set; }
        public string ExternalLinkUrl { get; set; }
    }

}