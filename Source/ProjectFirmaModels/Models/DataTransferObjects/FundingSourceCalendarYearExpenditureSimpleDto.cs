using System.Collections.Generic;

namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class FundingSourceCalendarYearExpenditureSimpleDto
    {
        public FundingSourceSimpleDto FundingSource { get; set; }
        public Dictionary<int, decimal?> CalendarYearExpenditure { get; set; }
    }
}
