/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetUpdate.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectBudgetUpdate : IProjectBudgetAmount
    {
        public string ExpenditureAmountDisplay
        {
            get { return MonetaryAmount.ToStringCurrency(); }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectBudgetUpdates =
                projectUpdateBatch.Project.ProjectBudgets.Select(tpb => CloneProjectBudget(projectUpdateBatch, tpb, tpb.CalendarYear, tpb.MonetaryAmount)).ToList();
        }

        public static ProjectBudgetUpdate CloneProjectBudget(ProjectUpdateBatch projectUpdateBatch, IProjectBudgetAmount projectBudgetAmount, int calendarYear, decimal? budgetedAmount)
        {
            return new ProjectBudgetUpdate(projectUpdateBatch, projectBudgetAmount.FundingSource, projectBudgetAmount.ProjectCostType, calendarYear) {BudgetedAmount = budgetedAmount};
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectBudget> allProjectBudgets)
        {
            var project = projectUpdateBatch.Project;
            var projectBudgetsFromProjectUpdate =
                projectUpdateBatch.ProjectBudgetUpdates.Select(
                    x => new ProjectBudget(project.ProjectID, x.FundingSource.FundingSourceID, x.ProjectCostTypeID, x.CalendarYear, x.MonetaryAmount ?? 0)).ToList();
            project.ProjectBudgets.Merge(projectBudgetsFromProjectUpdate,
                allProjectBudgets,
                (x, y) =>
                    x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.FundingSourceID == y.FundingSourceID && x.ProjectCostTypeID == y.ProjectCostTypeID,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);
        }

        public decimal? MonetaryAmount
        {
            get { return BudgetedAmount ?? 0; }
        }

        public int ProjectID
        {
            get { return ProjectUpdateBatch.ProjectID; }
        }
    }
}
