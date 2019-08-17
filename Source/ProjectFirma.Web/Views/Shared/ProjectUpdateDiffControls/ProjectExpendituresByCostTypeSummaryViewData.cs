/*-----------------------------------------------------------------------
<copyright file="ProjectExpendituresByCostTypeSummaryViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public class ProjectExpendituresByCostTypeSummaryViewData : FirmaUserControlViewData
    {
        public List<CalendarYearString> CalendarYears { get; }
        public List<ProjectExpenditureByCostType> ProjectExpenditureByCostTypes { get; }
        public List<CostType> CostTypes { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }


        public ProjectExpendituresByCostTypeSummaryViewData(List<ProjectExpenditureByCostType> projectExpenditureByCostTypes, List<CalendarYearString> calendarYears, List<CostType> costTypes)
        {
            CostTypes = costTypes;
            ProjectExpenditureByCostTypes = projectExpenditureByCostTypes;
            CalendarYears = calendarYears;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
        }
    }
}
