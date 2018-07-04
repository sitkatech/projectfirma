/*-----------------------------------------------------------------------
<copyright file="ProjectUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Common;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectUpdate : IProject
    {
        public int EntityID => ProjectUpdateID;
        public string DisplayName => ProjectUpdateBatch.Project.DisplayName;

        public decimal? UnfundedNeed => EstimatedTotalCost - GetSecuredFunding();

        public decimal GetSecuredFunding()
        {
            return ProjectUpdateBatch.ProjectFundingSourceRequestUpdates.Any()
                ? ProjectUpdateBatch.ProjectFundingSourceRequestUpdates.Sum(x => x.SecuredAmount.GetValueOrDefault())
                : 0;
        }

        public ProjectUpdate(ProjectUpdateBatch projectUpdateBatch) : this(projectUpdateBatch, projectUpdateBatch.Project.ProjectStage, projectUpdateBatch.Project.ProjectDescription, projectUpdateBatch.Project.ProjectLocationSimpleType)
        {
            var project = projectUpdateBatch.Project;
            LoadUpdateFromProject(project);
            LoadSimpleLocationFromProject(project);
            LoadWatershedNotesFromProject(project);
        }

        public void LoadUpdateFromProject(Project project)
        {
            ProjectDescription = project.ProjectDescription;
            ProjectStageID = project.ProjectStageID;
            PlanningDesignStartYear = project.PlanningDesignStartYear;
            ImplementationStartYear = project.ImplementationStartYear;
            CompletionYear = project.CompletionYear;
            EstimatedTotalCost = project.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost;
        }

        public void LoadSimpleLocationFromProject(Project project)
        {
            ProjectLocationPoint = project.ProjectLocationPoint;
            ProjectLocationNotes = project.ProjectLocationNotes;
            ProjectLocationSimpleTypeID = project.ProjectLocationSimpleTypeID;
        }

        public void LoadWatershedNotesFromProject(Project project)
        {
            ProjectWatershedNotes = project.ProjectWatershedNotes;            
        }

        public void CommitChangesToProject(Project project)
        {
            project.ProjectDescription = ProjectDescription;
            project.ProjectStageID = ProjectStageID;
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.ImplementationStartYear = ImplementationStartYear;
            project.CompletionYear = CompletionYear;
            project.EstimatedTotalCost = EstimatedTotalCost;
            project.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost;
            project.PrimaryContactPersonID = PrimaryContactPersonID;
        }

        public void CommitSimpleLocationToProject(Project project)
        {
            project.ProjectLocationPoint = ProjectLocationPoint;
            project.ProjectLocationNotes = ProjectLocationNotes;
            project.ProjectLocationSimpleTypeID = ProjectLocationSimpleTypeID;
        }

        public void CommitWatershedNotesToProject(Project project)
        {
            project.ProjectWatershedNotes = ProjectWatershedNotes;            
        }

        public bool HasProjectLocationPoint => ProjectLocationPoint != null;

        public bool HasProjectLocationDetail => DetailedLocationToGeoJsonFeatureCollection().Features.Any();

        public double? ProjectLocationPointLatitude => HasProjectLocationPoint ? ProjectLocationPoint.YCoordinate : null;

        public double? ProjectLocationPointLongitude => HasProjectLocationPoint ? ProjectLocationPoint.XCoordinate : null;

        public FundingType FundingType => ProjectUpdateBatch.Project.FundingType;

        public IEnumerable<IProjectCustomAttribute> ProjectCustomAttributes
        {
            get => ProjectUpdateCustomAttributes;
            set => ProjectUpdateCustomAttributes = (ICollection<ProjectUpdateCustomAttribute>) value;
        }

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return null;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProjectUpdateBatch.ProjectLocationUpdates.ToList();
        }

        public DbGeometry GetDefaultBoundingBox()
        {
            return ProjectUpdateBatch.Project.GetDefaultBoundingBox();
        }

        public IEnumerable<Watershed> GetProjectWatersheds()
        {
            return ProjectUpdateBatch.ProjectWatershedUpdates.Select(x => x.Watershed);
        }

        public FeatureCollection DetailedLocationToGeoJsonFeatureCollection()
        {
            return ProjectUpdateBatch.ProjectLocationUpdates.ToGeoJsonFeatureCollection();
        }

        public FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties)
        {
            var featureCollection = new FeatureCollection();

            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap && ProjectLocationPoint != null)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationPoint));
            }
            return featureCollection;
        }
        
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = new ProjectUpdate(projectUpdateBatch);
            HttpRequestStorage.DatabaseEntities.AllProjectUpdates.Add(projectUpdate);
        }

        public static void CommitToProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = new ProjectUpdate(projectUpdateBatch);
            HttpRequestStorage.DatabaseEntities.AllProjectUpdates.Add(projectUpdate);
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ?? GetPrimaryContactOrganization()?.PrimaryContactPerson;

        public Organization GetPrimaryContactOrganization()
        {
            return ProjectUpdateBatch.ProjectOrganizationUpdates.SingleOrDefault(x => x.RelationshipType.IsPrimaryContact)?.Organization;
        }
    }
}
