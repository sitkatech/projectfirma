//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GeospatialAreaPerformanceMeasureReportingPeriodTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GeospatialAreaPerformanceMeasureReportingPeriodTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GeospatialAreaPerformanceMeasureReportingPeriodTarget>
    {
        public GeospatialAreaPerformanceMeasureReportingPeriodTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GeospatialAreaPerformanceMeasureReportingPeriodTargetPrimaryKey(GeospatialAreaPerformanceMeasureReportingPeriodTarget geospatialAreaPerformanceMeasureReportingPeriodTarget) : base(geospatialAreaPerformanceMeasureReportingPeriodTarget){}

        public static implicit operator GeospatialAreaPerformanceMeasureReportingPeriodTargetPrimaryKey(int primaryKeyValue)
        {
            return new GeospatialAreaPerformanceMeasureReportingPeriodTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator GeospatialAreaPerformanceMeasureReportingPeriodTargetPrimaryKey(GeospatialAreaPerformanceMeasureReportingPeriodTarget geospatialAreaPerformanceMeasureReportingPeriodTarget)
        {
            return new GeospatialAreaPerformanceMeasureReportingPeriodTargetPrimaryKey(geospatialAreaPerformanceMeasureReportingPeriodTarget);
        }
    }
}