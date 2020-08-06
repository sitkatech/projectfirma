//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationTaxonomyTrunk]
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
        public static MatchmakerOrganizationTaxonomyTrunk GetMatchmakerOrganizationTaxonomyTrunk(this IQueryable<MatchmakerOrganizationTaxonomyTrunk> matchmakerOrganizationTaxonomyTrunks, int matchmakerOrganizationTaxonomyTrunkID)
        {
            var matchmakerOrganizationTaxonomyTrunk = matchmakerOrganizationTaxonomyTrunks.SingleOrDefault(x => x.MatchmakerOrganizationTaxonomyTrunkID == matchmakerOrganizationTaxonomyTrunkID);
            Check.RequireNotNullThrowNotFound(matchmakerOrganizationTaxonomyTrunk, "MatchmakerOrganizationTaxonomyTrunk", matchmakerOrganizationTaxonomyTrunkID);
            return matchmakerOrganizationTaxonomyTrunk;
        }

    }
}