//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTierOneImage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierOneImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTierOneImage>
    {
        public TaxonomyTierOneImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTierOneImagePrimaryKey(TaxonomyTierOneImage taxonomyTierOneImage) : base(taxonomyTierOneImage){}

        public static implicit operator TaxonomyTierOneImagePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTierOneImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTierOneImagePrimaryKey(TaxonomyTierOneImage taxonomyTierOneImage)
        {
            return new TaxonomyTierOneImagePrimaryKey(taxonomyTierOneImage);
        }
    }
}