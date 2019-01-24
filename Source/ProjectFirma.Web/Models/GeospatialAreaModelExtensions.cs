/*-----------------------------------------------------------------------
<copyright file="GeospatialAreaModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.PerformanceMeasure;

namespace ProjectFirmaModels.Models
{
    public static class GeospatialAreaModelExtensions
    {
        public static FeatureCollection ToGeoJsonFeatureCollection(this IEnumerable<GeospatialArea> geospatialAreas)
        {
            return new FeatureCollection(geospatialAreas.Select(x => x.MakeFeatureWithRelevantProperties()).ToList());
        }

        public static List<GeospatialArea> GetGeospatialAreasContainingProjectLocation(this IEnumerable<GeospatialArea> geospatialAreas, IProject project)
        {
            return project?.ProjectLocationPoint == null
                ? new List<GeospatialArea>()
                : geospatialAreas.Where(x =>
                    x.GeospatialAreaFeature.Contains(project.ProjectLocationPoint)).ToList();
        }

        public static HtmlString GetDisplayNameAsUrl(this GeospatialArea geospatialArea)
        {
            return UrlTemplate.MakeHrefString(geospatialArea.GetDetailUrl(), geospatialArea.GetDisplayName());
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));

        public static string GetDetailUrl(this GeospatialArea geospatialArea)
        {
            return DetailUrlTemplate.ParameterReplace(geospatialArea.GeospatialAreaID);
        }

        public static readonly UrlTemplate<int> MapTooltipUrlTemplate = new UrlTemplate<int>(SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.MapTooltip(UrlTemplate.Parameter1Int)));

        public static LayerGeoJson GetGeospatialAreaWmsLayerGeoJson(this GeospatialAreaType geospatialAreaType,
            string layerColor, decimal layerOpacity,
            LayerInitialVisibility layerInitialVisibility)
        {
            return new LayerGeoJson(geospatialAreaType.GeospatialAreaTypeNamePluralized, geospatialAreaType.MapServiceUrl,
                geospatialAreaType.GeospatialAreaLayerName, MapTooltipUrlTemplate.UrlTemplateString, layerColor, layerOpacity,
                layerInitialVisibility);
        }

        public static List<LayerGeoJson> GetGeospatialAreaAndAssociatedProjectLayers(this GeospatialArea geospatialArea, List<Project> projects)
        {
            var projectLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} - Simple",
                projects.MappedPointsToGeoJsonFeatureCollection(true, false),
                "#ffff00", 1, LayerInitialVisibility.Show);
            var geospatialAreaLayerGeoJson = new LayerGeoJson(geospatialArea.GetDisplayName(),
                new List<GeospatialArea> { geospatialArea }.ToGeoJsonFeatureCollection(), "#2dc3a1", 1,
                LayerInitialVisibility.Show);

            var layerGeoJsons = new List<LayerGeoJson>
            {
                projectLayerGeoJson,
                geospatialAreaLayerGeoJson,
                geospatialArea.GeospatialAreaType.GetGeospatialAreaWmsLayerGeoJson("#59ACFF", 0.6m,
                    LayerInitialVisibility.Show)
            };

            return layerGeoJsons;
        }

        public static PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(this GeospatialArea geospatialArea,
            PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            var projects = geospatialArea.GetAssociatedProjects(currentPerson);
            return new PerformanceMeasureChartViewData(performanceMeasure, currentPerson, false, projects);
        }
    }
}
