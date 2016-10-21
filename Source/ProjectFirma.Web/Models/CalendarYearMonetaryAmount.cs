namespace ProjectFirma.Web.Models
{
    public class CalendarYearMonetaryAmount
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public CalendarYearMonetaryAmount()
        {
        }

        public CalendarYearMonetaryAmount(int calendarYear, decimal? monetaryAmount)
        {
            CalendarYear = calendarYear;
            MonetaryAmount = monetaryAmount;
        }

        public int CalendarYear { get; set; }
        public decimal? MonetaryAmount { get; set; }
    }
}