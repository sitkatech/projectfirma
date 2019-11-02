//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportingPeriod]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        // Delete using an IDList (Firma style)
        public static void DeletePerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, List<int> performanceMeasureReportingPeriodIDList)
        {
            if(performanceMeasureReportingPeriodIDList.Any())
            {
                performanceMeasureReportingPeriods.Where(x => performanceMeasureReportingPeriodIDList.Contains(x.PerformanceMeasureReportingPeriodID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, ICollection<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsToDelete)
        {
            if(performanceMeasureReportingPeriodsToDelete.Any())
            {
                var performanceMeasureReportingPeriodIDList = performanceMeasureReportingPeriodsToDelete.Select(x => x.PerformanceMeasureReportingPeriodID).ToList();
                performanceMeasureReportingPeriods.Where(x => performanceMeasureReportingPeriodIDList.Contains(x.PerformanceMeasureReportingPeriodID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, int performanceMeasureReportingPeriodID)
        {
            DeletePerformanceMeasureReportingPeriod(performanceMeasureReportingPeriods, new List<int> { performanceMeasureReportingPeriodID });
        }

        public static void DeletePerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriodToDelete)
        {
            DeletePerformanceMeasureReportingPeriod(performanceMeasureReportingPeriods, new List<PerformanceMeasureReportingPeriod> { performanceMeasureReportingPeriodToDelete });
        }
    }
}