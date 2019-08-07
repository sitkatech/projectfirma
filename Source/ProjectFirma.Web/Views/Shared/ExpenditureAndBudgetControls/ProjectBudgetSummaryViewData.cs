/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetSummaryViewData.cs" company="Tahoe Regional Planning Agency">
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

using ProjectFirmaModels.Models;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectBudgetSummaryViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Project Project { get; }
        public ProjectFundingCalculatedCosts ProjectFundingCalculatedCosts { get; }
        public bool HasFundingSources { get; }

        public ProjectBudgetSummaryViewData(Person currentPerson, ProjectFirmaModels.Models.Project project) : base(currentPerson)
        {
            Project = project;
            ProjectFundingCalculatedCosts = new ProjectFundingCalculatedCosts(project);
            HasFundingSources = project.ProjectFundingSourceBudgets.Any();
        }

        public ProjectBudgetSummaryViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch) : base(currentPerson)
        {
            Project = projectUpdateBatch.Project;
            ProjectFundingCalculatedCosts = new ProjectFundingCalculatedCosts(projectUpdateBatch);
            HasFundingSources = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.Any();
        }
    }


    public class ProjectFundingCalculatedCosts
    {
        public decimal? TotalOperatingCostInYearOfExpenditure { get; }
        public int? StartYearForTotalCostCalculation { get; }

        public ProjectFundingCalculatedCosts(ProjectFirmaModels.Models.Project project)
        {
            TotalOperatingCostInYearOfExpenditure = project.CalculateTotalRemainingOperatingCost();
            StartYearForTotalCostCalculation = project.StartYearForTotalCostCalculations();
        }

        public ProjectFundingCalculatedCosts(ProjectUpdateBatch projectUpdateBatch)
        {
            TotalOperatingCostInYearOfExpenditure = projectUpdateBatch.ProjectUpdate.CalculateTotalRemainingOperatingCost();
            StartYearForTotalCostCalculation = projectUpdateBatch.ProjectUpdate.StartYearForTotalCostCalculations();
        }
    }
}
