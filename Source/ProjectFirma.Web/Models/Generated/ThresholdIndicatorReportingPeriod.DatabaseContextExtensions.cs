//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorReportingPeriod]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ThresholdIndicatorReportingPeriod GetThresholdIndicatorReportingPeriod(this IQueryable<ThresholdIndicatorReportingPeriod> thresholdIndicatorReportingPeriods, int thresholdIndicatorReportingPeriodID)
        {
            var thresholdIndicatorReportingPeriod = thresholdIndicatorReportingPeriods.SingleOrDefault(x => x.ThresholdIndicatorReportingPeriodID == thresholdIndicatorReportingPeriodID);
            Check.RequireNotNullThrowNotFound(thresholdIndicatorReportingPeriod, "ThresholdIndicatorReportingPeriod", thresholdIndicatorReportingPeriodID);
            return thresholdIndicatorReportingPeriod;
        }

        public static void DeleteThresholdIndicatorReportingPeriod(this IQueryable<ThresholdIndicatorReportingPeriod> thresholdIndicatorReportingPeriods, List<int> thresholdIndicatorReportingPeriodIDList)
        {
            if(thresholdIndicatorReportingPeriodIDList.Any())
            {
                thresholdIndicatorReportingPeriods.Where(x => thresholdIndicatorReportingPeriodIDList.Contains(x.ThresholdIndicatorReportingPeriodID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorReportingPeriod(this IQueryable<ThresholdIndicatorReportingPeriod> thresholdIndicatorReportingPeriods, ICollection<ThresholdIndicatorReportingPeriod> thresholdIndicatorReportingPeriodsToDelete)
        {
            if(thresholdIndicatorReportingPeriodsToDelete.Any())
            {
                var thresholdIndicatorReportingPeriodIDList = thresholdIndicatorReportingPeriodsToDelete.Select(x => x.ThresholdIndicatorReportingPeriodID).ToList();
                thresholdIndicatorReportingPeriods.Where(x => thresholdIndicatorReportingPeriodIDList.Contains(x.ThresholdIndicatorReportingPeriodID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorReportingPeriod(this IQueryable<ThresholdIndicatorReportingPeriod> thresholdIndicatorReportingPeriods, int thresholdIndicatorReportingPeriodID)
        {
            DeleteThresholdIndicatorReportingPeriod(thresholdIndicatorReportingPeriods, new List<int> { thresholdIndicatorReportingPeriodID });
        }

        public static void DeleteThresholdIndicatorReportingPeriod(this IQueryable<ThresholdIndicatorReportingPeriod> thresholdIndicatorReportingPeriods, ThresholdIndicatorReportingPeriod thresholdIndicatorReportingPeriodToDelete)
        {
            DeleteThresholdIndicatorReportingPeriod(thresholdIndicatorReportingPeriods, new List<ThresholdIndicatorReportingPeriod> { thresholdIndicatorReportingPeriodToDelete });
        }
    }
}