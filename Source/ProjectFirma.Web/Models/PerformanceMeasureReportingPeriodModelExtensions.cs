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
            var performanceMeasureReportingPeriod = performanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear);

            return performanceMeasureReportingPeriod ?? new PerformanceMeasureReportingPeriod(calendarYear, calendarYear.ToString());
        }

        public static double? GetTargetValue(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.PerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID)?.PerformanceMeasureTargetValue;
        }

        public static double? GetGeospatialAreaTargetValue(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            return performanceMeasure.GeospatialAreaPerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID && x.GeospatialAreaID == geospatialArea.GeospatialAreaID)?.GeospatialAreaPerformanceMeasureTargetValue;
        }

        public static string GetTargetValueLabel(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.PerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID)?.PerformanceMeasureTargetValueLabel;
        }

        public static string GetGeospatialAreaTargetValueLabel(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            return performanceMeasure.GeospatialAreaPerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID && x.GeospatialAreaID == geospatialArea.GeospatialAreaID)?.GeospatialAreaPerformanceMeasureTargetValueLabel;
        }
    }
}