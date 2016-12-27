//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTierTwoImage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTierTwoImage>
    {
        public TaxonomyTierTwoImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTierTwoImagePrimaryKey(TaxonomyTierTwoImage taxonomyTierTwoImage) : base(taxonomyTierTwoImage){}

        public static implicit operator TaxonomyTierTwoImagePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTierTwoImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTierTwoImagePrimaryKey(TaxonomyTierTwoImage taxonomyTierTwoImage)
        {
            return new TaxonomyTierTwoImagePrimaryKey(taxonomyTierTwoImage);
        }
    }
}