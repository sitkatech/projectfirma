using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureOverallTargetModelExtensions
    {
        public static PerformanceMeasureOverallTarget
            GetOrCreatePerformanceMeasureOverallTarget(PerformanceMeasure performanceMeasure,
                double overallTargetValue)
        {
            var overallTarget = HttpRequestStorage.DatabaseEntities.PerformanceMeasureOverallTargets.SingleOrDefault(pmot => pmot.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID);
            if (overallTarget == null)
            {
                overallTarget = new PerformanceMeasureOverallTarget(performanceMeasure)
                {
                    PerformanceMeasureTargetValue = overallTargetValue
                };
            }

            return overallTarget;
        }
    }
}