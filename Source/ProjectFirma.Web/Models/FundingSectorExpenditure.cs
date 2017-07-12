/*-----------------------------------------------------------------------
<copyright file="FundingSectorExpenditure.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class FundingSectorExpenditure
    {
        private readonly OrganizationTypeSimple _organizationType;
        public int OrganizationTypeID
        {
            get { return _organizationType.OrganizationTypeID; }
        }
        public string OrganizationTypeName
        {
            get { return _organizationType.OrganizationTypeName; }
        }
        public string LegendColor
        {
            get { return _organizationType.LegendColor; }
        }
        public readonly decimal CalendarYearExpenditureAmount;
        public readonly int FundingSourceCount;
        public readonly int FundingOrganizationCount;
        public readonly int? CalendarYear;

        public FundingSectorExpenditure(OrganizationType organizationType, decimal calendarYearExpenditureAmount, int fundingSourceCount, int fundingOrganizationCount, int? calendarYear)
        {
            _organizationType = new OrganizationTypeSimple(organizationType);
            CalendarYear = calendarYear;
            CalendarYearExpenditureAmount = calendarYearExpenditureAmount;
            FundingSourceCount = fundingSourceCount;
            FundingOrganizationCount = fundingOrganizationCount;
        }

        public FundingSectorExpenditure(OrganizationType organizationType, List<ProjectFundingSourceExpenditure> projectFundingSourceExpendituresForThisSectorAndCalendarYear, int? calendarYear)
        {
            _organizationType = new OrganizationTypeSimple(organizationType);
            CalendarYear = calendarYear;
            CalendarYearExpenditureAmount = projectFundingSourceExpendituresForThisSectorAndCalendarYear.Sum(x => x.ExpenditureAmount);
            FundingSourceCount = projectFundingSourceExpendituresForThisSectorAndCalendarYear.Select(x => x.FundingSourceID).Distinct().Count();
            FundingOrganizationCount = projectFundingSourceExpendituresForThisSectorAndCalendarYear.Select(x => x.FundingSource.OrganizationID).Distinct().Count();
        }
    }
}
