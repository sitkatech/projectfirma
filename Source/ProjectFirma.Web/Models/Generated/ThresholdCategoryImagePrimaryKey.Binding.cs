//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdCategoryImage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdCategoryImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdCategoryImage>
    {
        public ThresholdCategoryImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdCategoryImagePrimaryKey(ThresholdCategoryImage thresholdCategoryImage) : base(thresholdCategoryImage){}

        public static implicit operator ThresholdCategoryImagePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdCategoryImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdCategoryImagePrimaryKey(ThresholdCategoryImage thresholdCategoryImage)
        {
            return new ThresholdCategoryImagePrimaryKey(thresholdCategoryImage);
        }
    }
}