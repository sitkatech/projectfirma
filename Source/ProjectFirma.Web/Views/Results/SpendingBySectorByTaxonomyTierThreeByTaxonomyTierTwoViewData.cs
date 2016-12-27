using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewData : FirmaViewData
    {
        public readonly List<TaxonomyTierTwoSectorExpenditure> TaxonomyTierTwoSectorExpenditures;
        public readonly List<Sector> Sectors;
        public readonly int? SelectedCalendarYear;
        public readonly IEnumerable<SelectListItem> CalendarYears;
        public readonly string SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoUrl;

        public SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<TaxonomyTierTwoSectorExpenditure> taxonomyTierTwoSectorExpenditures,
            List<Sector> sectors,
            int? selectedCalendarYear,
            IEnumerable<SelectListItem> calendarYears) : base(currentPerson, firmaPage)
        {
            TaxonomyTierTwoSectorExpenditures = taxonomyTierTwoSectorExpenditures;
            PageTitle = string.Format("Spending by Sector by {0} by {1}", MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(), MultiTenantHelpers.GetTaxonomyTierTwoDisplayName());
            SelectedCalendarYear = selectedCalendarYear;
            CalendarYears = calendarYears;
            Sectors = sectors;
            SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwo(UrlTemplate.Parameter1Int));
        }
    }
}