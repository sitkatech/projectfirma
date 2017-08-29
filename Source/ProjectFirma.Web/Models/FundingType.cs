using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class FundingType
    {
        public FundingTypeData GetFundingTypeData()
        {
            return HttpRequestStorage.DatabaseEntities.FundingTypeDatas.GetFundingTypeDataByFundingType(this);
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