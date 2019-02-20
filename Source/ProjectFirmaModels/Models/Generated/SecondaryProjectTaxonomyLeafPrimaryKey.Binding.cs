//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SecondaryProjectTaxonomyLeaf
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SecondaryProjectTaxonomyLeafPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SecondaryProjectTaxonomyLeaf>
    {
        public SecondaryProjectTaxonomyLeafPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SecondaryProjectTaxonomyLeafPrimaryKey(SecondaryProjectTaxonomyLeaf secondaryProjectTaxonomyLeaf) : base(secondaryProjectTaxonomyLeaf){}

        public static implicit operator SecondaryProjectTaxonomyLeafPrimaryKey(int primaryKeyValue)
        {
            return new SecondaryProjectTaxonomyLeafPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SecondaryProjectTaxonomyLeafPrimaryKey(SecondaryProjectTaxonomyLeaf secondaryProjectTaxonomyLeaf)
        {
            return new SecondaryProjectTaxonomyLeafPrimaryKey(secondaryProjectTaxonomyLeaf);
        }
    }
}