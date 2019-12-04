//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureTarget GetPerformanceMeasureTarget(this IQueryable<PerformanceMeasureTarget> performanceMeasureTargets, int performanceMeasureTargetID)
        {
            var performanceMeasureTarget = performanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureTargetID == performanceMeasureTargetID);
            Check.RequireNotNullThrowNotFound(performanceMeasureTarget, "PerformanceMeasureTarget", performanceMeasureTargetID);
            return performanceMeasureTarget;
        }

    }
}