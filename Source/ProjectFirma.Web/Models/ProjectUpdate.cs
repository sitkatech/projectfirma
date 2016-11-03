using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectUpdate : IProject
    {
        public int EntityID
        {
            get { return ProjectUpdateID; }
        }
        public string DisplayName { get { return ProjectUpdateBatch.Project.DisplayName; } }

        public decimal? UnfundedNeed
        {
            get { return EstimatedTotalCost - SecuredFunding; }
        }

        public ProjectUpdate(ProjectUpdateBatch projectUpdateBatch) : this(projectUpdateBatch, projectUpdateBatch.Project.ProjectStage, projectUpdateBatch.Project.ProjectDescription, projectUpdateBatch.Project.ProjectLocationSimpleType)
        {
            var project = projectUpdateBatch.Project;
            LoadUpdateFromProject(project);
            LoadSimpleLocationFromProject(project);
        }

        public void LoadUpdateFromProject(Project project)
        {
            ProjectDescription = project.ProjectDescription;
            ProjectStageID = project.ProjectStageID;
            PlanningDesignStartYear = project.PlanningDesignStartYear;
            ImplementationStartYear = project.ImplementationStartYear;
            CompletionYear = project.CompletionYear;
            SecuredFunding = project.SecuredFunding;
            EstimatedTotalCost = project.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost;
        }

        public void LoadSimpleLocationFromProject(Project project)
        {
            ProjectLocationAreaID = project.ProjectLocationAreaID;
            ProjectLocationPoint = project.ProjectLocationPoint;
            ProjectLocationNotes = project.ProjectLocationNotes;
            ProjectLocationSimpleTypeID = project.ProjectLocationSimpleTypeID;
        }

        public void CommitChangesToProject(Project project)
        {
            project.ProjectDescription = ProjectDescription;
            project.ProjectStageID = ProjectStageID;
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.ImplementationStartYear = ImplementationStartYear;
            project.CompletionYear = CompletionYear;
            project.SecuredFunding = SecuredFunding;
            project.EstimatedTotalCost = EstimatedTotalCost;
            project.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost;
        }

        public void CommitSimpleLocationToProject(Project project)
        {
            project.ProjectLocationAreaID = ProjectLocationAreaID;
            project.ProjectLocationPoint = ProjectLocationPoint;
            project.ProjectLocationNotes = ProjectLocationNotes;
            project.ProjectLocationSimpleTypeID = ProjectLocationSimpleTypeID;
        }

        public bool HasProjectLocationPoint
        {
            get { return ProjectLocationPoint != null; }
        }

        public double? ProjectLocationPointLatitude
        {
            get { return HasProjectLocationPoint ? ProjectLocationPoint.YCoordinate : null; }
        }

        public double? ProjectLocationPointLongitude
        {
            get { return HasProjectLocationPoint ? ProjectLocationPoint.XCoordinate : null; }
        }

        public FundingType FundingType
        {
            get { return ProjectUpdateBatch.Project.FundingType; }
        }

        public ProjectType ProjectType
        {
            get { return ProjectType.ProjectUpdate; }
        }

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return null;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProjectUpdateBatch.ProjectLocationUpdates.ToList();
        }

        public FeatureCollection DetailedLocationToGeoJsonFeatureCollection()
        {
            return ProjectUpdateBatch.ProjectLocationUpdates.ToGeoJsonFeatureCollection();
        }

        public GeoJSON.Net.Feature.FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();

            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap && ProjectLocationPoint != null)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationPoint));
            }
            else if (ProjectLocationSimpleType == ProjectLocationSimpleType.NamedAreas)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationArea.GetGeometry()));
            }
            return featureCollection;
        }
        
        public static ProjectUpdate GetCurrentProjectUpdateForProject(Project project, Person currentPerson)
        {
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, currentPerson);
            return projectUpdateBatch.ProjectUpdate;
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = new ProjectUpdate(projectUpdateBatch);
            HttpRequestStorage.DatabaseEntities.ProjectUpdates.Add(projectUpdate);
        }

        public static void CommitToProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = new ProjectUpdate(projectUpdateBatch);
            HttpRequestStorage.DatabaseEntities.ProjectUpdates.Add(projectUpdate);
        }
    }
}