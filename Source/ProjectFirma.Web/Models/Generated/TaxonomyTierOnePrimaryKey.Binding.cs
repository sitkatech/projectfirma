//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTierOne
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierOnePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTierOne>
    {
        public TaxonomyTierOnePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTierOnePrimaryKey(TaxonomyTierOne taxonomyTierOne) : base(taxonomyTierOne){}

        public static implicit operator TaxonomyTierOnePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTierOnePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTierOnePrimaryKey(TaxonomyTierOne taxonomyTierOne)
        {
            return new TaxonomyTierOnePrimaryKey(taxonomyTierOne);
        }
    }
}