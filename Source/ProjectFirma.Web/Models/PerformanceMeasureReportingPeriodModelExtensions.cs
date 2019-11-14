using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureReportingPeriodModelExtensions
    {
        public static PerformanceMeasureReportingPeriod GetOrCreatePerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, PerformanceMeasure performanceMeasure, int calendarYear)
        {
            var performanceMeasureReportingPeriod = performanceMeasureReportingPeriods.SingleOrDefault(x => 
                                                                                                       x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID 
                                                                                                       && x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear);

            return performanceMeasureReportingPeriod ?? new PerformanceMeasureReportingPeriod(performanceMeasure, calendarYear, calendarYear.ToString());
        }
    }
}