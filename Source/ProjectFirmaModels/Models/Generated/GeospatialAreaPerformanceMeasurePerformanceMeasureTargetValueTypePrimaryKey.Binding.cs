//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType>
    {
        public GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypePrimaryKey(GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType) : base(geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType){}

        public static implicit operator GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypePrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypePrimaryKey(GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType)
        {
            return new GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypePrimaryKey(geospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType);
        }
    }
}