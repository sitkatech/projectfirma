/*-----------------------------------------------------------------------
<copyright file="ProjectLocationSummaryMapInitJson.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Data.Entity.Spatial;
using System.Linq;
using NUnit.Framework;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Map
{
    public class ProjectLocationSummaryMapInitJson : MapInitJson
    {
        private const int DefaultZoomLevel = 10;
        public readonly double? ProjectLocationXCoord;
        public readonly double? ProjectLocationYCoord;
        public bool HasSimpleLocation;
        public bool HasDetailedLocation;
        public bool HasWatersheds;

        public ProjectLocationSummaryMapInitJson(IProject project, string mapDivID) 
            : base(mapDivID, DefaultZoomLevel, GetAllWatershedMapLayers(LayerInitialVisibility.Hide), BoundingBox.MakeNewDefaultBoundingBox())
        {
            var simpleLocationGeoJsonFeatureCollection = project.SimpleLocationToGeoJsonFeatureCollection(true);
            HasSimpleLocation = simpleLocationGeoJsonFeatureCollection.Features.Any();
            if (HasSimpleLocation)
            {
                ProjectLocationYCoord = project.ProjectLocationPoint.YCoordinate;
                ProjectLocationXCoord = project.ProjectLocationPoint.XCoordinate;
                Layers.Add(new LayerGeoJson($"{Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Simple", project.SimpleLocationToGeoJsonFeatureCollection(true), "#ffff00", 1, HasDetailedLocation ? LayerInitialVisibility.Hide : LayerInitialVisibility.Show));
            }

            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            HasDetailedLocation = detailedLocationGeoJsonFeatureCollection.Features.Any();
            if (HasDetailedLocation)
            {
                Layers.Add(new LayerGeoJson($"{Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Detail", detailedLocationGeoJsonFeatureCollection, "blue", 1, LayerInitialVisibility.Show));    
            }

            HasWatersheds = project.GetProjectWatersheds().Any();
            if (HasWatersheds)
            {
               project.GetProjectWatersheds()
                .ToList()
                .ForEach(watershed => Layers.Add(new LayerGeoJson(watershed.DisplayName,
                    new List<Models.Watershed> {watershed}.ToGeoJsonFeatureCollection(), "#2dc3a1", 1,
                    LayerInitialVisibility.Show))); 
            } 

            BoundingBox = GetProjectBoundingBox(project);         
        }

        public static BoundingBox GetProjectBoundingBox(IProject project)
        {
            Point simpleLocationPoint = null;
            if (project.ProjectLocationPoint != null)
            {
                simpleLocationPoint = new Point(project.ProjectLocationPoint.YCoordinate ?? 0,
                    project.ProjectLocationPoint.XCoordinate ?? 0);
            }

            var detailAndWatershedGeometries = project.GetProjectLocationDetails().Select(x => x.ProjectLocationGeometry).Union(project.GetProjectWatersheds().Select(x => x.WatershedFeature));

            var pointList = detailAndWatershedGeometries.SelectMany(BoundingBox.GetPointsFromDbGeometry).ToList();
            if (simpleLocationPoint != null)
            {
                pointList.Add(simpleLocationPoint);
            }
            return !pointList.Any() ? BoundingBox.MakeNewDefaultBoundingBox() : new BoundingBox(pointList);
        }
    }
}
