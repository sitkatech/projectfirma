//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureNoTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaPerformanceMeasureNoTarget GetGeospatialAreaPerformanceMeasureNoTarget(this IQueryable<GeospatialAreaPerformanceMeasureNoTarget> geospatialAreaPerformanceMeasureNoTargets, int geospatialAreaPerformanceMeasureNoTargetID)
        {
            var geospatialAreaPerformanceMeasureNoTarget = geospatialAreaPerformanceMeasureNoTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureNoTargetID == geospatialAreaPerformanceMeasureNoTargetID);
            Check.RequireNotNullThrowNotFound(geospatialAreaPerformanceMeasureNoTarget, "GeospatialAreaPerformanceMeasureNoTarget", geospatialAreaPerformanceMeasureNoTargetID);
            return geospatialAreaPerformanceMeasureNoTarget;
        }

    }
}