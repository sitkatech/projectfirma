/*-----------------------------------------------------------------------
<copyright file="Watershed.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public partial class Watershed : IAuditableEntity
    {
        public string DisplayName => WatershedName;

        public List<Project> GetAssociatedProjects(Person person)
        {
            return ProjectWatersheds.Select(ptc => ptc.Project).ToList().GetActiveProjectsAndProposals(person.CanViewProposals);
        }

        public static bool IsWatershedNameUnique(IEnumerable<Watershed> watersheds, string watershedName, int currentWatershedID)
        {
            var watershed = watersheds.SingleOrDefault(x => x.WatershedID != currentWatershedID && String.Equals(x.WatershedName, watershedName, StringComparison.InvariantCultureIgnoreCase));
            return watershed == null;
        }

        public string AuditDescriptionString => WatershedName;

        public Feature MakeFeatureWithRelevantProperties()
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(WatershedFeature);
            feature.Properties.Add(FieldDefinition.Watershed.GetFieldDefinitionLabel(), GetDisplayNameAsUrl().ToString());
            return feature;
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(GetDetailUrl(), DisplayName);
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<WatershedController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));

        public string GetDetailUrl()
        {
            return DetailUrlTemplate.ParameterReplace(WatershedID);
        }

        public static readonly UrlTemplate<int> MapTooltipUrlTemplate = new UrlTemplate<int>(SitkaRoute<WatershedController>.BuildUrlFromExpression(t => t.MapTooltip(UrlTemplate.Parameter1Int)));

        public static LayerGeoJson GetWatershedWmsLayerGeoJson(string layerColor, decimal layerOpacity,
            LayerInitialVisibility layerInitialVisibility)
        {
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            return new LayerGeoJson(FieldDefinition.Watershed.GetFieldDefinitionLabel(), tenantAttribute.MapServiceUrl,
                tenantAttribute.WatershedLayerName, MapTooltipUrlTemplate.UrlTemplateString, layerColor, layerOpacity,
                layerInitialVisibility);
        }

        public static List<LayerGeoJson> GetWatershedAndAssociatedProjectLayers(Watershed watershed, List<Project> projects)
        {
            if (MultiTenantHelpers.HasWatershedMapServiceUrl())
            {

                return new List<LayerGeoJson>
                {
                    new LayerGeoJson(watershed.DisplayName,
                        new List<Watershed> {watershed}.ToGeoJsonFeatureCollection(), "#2dc3a1", 1,
                        LayerInitialVisibility.Show),
                    GetWatershedWmsLayerGeoJson("#59ACFF", 0.6m, LayerInitialVisibility.Show),
                    new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Simple",
                        Project.MappedPointsToGeoJsonFeatureCollection(new List<IMappableProject>(projects), true, false),
                        "#ffff00", 1, LayerInitialVisibility.Show)
                };
            }
            return new List<LayerGeoJson>();
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(WatershedName, WatershedName, false) {MapUrl = null};

            var projectChildren = ProjectWatersheds.Select(x => x.Project).OrderBy(x => x.DisplayName)
                .Select(x => x.ToFancyTreeNode()).ToList();
            fancyTreeNode.Children = projectChildren.ToList();

            return fancyTreeNode;
        }

        public PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            var projectIDs = ProjectWatersheds.Select(x => x.ProjectID).ToList();
            return new PerformanceMeasureChartViewData(performanceMeasure, projectIDs, currentPerson, false);
        }
    }
}
