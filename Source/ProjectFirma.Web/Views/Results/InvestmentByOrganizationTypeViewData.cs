/*-----------------------------------------------------------------------
<copyright file="InvestmentByFundingOrganizationTypeViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class InvestmentByOrganizationTypeViewData : FirmaViewData
    {
        public readonly List<OrganizationTypeExpenditure> OrganizationTypeExpenditures;
        public readonly int? SelectedCalendarYear;
        public readonly string ProjectFundingSourceExpendituresByOrganizationTypeUrl;
        public readonly string InvestmentByFundingOrganizationTypeUrl;
        public readonly IEnumerable<SelectListItem> CalendarYears;
        public readonly string SpendingByOrganizationTypeAndOrganizationUrl;
        public readonly string ReportingYearRangeTitle;
        public readonly GoogleChartJson GoogleChartJson;

        public InvestmentByOrganizationTypeViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<OrganizationTypeExpenditure> organizationTypeExpenditures,
            int? selectedCalendarYear,
            IEnumerable<SelectListItem> calendarYears,
            string reportingYearRangeTitle) : base(currentPerson, firmaPage)
        {
            OrganizationTypeExpenditures = organizationTypeExpenditures;
            PageTitle = "Investment by Organization Type";
            SelectedCalendarYear = selectedCalendarYear;
            CalendarYears = calendarYears;
            ReportingYearRangeTitle = reportingYearRangeTitle;
            ProjectFundingSourceExpendituresByOrganizationTypeUrl =
                SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectFundingSourceExpendituresByOrganizationType(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            SpendingByOrganizationTypeAndOrganizationUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByOrganizationTypeByOrganization(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            InvestmentByFundingOrganizationTypeUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.InvestmentByOrganizationType(UrlTemplate.Parameter1Int));

            GoogleChartJson = ResultsController.GetInvestmentByOrganizationTypeGoogleChart(OrganizationTypeExpenditures, selectedCalendarYear);
            GoogleChartJson.GoogleChartConfiguration.SetSize(300, 350);
        }
    }
}
