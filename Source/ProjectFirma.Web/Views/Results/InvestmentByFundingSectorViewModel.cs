using System.ComponentModel;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class InvestmentByFundingSectorViewModel : FormViewModel
    {
        [DisplayName("Time Period")]
        public int? CalendarYear { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public InvestmentByFundingSectorViewModel()
        {
        }

        public InvestmentByFundingSectorViewModel(int? calendarYear)
        {
            CalendarYear = calendarYear;
        }
    }
}