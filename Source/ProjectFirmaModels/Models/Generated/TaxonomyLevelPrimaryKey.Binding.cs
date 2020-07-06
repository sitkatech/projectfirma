//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyLevel
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyLevelPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyLevel>
    {
        public TaxonomyLevelPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyLevelPrimaryKey(TaxonomyLevel taxonomyLevel) : base(taxonomyLevel){}

        public static implicit operator TaxonomyLevelPrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyLevelPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyLevelPrimaryKey(TaxonomyLevel taxonomyLevel)
        {
            return new TaxonomyLevelPrimaryKey(taxonomyLevel);
        }
    }
}