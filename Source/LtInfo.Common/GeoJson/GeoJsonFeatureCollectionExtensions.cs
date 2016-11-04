using System.Collections.Generic;
using System.Linq;
using GeoJSON.Net.Feature;

namespace LtInfo.Common.GeoJson
{
    public static class GeoJsonFeatureCollectionExtensions
    {
        public static List<string> GetFeaturePropertyNames(this FeatureCollection featureCollection)
        {
            return featureCollection.Features.First().Properties.Keys.ToList();
        }
    }
}