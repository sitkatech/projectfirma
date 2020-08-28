//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchmakerOrganizationTaxonomyLeaf
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationTaxonomyLeafPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchmakerOrganizationTaxonomyLeaf>
    {
        public MatchmakerOrganizationTaxonomyLeafPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchmakerOrganizationTaxonomyLeafPrimaryKey(MatchmakerOrganizationTaxonomyLeaf matchmakerOrganizationTaxonomyLeaf) : base(matchmakerOrganizationTaxonomyLeaf){}

        public static implicit operator MatchmakerOrganizationTaxonomyLeafPrimaryKey(int primaryKeyValue)
        {
            return new MatchmakerOrganizationTaxonomyLeafPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchmakerOrganizationTaxonomyLeafPrimaryKey(MatchmakerOrganizationTaxonomyLeaf matchmakerOrganizationTaxonomyLeaf)
        {
            return new MatchmakerOrganizationTaxonomyLeafPrimaryKey(matchmakerOrganizationTaxonomyLeaf);
        }
    }
}