//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationMatchmakerKeyword]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationMatchmakerKeyword GetOrganizationMatchmakerKeyword(this IQueryable<OrganizationMatchmakerKeyword> organizationMatchmakerKeywords, int organizationMatchmakerKeywordID)
        {
            var organizationMatchmakerKeyword = organizationMatchmakerKeywords.SingleOrDefault(x => x.OrganizationMatchmakerKeywordID == organizationMatchmakerKeywordID);
            Check.RequireNotNullThrowNotFound(organizationMatchmakerKeyword, "OrganizationMatchmakerKeyword", organizationMatchmakerKeywordID);
            return organizationMatchmakerKeyword;
        }

    }
}