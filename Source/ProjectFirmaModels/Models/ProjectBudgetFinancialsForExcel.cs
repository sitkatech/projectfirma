/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetFinancialsForExcel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Views;
using NUnit.Framework;

namespace ProjectFirmaModels.Models
{
    public class ProjectBudgetFinancialsForExcel
    {
        public Project Project { get; set; }
        public FundingSource FundingSource { get; set; }
        public decimal? SecuredAmount { get; set; }
        public decimal? TargetedAmount { get; set; }
        public decimal? NoFundingSourceIdentifiedAmount { get; set; }
        public int? CalendarYear { get; set; }
        public string CostTypeName { get; set; }

        public ProjectBudgetFinancialsForExcel(ProjectFundingSourceBudget projectFundingSourceBudget, bool reportFinancialsByCostType, int? calendarYear)
        {
            Project = projectFundingSourceBudget.Project;
            FundingSource = projectFundingSourceBudget.FundingSource;
            SecuredAmount = projectFundingSourceBudget.SecuredAmount;
            TargetedAmount = projectFundingSourceBudget.TargetedAmount;
            CalendarYear = calendarYear ?? projectFundingSourceBudget.CalendarYear;
            if (reportFinancialsByCostType)
            {
                CostTypeName = projectFundingSourceBudget.CostType != null ? projectFundingSourceBudget.CostType.CostTypeName : ViewUtilities.NaString;
            }
        }

        public ProjectBudgetFinancialsForExcel(ProjectNoFundingSourceIdentified projectNoFundingSourceIdentified)
        {
            Project = projectNoFundingSourceIdentified.Project;
            NoFundingSourceIdentifiedAmount = projectNoFundingSourceIdentified.NoFundingSourceIdentifiedYet;
            CalendarYear = projectNoFundingSourceIdentified.CalendarYear;
        }

        public ProjectBudgetFinancialsForExcel(Project project, int calendarYear)
        {
            Project = project;
            CalendarYear = calendarYear;
            NoFundingSourceIdentifiedAmount = project.NoFundingSourceIdentifiedYet;
        }
    }
}