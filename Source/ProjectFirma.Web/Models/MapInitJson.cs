/*-----------------------------------------------------------------------
<copyright file="MapInitJson.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class MapInitJson
    {
        public const int CoordinateSystemId = 4326;

        public string MapDivID;
        public BoundingBox BoundingBox;
        public int ZoomLevel;
        public List<LayerGeoJson> Layers;
        public List<ExternalMapLayer> ExternalMapLayers;
        public readonly bool TurnOnFeatureIdentify;
        public bool AllowFullScreen = true;
        public bool DisablePopups = false;
        public string RequestSupportUrl;

        public MapInitJson(string mapDivID, int zoomLevel, List<LayerGeoJson> layers, List<ExternalMapLayer> externalMapLayers, BoundingBox boundingBox, bool turnOnFeatureIdentify)
        {
            MapDivID = mapDivID;
            ZoomLevel = zoomLevel;
            Layers = layers;
            ExternalMapLayers = externalMapLayers;
            BoundingBox = boundingBox;
            TurnOnFeatureIdentify = turnOnFeatureIdentify;
            RequestSupportUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.RequestSupport());
        }

        /// <summary>
        /// Summary maps with no editing should use this constructor
        /// </summary>
        public MapInitJson(string mapDivID, int zoomLevel, List<LayerGeoJson> layers, List<ExternalMapLayer> externalMapLayers, BoundingBox boundingBox) : this(mapDivID, zoomLevel, layers, externalMapLayers, boundingBox, true)
        {
        }

        public static List<ExternalMapLayer> GetExternalMapLayers()
        {
            return HttpRequestStorage.DatabaseEntities.ExternalMapLayers.Where(x => x.IsActive && x.DisplayOnAllProjectMaps).ToList();
        }

        public static List<ExternalMapLayer> GetExternalMapLayersForFullProjectMap()
        {
            return HttpRequestStorage.DatabaseEntities.ExternalMapLayers.Where(x => x.IsActive).ToList();
        }

        public static List<LayerGeoJson> GetAllGeospatialAreaMapLayers(LayerInitialVisibility layerInitialVisibility)
        {
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName)
                .ToList();
            var layerGeoJsons = new List<LayerGeoJson>();
            foreach (var geospatialAreaType in geospatialAreaTypes)
            {
                layerGeoJsons.Add(geospatialAreaType.GetGeospatialAreaWmsLayerGeoJson("#59ACFF", 0.2m,
                    layerInitialVisibility));
            }

            return layerGeoJsons;
        }

        public static List<LayerGeoJson> GetGeospatialAreaMapLayersForGeospatialAreaType(GeospatialAreaType geospatialAreaType, LayerInitialVisibility layerInitialVisibility)
        {
            var layerGeoJsons = new List<LayerGeoJson>
            {
                geospatialAreaType.GetGeospatialAreaWmsLayerGeoJson("#59ACFF", 0.2m,
                    layerInitialVisibility)
            };

            return layerGeoJsons;
        }

        public static List<LayerGeoJson> GetProjectLocationSimpleMapLayer(IProject project)
        {
            var layerGeoJsons = new List<LayerGeoJson>();
            if (project.ProjectLocationPoint != null)
            {
                layerGeoJsons.Add(new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} - Simple",
                    new FeatureCollection(new List<Feature>
                    {
                        DbGeometryToGeoJsonHelper.FromDbGeometry(project.ProjectLocationPoint)
                    }),
                    "#838383", 1, LayerInitialVisibility.Show));
            }
            return layerGeoJsons;
        }

        public static List<LayerGeoJson> GetProjectLocationSimpleAndDetailedMapLayers(ProjectUpdate projectUpdate)
        {
            var layerGeoJsons = new List<LayerGeoJson>();
            if (projectUpdate.ProjectLocationPoint != null)
            {
                layerGeoJsons.AddRange(GetProjectLocationSimpleMapLayer(projectUpdate));                
            }
            var detailedLocationGeoJsonFeatureCollection = projectUpdate.DetailedLocationToGeoJsonFeatureCollection();
            if (detailedLocationGeoJsonFeatureCollection.Features.Any())
            {
                layerGeoJsons.Add(new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} - Detail", detailedLocationGeoJsonFeatureCollection, "#838383", 1, LayerInitialVisibility.Show));
            }
            return layerGeoJsons;
        }

        public static List<LayerGeoJson> GetProjectLocationSimpleAndDetailedMapLayers(Project project)
        {
            var layerGeoJsons = new List<LayerGeoJson>();
            if (project.ProjectLocationPoint != null)
            {
                layerGeoJsons.AddRange(GetProjectLocationSimpleMapLayer(project));                
            }
            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            if (detailedLocationGeoJsonFeatureCollection.Features.Any())
            {
                layerGeoJsons.Add(new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} - Detail", detailedLocationGeoJsonFeatureCollection, "#838383", 1, LayerInitialVisibility.Show));
            }
            return layerGeoJsons;
        }
    }
}
