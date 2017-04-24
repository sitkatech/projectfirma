/*-----------------------------------------------------------------------
<copyright file="InvestmentByFundingSectorViewData.cs" company="Tahoe Regional Planning Agency">
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
    public class InvestmentByFundingSectorViewData : FirmaViewData
    {
        public readonly List<FundingSectorExpenditure> FundingSectorExpenditures;
        public readonly int? SelectedCalendarYear;
        public readonly string ProjectFundingSourceExpendituresBySectorUrl;
        public readonly string InvestmentByFundingSectorUrl;
        public readonly IEnumerable<SelectListItem> CalendarYears;
        public readonly string SpendingBySectorAndOrganizationUrl;
        public readonly string ReportingYearRangeTitle;
        public readonly GoogleChartJson GoogleChartJson;

        public InvestmentByFundingSectorViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<FundingSectorExpenditure> fundingSectorExpenditures,
            int? selectedCalendarYear,
            IEnumerable<SelectListItem> calendarYears,
            string reportingYearRangeTitle) : base(currentPerson, firmaPage)
        {
            FundingSectorExpenditures = fundingSectorExpenditures;
            PageTitle = "Investment by Funding Sector";
            SelectedCalendarYear = selectedCalendarYear;
            CalendarYears = calendarYears;
            ReportingYearRangeTitle = reportingYearRangeTitle;
            ProjectFundingSourceExpendituresBySectorUrl =
                SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectFundingSourceExpendituresBySector(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            SpendingBySectorAndOrganizationUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingBySectorByOrganization(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            InvestmentByFundingSectorUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.InvestmentByFundingSector(UrlTemplate.Parameter1Int));

            GoogleChartJson = ResultsController.GetInvestmentByFundingSectorGoogleChart(FundingSectorExpenditures, selectedCalendarYear);
            GoogleChartJson.GoogleChartConfiguration.SetSize(300, 350);
        }
    }
}
