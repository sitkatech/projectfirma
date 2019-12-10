using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaPerformanceMeasureOverallTargetModelExtensions
    {
        public static GeospatialAreaPerformanceMeasureOverallTarget
            GetOrCreateGeospatialAreaPerformanceMeasureOverallTarget(PerformanceMeasure performanceMeasure,
                GeospatialArea geospatialArea, double overallTargetValue)
        {
            var overallTarget = HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureOverallTargets.SingleOrDefault(pmot => pmot.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID && pmot.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            if (overallTarget == null)
            {
                overallTarget = new GeospatialAreaPerformanceMeasureOverallTarget(geospatialArea, performanceMeasure, overallTargetValue);
            }

            return overallTarget;
        }
    }
}