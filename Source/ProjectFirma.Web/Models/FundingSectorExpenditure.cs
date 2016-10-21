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