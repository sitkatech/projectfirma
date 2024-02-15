﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using LtInfo.Common.AgGridWrappers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.FundingSourceCustomAttributes;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.FundingSource FundingSource { get; }
        public bool UserHasFundingSourceManagePermissions { get; }
        public bool UserHasFundingSourceCustomAttributeManagePermissions { get; }
        public bool UserHasProjectFundingSourceExpenditureManagePermissions { get; }
        public string EditFundingSourceUrl { get; }
        public string ManageFundingSourcesUrl { get; }
        public readonly string EditFundingSourceCustomAttributesUrl;

        public List<int> CalendarYearsForProjectExpenditures { get; }

        public ProjectCalendarYearExpendituresGridSpec ProjectCalendarYearExpendituresGridSpec { get; }
        public string ProjectCalendarYearExpendituresGridName { get; }
        public string ProjectCalendarYearExpendituresGridDataUrl { get; }
        public ViewGoogleChartViewData ViewGoogleChartViewData { get; }

        public GridSpec<ProjectFirmaModels.Models.ProjectFundingSourceBudget> ProjectFundingSourceBudgetGridSpec { get; }
        public string ProjectFundingSourceBudgetGridName { get; }
        public string ProjectFundingSourceBudgetGridDataUrl { get; }
        public DisplayFundingSourceCustomAttributesViewData DisplayFundingSourceCustomAttributeTypesViewData { get; private set; }
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public readonly MapInitJson MapInitJson;
        public readonly LayerGeoJson ProjectLocationsLayerGeoJson;
        public readonly bool HasSpatialData;

        public DetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FundingSource fundingSource,
            ViewGoogleChartViewData viewGoogleChartViewData,
            GridSpec<ProjectFirmaModels.Models.ProjectFundingSourceBudget> projectFundingSourceBudgetGridSpec,
            DisplayFundingSourceCustomAttributesViewData displayFundingSourceCustomAttributeTypesViewData,
            MapInitJson mapInitJson,
            LayerGeoJson projectLocationsLayerGeoJson,
            bool hasSpatialData,
            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures) : base(currentFirmaSession)
        {
            ViewGoogleChartViewData = viewGoogleChartViewData;
            FundingSource = fundingSource;
            PageTitle = fundingSource.GetDisplayName();
            EntityName = $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}";
            UserHasFundingSourceManagePermissions = new FundingSourceEditFeature().HasPermission(currentFirmaSession, fundingSource).HasPermission;
            UserHasFundingSourceCustomAttributeManagePermissions = new FundingSourceCustomAttributeEditFeature().HasPermission(currentFirmaSession, fundingSource).HasPermission;
            UserHasProjectFundingSourceExpenditureManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
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

            ProjectFundingSourceBudgetGridSpec = projectFundingSourceBudgetGridSpec;
            ProjectFundingSourceBudgetGridName = "projectsFundingSourceRequestsFromFundingSourceGrid";
            ProjectFundingSourceBudgetGridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.ProjectFundingSourceBudgetGridJsonData(fundingSource));

            DisplayFundingSourceCustomAttributeTypesViewData = displayFundingSourceCustomAttributeTypesViewData;

            MapInitJson = mapInitJson;
            ProjectLocationsLayerGeoJson = projectLocationsLayerGeoJson;
            HasSpatialData = hasSpatialData;

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(x => fundingSource.GetPerformanceMeasureChartViewData(x, currentFirmaSession)).ToList();

        }
    }
}
