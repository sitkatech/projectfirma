/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetsAnnualViewData.cs" company="Tahoe Regional Planning Agency">
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

using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectBudgetsAnnualViewData : FirmaViewData
    {
        // Shared
        public ProjectFirmaModels.Models.Project Project { get; }

        // Annual Budgeting
        public List<IFundingSourceBudgetAmount> ProjectFundingSourceBudgetsAnnual { get; }

        public string ExpectedFundingUpdateNote { get; }

        // Constructor for Annual Budgeting
        public ProjectBudgetsAnnualViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project) : base(currentFirmaSession)
        {
            Project = project;
            ProjectFundingSourceBudgetsAnnual = new List<IFundingSourceBudgetAmount>(project.ProjectFundingSourceBudgets);
            ExpectedFundingUpdateNote = project.ExpectedFundingUpdateNote;
        }
        public ProjectBudgetsAnnualViewData(FirmaSession currentFirmaSession, ProjectUpdateBatch projectUpdateBatch) : base(currentFirmaSession)
        {
            Project = projectUpdateBatch.Project;
            ProjectFundingSourceBudgetsAnnual = new List<IFundingSourceBudgetAmount>(projectUpdateBatch.ProjectFundingSourceBudgetUpdates);
            ExpectedFundingUpdateNote = projectUpdateBatch.ExpectedFundingUpdateNote;
        }
    }
}
