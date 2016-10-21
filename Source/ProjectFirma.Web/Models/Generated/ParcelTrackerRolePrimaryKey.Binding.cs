//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelTrackerRole
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelTrackerRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelTrackerRole>
    {
        public ParcelTrackerRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelTrackerRolePrimaryKey(ParcelTrackerRole parcelTrackerRole) : base(parcelTrackerRole){}

        public static implicit operator ParcelTrackerRolePrimaryKey(int primaryKeyValue)
        {
            return new ParcelTrackerRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelTrackerRolePrimaryKey(ParcelTrackerRole parcelTrackerRole)
        {
            return new ParcelTrackerRolePrimaryKey(parcelTrackerRole);
        }
    }
}