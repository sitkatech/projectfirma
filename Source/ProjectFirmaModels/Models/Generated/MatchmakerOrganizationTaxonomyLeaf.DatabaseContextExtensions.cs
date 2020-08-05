//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyLeaf]
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
        public static MatchmakerOrganizationTaxonomyLeaf GetMatchmakerOrganizationTaxonomyLeaf(this IQueryable<MatchmakerOrganizationTaxonomyLeaf> matchmakerOrganizationTaxonomyLeafs, int matchmakerOrganizationTaxonomyLeafID)
        {
            var matchmakerOrganizationTaxonomyLeaf = matchmakerOrganizationTaxonomyLeafs.SingleOrDefault(x => x.MatchmakerOrganizationTaxonomyLeafID == matchmakerOrganizationTaxonomyLeafID);
            Check.RequireNotNullThrowNotFound(matchmakerOrganizationTaxonomyLeaf, "MatchmakerOrganizationTaxonomyLeaf", matchmakerOrganizationTaxonomyLeafID);
            return matchmakerOrganizationTaxonomyLeaf;
        }

    }
}