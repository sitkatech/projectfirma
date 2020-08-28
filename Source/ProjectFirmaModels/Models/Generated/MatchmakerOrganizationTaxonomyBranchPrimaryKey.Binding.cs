//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MatchmakerOrganizationTaxonomyBranch
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class MatchmakerOrganizationTaxonomyBranchPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MatchmakerOrganizationTaxonomyBranch>
    {
        public MatchmakerOrganizationTaxonomyBranchPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MatchmakerOrganizationTaxonomyBranchPrimaryKey(MatchmakerOrganizationTaxonomyBranch matchmakerOrganizationTaxonomyBranch) : base(matchmakerOrganizationTaxonomyBranch){}

        public static implicit operator MatchmakerOrganizationTaxonomyBranchPrimaryKey(int primaryKeyValue)
        {
            return new MatchmakerOrganizationTaxonomyBranchPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MatchmakerOrganizationTaxonomyBranchPrimaryKey(MatchmakerOrganizationTaxonomyBranch matchmakerOrganizationTaxonomyBranch)
        {
            return new MatchmakerOrganizationTaxonomyBranchPrimaryKey(matchmakerOrganizationTaxonomyBranch);
        }
    }
}