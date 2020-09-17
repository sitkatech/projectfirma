//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchmakerOrganizationClassification
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationClassificationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchmakerOrganizationClassification>
    {
        public MatchmakerOrganizationClassificationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchmakerOrganizationClassificationPrimaryKey(MatchmakerOrganizationClassification matchmakerOrganizationClassification) : base(matchmakerOrganizationClassification){}

        public static implicit operator MatchmakerOrganizationClassificationPrimaryKey(int primaryKeyValue)
        {
            return new MatchmakerOrganizationClassificationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchmakerOrganizationClassificationPrimaryKey(MatchmakerOrganizationClassification matchmakerOrganizationClassification)
        {
            return new MatchmakerOrganizationClassificationPrimaryKey(matchmakerOrganizationClassification);
        }
    }
}