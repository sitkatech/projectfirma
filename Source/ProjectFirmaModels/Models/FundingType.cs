using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class FundingType
    {
        public FundingTypeData GetFundingTypeData()
        {
            return FundingTypeDatas.SingleOrDefault();
        }

        public string GetFundingTypeDisplayName()
        {
            var fundingTypeData = GetFundingTypeData();
            return fundingTypeData.FundingTypeDisplayName;
        }

        public string GetFundingTypeShortName()
        {
            var fundingTypeData = GetFundingTypeData();
            return fundingTypeData.FundingTypeShortName;
        }

        public int GetFundingTypeSortOrder()
        {
            var fundingTypeData = GetFundingTypeData();
            return fundingTypeData.SortOrder;
        }
    }
}