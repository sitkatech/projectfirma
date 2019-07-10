using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class FundingSourceBudgetAmount : IFundingSourceBudgetAmount
    {
        public ProjectFirmaModels.Models.FundingSource FundingSource { get; }
        public int FundingSourceID => FundingSource?.FundingSourceID ?? ModelObjectHelpers.NotYetAssignedID;

        public decimal? SecuredAmount { get; set; }
        public decimal? TargetedAmount { get; set;  }
        public string DisplayCssClass;

        public FundingSourceBudgetAmount(ProjectFirmaModels.Models.FundingSource fundingSource, decimal? securedAmount, decimal? targetedAmount, string displayCssClass)
        {
            FundingSource = fundingSource;
            SecuredAmount = securedAmount;
            TargetedAmount = targetedAmount;
            DisplayCssClass = displayCssClass;
        }

        public FundingSourceBudgetAmount(IFundingSourceBudgetAmount fundingSourceBudgetAmount)
        {
            FundingSource = fundingSourceBudgetAmount.FundingSource;
            SecuredAmount = fundingSourceBudgetAmount.SecuredAmount;
            TargetedAmount = fundingSourceBudgetAmount.TargetedAmount;
        }

        public static FundingSourceBudgetAmount Clone(IFundingSourceBudgetAmount fundingSourceBudgetAmountToDiff, string displayCssClass)
        {
            return new FundingSourceBudgetAmount(fundingSourceBudgetAmountToDiff.FundingSource,
                fundingSourceBudgetAmountToDiff.SecuredAmount,
                fundingSourceBudgetAmountToDiff.TargetedAmount,
                displayCssClass);
        }
    }
}