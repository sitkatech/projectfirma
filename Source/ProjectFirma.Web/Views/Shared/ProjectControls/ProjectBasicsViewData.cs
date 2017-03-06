/*-----------------------------------------------------------------------
<copyright file="ProjectBasicsViewData.cs" company="Tahoe Regional Planning Agency">
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
using LtInfo.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ProjectBasicsViewData
    {
        public readonly Models.Project Project;
        public readonly bool UserHasProjectBudgetManagePermissions;
        public readonly bool UserHasTaggingPermissions;
        public readonly ProjectBasicsCalculatedCosts ProjectBasicsCalculatedCosts;
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;
        public readonly ProjectBasicsTagsViewData ProjectBasicsTagsViewData;

        public ProjectBasicsViewData(Models.Project project, bool userHasProjectBudgetManagePermissions, bool userHasTaggingPermissions, ProjectBasicsTagsViewData projectBasicsTagsViewData)
        {
            Project = project;
            UserHasProjectBudgetManagePermissions = userHasProjectBudgetManagePermissions;
            UserHasTaggingPermissions = userHasTaggingPermissions;
            ProjectBasicsTagsViewData = projectBasicsTagsViewData;
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(project);
            ProjectBasicsCalculatedCosts = new ProjectBasicsCalculatedCosts(project);
            
        }        
    }

    public class ProjectBasicsCalculatedCosts
    {
        public readonly decimal? CapitalCostInYearOfExpenditure;
        public readonly string EditInflationUrl;
        public readonly decimal InflationRate;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly int? StartYearForTotalOperatingCostCalculation;

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
