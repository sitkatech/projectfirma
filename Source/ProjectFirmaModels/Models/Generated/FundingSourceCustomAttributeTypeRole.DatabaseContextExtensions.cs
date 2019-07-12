//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeTypeRole]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingSourceCustomAttributeTypeRole GetFundingSourceCustomAttributeTypeRole(this IQueryable<FundingSourceCustomAttributeTypeRole> fundingSourceCustomAttributeTypeRoles, int fundingSourceCustomAttributeTypeRoleID)
        {
            var fundingSourceCustomAttributeTypeRole = fundingSourceCustomAttributeTypeRoles.SingleOrDefault(x => x.FundingSourceCustomAttributeTypeRoleID == fundingSourceCustomAttributeTypeRoleID);
            Check.RequireNotNullThrowNotFound(fundingSourceCustomAttributeTypeRole, "FundingSourceCustomAttributeTypeRole", fundingSourceCustomAttributeTypeRoleID);
            return fundingSourceCustomAttributeTypeRole;
        }

    }
}