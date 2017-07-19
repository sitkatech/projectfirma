/*-----------------------------------------------------------------------
<copyright file="SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewData.cs" company="Tahoe Regional Planning Agency">
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
    public class SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewData : FirmaViewData
    {
        public readonly List<TaxonomyTierTwoOrganizationTypeExpenditure> TaxonomyTierTwoOrganizationTypeExpenditures;
        public readonly List<Models.OrganizationType> OrganizationTypes;
        public readonly int? SelectedCalendarYear;
        public readonly IEnumerable<SelectListItem> CalendarYears;
        public readonly string SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoUrl;
        public readonly string TaxonomyTierTwoDisplayNamePluralized;

        public SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<TaxonomyTierTwoOrganizationTypeExpenditure> taxonomyTierTwoOrganizationTypeExpenditures,
            List<Models.OrganizationType> organizationTypes,
            int? selectedCalendarYear,
            IEnumerable<SelectListItem> calendarYears) : base(currentPerson, firmaPage)
        {
            TaxonomyTierTwoOrganizationTypeExpenditures = taxonomyTierTwoOrganizationTypeExpenditures;
            PageTitle =
                $"Spending by {Models.FieldDefinition.OrganizationType.GetFieldDefinitionLabel()} by {Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabel()} by {Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel()}";
            SelectedCalendarYear = selectedCalendarYear;
            CalendarYears = calendarYears;
            OrganizationTypes = organizationTypes;
            SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwo(UrlTemplate.Parameter1Int));
            TaxonomyTierTwoDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized();
        }
    }
}
