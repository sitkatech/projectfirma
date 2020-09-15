//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerKeyword]
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
        public static MatchmakerKeyword GetMatchmakerKeyword(this IQueryable<MatchmakerKeyword> matchmakerKeywords, int matchmakerKeywordID)
        {
            var matchmakerKeyword = matchmakerKeywords.SingleOrDefault(x => x.MatchmakerKeywordID == matchmakerKeywordID);
            Check.RequireNotNullThrowNotFound(matchmakerKeyword, "MatchmakerKeyword", matchmakerKeywordID);
            return matchmakerKeyword;
        }

    }
}