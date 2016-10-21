//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelDistanceFromTownCenter
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelDistanceFromTownCenterPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelDistanceFromTownCenter>
    {
        public ParcelDistanceFromTownCenterPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelDistanceFromTownCenterPrimaryKey(ParcelDistanceFromTownCenter parcelDistanceFromTownCenter) : base(parcelDistanceFromTownCenter){}

        public static implicit operator ParcelDistanceFromTownCenterPrimaryKey(int primaryKeyValue)
        {
            return new ParcelDistanceFromTownCenterPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelDistanceFromTownCenterPrimaryKey(ParcelDistanceFromTownCenter parcelDistanceFromTownCenter)
        {
            return new ParcelDistanceFromTownCenterPrimaryKey(parcelDistanceFromTownCenter);
        }
    }
}