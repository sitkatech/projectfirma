/*-----------------------------------------------------------------------
<copyright file="GeospatialArea.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.GeoJson;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.PerformanceMeasure;

namespace ProjectFirma.Web.Models
{
    public partial class GeospatialArea : IAuditableEntity
    {
        public string DisplayName => GeospatialAreaName;

        public List<Project> GetAssociatedProjects(Person person)
        {
            return ProjectGeospatialAreas.Select(ptc => ptc.Project).ToList().GetActiveProjectsAndProposals(person.CanViewProposals);
        }

        public static bool IsGeospatialAreaNameUnique(IEnumerable<GeospatialArea> geospatialAreas, string geospatialAreaName, int currentGeospatialAreaID)
        {
            var geospatialArea = geospatialAreas.SingleOrDefault(x => x.GeospatialAreaID != currentGeospatialAreaID && string.Equals(x.GeospatialAreaName, geospatialAreaName, StringComparison.InvariantCultureIgnoreCase));
            return geospatialArea == null;
        }

        public string AuditDescriptionString => GeospatialAreaName;

        public Feature MakeFeatureWithRelevantProperties()
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(GeospatialAreaFeature);
            feature.Properties.Add(GeospatialAreaType.GeospatialAreaTypeName, GetDisplayNameAsUrl().ToString());
            return feature;
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(GetDetailUrl(), DisplayName);
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));

        public string GetDetailUrl()
        {
            return DetailUrlTemplate.ParameterReplace(GeospatialAreaID);
        }

        public static readonly UrlTemplate<int> MapTooltipUrlTemplate = new UrlTemplate<int>(SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.MapTooltip(UrlTemplate.Parameter1Int)));

        public static LayerGeoJson GetGeospatialAreaWmsLayerGeoJson(GeospatialAreaType geospatialAreaType,
            string layerColor, decimal layerOpacity,
            LayerInitialVisibility layerInitialVisibility)
        {
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            return new LayerGeoJson(geospatialAreaType.GeospatialAreaTypeNamePluralized, tenantAttribute.MapServiceUrl,
                tenantAttribute.GeospatialAreaLayerName, MapTooltipUrlTemplate.UrlTemplateString, layerColor, layerOpacity,
                layerInitialVisibility);
        }

        public static List<LayerGeoJson> GetGeospatialAreaAndAssociatedProjectLayers(GeospatialArea geospatialArea, List<Project> projects)
        {
            var geospatialAreaType = geospatialArea.GeospatialAreaType;
            var projectLayerGeoJson = new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Simple",
                Project.MappedPointsToGeoJsonFeatureCollection(new List<IMappableProject>(projects), true, false),
                "#ffff00", 1, LayerInitialVisibility.Show);
            var geospatialAreaLayerGeoJson = new LayerGeoJson(geospatialArea.DisplayName,
                new List<GeospatialArea> { geospatialArea }.ToGeoJsonFeatureCollection(), "#2dc3a1", 1,
                LayerInitialVisibility.Show);

            var layerGeoJsons = new List<LayerGeoJson>{projectLayerGeoJson, geospatialAreaLayerGeoJson};
            if (MultiTenantHelpers.HasGeospatialAreaMapServiceUrl())
            {

                layerGeoJsons.Add(GetGeospatialAreaWmsLayerGeoJson(geospatialArea.GeospatialAreaType, "#59ACFF", 0.6m, LayerInitialVisibility.Show));
            }
            else
            {
                var geospatialAreas = geospatialAreaType.GeospatialAreas.ToList();
                if (geospatialAreas.Any())
                {
                    layerGeoJsons.Add(new LayerGeoJson(geospatialAreaType.GeospatialAreaTypeName,
                        geospatialAreas.ToGeoJsonFeatureCollection(), "#59ACFF", 0.6m,
                        LayerInitialVisibility.Show));
                }
            }
            return layerGeoJsons;
        }     

        public FancyTreeNode ToFancyTreeNode(Person currentPerson)
        {
            var fancyTreeNode = new FancyTreeNode(GeospatialAreaName, GeospatialAreaName, false) {MapUrl = null};

            var projectChildren = GetAssociatedProjects(currentPerson).OrderBy(x => x.DisplayName)
                .Select(x => x.ToFancyTreeNode()).ToList();
            fancyTreeNode.Children = projectChildren.ToList();

            return fancyTreeNode;
        }

        public PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            var projects = GetAssociatedProjects(currentPerson);
            return new PerformanceMeasureChartViewData(performanceMeasure, currentPerson, false, projects);
        }
    }
}
