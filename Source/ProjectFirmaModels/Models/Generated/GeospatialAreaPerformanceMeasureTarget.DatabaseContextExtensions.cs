//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaPerformanceMeasureTarget GetGeospatialAreaPerformanceMeasureTarget(this IQueryable<GeospatialAreaPerformanceMeasureTarget> geospatialAreaPerformanceMeasureTargets, int geospatialAreaPerformanceMeasureTargetID)
        {
            var geospatialAreaPerformanceMeasureTarget = geospatialAreaPerformanceMeasureTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureTargetID == geospatialAreaPerformanceMeasureTargetID);
            Check.RequireNotNullThrowNotFound(geospatialAreaPerformanceMeasureTarget, "GeospatialAreaPerformanceMeasureTarget", geospatialAreaPerformanceMeasureTargetID);
            return geospatialAreaPerformanceMeasureTarget;
        }

    }
}