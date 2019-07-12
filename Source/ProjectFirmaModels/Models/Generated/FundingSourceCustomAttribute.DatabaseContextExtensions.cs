//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttribute]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingSourceCustomAttribute GetFundingSourceCustomAttribute(this IQueryable<FundingSourceCustomAttribute> fundingSourceCustomAttributes, int fundingSourceCustomAttributeID)
        {
            var fundingSourceCustomAttribute = fundingSourceCustomAttributes.SingleOrDefault(x => x.FundingSourceCustomAttributeID == fundingSourceCustomAttributeID);
            Check.RequireNotNullThrowNotFound(fundingSourceCustomAttribute, "FundingSourceCustomAttribute", fundingSourceCustomAttributeID);
            return fundingSourceCustomAttribute;
        }

    }
}