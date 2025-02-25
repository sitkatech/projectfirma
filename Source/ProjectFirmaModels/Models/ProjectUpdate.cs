﻿/*-----------------------------------------------------------------------
<copyright file="ProjectUpdate.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

namespace ProjectFirmaModels.Models
{
    public partial class ProjectUpdate : IProject
    {
        public int GetEntityID() => ProjectUpdateID;
        public Project GetProject() => ProjectUpdateBatch.Project;
        public string GetDisplayName() => ProjectUpdateBatch.Project.GetDisplayName();
        public int ProjectCategoryID => ProjectUpdateBatch.Project.ProjectCategoryID;

        public decimal GetSecuredFunding()
        {
            return ProjectUpdateBatch.ProjectFundingSourceBudgetUpdates.Any()
                ? ProjectUpdateBatch.ProjectFundingSourceBudgetUpdates.Sum(x => x.SecuredAmount.GetValueOrDefault())
                : 0;
        }

        public decimal GetTargetedFunding()
        {
            return ProjectUpdateBatch.ProjectFundingSourceBudgetUpdates.Any()
                ? ProjectUpdateBatch.ProjectFundingSourceBudgetUpdates.Sum(x => x.TargetedAmount.GetValueOrDefault())
                : 0;
        }

        public decimal? GetNoFundingSourceIdentifiedAmount()
        {
            return ProjectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates.Sum(x => x.NoFundingSourceIdentifiedYet.GetValueOrDefault());
        }

        public decimal GetNoFundingSourceIdentifiedAmountOrZero()
        {
            return GetNoFundingSourceIdentifiedAmount() ?? 0;
        }

        public decimal? GetEstimatedTotalRegardlessOfFundingType()
        {
            var securedFunding = GetSecuredFunding();
            var targetedFunding = GetTargetedFunding();
            var noFundingSourceIdentified = GetNoFundingSourceIdentifiedAmount();
            return (noFundingSourceIdentified ?? 0) + securedFunding + targetedFunding;
        }


        public ProjectUpdate(ProjectUpdateBatch projectUpdateBatch) : this(projectUpdateBatch, projectUpdateBatch.Project.ProjectStage, 
            projectUpdateBatch.Project.ProjectDescription, projectUpdateBatch.Project.ProjectLocationSimpleType, projectUpdateBatch.Project.LocationIsPrivate)
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
            FundingTypeID = project.FundingTypeID;
        }

        public void LoadSimpleLocationFromProject(Project project)
        {
            ProjectLocationPoint = project.GetProjectLocationPoint(true);
            ProjectLocationNotes = project.ProjectLocationNotes;
            ProjectLocationSimpleTypeID = project.ProjectLocationSimpleTypeID;
            LocationIsPrivate = project.LocationIsPrivate;
        }

        public void CommitBasicsChangesToProject(Project project)
        {
            project.ProjectDescription = ProjectDescription;
            project.ProjectStageID = ProjectStageID;
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.ImplementationStartYear = ImplementationStartYear;
            project.CompletionYear = CompletionYear;
            project.PrimaryContactPersonID = PrimaryContactPersonID;
        }
        
        public void CommitSimpleLocationToProject(Project project)
        {
            // Using ProjectLocationPoint here because location is being updated
            project.ProjectLocationPoint = ProjectLocationPoint;
            project.ProjectLocationNotes = ProjectLocationNotes;
            project.ProjectLocationSimpleTypeID = ProjectLocationSimpleTypeID;
            project.LocationIsPrivate = LocationIsPrivate;
        }



        public IEnumerable<IProjectCustomAttribute> GetProjectCustomAttributes() => ProjectUpdateBatch.ProjectCustomAttributeUpdates;

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return null;
        }

        public DbGeometry GetDefaultBoundingBox()
        {
            return ProjectUpdateBatch.Project.GetDefaultBoundingBox();
        }

        public IEnumerable<GeospatialArea> GetProjectGeospatialAreas()
        {
            return ProjectUpdateBatch.ProjectGeospatialAreaUpdates.Select(x => x.GeospatialArea);
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ?? GetPrimaryContactOrganization()?.PrimaryContactPerson;

        public Organization GetPrimaryContactOrganization()
        {
            return ProjectUpdateBatch.ProjectOrganizationUpdates.SingleOrDefault(x => x.OrganizationRelationshipType.IsPrimaryContact)?.Organization;
        }

        public int ProjectOrProjectUpdateID
        {
            get { return ProjectUpdateID; }
        }
        public bool IsProject { get { return false; } }
        public bool IsProjectUpdate { get { return true; } }

        public bool HasProjectLocationPoint(bool includePrivateLocation)
        {
            if (LocationIsPrivate && !includePrivateLocation)
            {
                return false;
            }
            return ProjectLocationPoint != null;
        }

        public DbGeometry GetProjectLocationPoint(bool showLocationIfPrivate)
        {
            if (LocationIsPrivate && !showLocationIfPrivate)
            {
                return null;
            }
            return ProjectLocationPoint;
        }

        public bool HasProjectLocationDetailed(bool includePrivateLocation)
        {
            if (LocationIsPrivate && !includePrivateLocation)
            {
                return false;
            }
            return ProjectUpdateBatch.ProjectLocationUpdates.Any();
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetailed(bool showLocationIfPrivate)
        {
            if (LocationIsPrivate && !showLocationIfPrivate)
            {
                return new List<IProjectLocation>();
            }
            return ProjectUpdateBatch.ProjectLocationUpdates;
        }    
        
        public List<ProjectLocationUpdate> GetProjectLocationDetailedAsProjectLocationUpdate(bool showLocationIfPrivate)
        {
            if (LocationIsPrivate && !showLocationIfPrivate)
            {
                return new List<ProjectLocationUpdate>();
            }
            return ProjectUpdateBatch.ProjectLocationUpdates.ToList();
        }
    }
}
