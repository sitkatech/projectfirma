//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureFixedTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureFixedTarget GetPerformanceMeasureFixedTarget(this IQueryable<PerformanceMeasureFixedTarget> performanceMeasureFixedTargets, int performanceMeasureFixedTargetID)
        {
            var performanceMeasureFixedTarget = performanceMeasureFixedTargets.SingleOrDefault(x => x.PerformanceMeasureFixedTargetID == performanceMeasureFixedTargetID);
            Check.RequireNotNullThrowNotFound(performanceMeasureFixedTarget, "PerformanceMeasureFixedTarget", performanceMeasureFixedTargetID);
            return performanceMeasureFixedTarget;
        }

    }
}