//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelLandCapabilityRating
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelLandCapabilityRatingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelLandCapabilityRating>
    {
        public ParcelLandCapabilityRatingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelLandCapabilityRatingPrimaryKey(ParcelLandCapabilityRating parcelLandCapabilityRating) : base(parcelLandCapabilityRating){}

        public static implicit operator ParcelLandCapabilityRatingPrimaryKey(int primaryKeyValue)
        {
            return new ParcelLandCapabilityRatingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelLandCapabilityRatingPrimaryKey(ParcelLandCapabilityRating parcelLandCapabilityRating)
        {
            return new ParcelLandCapabilityRatingPrimaryKey(parcelLandCapabilityRating);
        }
    }
}