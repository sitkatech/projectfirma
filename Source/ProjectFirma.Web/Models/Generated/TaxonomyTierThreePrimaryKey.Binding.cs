//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTierThree
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierThreePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTierThree>
    {
        public TaxonomyTierThreePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTierThreePrimaryKey(TaxonomyTierThree taxonomyTierThree) : base(taxonomyTierThree){}

        public static implicit operator TaxonomyTierThreePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTierThreePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTierThreePrimaryKey(TaxonomyTierThree taxonomyTierThree)
        {
            return new TaxonomyTierThreePrimaryKey(taxonomyTierThree);
        }
    }
}