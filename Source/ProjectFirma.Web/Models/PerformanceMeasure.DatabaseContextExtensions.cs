using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasure GetPerformanceMeasureByPerformanceMeasureName(this IQueryable<PerformanceMeasure> performanceMeasures, string performanceMeasureName)
        {
            var performanceMeasure = performanceMeasures.SingleOrDefault(x => x.PerformanceMeasureName == performanceMeasureName);
            Check.RequireNotNullThrowNotFound(performanceMeasure, "PerformanceMeasure", performanceMeasureName);
            return performanceMeasure;
        }
    }
}