//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSource]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingSource GetFundingSource(this IQueryable<FundingSource> fundingSources, int fundingSourceID)
        {
            var fundingSource = fundingSources.SingleOrDefault(x => x.FundingSourceID == fundingSourceID);
            Check.RequireNotNullThrowNotFound(fundingSource, "FundingSource", fundingSourceID);
            return fundingSource;
        }

        public static void DeleteFundingSource(this IQueryable<FundingSource> fundingSources, List<int> fundingSourceIDList)
        {
            if(fundingSourceIDList.Any())
            {
                fundingSources.Where(x => fundingSourceIDList.Contains(x.FundingSourceID)).Delete();
            }
        }

        public static void DeleteFundingSource(this IQueryable<FundingSource> fundingSources, ICollection<FundingSource> fundingSourcesToDelete)
        {
            if(fundingSourcesToDelete.Any())
            {
                var fundingSourceIDList = fundingSourcesToDelete.Select(x => x.FundingSourceID).ToList();
                fundingSources.Where(x => fundingSourceIDList.Contains(x.FundingSourceID)).Delete();
            }
        }

        public static void DeleteFundingSource(this IQueryable<FundingSource> fundingSources, int fundingSourceID)
        {
            DeleteFundingSource(fundingSources, new List<int> { fundingSourceID });
        }

        public static void DeleteFundingSource(this IQueryable<FundingSource> fundingSources, FundingSource fundingSourceToDelete)
        {
            DeleteFundingSource(fundingSources, new List<FundingSource> { fundingSourceToDelete });
        }
    }
}