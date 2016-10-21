using System.ComponentModel;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public class SpendingBySectorByFocusAreaByProgramViewModel : FormViewModel
    {
        [DisplayName("Time Period")]
        public int? CalendarYear { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public SpendingBySectorByFocusAreaByProgramViewModel()
        {
        }

        public SpendingBySectorByFocusAreaByProgramViewModel(int? calendarYear)
        {
            CalendarYear = calendarYear;
        }
    }
}