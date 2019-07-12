namespace ProjectFirmaModels.Models
{
    public interface IFundingSourceBudgetAmount
    {
        FundingSource FundingSource { get; }
        decimal? SecuredAmount { get; }
        decimal? TargetedAmount { get; }
    }
}