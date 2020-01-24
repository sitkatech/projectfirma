using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class FundingSourceDto
    {
        public FundingSourceDto(FundingSource fundingSource)
        {
            FundingSourceID = fundingSource.FundingSourceID;
            OrganizationID = fundingSource.OrganizationID;
            FundingSourceName = fundingSource.FundingSourceName;
            IsActive = fundingSource.IsActive;
            FundingSourceDescription = fundingSource.FundingSourceDescription;
            FundingSourceAmount = fundingSource.FundingSourceAmount;
        }

        public FundingSourceDto()
        {
        }

        public int FundingSourceID { get; set; }
        public int OrganizationID { get; set; }
        public string FundingSourceName { get; set; }
        public bool IsActive { get; set; }
        public string FundingSourceDescription { get; set; }
        public decimal? FundingSourceAmount { get; set; }
    }

}