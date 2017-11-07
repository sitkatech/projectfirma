/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.FundingSource FundingSource;
        public readonly bool UserHasFundingSourceManagePermissions;
        public readonly bool UserHasProjectFundingSourceExpenditureManagePermissions;
        public readonly string EditFundingSourceUrl;
        public readonly string EditReportedExpendituresUrl;
        public readonly string ManageFundingSourcesUrl;

        public readonly List<int> CalendarYearsForProjectExpenditures;

        public readonly ProjectCalendarYearExpendituresGridSpec ProjectCalendarYearExpendituresGridSpec;
        public readonly string ProjectCalendarYearExpendituresGridName;
        public readonly string ProjectCalendarYearExpendituresGridDataUrl;
        public readonly ViewGoogleChartViewData ViewGoogleChartViewData;

        public readonly GridSpec<Models.ProjectFundingSourceRequest> ProjectFundingSourceRequestsGridSpec;
        public readonly string ProjectFundingSourceRequestsGridName;
        public readonly string ProjectFundingSourceRequestsGridDataUrl;

        public DetailViewData(Person currentPerson, Models.FundingSource fundingSource, ViewGoogleChartViewData viewGoogleChartViewData, GridSpec<Models.ProjectFundingSourceRequest> projectFundingSourceRequestsGridSpec) : base(currentPerson)
        {
            ViewGoogleChartViewData = viewGoogleChartViewData;
            FundingSource = fundingSource;
            PageTitle = fundingSource.DisplayName;
            EntityName = $"{Models.FieldDefinition.FundingSource.GetFieldDefinitionLabel()}";
            UserHasFundingSourceManagePermissions = new FundingSourceEditFeature().HasPermission(CurrentPerson, fundingSource).HasPermission;
            UserHasProjectFundingSourceExpenditureManagePermissions = new ProjectFundingSourceExpenditureFromFundingSourceManageFeature().HasPermissionByPerson(currentPerson);
            EditFundingSourceUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Edit(fundingSource));
            EditReportedExpendituresUrl = SitkaRoute<ProjectFundingSourceExpenditureController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceExpendituresForFundingSource(fundingSource));

            var projectFundingSourceExpenditures = FundingSource.ProjectFundingSourceExpenditures.ToList();
            CalendarYearsForProjectExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(fundingSource);

            ProjectCalendarYearExpendituresGridSpec = new ProjectCalendarYearExpendituresGridSpec(CalendarYearsForProjectExpenditures)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            ProjectCalendarYearExpendituresGridName = "projectsCalendarYearExpendituresFromFundingSourceGrid";
            ProjectCalendarYearExpendituresGridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.ProjectCalendarYearExpendituresGridJsonData(fundingSource));
            ManageFundingSourcesUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Index());

            ProjectFundingSourceRequestsGridSpec = projectFundingSourceRequestsGridSpec;
            ProjectFundingSourceRequestsGridName = "projectsFundingSourceRequestsFromFundingSourceGrid";
            ProjectFundingSourceRequestsGridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.ProjectFundingSourceRequestsGridJsonData(fundingSource));
        }
    }
}
