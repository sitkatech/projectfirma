//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerSubScoreType]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static MatchmakerSubScoreType GetMatchmakerSubScoreType(this IQueryable<MatchmakerSubScoreType> matchmakerSubScoreTypes, int matchmakerSubScoreTypeID)
        {
            var matchmakerSubScoreType = matchmakerSubScoreTypes.SingleOrDefault(x => x.MatchmakerSubScoreTypeID == matchmakerSubScoreTypeID);
            Check.RequireNotNullThrowNotFound(matchmakerSubScoreType, "MatchmakerSubScoreType", matchmakerSubScoreTypeID);
            return matchmakerSubScoreType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteMatchmakerSubScoreType(this IQueryable<MatchmakerSubScoreType> matchmakerSubScoreTypes, List<int> matchmakerSubScoreTypeIDList)
        {
            if(matchmakerSubScoreTypeIDList.Any())
            {
                matchmakerSubScoreTypes.Where(x => matchmakerSubScoreTypeIDList.Contains(x.MatchmakerSubScoreTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteMatchmakerSubScoreType(this IQueryable<MatchmakerSubScoreType> matchmakerSubScoreTypes, ICollection<MatchmakerSubScoreType> matchmakerSubScoreTypesToDelete)
        {
            if(matchmakerSubScoreTypesToDelete.Any())
            {
                var matchmakerSubScoreTypeIDList = matchmakerSubScoreTypesToDelete.Select(x => x.MatchmakerSubScoreTypeID).ToList();
                matchmakerSubScoreTypes.Where(x => matchmakerSubScoreTypeIDList.Contains(x.MatchmakerSubScoreTypeID)).Delete();
            }
        }

        public static void DeleteMatchmakerSubScoreType(this IQueryable<MatchmakerSubScoreType> matchmakerSubScoreTypes, int matchmakerSubScoreTypeID)
        {
            DeleteMatchmakerSubScoreType(matchmakerSubScoreTypes, new List<int> { matchmakerSubScoreTypeID });
        }

        public static void DeleteMatchmakerSubScoreType(this IQueryable<MatchmakerSubScoreType> matchmakerSubScoreTypes, MatchmakerSubScoreType matchmakerSubScoreTypeToDelete)
        {
            DeleteMatchmakerSubScoreType(matchmakerSubScoreTypes, new List<MatchmakerSubScoreType> { matchmakerSubScoreTypeToDelete });
        }
    }
}