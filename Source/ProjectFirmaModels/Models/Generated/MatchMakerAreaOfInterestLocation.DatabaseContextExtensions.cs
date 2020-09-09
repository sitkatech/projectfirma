//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchMakerAreaOfInterestLocation]
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
        public static MatchMakerAreaOfInterestLocation GetMatchMakerAreaOfInterestLocation(this IQueryable<MatchMakerAreaOfInterestLocation> matchMakerAreaOfInterestLocations, int matchMakerAreaOfInterestLocationID)
        {
            var matchMakerAreaOfInterestLocation = matchMakerAreaOfInterestLocations.SingleOrDefault(x => x.MatchMakerAreaOfInterestLocationID == matchMakerAreaOfInterestLocationID);
            Check.RequireNotNullThrowNotFound(matchMakerAreaOfInterestLocation, "MatchMakerAreaOfInterestLocation", matchMakerAreaOfInterestLocationID);
            return matchMakerAreaOfInterestLocation;
        }

    }
}