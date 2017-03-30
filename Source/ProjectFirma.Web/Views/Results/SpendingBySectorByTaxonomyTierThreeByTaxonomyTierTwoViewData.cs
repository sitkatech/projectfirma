/*-----------------------------------------------------------------------
<copyright file="SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewData : FirmaViewData
    {
        public readonly List<TaxonomyTierTwoSectorExpenditure> TaxonomyTierTwoSectorExpenditures;
        public readonly List<Sector> Sectors;
        public readonly int? SelectedCalendarYear;
        public readonly IEnumerable<SelectListItem> CalendarYears;
        public readonly string SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoUrl;
        public readonly string TaxonomyTierTwoDisplayNamePluralized;

        public SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<TaxonomyTierTwoSectorExpenditure> taxonomyTierTwoSectorExpenditures,
            List<Sector> sectors,
            int? selectedCalendarYear,
            IEnumerable<SelectListItem> calendarYears) : base(currentPerson, firmaPage, false)
        {
            TaxonomyTierTwoSectorExpenditures = taxonomyTierTwoSectorExpenditures;
            PageTitle = string.Format("Spending by Sector by {0} by {1}", Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabel(), Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel());
            SelectedCalendarYear = selectedCalendarYear;
            CalendarYears = calendarYears;
            Sectors = sectors;
            SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwo(UrlTemplate.Parameter1Int));
            TaxonomyTierTwoDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized();
        }
    }
}
