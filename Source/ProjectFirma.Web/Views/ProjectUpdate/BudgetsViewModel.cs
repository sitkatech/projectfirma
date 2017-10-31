/*-----------------------------------------------------------------------
<copyright file="BudgetsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BudgetsViewModel : FormViewModel
    {

        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public List<ProjectBudgetBulk> ProjectBudgets { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public BudgetsViewModel()
        {
        }

        public BudgetsViewModel(List<ProjectBudgetUpdate> ProjectBudgetUpdates,
            List<int> calendarYearsToPopulate,
            string comments)
        {
            ProjectBudgets = ProjectBudgetBulk.MakeFromList(new List<IProjectBudgetAmount>(ProjectBudgetUpdates), calendarYearsToPopulate);
            Comments = comments;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectBudgetUpdate> currentProjectBudgetUpdates,
            IList<ProjectBudgetUpdate> allProjectBudgetUpdates)
        {
            var projectFundingSourceExpenditureUpdatesUpdated = new List<ProjectBudgetUpdate>();
            if (ProjectBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpenditureUpdatesUpdated = ProjectBudgets.SelectMany(x => x.ToProjectBudgetUpdates(projectUpdateBatch)).ToList();
            }

            currentProjectBudgetUpdates.Merge(projectFundingSourceExpenditureUpdatesUpdated,
                allProjectBudgetUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID  && x.ProjectCostTypeID == y.ProjectCostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);
        }
    }
}
