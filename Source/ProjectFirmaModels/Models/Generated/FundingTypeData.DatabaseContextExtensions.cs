//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingTypeData]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingTypeData GetFundingTypeData(this IQueryable<FundingTypeData> fundingTypeDatas, int fundingTypeDataID)
        {
            var fundingTypeData = fundingTypeDatas.SingleOrDefault(x => x.FundingTypeDataID == fundingTypeDataID);
            Check.RequireNotNullThrowNotFound(fundingTypeData, "FundingTypeData", fundingTypeDataID);
            return fundingTypeData;
        }

    }
}