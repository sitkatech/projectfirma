using System;
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
        public readonly string ProjectLocationAreaName;
        public readonly string ProjectLocationAreaType;
        public bool HasDetailedLocation;

        public ProjectLocationSummaryMapInitJson(IProject project, string mapDivID) 
            : base(mapDivID, DefaultZoomLevel, GetWatershedAndJurisdictionMapLayers(), BoundingBox.MakeNewDefaultBoundingBox())
        {
            ProjectLocationSimpleTypeID = project.ProjectLocationSimpleType.ProjectLocationSimpleTypeID;            
            switch (project.ProjectLocationSimpleType.ToEnum)
            {
                case ProjectLocationSimpleTypeEnum.NamedAreas:
                    BoundingBox = new BoundingBox(project.ProjectLocationArea.GetGeometry());
                    ProjectLocationAreaName = project.ProjectLocationArea.ProjectLocationAreaDisplayName;
                    ProjectLocationAreaType = project.ProjectLocationArea.ProjectLocationAreaGroup.ProjectLocationAreaGroupType.ProjectLocationAreaGroupTypeDisplayName;
                    break;
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                    if (project.ProjectLocationPoint == null)
                    {
                        break;
                    }
                    BoundingBox = new BoundingBox(new Point(project.ProjectLocationPoint.YCoordinate.Value, project.ProjectLocationPoint.XCoordinate.Value), 0.25m);
                    ProjectLocationYCoord = project.ProjectLocationPoint.YCoordinate;
                    ProjectLocationXCoord = project.ProjectLocationPoint.XCoordinate;
                    break;
                case ProjectLocationSimpleTypeEnum.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid ProjectLocationType \"{0}\"", project.ProjectLocationSimpleType));
            }

            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            HasDetailedLocation = detailedLocationGeoJsonFeatureCollection.Features.Any();

            Layers.Add(new LayerGeoJson("Project Location - Simple", project.SimpleLocationToGeoJsonFeatureCollection(true), "red", 1, HasDetailedLocation ? LayerInitialVisibility.Hide : LayerInitialVisibility.Show));
            Layers.Add(new LayerGeoJson("Project Location - Detail", detailedLocationGeoJsonFeatureCollection, "blue", 1, LayerInitialVisibility.Show));

            if (HasDetailedLocation)
            {
                BoundingBox = new BoundingBox(project.GetProjectLocationDetails().Select(x => x.ProjectLocationGeometry));
            }
        }
    }
}