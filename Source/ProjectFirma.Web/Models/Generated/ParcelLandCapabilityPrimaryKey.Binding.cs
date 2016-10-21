//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelLandCapability
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelLandCapabilityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelLandCapability>
    {
        public ParcelLandCapabilityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelLandCapabilityPrimaryKey(ParcelLandCapability parcelLandCapability) : base(parcelLandCapability){}

        public static implicit operator ParcelLandCapabilityPrimaryKey(int primaryKeyValue)
        {
            return new ParcelLandCapabilityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelLandCapabilityPrimaryKey(ParcelLandCapability parcelLandCapability)
        {
            return new ParcelLandCapabilityPrimaryKey(parcelLandCapability);
        }
    }
}