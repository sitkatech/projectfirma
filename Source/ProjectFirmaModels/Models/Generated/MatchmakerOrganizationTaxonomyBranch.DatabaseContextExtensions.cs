//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyBranch]
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
        public static MatchmakerOrganizationTaxonomyBranch GetMatchmakerOrganizationTaxonomyBranch(this IQueryable<MatchmakerOrganizationTaxonomyBranch> matchmakerOrganizationTaxonomyBranches, int matchmakerOrganizationTaxonomyBranchID)
        {
            var matchmakerOrganizationTaxonomyBranch = matchmakerOrganizationTaxonomyBranches.SingleOrDefault(x => x.MatchmakerOrganizationTaxonomyBranchID == matchmakerOrganizationTaxonomyBranchID);
            Check.RequireNotNullThrowNotFound(matchmakerOrganizationTaxonomyBranch, "MatchmakerOrganizationTaxonomyBranch", matchmakerOrganizationTaxonomyBranchID);
            return matchmakerOrganizationTaxonomyBranch;
        }

    }
}