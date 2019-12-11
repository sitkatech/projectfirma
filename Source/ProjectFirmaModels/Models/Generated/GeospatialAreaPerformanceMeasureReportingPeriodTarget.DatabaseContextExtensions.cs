//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureReportingPeriodTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaPerformanceMeasureReportingPeriodTarget GetGeospatialAreaPerformanceMeasureReportingPeriodTarget(this IQueryable<GeospatialAreaPerformanceMeasureReportingPeriodTarget> geospatialAreaPerformanceMeasureReportingPeriodTargets, int geospatialAreaPerformanceMeasureReportingPeriodTargetID)
        {
            var geospatialAreaPerformanceMeasureReportingPeriodTarget = geospatialAreaPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID == geospatialAreaPerformanceMeasureReportingPeriodTargetID);
            Check.RequireNotNullThrowNotFound(geospatialAreaPerformanceMeasureReportingPeriodTarget, "GeospatialAreaPerformanceMeasureReportingPeriodTarget", geospatialAreaPerformanceMeasureReportingPeriodTargetID);
            return geospatialAreaPerformanceMeasureReportingPeriodTarget;
        }

    }
}