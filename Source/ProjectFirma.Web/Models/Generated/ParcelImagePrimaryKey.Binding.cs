//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelImage>
    {
        public ParcelImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelImagePrimaryKey(ParcelImage parcelImage) : base(parcelImage){}

        public static implicit operator ParcelImagePrimaryKey(int primaryKeyValue)
        {
            return new ParcelImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelImagePrimaryKey(ParcelImage parcelImage)
        {
            return new ParcelImagePrimaryKey(parcelImage);
        }
    }
}