using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaPerformanceMeasureNoTargetModelExtensions
    {
        public static GeospatialAreaPerformanceMeasureNoTarget GetOrCreateGeospatialAreaPerformanceMeasureNoTarget(PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            var noTarget = HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureNoTargets.SingleOrDefault(pmnt =>pmnt.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID && pmnt.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            if (noTarget == null)
            {
                noTarget = new GeospatialAreaPerformanceMeasureNoTarget(geospatialArea, performanceMeasure);
            }

            return noTarget;
        }
    }
}