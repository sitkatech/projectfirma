namespace ProjectFirmaModels.Models
{
    public interface IFundingSourceBudgetAmount
    {
        FundingSource FundingSource { get; }
        decimal? SecuredAmount { get; }
        decimal? TargetedAmount { get; }
    }

    public interface ICostTypeFundingSourceBudgetAmount : IFundingSourceBudgetAmount
    {
        CostType CostType { get; }
        int? CostTypeID { get; }
        int? CalendarYear { get; }
        decimal? GetMonetaryAmount(bool isSecured);
    }
}