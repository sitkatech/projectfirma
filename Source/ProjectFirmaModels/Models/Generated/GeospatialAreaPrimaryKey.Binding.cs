//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialArea
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialArea>
    {
        public GeospatialAreaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaPrimaryKey(GeospatialArea geospatialArea) : base(geospatialArea){}

        public static implicit operator GeospatialAreaPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaPrimaryKey(GeospatialArea geospatialArea)
        {
            return new GeospatialAreaPrimaryKey(geospatialArea);
        }
    }
}