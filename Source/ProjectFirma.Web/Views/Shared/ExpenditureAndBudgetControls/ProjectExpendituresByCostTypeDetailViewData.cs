/*-----------------------------------------------------------------------
<copyright file="ProjectExpendituresByCostTypeDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectExpendituresByCostTypeDetailViewData : FirmaUserControlViewData
    {
        public List<ProjectFundingSourceCostTypeExpenditureAmount> ProjectFundingSourceExpenditureAmounts { get; }
        public List<int> CalendarYears { get; }
        public List<string> ExemptReportingYears { get; }
        public string ExemptionExplanation { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }

        public ProjectExpendituresByCostTypeDetailViewData(List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, List<int> calendarYears, List<string> exemptReportingYears, string exemptionExplanation)
        {
            ProjectFundingSourceExpenditureAmounts = ProjectFundingSourceCostTypeExpenditureAmount.CreateFromProjectFundingSourceExpenditures(projectFundingSourceExpenditures);
            CalendarYears = calendarYears;
            ExemptReportingYears = exemptReportingYears;
            ExemptionExplanation = exemptionExplanation;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
        }
    }
}