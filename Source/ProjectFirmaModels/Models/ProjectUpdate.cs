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

namespace ProjectFirmaModels.Models
{
    public partial class ProjectUpdate : IProject
    {

        public int GetEntityID() => ProjectUpdateID;
        public string GetDisplayName() => ProjectUpdateBatch.Project.GetDisplayName();

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
            if (FundingType == FundingType.BudgetVariesByYear)
            {
                return ProjectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates.Sum(x => x.NoFundingSourceIdentifiedYet.GetValueOrDefault());
            }
            return NoFundingSourceIdentifiedYet;
        }

        public decimal? GetEstimatedTotalRegardlessOfFundingType()
        {
            var securedFunding = GetSecuredFunding();
            var targetedFunding = GetTargetedFunding();
            var noFundingSourceIdentified = GetNoFundingSourceIdentifiedAmount();
            return (noFundingSourceIdentified ?? 0) + securedFunding + targetedFunding;
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
            NoFundingSourceIdentifiedYet = project.NoFundingSourceIdentifiedYet;
            FundingTypeID = project.FundingTypeID;
        }

        public void LoadSimpleLocationFromProject(Project project)
        {
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
            project.PrimaryContactPersonID = PrimaryContactPersonID;
        }
        
        public void CommitSimpleLocationToProject(Project project)
        {
            project.ProjectLocationPoint = ProjectLocationPoint;
            project.ProjectLocationNotes = ProjectLocationNotes;
            project.ProjectLocationSimpleTypeID = ProjectLocationSimpleTypeID;
        }

        public bool HasProjectLocationPoint => ProjectLocationPoint != null;

        public bool HasProjectLocationDetail => ProjectUpdateBatch.ProjectLocationUpdates.Any();

        public IEnumerable<IProjectCustomAttribute> GetProjectCustomAttributes() => ProjectUpdateBatch.ProjectCustomAttributeUpdates;

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

        public IEnumerable<GeospatialArea> GetProjectGeospatialAreas()
        {
            return ProjectUpdateBatch.ProjectGeospatialAreaUpdates.Select(x => x.GeospatialArea);
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ?? GetPrimaryContactOrganization()?.PrimaryContactPerson;

        public Organization GetPrimaryContactOrganization()
        {
            return ProjectUpdateBatch.ProjectOrganizationUpdates.SingleOrDefault(x => x.OrganizationRelationshipType.IsPrimaryContact)?.Organization;
        }
    }
}
