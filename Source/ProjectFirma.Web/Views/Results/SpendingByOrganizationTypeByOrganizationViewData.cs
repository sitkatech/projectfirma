/*-----------------------------------------------------------------------
<copyright file="SpendingByOrganizationTypeByOrganizationViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByOrganizationTypeByOrganizationViewData : FirmaUserControlViewData
    {
        public readonly List<FundingSourceCalendarYearExpenditure> FundingSourceCalendarYearExpenditures;
        public readonly Dictionary<int, string> CalendarYears;
        public readonly string ExcelUrl;

        public SpendingByOrganizationTypeByOrganizationViewData(List<FundingSourceCalendarYearExpenditure> fundingSourceCalendarYearExpenditures, Dictionary<int, string> calendarYears, string excelUrl)
        {
            FundingSourceCalendarYearExpenditures = fundingSourceCalendarYearExpenditures;
            CalendarYears = calendarYears;
            ExcelUrl = excelUrl;
        }
    }
}
