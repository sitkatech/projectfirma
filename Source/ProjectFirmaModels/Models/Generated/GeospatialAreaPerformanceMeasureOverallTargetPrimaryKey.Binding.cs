//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaPerformanceMeasureOverallTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureOverallTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaPerformanceMeasureOverallTarget>
    {
        public GeospatialAreaPerformanceMeasureOverallTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaPerformanceMeasureOverallTargetPrimaryKey(GeospatialAreaPerformanceMeasureOverallTarget geospatialAreaPerformanceMeasureOverallTarget) : base(geospatialAreaPerformanceMeasureOverallTarget){}

        public static implicit operator GeospatialAreaPerformanceMeasureOverallTargetPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaPerformanceMeasureOverallTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaPerformanceMeasureOverallTargetPrimaryKey(GeospatialAreaPerformanceMeasureOverallTarget geospatialAreaPerformanceMeasureOverallTarget)
        {
            return new GeospatialAreaPerformanceMeasureOverallTargetPrimaryKey(geospatialAreaPerformanceMeasureOverallTarget);
        }
    }
}