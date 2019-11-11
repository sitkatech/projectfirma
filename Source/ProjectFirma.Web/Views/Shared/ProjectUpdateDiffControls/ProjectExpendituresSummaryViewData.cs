/*-----------------------------------------------------------------------
<copyright file="ProjectExpendituresSummaryViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public class ProjectExpendituresSummaryViewData : FirmaUserControlViewData
    {
        public string ExpendituresNote { get; }
        public List<CalendarYearString> CalendarYears { get; }
        public List<FundingSourceCalendarYearExpenditure> FundingSourceExpenditures { get; }
        

        public ProjectExpendituresSummaryViewData(string expendituresNote, List<FundingSourceCalendarYearExpenditure> fundingSourceExpenditures, List<CalendarYearString> calendarYears)
        {
            ExpendituresNote = expendituresNote;
            FundingSourceExpenditures = fundingSourceExpenditures;
            CalendarYears = calendarYears;
        }
    }
}
