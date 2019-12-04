//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaPerformanceMeasureTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaPerformanceMeasureTarget>
    {
        public GeospatialAreaPerformanceMeasureTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaPerformanceMeasureTargetPrimaryKey(GeospatialAreaPerformanceMeasureTarget geospatialAreaPerformanceMeasureTarget) : base(geospatialAreaPerformanceMeasureTarget){}

        public static implicit operator GeospatialAreaPerformanceMeasureTargetPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaPerformanceMeasureTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaPerformanceMeasureTargetPrimaryKey(GeospatialAreaPerformanceMeasureTarget geospatialAreaPerformanceMeasureTarget)
        {
            return new GeospatialAreaPerformanceMeasureTargetPrimaryKey(geospatialAreaPerformanceMeasureTarget);
        }
    }
}