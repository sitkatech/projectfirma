namespace ProjectFirma.Web.Models
{
    public interface IFundingSourceExpenditure : ICalendarYearMonetaryAmount
    {
        FundingSource FundingSource { get; }
        int FundingSourceID { get; }
    }
}