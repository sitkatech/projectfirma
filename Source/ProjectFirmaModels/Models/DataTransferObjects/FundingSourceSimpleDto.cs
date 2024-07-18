
namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class FundingSourceSimpleDto
    {
        public int FundingSourceID { get; set; }
        public int OrganizationID { get; set; }
        public string FundingSourceName { get; set; }
        public bool IsActive { get; set; }
        public string FundingSourceDescription { get; set; }
        public bool IsTransportationFundingSource { get; set; }
        public OrganizationSimpleDto Organization { get; set; }
    }

}