//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportingPeriodTarget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureReportingPeriodTarget GetPerformanceMeasureReportingPeriodTarget(this IQueryable<PerformanceMeasureReportingPeriodTarget> performanceMeasureReportingPeriodTargets, int performanceMeasureReportingPeriodTargetID)
        {
            var performanceMeasureReportingPeriodTarget = performanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodTargetID == performanceMeasureReportingPeriodTargetID);
            Check.RequireNotNullThrowNotFound(performanceMeasureReportingPeriodTarget, "PerformanceMeasureReportingPeriodTarget", performanceMeasureReportingPeriodTargetID);
            return performanceMeasureReportingPeriodTarget;
        }

    }
}