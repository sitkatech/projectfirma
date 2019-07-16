/*-----------------------------------------------------------------------
<copyright file="ProjectFundingDetailViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.ProjectFunding
{
    public class ProjectFundingDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Project Project { get; }
        public bool UserHasProjectBudgetManagePermissions { get; }
        public ProjectFundingCalculatedCosts ProjectFundingCalculatedCosts { get; }
        public List<IFundingSourceBudgetAmount> FundingSourceRequestAmounts { get; }

        public ProjectFundingDetailViewData(Person currentPerson, ProjectFirmaModels.Models.Project project,
            bool userHasProjectBudgetManagePermissions, List<IFundingSourceBudgetAmount> fundingSourceRequestAmounts) : base(currentPerson)
        {
            Project = project;
            UserHasProjectBudgetManagePermissions = userHasProjectBudgetManagePermissions;
            FundingSourceRequestAmounts = fundingSourceRequestAmounts;

            ProjectFundingCalculatedCosts = new ProjectFundingCalculatedCosts(project);
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
    }
}
