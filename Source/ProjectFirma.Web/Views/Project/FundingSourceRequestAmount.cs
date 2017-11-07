using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class FundingSourceRequestAmount : IFundingSourceRequestAmount
    {
        public Models.FundingSource FundingSource { get; }
        public int FundingSourceID => FundingSource?.FundingSourceID ?? ModelObjectHelpers.NotYetAssignedID;

        public decimal SecuredAmount { get; set; }
        public decimal UnsecuredAmount { get; set;  }
        public string DisplayCssClass;

        public FundingSourceRequestAmount(Models.FundingSource fundingSource, decimal securedAmount, decimal unsecuredAmount, string displayCssClass)
        {
            FundingSource = fundingSource;
            SecuredAmount = securedAmount;
            UnsecuredAmount = unsecuredAmount;
            DisplayCssClass = displayCssClass;
        }

        public FundingSourceRequestAmount(IFundingSourceRequestAmount fundingSourceRequestAmount)
        {
            FundingSource = fundingSourceRequestAmount.FundingSource;
            SecuredAmount = fundingSourceRequestAmount.SecuredAmount;
            UnsecuredAmount = fundingSourceRequestAmount.UnsecuredAmount;
        }

        public static FundingSourceRequestAmount Clone(IFundingSourceRequestAmount fundingSourceRequestAmountToDiff, string displayCssClass)
        {
            return new FundingSourceRequestAmount(fundingSourceRequestAmountToDiff.FundingSource,
                fundingSourceRequestAmountToDiff.SecuredAmount,
                fundingSourceRequestAmountToDiff.UnsecuredAmount,
                displayCssClass);
        }
    }
}