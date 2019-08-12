/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetsByCostTypeDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public class ProjectBudgetsByCostTypeSummaryViewData : FirmaUserControlViewData
    {
        public FundingType FundingType { get; }
        public List<CalendarYearString> CalendarYears { get; }
        public List<ProjectBudgetByCostType> ProjectBudgetByCostTypes { get; }
        public List<CostType> CostTypes { get; }
        public decimal? NoFundingSourceIdentified { get; }
        public decimal? EstimatedTotal { get; }
        public string ExpectedFundingUpdateNote { get; }
        public List<ProjectFundingSourceCostTypeAmount> ProjectFundingSourceCostTypeAmounts { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForSecuredFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForTargetedFunding { get; }



        public ProjectBudgetsByCostTypeSummaryViewData(FundingType fundingType, List<ProjectBudgetByCostType> projectBudgetByCostTypes, List<CalendarYearString> calendarYears, List<CostType> costTypes, 
            decimal? noFundingSourceIdentified, decimal? estimatedTotal, List<ProjectFundingSourceCostTypeAmount> projectFundingSourceCostTypeAmounts, string expectedFundingUpdateNote)
        {
            FundingType = fundingType;
            CostTypes = costTypes;
            ProjectBudgetByCostTypes = projectBudgetByCostTypes;
            CalendarYears = calendarYears;
            NoFundingSourceIdentified = noFundingSourceIdentified;
            EstimatedTotal = estimatedTotal;
            ProjectFundingSourceCostTypeAmounts = projectFundingSourceCostTypeAmounts;
            ExpectedFundingUpdateNote = expectedFundingUpdateNote;

            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
            FieldDefinitionForSecuredFunding = FieldDefinitionEnum.SecuredFunding.ToType();
            FieldDefinitionForTargetedFunding = FieldDefinitionEnum.TargetedFunding.ToType();
        }
    }
}
