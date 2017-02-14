//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSource]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteFundingSource(this List<int> fundingSourceIDList)
        {
            if(fundingSourceIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFundingSources.RemoveRange(HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => fundingSourceIDList.Contains(x.FundingSourceID)));
            }
        }

        public static void DeleteFundingSource(this ICollection<FundingSource> fundingSourcesToDelete)
        {
            if(fundingSourcesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFundingSources.RemoveRange(fundingSourcesToDelete);
            }
        }

        public static void DeleteFundingSource(this int fundingSourceID)
        {
            DeleteFundingSource(new List<int> { fundingSourceID });
        }

        public static void DeleteFundingSource(this FundingSource fundingSourceToDelete)
        {
            DeleteFundingSource(new List<FundingSource> { fundingSourceToDelete });
        }
    }
}