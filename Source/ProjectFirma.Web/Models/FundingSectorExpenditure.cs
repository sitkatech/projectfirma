/*-----------------------------------------------------------------------
<copyright file="FundingSectorExpenditure.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
        private readonly SectorSimple _sector;
        public int SectorID
        {
            get { return _sector.SectorID; }
        }
        public string SectorDisplayName
        {
            get { return _sector.SectorDisplayName; }
        }
        public string LegendColor
        {
            get { return _sector.LegendColor; }
        }
        public readonly decimal CalendarYearExpenditureAmount;
        public readonly int FundingSourceCount;
        public readonly int FundingOrganizationCount;
        public readonly int? CalendarYear;

        public FundingSectorExpenditure(Sector sector, decimal calendarYearExpenditureAmount, int fundingSourceCount, int fundingOrganizationCount, int? calendarYear)
        {
            _sector = new SectorSimple(sector);
            CalendarYear = calendarYear;
            CalendarYearExpenditureAmount = calendarYearExpenditureAmount;
            FundingSourceCount = fundingSourceCount;
            FundingOrganizationCount = fundingOrganizationCount;
        }

        public FundingSectorExpenditure(Sector sector, List<ProjectFundingSourceExpenditure> projectFundingSourceExpendituresForThisSectorAndCalendarYear, int? calendarYear)
        {
            _sector = new SectorSimple(sector);
            CalendarYear = calendarYear;
            CalendarYearExpenditureAmount = projectFundingSourceExpendituresForThisSectorAndCalendarYear.Sum(x => x.ExpenditureAmount);
            FundingSourceCount = projectFundingSourceExpendituresForThisSectorAndCalendarYear.Select(x => x.FundingSourceID).Distinct().Count();
            FundingOrganizationCount = projectFundingSourceExpendituresForThisSectorAndCalendarYear.Select(x => x.FundingSource.OrganizationID).Distinct().Count();
        }
    }
}
