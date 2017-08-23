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
using System.Linq;  
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Map
{
    public class ProjectLocationSummaryMapInitJson : MapInitJson
    {
        private const int DefaultZoomLevel = 10;
        public readonly int ProjectLocationSimpleTypeID;
        public readonly double? ProjectLocationXCoord;
        public readonly double? ProjectLocationYCoord;
        public bool HasDetailedLocation;

        public ProjectLocationSummaryMapInitJson(IProject project, string mapDivID) 
            : base(mapDivID, DefaultZoomLevel, GetWatershedMapLayers(LayerInitialVisibility.Show), BoundingBox.MakeNewDefaultBoundingBox())
        {
            ProjectLocationSimpleTypeID = project.ProjectLocationSimpleType.ProjectLocationSimpleTypeID;            
            switch (project.ProjectLocationSimpleType.ToEnum)
            {
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                    if (project.ProjectLocationPoint == null)
                    {
                        break;
                    }
                    BoundingBox = new BoundingBox(new Point(project.ProjectLocationPoint.YCoordinate ?? 0, project.ProjectLocationPoint.XCoordinate ?? 0), 0.25m);
                    ProjectLocationYCoord = project.ProjectLocationPoint.YCoordinate;
                    ProjectLocationXCoord = project.ProjectLocationPoint.XCoordinate;
                    break;
                case ProjectLocationSimpleTypeEnum.None:
                    Layers = GetWatershedMapLayers(LayerInitialVisibility.Hide);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid ProjectLocationType \"{project.ProjectLocationSimpleType}\"");
            }

            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            HasDetailedLocation = detailedLocationGeoJsonFeatureCollection.Features.Any();

            Layers.Add(new LayerGeoJson($"{Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Simple", project.SimpleLocationToGeoJsonFeatureCollection(true), "#ffff00", 1, HasDetailedLocation ? LayerInitialVisibility.Hide : LayerInitialVisibility.Show));
            Layers.Add(new LayerGeoJson($"{Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - Detail", detailedLocationGeoJsonFeatureCollection, "blue", 1, LayerInitialVisibility.Show));
            Layers.Add(new LayerGeoJson($"{Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} - {Models.FieldDefinition.Watershed.GetFieldDefinitionLabel()}", detailedLocationGeoJsonFeatureCollection, "red", 0.7m, LayerInitialVisibility.Show));

            project.GetProjectWatersheds()
                .ToList()
                .ForEach(watershed => Layers.Add(new LayerGeoJson(watershed.DisplayName,
                    new List<Models.Watershed> {watershed}.ToGeoJsonFeatureCollection(), "red", 1,
                    LayerInitialVisibility.Show)));

            if (HasDetailedLocation)
            {
                BoundingBox = new BoundingBox(project.GetProjectLocationDetails().Select(x => x.ProjectLocationGeometry));
            }


        }
    }
}
