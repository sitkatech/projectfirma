using System.Drawing;
using System.Linq;
using GeoJSON.Net.Feature;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// example: Jurisdiction layer or Road layer
    /// </summary>
    public class LayerGeoJson
    {
        public readonly decimal LayerOpacity;
        public readonly LayerInitialVisibility LayerInitialVisibility;
        public readonly string LayerName;
        public readonly string LayerColor;
        public readonly FeatureCollection GeoJsonFeatureCollection;
        public readonly bool HasCustomPopups;

        public LayerGeoJson(string layerName, FeatureCollection geoJsonFeatureCollection, string layerColor, decimal layerOpacity, LayerInitialVisibility layerInitialVisibility)
        {
            LayerOpacity = layerOpacity;
            LayerInitialVisibility = layerInitialVisibility;
            LayerName = layerName;

            if (layerColor.StartsWith("#"))
            {
                LayerColor = layerColor;   
            }
            else
            {                
                var color = Color.FromName(layerColor);
                LayerColor = string.Format("#{0:x2}{1:x2}{2:x2}", color.R, color.G, color.B);
            }
            
            GeoJsonFeatureCollection = geoJsonFeatureCollection;
            HasCustomPopups = geoJsonFeatureCollection.Features.Any(x => x.Properties.ContainsKey("PopupUrl"));
        }

        public string ToGeoJsonString()
        {
            return JsonTools.SerializeObject(this);
        }
    }
}