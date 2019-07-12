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
using ProjectFirmaModels.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.FundingSourceCustomAttributes;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class DetailViewData : FirmaViewData
    {
        public readonly ProjectFirmaModels.Models.FundingSource FundingSource;
        public readonly bool UserHasFundingSourceManagePermissions;
        public readonly bool UserHasProjectFundingSourceExpenditureManagePermissions;
        public readonly string EditFundingSourceUrl;
        public readonly string ManageFundingSourcesUrl;
        public readonly string EditFundingSourceCustomAttributesUrl;

        public readonly List<int> CalendarYearsForProjectExpenditures;

        public readonly ProjectCalendarYearExpendituresGridSpec ProjectCalendarYearExpendituresGridSpec;
        public readonly string ProjectCalendarYearExpendituresGridName;
        public readonly string ProjectCalendarYearExpendituresGridDataUrl;
        public readonly ViewGoogleChartViewData ViewGoogleChartViewData;

        public readonly GridSpec<ProjectFirmaModels.Models.ProjectFundingSourceRequest> ProjectFundingSourceRequestsGridSpec;
        public readonly string ProjectFundingSourceRequestsGridName;
        public readonly string ProjectFundingSourceRequestsGridDataUrl;

        public DisplayFundingSourceCustomAttributesViewData DisplayFundingSourceCustomAttributeTypesViewData { get; private set; }

        public DetailViewData(Person currentPerson, ProjectFirmaModels.Models.FundingSource fundingSource, ViewGoogleChartViewData viewGoogleChartViewData, GridSpec<ProjectFirmaModels.Models.ProjectFundingSourceRequest> projectFundingSourceRequestsGridSpec, DisplayFundingSourceCustomAttributesViewData displayFundingSourceCustomAttributeTypesViewData) : base(currentPerson)
        {
            ViewGoogleChartViewData = viewGoogleChartViewData;
            FundingSource = fundingSource;
            PageTitle = fundingSource.GetDisplayName();
            EntityName = $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}";
            UserHasFundingSourceManagePermissions = new FundingSourceEditFeature().HasPermission(CurrentPerson, fundingSource).HasPermission;
            UserHasProjectFundingSourceExpenditureManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            EditFundingSourceUrl = fundingSource.GetEditUrl();

            EditFundingSourceCustomAttributesUrl = SitkaRoute<FundingSourceCustomAttributesController>.BuildUrlFromExpression(c => c.EditFundingSourceCustomAttributesForFundingSource(fundingSource));

            var projectFundingSourceExpenditures = FundingSource.ProjectFundingSourceExpenditures.ToList();
            CalendarYearsForProjectExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(fundingSource);

            ProjectCalendarYearExpendituresGridSpec = new ProjectCalendarYearExpendituresGridSpec(CalendarYearsForProjectExpenditures)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            ProjectCalendarYearExpendituresGridName = "projectsCalendarYearExpendituresFromFundingSourceGrid";
            ProjectCalendarYearExpendituresGridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.ProjectCalendarYearExpendituresGridJsonData(fundingSource));
            ManageFundingSourcesUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Index());

            ProjectFundingSourceRequestsGridSpec = projectFundingSourceRequestsGridSpec;
            ProjectFundingSourceRequestsGridName = "projectsFundingSourceRequestsFromFundingSourceGrid";
            ProjectFundingSourceRequestsGridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.ProjectFundingSourceRequestsGridJsonData(fundingSource));

            DisplayFundingSourceCustomAttributeTypesViewData = displayFundingSourceCustomAttributeTypesViewData;
        }
    }
}
