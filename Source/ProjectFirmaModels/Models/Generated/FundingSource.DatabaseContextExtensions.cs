//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSource]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingSource GetFundingSource(this IQueryable<FundingSource> fundingSources, int fundingSourceID)
        {
            var fundingSource = fundingSources.SingleOrDefault(x => x.FundingSourceID == fundingSourceID);
            Check.RequireNotNullThrowNotFound(fundingSource, "FundingSource", fundingSourceID);
            return fundingSource;
        }

    }
}