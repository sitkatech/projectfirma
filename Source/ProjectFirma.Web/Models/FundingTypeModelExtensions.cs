using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FundingTypeModelExtensions
    {
        public static FundingType ToType(this FundingTypeEnum fieldDefinitionEnum)
        {
            return HttpRequestStorage.DatabaseEntities.FundingTypes.SingleOrDefault(x =>
                x.FundingTypeID == (int) fieldDefinitionEnum);
        }
        public static FundingType ToType(int fieldDefinitionID)
        {
            return HttpRequestStorage.DatabaseEntities.FundingTypes.SingleOrDefault(x =>
                x.FundingTypeID == fieldDefinitionID);
        }

        public static FundingTypeData GetFundingTypeData(this FundingType fundingType)
        {
            return fundingType.FundingTypeDatas.SingleOrDefault(x => x.TenantID == HttpRequestStorage.Tenant.TenantID);
        }

        public static string GetFundingTypeDisplayName(this FundingType fundingType)
        {
            var fundingTypeData = fundingType.GetFundingTypeData();
            return fundingTypeData.FundingTypeDisplayName;
        }

        public static string GetFundingTypeShortName(this FundingType fundingType)
        {
            var fundingTypeData = fundingType.GetFundingTypeData();
            return fundingTypeData.FundingTypeShortName;
        }

        public static int GetFundingTypeSortOrder(this FundingType fundingType)
        {
            var fundingTypeData = fundingType.GetFundingTypeData();
            return fundingTypeData.SortOrder;
        }
    }
}