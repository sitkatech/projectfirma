//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Parcel
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Parcel>
    {
        public ParcelPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelPrimaryKey(Parcel parcel) : base(parcel){}

        public static implicit operator ParcelPrimaryKey(int primaryKeyValue)
        {
            return new ParcelPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelPrimaryKey(Parcel parcel)
        {
            return new ParcelPrimaryKey(parcel);
        }
    }
}