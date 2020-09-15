//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchmakerKeyword
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerKeywordPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchmakerKeyword>
    {
        public MatchmakerKeywordPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchmakerKeywordPrimaryKey(MatchmakerKeyword matchmakerKeyword) : base(matchmakerKeyword){}

        public static implicit operator MatchmakerKeywordPrimaryKey(int primaryKeyValue)
        {
            return new MatchmakerKeywordPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchmakerKeywordPrimaryKey(MatchmakerKeyword matchmakerKeyword)
        {
            return new MatchmakerKeywordPrimaryKey(matchmakerKeyword);
        }
    }
}