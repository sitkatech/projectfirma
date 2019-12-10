//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaPerformanceMeasureOverallTarget GetGeospatialAreaPerformanceMeasureOverallTarget(this IQueryable<GeospatialAreaPerformanceMeasureOverallTarget> geospatialAreaPerformanceMeasureOverallTargets, int geospatialAreaPerformanceMeasureOverallTargetID)
        {
            var geospatialAreaPerformanceMeasureOverallTarget = geospatialAreaPerformanceMeasureOverallTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureOverallTargetID == geospatialAreaPerformanceMeasureOverallTargetID);
            Check.RequireNotNullThrowNotFound(geospatialAreaPerformanceMeasureOverallTarget, "GeospatialAreaPerformanceMeasureOverallTarget", geospatialAreaPerformanceMeasureOverallTargetID);
            return geospatialAreaPerformanceMeasureOverallTarget;
        }

    }
}