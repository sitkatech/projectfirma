//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyBranch
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyBranchPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyBranch>
    {
        public TaxonomyBranchPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyBranchPrimaryKey(TaxonomyBranch taxonomyBranch) : base(taxonomyBranch){}

        public static implicit operator TaxonomyBranchPrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyBranchPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyBranchPrimaryKey(TaxonomyBranch taxonomyBranch)
        {
            return new TaxonomyBranchPrimaryKey(taxonomyBranch);
        }
    }
}