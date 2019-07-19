//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingSourceCustomAttributeType GetFundingSourceCustomAttributeType(this IQueryable<FundingSourceCustomAttributeType> fundingSourceCustomAttributeTypes, int fundingSourceCustomAttributeTypeID)
        {
            var fundingSourceCustomAttributeType = fundingSourceCustomAttributeTypes.SingleOrDefault(x => x.FundingSourceCustomAttributeTypeID == fundingSourceCustomAttributeTypeID);
            Check.RequireNotNullThrowNotFound(fundingSourceCustomAttributeType, "FundingSourceCustomAttributeType", fundingSourceCustomAttributeTypeID);
            return fundingSourceCustomAttributeType;
        }

    }
}