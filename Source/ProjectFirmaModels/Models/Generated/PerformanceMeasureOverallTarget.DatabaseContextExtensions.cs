//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureOverallTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureOverallTarget GetPerformanceMeasureOverallTarget(this IQueryable<PerformanceMeasureOverallTarget> performanceMeasureOverallTargets, int performanceMeasureOverallTargetID)
        {
            var performanceMeasureOverallTarget = performanceMeasureOverallTargets.SingleOrDefault(x => x.PerformanceMeasureOverallTargetID == performanceMeasureOverallTargetID);
            Check.RequireNotNullThrowNotFound(performanceMeasureOverallTarget, "PerformanceMeasureOverallTarget", performanceMeasureOverallTargetID);
            return performanceMeasureOverallTarget;
        }

    }
}