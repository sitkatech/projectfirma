namespace ProjectFirma.Web.Models
{
    public interface ICalendarYearMonetaryAmount
    {
        int CalendarYear { get; }
        decimal? MonetaryAmount { get; }
    }
}