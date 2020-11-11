//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchmakerSubScoreType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerSubScoreTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchmakerSubScoreType>
    {
        public MatchmakerSubScoreTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchmakerSubScoreTypePrimaryKey(MatchmakerSubScoreType matchmakerSubScoreType) : base(matchmakerSubScoreType){}

        public static implicit operator MatchmakerSubScoreTypePrimaryKey(int primaryKeyValue)
        {
            return new MatchmakerSubScoreTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchmakerSubScoreTypePrimaryKey(MatchmakerSubScoreType matchmakerSubScoreType)
        {
            return new MatchmakerSubScoreTypePrimaryKey(matchmakerSubScoreType);
        }
    }
}