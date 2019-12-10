//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaPerformanceMeasureNoTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureNoTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaPerformanceMeasureNoTarget>
    {
        public GeospatialAreaPerformanceMeasureNoTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaPerformanceMeasureNoTargetPrimaryKey(GeospatialAreaPerformanceMeasureNoTarget geospatialAreaPerformanceMeasureNoTarget) : base(geospatialAreaPerformanceMeasureNoTarget){}

        public static implicit operator GeospatialAreaPerformanceMeasureNoTargetPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaPerformanceMeasureNoTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaPerformanceMeasureNoTargetPrimaryKey(GeospatialAreaPerformanceMeasureNoTarget geospatialAreaPerformanceMeasureNoTarget)
        {
            return new GeospatialAreaPerformanceMeasureNoTargetPrimaryKey(geospatialAreaPerformanceMeasureNoTarget);
        }
    }
}