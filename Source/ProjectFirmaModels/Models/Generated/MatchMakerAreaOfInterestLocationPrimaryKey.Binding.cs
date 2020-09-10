//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchMakerAreaOfInterestLocation
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchMakerAreaOfInterestLocationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchMakerAreaOfInterestLocation>
    {
        public MatchMakerAreaOfInterestLocationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchMakerAreaOfInterestLocationPrimaryKey(MatchMakerAreaOfInterestLocation matchMakerAreaOfInterestLocation) : base(matchMakerAreaOfInterestLocation){}

        public static implicit operator MatchMakerAreaOfInterestLocationPrimaryKey(int primaryKeyValue)
        {
            return new MatchMakerAreaOfInterestLocationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchMakerAreaOfInterestLocationPrimaryKey(MatchMakerAreaOfInterestLocation matchMakerAreaOfInterestLocation)
        {
            return new MatchMakerAreaOfInterestLocationPrimaryKey(matchMakerAreaOfInterestLocation);
        }
    }
}