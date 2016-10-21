using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public static class ProjectLocationModelExtensions
    {
        public static GeoJSON.Net.Feature.FeatureCollection ToGeoJsonFeatureCollection(this IEnumerable<IProjectLocation> projectLocations)
        {
            return new GeoJSON.Net.Feature.FeatureCollection(projectLocations.Select(x =>
            {
                var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(x.ProjectLocationGeometry);
                feature.Properties.Add("Info", x.Annotation);
                return feature;
            }).ToList());
        }

        public static string ToGeoJsonString(this GeoJSON.Net.Feature.FeatureCollection featureCollection)
        {
            return JsonTools.SerializeObject(featureCollection);
        }
    }
}