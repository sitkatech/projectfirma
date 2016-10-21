//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelLandCapabilityDeterminationType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelLandCapabilityDeterminationTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelLandCapabilityDeterminationType>
    {
        public ParcelLandCapabilityDeterminationTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelLandCapabilityDeterminationTypePrimaryKey(ParcelLandCapabilityDeterminationType parcelLandCapabilityDeterminationType) : base(parcelLandCapabilityDeterminationType){}

        public static implicit operator ParcelLandCapabilityDeterminationTypePrimaryKey(int primaryKeyValue)
        {
            return new ParcelLandCapabilityDeterminationTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelLandCapabilityDeterminationTypePrimaryKey(ParcelLandCapabilityDeterminationType parcelLandCapabilityDeterminationType)
        {
            return new ParcelLandCapabilityDeterminationTypePrimaryKey(parcelLandCapabilityDeterminationType);
        }
    }
}