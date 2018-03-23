/*-----------------------------------------------------------------------
<copyright file="BasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsViewData : ProjectUpdateViewData
    {
        public readonly IEnumerable<SelectListItem> PlanningDesignStartYearRange;
        public readonly IEnumerable<SelectListItem> ImplementationStartYearRange;
        public readonly IEnumerable<SelectListItem> CompletionYearRange;
        public readonly IEnumerable<SelectListItem> ProjectStages;
        public readonly string TaxonomyLeafDisplayName;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly string RequestPrimaryContactChangeUrl;

        public readonly Models.ProjectUpdate ProjectUpdate;
        public readonly SectionCommentsViewData SectionCommentsViewData;

        public readonly decimal InflationRate;
        public readonly decimal? CapitalCostInYearOfExpenditure;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public BasicsViewData(Person currentPerson, Models.ProjectUpdate projectUpdate, IEnumerable<ProjectStage> projectStages, decimal inflationRate, UpdateStatus updateStatus, BasicsValidationResult basicsValidationResult)
            : base(currentPerson, projectUpdate.ProjectUpdateBatch, ProjectUpdateSection.Basics, updateStatus, basicsValidationResult.GetWarningMessages())
        {
            ProjectUpdate = projectUpdate;
            TaxonomyLeafDisplayName = projectUpdate.ProjectUpdateBatch.Project.TaxonomyLeaf.DisplayName;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            PlanningDesignStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            ImplementationStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshBasics(Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffBasics(Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.BasicsComment, projectUpdate.ProjectUpdateBatch.IsReturned);            
                        
            InflationRate = inflationRate;
            CapitalCostInYearOfExpenditure = Models.CostParameterSet.CalculateCapitalCostInYearOfExpenditure(projectUpdate);
            TotalOperatingCostInYearOfExpenditure = Models.CostParameterSet.CalculateTotalRemainingOperatingCost(projectUpdate);
            StartYearForTotalOperatingCostCalculation = Models.CostParameterSet.StartYearForTotalCostCalculations(projectUpdate);
        }
    }
}
