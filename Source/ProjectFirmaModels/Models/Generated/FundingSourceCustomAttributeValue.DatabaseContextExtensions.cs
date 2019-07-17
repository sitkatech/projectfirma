//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingSourceCustomAttributeValue GetFundingSourceCustomAttributeValue(this IQueryable<FundingSourceCustomAttributeValue> fundingSourceCustomAttributeValues, int fundingSourceCustomAttributeValueID)
        {
            var fundingSourceCustomAttributeValue = fundingSourceCustomAttributeValues.SingleOrDefault(x => x.FundingSourceCustomAttributeValueID == fundingSourceCustomAttributeValueID);
            Check.RequireNotNullThrowNotFound(fundingSourceCustomAttributeValue, "FundingSourceCustomAttributeValue", fundingSourceCustomAttributeValueID);
            return fundingSourceCustomAttributeValue;
        }

    }
}