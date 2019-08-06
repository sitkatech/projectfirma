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
using System;
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
        public List<CalendarYearMonetaryAmount> NoFundingSourceAmounts { get; set; }
        public decimal? NoFundingSourceIdentifiedYet { get; set; }

        public ProjectBudgetsAnnualByCostTypeViewData(Person currentPerson, ProjectFirmaModels.Models.Project project, List<ProjectFundingSourceCostTypeAmount> projectFundingSourceCostTypeAmounts) : base(currentPerson)
        {
            Project = project;
            ProjectFundingSourceCostTypeAmounts = projectFundingSourceCostTypeAmounts;
           var calendarYears = project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
            CalendarYears = calendarYears;
            var calendarYearMonetaryAmounts = new List<CalendarYearMonetaryAmount>();
            if (project.FundingTypeID.HasValue)
            {
                switch (project.FundingType.ToEnum)
                {
                    case FundingTypeEnum.BudgetVariesByYear:
                        {
                            var projectNoFundingSourceIdentifieds =
                                project.ProjectNoFundingSourceIdentifieds.ToList();
                            projectNoFundingSourceIdentifieds.ForEach(x =>
                                calendarYearMonetaryAmounts.Add(new CalendarYearMonetaryAmount(x.CalendarYear.Value,
                                    x.NoFundingSourceIdentifiedYet)));
                            var usedCalendarYears = projectNoFundingSourceIdentifieds.Select(x => x.CalendarYear).ToList();
                            calendarYearMonetaryAmounts.AddRange(calendarYears.Where(x => !usedCalendarYears.Contains(x))
                                .ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
                            NoFundingSourceAmounts = calendarYearMonetaryAmounts;
                            break;
                        }

                    case FundingTypeEnum.BudgetSameEachYear:
                        NoFundingSourceIdentifiedYet = project.NoFundingSourceIdentifiedYet;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
