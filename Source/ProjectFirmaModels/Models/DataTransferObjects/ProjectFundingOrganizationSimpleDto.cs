
namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class ProjectFundingOrganizationSimpleDto
    {
        public int ProjectFundingOrganizationID { get; set; }
        public int ProjectID { get; set; }
        public int OrganizationID { get; set; }
        public OrganizationSimpleDto Organization { get; set; }
    }

}