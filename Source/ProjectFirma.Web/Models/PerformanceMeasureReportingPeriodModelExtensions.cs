using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureReportingPeriodModelExtensions
    {
        public static PerformanceMeasureReportingPeriod GetOrCreatePerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, int calendarYear)
        {
            var performanceMeasureReportingPeriod = performanceMeasureReportingPeriods.FirstOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear);//todo: change to SingleOrDefault once bad data is removed

            return performanceMeasureReportingPeriod ?? new PerformanceMeasureReportingPeriod(calendarYear, calendarYear.ToString());
        }

        public static double? GetTargetValue(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.PerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID)?.PerformanceMeasureTargetValue;
        }

        public static string GetTargetValueLabel(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.PerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID)?.PerformanceMeasureTargetValueLabel;
        }

    }
}