//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTierTwo
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTierTwo>
    {
        public TaxonomyTierTwoPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTierTwoPrimaryKey(TaxonomyTierTwo taxonomyTierTwo) : base(taxonomyTierTwo){}

        public static implicit operator TaxonomyTierTwoPrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTierTwoPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTierTwoPrimaryKey(TaxonomyTierTwo taxonomyTierTwo)
        {
            return new TaxonomyTierTwoPrimaryKey(taxonomyTierTwo);
        }
    }
}