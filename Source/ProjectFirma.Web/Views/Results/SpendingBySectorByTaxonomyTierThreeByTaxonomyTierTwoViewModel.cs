using System.ComponentModel;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewModel : FormViewModel
    {
        [DisplayName("Time Period")]
        public int? CalendarYear { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewModel()
        {
        }

        public SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewModel(int? calendarYear)
        {
            CalendarYear = calendarYear;
        }
    }
}