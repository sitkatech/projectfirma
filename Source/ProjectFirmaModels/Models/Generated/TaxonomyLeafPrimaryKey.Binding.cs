//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyLeaf
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyLeafPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyLeaf>
    {
        public TaxonomyLeafPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyLeafPrimaryKey(TaxonomyLeaf taxonomyLeaf) : base(taxonomyLeaf){}

        public static implicit operator TaxonomyLeafPrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyLeafPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyLeafPrimaryKey(TaxonomyLeaf taxonomyLeaf)
        {
            return new TaxonomyLeafPrimaryKey(taxonomyLeaf);
        }
    }
}