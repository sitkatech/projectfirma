﻿/*-----------------------------------------------------------------------
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GeoJson;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaModelExtensions
    {
        public static FeatureCollection ToGeoJsonFeatureCollection(this IEnumerable<GeospatialArea> geospatialAreas)
        {
            return new FeatureCollection(geospatialAreas.Select(x => x.MakeFeatureWithRelevantProperties()).ToList());
        }

        public static List<fGeoServerGeospatialAreaAreasContainingProjectLocation_Result> GetGeospatialAreasContainingProjectLocation( IProject project,int? geoSpatialAreaTypeID)
        {
            return project?.ProjectLocationPoint == null
                ? new List<fGeoServerGeospatialAreaAreasContainingProjectLocation_Result>()
                : HttpRequestStorage.DatabaseEntities.GetfGeoServerGeospatialAreaAreasContainingProjectLocations(project.ProjectOrProjectUpdateID
                    , project.IsProject
                    , geoSpatialAreaTypeID).ToList();
        }

        public static HtmlString GetDisplayNameAsUrl(this GeospatialArea geospatialArea)
        {
            return UrlTemplate.MakeHrefString(geospatialArea.GetDetailUrl(), geospatialArea.GeospatialAreaShortName);
        }

        public static HtmlString GetDisplayNameAsUrl(this vGeospatialArea geospatialArea)
        {
            return UrlTemplate.MakeHrefString(geospatialArea.GetDetailUrl(), geospatialArea.GeospatialAreaShortName);
        }

        public static string GetDetailUrl(this vGeospatialArea geospatialArea)
        {
            return GetDetailUrl(geospatialArea.GeospatialAreaID);
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));

        public static string GetDetailUrl(this GeospatialArea geospatialArea)
        {
            return GetDetailUrl(geospatialArea.GeospatialAreaID);
        }

        public static string GetDetailUrl(int geospatialAreaID)
        {
            return DetailUrlTemplate.ParameterReplace(geospatialAreaID);
        }

        public static readonly UrlTemplate<int> MapTooltipUrlTemplate =
            new UrlTemplate<int>(
                SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(
                    t => t.MapTooltip(UrlTemplate.Parameter1Int)));

        public static LayerGeoJson GetGeospatialAreaWmsLayerGeoJson(this GeospatialAreaType geospatialAreaType,
            string layerColor, decimal layerOpacity,
            LayerInitialVisibility layerInitialVisibility)
        {
            return new LayerGeoJson(geospatialAreaType.GeospatialAreaTypeNamePluralized,
                geospatialAreaType.MapServiceUrl(),
                geospatialAreaType.GeospatialAreaLayerName, MapTooltipUrlTemplate.UrlTemplateString, layerColor,
                layerOpacity,
                layerInitialVisibility);
        }

        public static List<LayerGeoJson> GetGeospatialAreaAndAssociatedProjectLayers(this GeospatialArea geospatialArea,
            List<Project> projects)
        {
            var projectLayerGeoJson = new LayerGeoJson(
                $"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} - Simple",
                projects.MappedPointsToGeoJsonFeatureCollection(true, false),
                "#ffff00", 1, LayerInitialVisibility.Show);
            var geospatialAreaLayerGeoJson = new LayerGeoJson(geospatialArea.GeospatialAreaShortName,
                new List<GeospatialArea> {geospatialArea}.ToGeoJsonFeatureCollection(), "#2dc3a1", 1,
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

        public static PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(
            this GeospatialArea geospatialArea,
            PerformanceMeasure performanceMeasure,
            FirmaSession currentFirmaSession)
        {
            var projects = geospatialArea.GetAssociatedProjects(currentFirmaSession);
            return new PerformanceMeasureChartViewData(geospatialArea, performanceMeasure, currentFirmaSession, false, projects);
        }

        public static List<Project> GetAssociatedProjects(this GeospatialArea geospatialArea, FirmaSession currentFirmaSession)
        {
            return geospatialArea.ProjectGeospatialAreas.Select(ptc => ptc.Project).ToList()
                .GetActiveProjectsAndProposals(currentFirmaSession.Person.CanViewProposals());
        }

        public static Feature MakeFeatureWithRelevantProperties(this GeospatialArea geospatialArea)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(geospatialArea.GeospatialAreaFeature);
            feature.Properties.Add(geospatialArea.GeospatialAreaType.GeospatialAreaTypeName,
                geospatialArea.GetDisplayNameAsUrl().ToString());
            return feature;
        }

        public static List<GeospatialAreaIndexGridSimple> GetGeospatialAreaIndexGridSimples(GeospatialAreaType geospatialAreaType, List<int> projectIDsViewableByUser)
        {
            var results = from geospatialArea in HttpRequestStorage.DatabaseEntities.GeospatialAreas
                join projectGeospatialArea in HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreas.Where(x => projectIDsViewableByUser.Contains(x.ProjectID))
                    on geospatialArea.GeospatialAreaID equals projectGeospatialArea.GeospatialAreaID
                    into x
                where geospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID
                from x2 in x.DefaultIfEmpty()
                group x2 by new { geospatialArea.GeospatialAreaID, geospatialArea.GeospatialAreaShortName } into grouped
                select new GeospatialAreaIndexGridSimple()
                {
                    GeospatialAreaID = grouped.Key.GeospatialAreaID,
                    GeospatialAreaShortName = grouped.Key.GeospatialAreaShortName,
                    ProjectViewableByUserCount = grouped.Count(t => t.ProjectGeospatialAreaID > 0)
                };

            var geospatialAreaIndexGridSimplesNew = results.ToList();
            return geospatialAreaIndexGridSimplesNew;
        }

        public static string GetDeleteGeospatialAreaPerformanceMeasureTargetUrl(this GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure)
        {
            return SitkaRoute<GeospatialAreaPerformanceMeasureTargetController>.BuildUrlFromExpression(t => t.Delete(geospatialArea.GeospatialAreaID, performanceMeasure.PerformanceMeasureID));
        }

        public static string GetEditGeospatialAreaPerformanceMeasureTargetUrl(this GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure)
        {
            return SitkaRoute<GeospatialAreaPerformanceMeasureTargetController>.BuildUrlFromExpression(t => t.Edit(geospatialArea.GeospatialAreaID, performanceMeasure.PerformanceMeasureID));
        }

        /*
        public static string GetTargetValueDisplayForGrid(this GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure)
        {
            if (!performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).Any(x => x.GeospatialAreaPerformanceMeasureTargetValue.HasValue))
            {
                return "No Target Set";
            }

            if (performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).Select(x => $"{x.GeospatialAreaPerformanceMeasureTargetValue}{x.GeospatialAreaPerformanceMeasureTargetValueLabel}").Distinct().Count() == 1)
            {
                //we know all targetValues are the same so just get the first geospatial target
                var geospatialAreaPerformanceMeasureTarget = performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).First(x => x.GeospatialAreaPerformanceMeasureTargetValue.HasValue);
                Check.EnsureNotNull(geospatialAreaPerformanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue, "geospatialAreaPerformanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue != null");
                var targetValue = geospatialAreaPerformanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue.Value.ToString();
                var performanceMeasureMeasurementUnitType = geospatialAreaPerformanceMeasureTarget.PerformanceMeasure.MeasurementUnitType;
                var measurementUnit = performanceMeasureMeasurementUnitType == MeasurementUnitType.Number ? "" : performanceMeasureMeasurementUnitType.LegendDisplayName;
                return $"{targetValue} {measurementUnit}";
            }
            return "Target by Year";
        }
        */

        public static string GetTargetValueDisplayForGrid(this GeospatialArea geospatialArea, PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureTargetValueTypeEnum performanceMeasureTargetValueTypeEnum = performanceMeasure.GetPerformanceMeasureTargetValueTypeForGeospatialArea(geospatialArea);

            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    return "No Target";
                case PerformanceMeasureTargetValueTypeEnum.FixedTarget:
                    var areaPerformanceMeasureFixedTarget =
                        performanceMeasure.GeospatialAreaPerformanceMeasureFixedTargets.SingleOrDefault(x =>
                            x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
                    Check.EnsureNotNull(areaPerformanceMeasureFixedTarget);
                    Check.EnsureNotNull(areaPerformanceMeasureFixedTarget.GeospatialAreaPerformanceMeasureTargetValue, "geospatialAreaPerformanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue != null");
                    var targetValue = areaPerformanceMeasureFixedTarget.GeospatialAreaPerformanceMeasureTargetValue.ToString();
                    var performanceMeasureMeasurementUnitType = areaPerformanceMeasureFixedTarget.PerformanceMeasure.MeasurementUnitType;
                    var measurementUnit = performanceMeasureMeasurementUnitType == MeasurementUnitType.Number ? "" : performanceMeasureMeasurementUnitType.LegendDisplayName;
                    return $"{targetValue} {measurementUnit}";
                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    return "Target By Year";
                default:
                    throw new NotImplementedException("There should never be a valid target value type here");
            }

        }



    }
}

