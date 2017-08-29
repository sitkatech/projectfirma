//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingTypeData]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingTypeData GetFundingTypeData(this IQueryable<FundingTypeData> fundingTypeDatas, int fundingTypeDataID)
        {
            var fundingTypeData = fundingTypeDatas.SingleOrDefault(x => x.FundingTypeDataID == fundingTypeDataID);
            Check.RequireNotNullThrowNotFound(fundingTypeData, "FundingTypeData", fundingTypeDataID);
            return fundingTypeData;
        }

        public static void DeleteFundingTypeData(this List<int> fundingTypeDataIDList)
        {
            if(fundingTypeDataIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFundingTypeDatas.RemoveRange(HttpRequestStorage.DatabaseEntities.FundingTypeDatas.Where(x => fundingTypeDataIDList.Contains(x.FundingTypeDataID)));
            }
        }

        public static void DeleteFundingTypeData(this ICollection<FundingTypeData> fundingTypeDatasToDelete)
        {
            if(fundingTypeDatasToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFundingTypeDatas.RemoveRange(fundingTypeDatasToDelete);
            }
        }

        public static void DeleteFundingTypeData(this int fundingTypeDataID)
        {
            DeleteFundingTypeData(new List<int> { fundingTypeDataID });
        }

        public static void DeleteFundingTypeData(this FundingTypeData fundingTypeDataToDelete)
        {
            DeleteFundingTypeData(new List<FundingTypeData> { fundingTypeDataToDelete });
        }
    }
}