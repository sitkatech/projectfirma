//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelStatus
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelStatus>
    {
        public ParcelStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelStatusPrimaryKey(ParcelStatus parcelStatus) : base(parcelStatus){}

        public static implicit operator ParcelStatusPrimaryKey(int primaryKeyValue)
        {
            return new ParcelStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelStatusPrimaryKey(ParcelStatus parcelStatus)
        {
            return new ParcelStatusPrimaryKey(parcelStatus);
        }
    }
}