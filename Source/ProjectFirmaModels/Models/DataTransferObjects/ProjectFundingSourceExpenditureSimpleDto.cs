using System.Collections.Generic;

namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class ProjectFundingSourceExpenditureSimpleDto
    {
        public int ProjectFundingSourceExpenditureID { get; set; }
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public int CalendarYear { get; set; }
        public decimal ExpenditureAmount { get; set; }
        public FundingSourceSimpleDto FundingSource { get; set; }
    }
}
