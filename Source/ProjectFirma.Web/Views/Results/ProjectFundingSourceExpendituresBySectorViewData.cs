/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpendituresBySectorViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectFundingSourceExpendituresBySectorViewData : FirmaUserControlViewData
    {
        public readonly ProjectFundingSourceExpendituresBySectorGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public ProjectFundingSourceExpendituresBySectorViewData(int? organizationTypeID, int? calendarYear)
        {
            var organizationTypeDisplayName = "all Organization Types";
            if (organizationTypeID.HasValue)
            {
                var organizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetOrganizationType(organizationTypeID.Value);
                organizationTypeDisplayName = string.Format("selected Organization Type: {0}", organizationType.OrganizationTypeName);
            }
            GridSpec = new ProjectFundingSourceExpendituresBySectorGridSpec(calendarYear)
            {
                ObjectNameSingular = string.Format("record by {0}", organizationTypeDisplayName),
                ObjectNamePlural = string.Format("records by {0}", organizationTypeDisplayName),
                SaveFiltersInCookie = true
            };

            GridName = "projectFundingSourceExpendituresBySectorGrid";
            GridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(tc => tc.ProjectExpendituresByFundingSectorGridJsonData(organizationTypeID, calendarYear));
        }
    }
}
