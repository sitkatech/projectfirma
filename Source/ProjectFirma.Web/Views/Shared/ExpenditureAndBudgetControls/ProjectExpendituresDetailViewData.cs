/*-----------------------------------------------------------------------
<copyright file="ProjectExpendituresDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectExpendituresDetailViewData : FirmaUserControlViewData
    {
        public List<CalendarYearString> CalendarYearStrings { get; }
        public List<FundingSourceCalendarYearExpenditure> FundingSourceExpenditures { get; }
        public List<string> ExemptReportingYears { get; }
        public string ExemptionExplanation { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }

        public ProjectExpendituresDetailViewData(List<FundingSourceCalendarYearExpenditure> fundingSourceExpenditures, List<CalendarYearString> calendarYearStrings, List<string> exemptReportingYears, string exemptionExplanation)
        {
            FundingSourceExpenditures = fundingSourceExpenditures;
            CalendarYearStrings = calendarYearStrings;
            ExemptReportingYears = exemptReportingYears;
            ExemptionExplanation = exemptionExplanation;
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
        }
    }
}
