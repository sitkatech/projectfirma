//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureFixedTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaPerformanceMeasureFixedTarget GetGeospatialAreaPerformanceMeasureFixedTarget(this IQueryable<GeospatialAreaPerformanceMeasureFixedTarget> geospatialAreaPerformanceMeasureFixedTargets, int geospatialAreaPerformanceMeasureFixedTargetID)
        {
            var geospatialAreaPerformanceMeasureFixedTarget = geospatialAreaPerformanceMeasureFixedTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureFixedTargetID == geospatialAreaPerformanceMeasureFixedTargetID);
            Check.RequireNotNullThrowNotFound(geospatialAreaPerformanceMeasureFixedTarget, "GeospatialAreaPerformanceMeasureFixedTarget", geospatialAreaPerformanceMeasureFixedTargetID);
            return geospatialAreaPerformanceMeasureFixedTarget;
        }

    }
}