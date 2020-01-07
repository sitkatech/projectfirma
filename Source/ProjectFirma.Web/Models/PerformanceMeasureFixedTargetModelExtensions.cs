using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureFixedTargetModelExtensions
    {
        public static PerformanceMeasureFixedTarget GetOrCreatePerformanceMeasureFixedTarget(this PerformanceMeasure performanceMeasure, double fixedTargetValue)
        {
            var fixedTarget = HttpRequestStorage.DatabaseEntities.PerformanceMeasureFixedTargets.SingleOrDefault(pmot => pmot.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID);
            if (fixedTarget == null)
            {
                fixedTarget = new PerformanceMeasureFixedTarget(performanceMeasure)
                {
                    PerformanceMeasureTargetValue = fixedTargetValue
                };
            }

            return fixedTarget;
        }
    }
}