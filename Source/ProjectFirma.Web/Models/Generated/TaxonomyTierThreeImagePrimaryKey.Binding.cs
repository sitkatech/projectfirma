//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTierThreeImage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierThreeImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTierThreeImage>
    {
        public TaxonomyTierThreeImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTierThreeImagePrimaryKey(TaxonomyTierThreeImage taxonomyTierThreeImage) : base(taxonomyTierThreeImage){}

        public static implicit operator TaxonomyTierThreeImagePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTierThreeImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTierThreeImagePrimaryKey(TaxonomyTierThreeImage taxonomyTierThreeImage)
        {
            return new TaxonomyTierThreeImagePrimaryKey(taxonomyTierThreeImage);
        }
    }
}