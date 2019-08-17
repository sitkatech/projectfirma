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
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectExpendituresByCostTypeDetailViewData : FirmaUserControlViewData
    {
        public List<ProjectFundingSourceCostTypeAmount> ProjectFundingSourceCostTypeExpenditureAmountAmounts { get; }
        public List<int> CalendarYears { get; }
        public string ExemptionExplanation { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }

        public ProjectExpendituresByCostTypeDetailViewData(string exemptionExplanation, List<ProjectFundingSourceCostTypeAmount> projectFundingSourceCostTypeExpenditureAmounts)
        {
            ProjectFundingSourceCostTypeExpenditureAmountAmounts = projectFundingSourceCostTypeExpenditureAmounts;
            CalendarYears = projectFundingSourceCostTypeExpenditureAmounts.Select(x => x.CalendarYear.Value).Distinct().ToList();
            ExemptionExplanation = exemptionExplanation;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
        }
    }
}