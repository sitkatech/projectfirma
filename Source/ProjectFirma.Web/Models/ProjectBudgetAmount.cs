/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetAmount.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetAmount
    {
        public readonly int FundingSourceID;
        public readonly string FundingSourceName;
        public readonly string FundingSourceDisplayName;
        public readonly ProjectCostType ProjectCostType;
        public readonly int CalendarYear;
        public readonly decimal? MonetaryAmount;
        public readonly bool IsRealEntry;

        private ProjectBudgetAmount(int fundingSourceID, string fundingSourceName, string fundingSourceDisplayName, ProjectCostType projectCostType, int calendarYear, decimal? monetaryAmount, bool isRealEntry)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            FundingSourceDisplayName = fundingSourceDisplayName;
            ProjectCostType = projectCostType;
            CalendarYear = calendarYear;
            MonetaryAmount = monetaryAmount;
            IsRealEntry = isRealEntry;
        }

        public static List<ProjectBudgetAmount> CreateFromProjectBudgets(List<IProjectBudgetAmount> projectBudgetAmounts)
        {
            return
                projectBudgetAmounts.Select(
                    x =>
                        new ProjectBudgetAmount(x.FundingSourceID,
                            x.FundingSource.FundingSourceName,
                            x.FundingSource.DisplayNameAsUrl.ToString(),
                            x.ProjectCostType,
                            x.CalendarYear,
                            x.MonetaryAmount,
                            true)).ToList();
        }

        public static ProjectBudgetAmount CloneEmpty(ProjectBudgetAmount projectBudgetAmountToDiff)
        {
            return new ProjectBudgetAmount(projectBudgetAmountToDiff.FundingSourceID,
                projectBudgetAmountToDiff.FundingSourceName,
                string.Empty,
                projectBudgetAmountToDiff.ProjectCostType,
                projectBudgetAmountToDiff.CalendarYear,
                null,
                false);
        }
    }
}
