/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetsAnnualByCostTypeViewData.cs" company="Tahoe Regional Planning Agency">
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

using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectBudgetsAnnualByCostTypeViewData : FirmaViewData
    {
        // Shared
        public ProjectFirmaModels.Models.Project Project { get; }

        // Budgeting by Cost Type
        public List<CostType> ProjectCostTypes { get; }

        public List<int> CalendarYears { get; }
        public List<ProjectFundingSourceCostTypeAmount> ProjectFundingSourceCostTypeAmounts { get; set; }
        public string ExpectedFundingUpdateNote { get; }

        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForSecuredFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForTargetedFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForEstimatedTotalCost { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForEstimatedAnnualOperatingCost { get; }

        public ProjectBudgetsAnnualByCostTypeViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, List<ProjectFundingSourceCostTypeAmount> projectFundingSourceCostTypeAmounts, string expectedFundingUpdateNote) : base(currentFirmaSession)
        {
            Project = project;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
            FieldDefinitionForSecuredFunding = FieldDefinitionEnum.SecuredFunding.ToType();
            FieldDefinitionForTargetedFunding = FieldDefinitionEnum.TargetedFunding.ToType();
            FieldDefinitionForEstimatedTotalCost = FieldDefinitionEnum.EstimatedTotalCost.ToType();
            FieldDefinitionForEstimatedAnnualOperatingCost = FieldDefinitionEnum.EstimatedAnnualOperatingCost.ToType();

            ProjectFundingSourceCostTypeAmounts = projectFundingSourceCostTypeAmounts;
            var calendarYears = project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
            var usedCalendarYears = projectFundingSourceCostTypeAmounts.Where(x => x.CalendarYear.HasValue && !calendarYears.Contains(x.CalendarYear.Value)).Select(x => x.CalendarYear.Value).Distinct().ToList();
            calendarYears.AddRange(usedCalendarYears);
            calendarYears.Sort();
            CalendarYears = calendarYears;

            ExpectedFundingUpdateNote = expectedFundingUpdateNote;
        }
    }
}
