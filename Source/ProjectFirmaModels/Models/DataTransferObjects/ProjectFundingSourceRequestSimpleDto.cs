
namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class ProjectFundingSourceRequestSimpleDto
    {
        public int ProjectFundingSourceRequestID { get; set; }
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal SecuredAmount { get; set; }
        public decimal UnsecuredAmount { get; set; }
        public FundingSourceSimpleDto FundingSource { get; set; }
    }

}