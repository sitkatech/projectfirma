//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class GeospatialAreaTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaType>
    {
        public GeospatialAreaTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaTypePrimaryKey(GeospatialAreaType geospatialAreaType) : base(geospatialAreaType){}

        public static implicit operator GeospatialAreaTypePrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaTypePrimaryKey(GeospatialAreaType geospatialAreaType)
        {
            return new GeospatialAreaTypePrimaryKey(geospatialAreaType);
        }
    }
}