//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaStaging
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaStagingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaStaging>
    {
        public GeospatialAreaStagingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaStagingPrimaryKey(GeospatialAreaStaging geospatialAreaStaging) : base(geospatialAreaStaging){}

        public static implicit operator GeospatialAreaStagingPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaStagingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaStagingPrimaryKey(GeospatialAreaStaging geospatialAreaStaging)
        {
            return new GeospatialAreaStagingPrimaryKey(geospatialAreaStaging);
        }
    }
}