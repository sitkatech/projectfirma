namespace ProjectFirmaModels.Models
{
    public interface IFundingSourceRequestAmount
    {
        FundingSource FundingSource { get; }
        decimal? SecuredAmount { get; }
        decimal? UnsecuredAmount { get; }
    }
}