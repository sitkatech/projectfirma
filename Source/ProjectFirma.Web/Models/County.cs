using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public partial class County
    {
        public static GeoJSON.Net.Feature.FeatureCollection ToGeoJsonFeatureCollection(List<County> counties)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();
            featureCollection.Features.AddRange(counties.Select(MakeFeatureWithRelevantProperties).ToList());
            return featureCollection;
        }

        private static GeoJSON.Net.Feature.Feature MakeFeatureWithRelevantProperties(County county)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(county.CountyFeature);
            feature.Properties.Add("State", county.StateProvince.StateProvinceAbbreviation);
            feature.Properties.Add("County", county.CountyName);
            return feature;
        }
    }
}