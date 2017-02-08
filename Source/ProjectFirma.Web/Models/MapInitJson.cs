using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class MapInitJson
    {
        public const int CoordinateSystemId = 4326;

        public string MapDivID;
        public BoundingBox BoundingBox;
        public int ZoomLevel;
        public List<LayerGeoJson> Layers;
        public readonly bool TurnOnFeatureIdentify;
        public bool AllowFullScreen = true;

        public MapInitJson(string mapDivID, int zoomLevel, List<LayerGeoJson> layers, BoundingBox boundingBox, bool turnOnFeatureIdentify)
        {
            MapDivID = mapDivID;
            ZoomLevel = zoomLevel;
            Layers = layers;
            BoundingBox = boundingBox;
            TurnOnFeatureIdentify = turnOnFeatureIdentify;
        }

        /// <summary>
        /// Summary maps with no editing should use this constructor
        /// </summary>
        public MapInitJson(string mapDivID, int zoomLevel, List<LayerGeoJson> layers, BoundingBox boundingBox) : this(mapDivID, zoomLevel, layers, boundingBox, true)
        {
        }

        public static List<LayerGeoJson> GetWatershedAndJurisdictionMapLayers()
        {
            var layerGeoJsons = new List<LayerGeoJson>();
            var jurisdictions = HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures();
            var geoJsonForJurisdictions = Jurisdiction.ToGeoJsonFeatureCollection(jurisdictions);
            layerGeoJsons.Add(new LayerGeoJson("County/City", geoJsonForJurisdictions, "#FF6C2D", 0.6m, LayerInitialVisibility.Hide));

            var watersheds = HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures();
            var geoJsonForWatersheds = Models.Watershed.ToGeoJsonFeatureCollection(watersheds);
            layerGeoJsons.Add(new LayerGeoJson("Watershed", geoJsonForWatersheds, "#90C3D4", 0.1m, LayerInitialVisibility.Show));
            return layerGeoJsons;
        }

        public static List<LayerGeoJson> GetWatershedLayers(Watershed watershed, List<Models.Project> projects)
        {
            var layerGeoJsons = new List<LayerGeoJson>
            {
                new LayerGeoJson(watershed.DisplayName, Models.Watershed.ToGeoJsonFeatureCollection(new List<Models.Watershed> {watershed}), "red", 1, LayerInitialVisibility.Show),
                new LayerGeoJson("Watersheds",
                    Watershed.ToGeoJsonFeatureCollection(HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures().Where(x => x.WatershedID != watershed.WatershedID).ToList()), "#59ACFF", 0.6m, LayerInitialVisibility.Show),
                new LayerGeoJson("County/City", Jurisdiction.ToGeoJsonFeatureCollection(HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures()), "#FF6C2D", 0.6m, LayerInitialVisibility.Hide),
                new LayerGeoJson("Project Location - Simple", Models.Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show),
                new LayerGeoJson("Named Areas", Models.Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show)
            };
            return layerGeoJsons;
        }
    }
}