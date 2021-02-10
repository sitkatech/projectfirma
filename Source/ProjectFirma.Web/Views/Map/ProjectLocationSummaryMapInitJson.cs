/*-----------------------------------------------------------------------
<copyright file="ProjectLocationSummaryMapInitJson.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Map
{
    public class ProjectLocationSummaryMapInitJson : MapInitJson
    {
        private const int DefaultZoomLevel = 10;
        /* used by ProjectFirmaMaps.ProjectLocationSummary.js */
        public double? ProjectLocationXCoord { get; }
        public double? ProjectLocationYCoord { get; }
        public bool HasViewableSimpleLocation { get; }
        public bool HasDetailedLocation { get; }
        public bool HasGeospatialAreas { get; }
        /* used by ProjectFirmaMaps.ProjectLocationSummary.js */

        public ProjectLocationSummaryMapInitJson(IProject iProject, FirmaSession currentFirmaSession, string mapDivID, 
            List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreas, FeatureCollection detailedLocationAsGeoJsonFeatureCollection, 
            FeatureCollection simpleLocationToGeoJsonFeatureCollection, bool callGetExternalMapLayers, bool userCanViewPrivateLocations, bool alwaysHideGeospatialAreaLayers = false) 
            : base(mapDivID, DefaultZoomLevel, GetConfiguredGeospatialAreaMapLayers(alwaysHideGeospatialAreaLayers), 
                callGetExternalMapLayers ? GetExternalMapLayers() : new List<ExternalMapLayer>(), 
                GetProjectBoundingBox(iProject, userCanViewPrivateLocations))
        {
            HasViewableSimpleLocation = iProject.HasProjectLocationPoint(userCanViewPrivateLocations);
            if (HasViewableSimpleLocation)
            {
                var projectLocationPoint = iProject.GetProjectLocationPoint(userCanViewPrivateLocations);
                ProjectLocationYCoord = projectLocationPoint.YCoordinate;
                ProjectLocationXCoord = projectLocationPoint.XCoordinate;
                Layers.Add(
                    new LayerGeoJson(
                        $"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} - Simple", 
                        simpleLocationToGeoJsonFeatureCollection, "#ffff00", 1, 
                        LayerInitialVisibility.GetInitialVisibility(!detailedLocationAsGeoJsonFeatureCollection.Features.Any()))
                    );
            }

            HasDetailedLocation = iProject.HasProjectLocationDetailed(userCanViewPrivateLocations);
            if (HasDetailedLocation)
            {
                Layers.Add(
                    new LayerGeoJson(
                        $"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} - Detail", 
                        detailedLocationAsGeoJsonFeatureCollection, "blue", 1, LayerInitialVisibility.LayerInitialVisibilityEnum.Show));
            }

            HasGeospatialAreas = geospatialAreas.Any();
            if (HasGeospatialAreas)
            {
               foreach(var geospatialAreaTypeGroup in geospatialAreas.GroupBy(x => x.GeospatialAreaType).OrderBy(x => x.Key.GeospatialAreaTypeName))
               {
                   Layers.Add(
                       new LayerGeoJson(
                           $"Selected {geospatialAreaTypeGroup.Key.GeospatialAreaTypeNamePluralized}", 
                           geospatialAreaTypeGroup.ToGeoJsonFeatureCollection(), "#2dc3a1", 1, 
                           LayerInitialVisibility.LayerInitialVisibilityEnum.Hide));
               }
            }
        }

        public ProjectLocationSummaryMapInitJson(IProject iProject, FirmaSession currentFirmaSession, string mapDivID,
            List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreas,
            FeatureCollection detailedLocationAsGeoJsonFeatureCollection,
            FeatureCollection simpleLocationToGeoJsonFeatureCollection, bool alwaysHideGeospatialAreaLayers, bool userCanViewPrivateLocations) : 
            this(iProject, currentFirmaSession, mapDivID, geospatialAreas, detailedLocationAsGeoJsonFeatureCollection, simpleLocationToGeoJsonFeatureCollection,
                true, userCanViewPrivateLocations, alwaysHideGeospatialAreaLayers)
        {
        }

        public static BoundingBox GetProjectBoundingBox(IProject project, bool userCanViewPrivateLocations)
        {
            return BoundingBox.MakeBoundingBoxFromProject(project, userCanViewPrivateLocations);
        }
    }
}
