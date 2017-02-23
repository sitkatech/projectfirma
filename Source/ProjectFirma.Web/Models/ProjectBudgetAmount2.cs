/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetAmount2.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetAmount2
    {
        public readonly int FundingSourceID;
        public readonly string FundingSourceName;
        public readonly List<ProjectCostTypeCalendarYearBudget> ProjectCostTypeCalendarYearBudgets;
        public string DisplayCssClass;

        private ProjectBudgetAmount2(int fundingSourceID, string fundingSourceName, List<ProjectCostTypeCalendarYearBudget> projectCostTypeCalendarYearBudgets, string displayCssClass)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            ProjectCostTypeCalendarYearBudgets = projectCostTypeCalendarYearBudgets;
            DisplayCssClass = displayCssClass;
        }

        public static List<ProjectBudgetAmount2> CreateFromProjectBudgets(List<IProjectBudgetAmount> projectBudgetAmounts, List<int> calendarYears)
        {
            var distinctFundingSources = projectBudgetAmounts.Select(x => x.FundingSource).Distinct(new HavePrimaryKeyComparer<FundingSource>());
            var fundingSourcesCrossJoinCalendarYears =
                distinctFundingSources.Select(
                    x =>
                        new ProjectBudgetAmount2(x.FundingSourceID,
                            x.FundingSourceName,
                            ProjectCostType.All.Select(
                                y => new ProjectCostTypeCalendarYearBudget(y, calendarYears.ToDictionary<int, int, decimal?>(calendarYear => calendarYear, calendarYear => null)))
                                .ToList(),
                            null)).ToList();

            foreach (var projectFundingSourceExpenditure in projectBudgetAmounts.GroupBy(x => x.FundingSourceID))
            {
                var currentFundingSource = fundingSourcesCrossJoinCalendarYears.Single(x => x.FundingSourceID == projectFundingSourceExpenditure.Key);
                foreach (var projectBudgetAmount in projectFundingSourceExpenditure.GroupBy(x => x.ProjectCostTypeID))
                {
                    var current = currentFundingSource.ProjectCostTypeCalendarYearBudgets.Single(x => x.ProjectCostType.ProjectCostTypeID == projectBudgetAmount.Key);
                    foreach (var calendarYear in calendarYears)
                    {
                        current.CalendarYearBudget[calendarYear] =
                            projectBudgetAmount.Where(fundingSourceExpenditure => fundingSourceExpenditure.CalendarYear == calendarYear).Select(x => x.MonetaryAmount).Sum();
                    }
                }
            }
            return fundingSourcesCrossJoinCalendarYears;
        }

        public static ProjectBudgetAmount2 Clone(ProjectBudgetAmount2 fundingSourceCalendarYearExpenditureToDiff, string displayCssClass)
        {
            return new ProjectBudgetAmount2(fundingSourceCalendarYearExpenditureToDiff.FundingSourceID,
                fundingSourceCalendarYearExpenditureToDiff.FundingSourceName,
                fundingSourceCalendarYearExpenditureToDiff.ProjectCostTypeCalendarYearBudgets.Select(
                    x => new ProjectCostTypeCalendarYearBudget(x.ProjectCostType, x.CalendarYearBudget.ToDictionary(y => y.Key, y => y.Value))).ToList(),
                displayCssClass);
        }
    }

    public class ProjectCostTypeCalendarYearBudget
    {
        public readonly ProjectCostType ProjectCostType;
        public readonly Dictionary<int, decimal?> CalendarYearBudget;

        public ProjectCostTypeCalendarYearBudget(ProjectCostType projectCostType, Dictionary<int, decimal?> calendarYearBudget)
        {
            ProjectCostType = projectCostType;
            CalendarYearBudget = calendarYearBudget;
        }
    }
}
