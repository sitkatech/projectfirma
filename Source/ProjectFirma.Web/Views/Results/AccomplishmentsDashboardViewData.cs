/*-----------------------------------------------------------------------
<copyright file="InvestmentByFundingOrganizationTypeViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class AccomplishmentsDashboardViewData : FirmaViewData
    {
        public string OrganizationDashboardSummaryUrl { get; }
        public string OrganizationAccomplishmentsUrl { get; }
        public string TaxonomyTierTwoDetailUrl { get; }
        public string OrganizationDetailUrl { get; }
        public string SpendingByOrganizationTypeAndOrganizationUrl { get; }
        public string ParticipatingOrganizationsUrl { get; }

        public List<Models.Organization> Organizations { get; }
        public List<int> CalendarYears { get; }
        public int DefaultBeginYear { get; }
        public int DefaultEndYear { get; }
        public List<Models.TaxonomyTierTwo> TaxonomyTierTwos { get; }
        public string ProjectStewardOrganizationTypeName { get; }

        public AccomplishmentsDashboardViewData(Person currentPerson, Models.FirmaPage firmaPage, List<Models.Organization> organizations, List<int> calendarYears, int defaultBeginYear, int defaultEndYear, List<Models.TaxonomyTierTwo> taxonomyTierTwos) :
            base(currentPerson, firmaPage)
        {
            var projectStewardOrganizationTypeName = Models.FieldDefinition.ProjectStewardOrganizationDisplayName
                .GetFieldDefinitionLabelPluralized();
            PageTitle = "Accomplishments Dashboard";
            Organizations = organizations;
            CalendarYears = calendarYears;
            DefaultBeginYear = defaultBeginYear;
            DefaultEndYear = defaultEndYear;
            TaxonomyTierTwos = taxonomyTierTwos;
            ParticipatingOrganizationsUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ParticipatingOrganizations(UrlTemplate.Parameter1Int));
            OrganizationDashboardSummaryUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.OrganizationDashboardSummary(UrlTemplate.Parameter1Int));
            OrganizationAccomplishmentsUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.OrganizationAccomplishments(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            TaxonomyTierTwoDetailUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(x => x.Detail(UrlTemplate.Parameter1Int));
            OrganizationDetailUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(UrlTemplate.Parameter1Int));
            SpendingByOrganizationTypeAndOrganizationUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByOrganizationTypeByOrganization(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int, UrlTemplate.Parameter3Int));
            ProjectStewardOrganizationTypeName = projectStewardOrganizationTypeName;
        }
    }
}
