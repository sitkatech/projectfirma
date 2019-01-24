using System.Collections.Generic;
using System.Linq;
using GeoJSON.Net;
using GeoJSON.Net.Feature;
using LtInfo.Common;

namespace ProjectFirmaModels.Models
{
    public partial class OrganizationBoundaryStaging : IAuditableEntity
    {
        public string GetAuditDescriptionString() =>
            $"Organization boundary staging {Organization?.OrganizationName ?? "(Organization Not Found)"}";

        public FeatureCollection ToGeoJsonFeatureCollection()
        {
            return JsonTools.DeserializeObject<FeatureCollection>(GeoJson);
        }

        public static bool IsUsableFeatureCollectionGeoJson(FeatureCollection featureCollection)
        {
            return featureCollection.Features.Any(IsUsableFeatureGeoJson);
        }

        public static bool IsUsableFeatureGeoJson(Feature feature)
        {
            return new List<GeoJSONObjectType> { GeoJSONObjectType.Polygon, GeoJSONObjectType.MultiPolygon }.Contains(feature.Geometry.Type);
        }
    }
}
