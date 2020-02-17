using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaPerformanceMeasureFixedTargetModelExtensions
    {
        public static GeospatialAreaPerformanceMeasureFixedTarget GetOrCreateGeospatialAreaPerformanceMeasureFixedTarget(this PerformanceMeasure performanceMeasure,
                                                                                                                         GeospatialArea geospatialArea, 
                                                                                                                         double fixedTargetValue)
        {
            var fixedTarget = HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureFixedTargets.SingleOrDefault(pmot => pmot.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID && pmot.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            if (fixedTarget == null)
            {
                fixedTarget = new GeospatialAreaPerformanceMeasureFixedTarget(geospatialArea, performanceMeasure, fixedTargetValue);
            }

            return fixedTarget;
        }
    }
}