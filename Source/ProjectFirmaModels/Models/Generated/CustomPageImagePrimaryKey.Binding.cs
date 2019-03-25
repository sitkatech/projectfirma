//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CustomPageImage
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CustomPageImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CustomPageImage>
    {
        public CustomPageImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CustomPageImagePrimaryKey(CustomPageImage customPageImage) : base(customPageImage){}

        public static implicit operator CustomPageImagePrimaryKey(int primaryKeyValue)
        {
            return new CustomPageImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator CustomPageImagePrimaryKey(CustomPageImage customPageImage)
        {
            return new CustomPageImagePrimaryKey(customPageImage);
        }
    }
}