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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Map
{
    public class ProjectLocationSummaryMapInitJson : MapInitJson
    {
        private const int DefaultZoomLevel = 10;
        /* used by ProjectFirmaMaps.ProjectLocationSummary.js */
        public double? ProjectLocationXCoord { get; }
        public double? ProjectLocationYCoord { get; }
        public bool HasSimpleLocation { get; }
        public bool HasDetailedLocation { get; }
        public bool HasGeospatialAreas { get; }
        /* used by ProjectFirmaMaps.ProjectLocationSummary.js */

        public ProjectLocationSummaryMapInitJson(IProject project, string mapDivID, bool addProjectProperties, List<Models.GeospatialArea> geospatialAreas) 
            : base(mapDivID, DefaultZoomLevel, GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Hide), GetProjectBoundingBox(project))
        {
            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            HasDetailedLocation = detailedLocationGeoJsonFeatureCollection.Features.Any();
            if (HasDetailedLocation)
            {
                ProjectLocationYCoord = project.ProjectLocationPoint.YCoordinate;
                ProjectLocationXCoord = project.ProjectLocationPoint.XCoordinate;
                Layers.Add(new LayerGeoJson($"{Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Detail", detailedLocationGeoJsonFeatureCollection, "blue", 1, LayerInitialVisibility.Show));    
            }

            var simpleLocationGeoJsonFeatureCollection = project.SimpleLocationToGeoJsonFeatureCollection(addProjectProperties);
            HasSimpleLocation = simpleLocationGeoJsonFeatureCollection.Features.Any();
            if (HasSimpleLocation)
            {
                Layers.Add(new LayerGeoJson($"{Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Simple", project.SimpleLocationToGeoJsonFeatureCollection(addProjectProperties), "#ffff00", 1, HasDetailedLocation ? LayerInitialVisibility.Hide : LayerInitialVisibility.Show));
            }

            HasGeospatialAreas = geospatialAreas.Any();
            if (HasGeospatialAreas)
            {
               geospatialAreas.ForEach(geospatialArea => Layers.Add(new LayerGeoJson(geospatialArea.DisplayName,
                    new List<Models.GeospatialArea> {geospatialArea}.ToGeoJsonFeatureCollection(), "#2dc3a1", 1,
                    LayerInitialVisibility.Show))); 
            }
        }

        public static BoundingBox GetProjectBoundingBox(IProject project)
        {
            return BoundingBox.MakeBoundingBoxFromProject(project);
        }
    }
}
