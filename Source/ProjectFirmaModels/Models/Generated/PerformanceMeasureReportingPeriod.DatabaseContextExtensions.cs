//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportingPeriod]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureReportingPeriod GetPerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, int performanceMeasureReportingPeriodID)
        {
            var performanceMeasureReportingPeriod = performanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriodID);
            Check.RequireNotNullThrowNotFound(performanceMeasureReportingPeriod, "PerformanceMeasureReportingPeriod", performanceMeasureReportingPeriodID);
            return performanceMeasureReportingPeriod;
        }

    }
}