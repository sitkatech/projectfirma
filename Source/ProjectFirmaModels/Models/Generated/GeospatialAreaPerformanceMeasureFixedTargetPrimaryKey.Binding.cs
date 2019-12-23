//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaPerformanceMeasureFixedTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureFixedTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaPerformanceMeasureFixedTarget>
    {
        public GeospatialAreaPerformanceMeasureFixedTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaPerformanceMeasureFixedTargetPrimaryKey(GeospatialAreaPerformanceMeasureFixedTarget geospatialAreaPerformanceMeasureFixedTarget) : base(geospatialAreaPerformanceMeasureFixedTarget){}

        public static implicit operator GeospatialAreaPerformanceMeasureFixedTargetPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaPerformanceMeasureFixedTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaPerformanceMeasureFixedTargetPrimaryKey(GeospatialAreaPerformanceMeasureFixedTarget geospatialAreaPerformanceMeasureFixedTarget)
        {
            return new GeospatialAreaPerformanceMeasureFixedTargetPrimaryKey(geospatialAreaPerformanceMeasureFixedTarget);
        }
    }
}