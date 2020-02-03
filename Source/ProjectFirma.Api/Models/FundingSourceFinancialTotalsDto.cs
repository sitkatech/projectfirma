using ProjectFirmaModels.Models;
using System.Linq;

namespace ProjectFirma.Api.Models
{
    public class FundingSourceFinancialTotalsDto
    {
        public FundingSourceFinancialTotalsDto(FundingSource fundingSource, IQueryable<ProjectFundingSourceBudget> projectFundingSourceBudgets, IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            ProjectFirmaFundingSourceID = fundingSource.FundingSourceID;
            BudgetSecuredTotal = projectFundingSourceBudgets.Any(x => x.SecuredAmount != null) ? projectFundingSourceBudgets.Sum(x => x.SecuredAmount) : null;
            ExpendituresTotal = projectFundingSourceExpenditures.Any() ? projectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?) null;
        }

        public FundingSourceFinancialTotalsDto()
        {
        }

        public int ProjectFirmaFundingSourceID { get; set; }
        public decimal? BudgetSecuredTotal { get; set; }
        public decimal? ExpendituresTotal { get; set; }
    }


}