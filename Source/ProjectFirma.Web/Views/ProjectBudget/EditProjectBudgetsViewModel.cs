/*-----------------------------------------------------------------------
<copyright file="EditProjectBudgetsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectBudget
{
    public class EditProjectBudgetsViewModel : FormViewModel
    {
        public List<ProjectBudgetBulk> ProjectBudgets { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectBudgetsViewModel()
        {
        }

        public EditProjectBudgetsViewModel(List<Models.ProjectBudget> projectBudgets, List<int> calendarYearsToPopulate)
        {
            ProjectBudgets = ProjectBudgetBulk.MakeFromList(new List<IProjectBudgetAmount>(projectBudgets), calendarYearsToPopulate);
        }

        public void UpdateModel(List<Models.ProjectBudget> currentProjectBudgets, IList<Models.ProjectBudget> allProjectBudgets)
        {
            var projectBudgetsUpdated = new List<Models.ProjectBudget>();
            if (ProjectBudgets != null)
            {
                // Completely rebuild the list
                projectBudgetsUpdated = ProjectBudgets.SelectMany(x => x.ToProjectBudgets()).ToList();
            }

            currentProjectBudgets.Merge(projectBudgetsUpdated,
                allProjectBudgets,
                (x, y) =>
                    x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear && x.ProjectCostTypeID == y.ProjectCostTypeID,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);
        }
    }
}
