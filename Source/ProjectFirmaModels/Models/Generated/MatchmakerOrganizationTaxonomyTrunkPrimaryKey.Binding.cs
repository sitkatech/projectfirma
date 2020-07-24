//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchmakerOrganizationTaxonomyTrunk
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationTaxonomyTrunkPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchmakerOrganizationTaxonomyTrunk>
    {
        public MatchmakerOrganizationTaxonomyTrunkPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchmakerOrganizationTaxonomyTrunkPrimaryKey(MatchmakerOrganizationTaxonomyTrunk matchmakerOrganizationTaxonomyTrunk) : base(matchmakerOrganizationTaxonomyTrunk){}

        public static implicit operator MatchmakerOrganizationTaxonomyTrunkPrimaryKey(int primaryKeyValue)
        {
            return new MatchmakerOrganizationTaxonomyTrunkPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchmakerOrganizationTaxonomyTrunkPrimaryKey(MatchmakerOrganizationTaxonomyTrunk matchmakerOrganizationTaxonomyTrunk)
        {
            return new MatchmakerOrganizationTaxonomyTrunkPrimaryKey(matchmakerOrganizationTaxonomyTrunk);
        }
    }
}