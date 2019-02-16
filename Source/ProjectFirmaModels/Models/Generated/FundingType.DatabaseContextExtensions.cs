//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingType]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingType GetFundingType(this IQueryable<FundingType> fundingTypes, int fundingTypeID)
        {
            var fundingType = fundingTypes.SingleOrDefault(x => x.FundingTypeID == fundingTypeID);
            Check.RequireNotNullThrowNotFound(fundingType, "FundingType", fundingTypeID);
            return fundingType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFundingType(this IQueryable<FundingType> fundingTypes, List<int> fundingTypeIDList)
        {
            if(fundingTypeIDList.Any())
            {
                fundingTypes.Where(x => fundingTypeIDList.Contains(x.FundingTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFundingType(this IQueryable<FundingType> fundingTypes, ICollection<FundingType> fundingTypesToDelete)
        {
            if(fundingTypesToDelete.Any())
            {
                var fundingTypeIDList = fundingTypesToDelete.Select(x => x.FundingTypeID).ToList();
                fundingTypes.Where(x => fundingTypeIDList.Contains(x.FundingTypeID)).Delete();
            }
        }

        public static void DeleteFundingType(this IQueryable<FundingType> fundingTypes, int fundingTypeID)
        {
            DeleteFundingType(fundingTypes, new List<int> { fundingTypeID });
        }

        public static void DeleteFundingType(this IQueryable<FundingType> fundingTypes, FundingType fundingTypeToDelete)
        {
            DeleteFundingType(fundingTypes, new List<FundingType> { fundingTypeToDelete });
        }
    }
}