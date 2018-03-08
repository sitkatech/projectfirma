/*-----------------------------------------------------------------------
<copyright file="ProjectBasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectBasicsViewData
    {
        public Models.Project Project { get; }
        public bool UserHasProjectBudgetManagePermissions { get; }
        public ProjectBasicsCalculatedCosts ProjectBasicsCalculatedCosts { get; }
        public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }

        public ProjectBasicsViewData(Models.Project project, bool userHasProjectBudgetManagePermissions)
        {
            Project = project;
            UserHasProjectBudgetManagePermissions = userHasProjectBudgetManagePermissions;
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(project);
            ProjectBasicsCalculatedCosts = new ProjectBasicsCalculatedCosts(project);            
        }        
    }

    public class ProjectBasicsCalculatedCosts
    {
        public decimal? CapitalCostInYearOfExpenditure { get; }
        public string EditInflationUrl { get; }
        public decimal InflationRate { get; }
        public decimal? TotalOperatingCostInYearOfExpenditure { get; }
        public int? StartYearForTotalOperatingCostCalculation { get; }

        public ProjectBasicsCalculatedCosts(Models.Project project)
        {
            CapitalCostInYearOfExpenditure = Models.CostParameterSet.CalculateCapitalCostInYearOfExpenditure(project);
            EditInflationUrl = SitkaRoute<CostParameterSetController>.BuildUrlFromExpression(controller => controller.Detail());
            InflationRate = Models.CostParameterSet.GetLatestInflationRate();
            TotalOperatingCostInYearOfExpenditure = Models.CostParameterSet.CalculateTotalRemainingOperatingCost(project);
            StartYearForTotalOperatingCostCalculation = Models.CostParameterSet.StartYearForTotalCostCalculations(project);
        }
    }
}
