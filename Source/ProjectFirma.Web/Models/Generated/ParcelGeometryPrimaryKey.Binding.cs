//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ParcelGeometry
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ParcelGeometryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ParcelGeometry>
    {
        public ParcelGeometryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ParcelGeometryPrimaryKey(ParcelGeometry parcelGeometry) : base(parcelGeometry){}

        public static implicit operator ParcelGeometryPrimaryKey(int primaryKeyValue)
        {
            return new ParcelGeometryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ParcelGeometryPrimaryKey(ParcelGeometry parcelGeometry)
        {
            return new ParcelGeometryPrimaryKey(parcelGeometry);
        }
    }
}