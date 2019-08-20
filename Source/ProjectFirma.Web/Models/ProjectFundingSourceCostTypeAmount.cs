/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceAmount.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceCostTypeAmount
    {
        public FundingSource FundingSource { get; }
        public CostType CostType { get; }
        public int? CalendarYear { get; }
        public decimal? MonetaryAmount { get; }
        public bool IsRealEntry { get; }
        public bool IsSecured { get; }

        private ProjectFundingSourceCostTypeAmount(FundingSource fundingSource, CostType costType, int? calendarYear, decimal? monetaryAmount, bool isRealEntry)
        {
            FundingSource = fundingSource;
            CostType = costType;
            CalendarYear = calendarYear;
            MonetaryAmount = monetaryAmount;
            IsRealEntry = isRealEntry;
        }

        private ProjectFundingSourceCostTypeAmount(FundingSource fundingSource, CostType costType, int? calendarYear, decimal? monetaryAmount, bool isRealEntry, bool isSecured) : this(fundingSource, costType, calendarYear, monetaryAmount, isRealEntry)
        {
            IsSecured = isSecured;
        }
        // Budgets
        public static List<ProjectFundingSourceCostTypeAmount> CreateFromProjectFundingSourceBudgets(List<ProjectFundingSourceBudget> projectFundingSourceBudgets)
        {
            var projectFundingSourceCostTypeAmounts = new List<ProjectFundingSourceCostTypeAmount>();
            // Get Secured and Targeted amounts for each FundingSource/CostType/Year
            foreach (var projectFundingSourceBudget in projectFundingSourceBudgets)
            {
                projectFundingSourceCostTypeAmounts.Add(new ProjectFundingSourceCostTypeAmount(projectFundingSourceBudget.FundingSource, projectFundingSourceBudget.CostType, projectFundingSourceBudget.CalendarYear, projectFundingSourceBudget.GetMonetaryAmount(true), true, true));
                projectFundingSourceCostTypeAmounts.Add(new ProjectFundingSourceCostTypeAmount(projectFundingSourceBudget.FundingSource, projectFundingSourceBudget.CostType, projectFundingSourceBudget.CalendarYear, projectFundingSourceBudget.GetMonetaryAmount(false), true, false));
            }
            return projectFundingSourceCostTypeAmounts;
        }
        public static List<ProjectFundingSourceCostTypeAmount> CreateFromProjectFundingSourceBudgets(List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates)
        {
            var projectFundingSourceCostTypeAmounts = new List<ProjectFundingSourceCostTypeAmount>();
            // Get Secured and Targeted amounts for each FundingSource/CostType/Year
            foreach (var projectFundingSourceBudgetUpdate in projectFundingSourceBudgetUpdates)
            {
                projectFundingSourceCostTypeAmounts.Add(new ProjectFundingSourceCostTypeAmount(projectFundingSourceBudgetUpdate.FundingSource, projectFundingSourceBudgetUpdate.CostType, projectFundingSourceBudgetUpdate.CalendarYear, projectFundingSourceBudgetUpdate.GetMonetaryAmount(true), true, true));
                projectFundingSourceCostTypeAmounts.Add(new ProjectFundingSourceCostTypeAmount(projectFundingSourceBudgetUpdate.FundingSource, projectFundingSourceBudgetUpdate.CostType, projectFundingSourceBudgetUpdate.CalendarYear, projectFundingSourceBudgetUpdate.GetMonetaryAmount(false), true, false));
            }
            return projectFundingSourceCostTypeAmounts;
        }
        // Expenditures
        public static List<ProjectFundingSourceCostTypeAmount> CreateFromProjectFundingSourceExpenditures(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            return projectFundingSourceExpenditures.Select(x => new ProjectFundingSourceCostTypeAmount(x.FundingSource, x.CostType, x.CalendarYear, x.GetMonetaryAmount(), true)).ToList();
        }
        public static List<ProjectFundingSourceCostTypeAmount> CreateFromProjectFundingSourceExpenditures(List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates)
        {
            return projectFundingSourceExpenditureUpdates.Select(x => new ProjectFundingSourceCostTypeAmount(x.FundingSource, x.CostType, x.CalendarYear, x.GetMonetaryAmount(), true)).ToList();
        }
    }
}
