/*-----------------------------------------------------------------------
<copyright file="MapInitJson.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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

        public static List<LayerGeoJson> GetWatershedMapLayers()
        {
            var layerGeoJsons = new List<LayerGeoJson>();
            var watersheds = HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures();
            var geoJsonForWatersheds = Watershed.ToGeoJsonFeatureCollection(watersheds);
            layerGeoJsons.Add(new LayerGeoJson("Watershed", geoJsonForWatersheds, "#90C3D4", 0.1m, LayerInitialVisibility.Show));
            return layerGeoJsons;
        }

        public static List<LayerGeoJson> GetWatershedLayers(Watershed watershed, List<Project> projects)
        {
            var layerGeoJsons = new List<LayerGeoJson>
            {
                new LayerGeoJson(watershed.DisplayName, Watershed.ToGeoJsonFeatureCollection(new List<Watershed> {watershed}), "red", 1, LayerInitialVisibility.Show),
                new LayerGeoJson("Watersheds",
                    Watershed.ToGeoJsonFeatureCollection(HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures().Where(x => x.WatershedID != watershed.WatershedID).ToList()), "#59ACFF", 0.6m, LayerInitialVisibility.Show),
                new LayerGeoJson("Project Location - Simple", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show),
                new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show)
            };
            return layerGeoJsons;
        }
    }
}
