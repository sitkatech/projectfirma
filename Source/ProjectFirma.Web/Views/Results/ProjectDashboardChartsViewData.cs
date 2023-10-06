/*-----------------------------------------------------------------------
<copyright file="ProjectDashboardChartsViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectDashboardChartsViewData : FirmaUserControlViewData
    {
        public readonly ViewGoogleChartViewData UnderservedCommunitiesViewGoogleChartViewData;
        public readonly ViewGoogleChartViewData ProjectsByOwnerOrgTypeViewGoogleChartViewData;
        public readonly ViewGoogleChartViewData ProjectsByCountyAndTribalLandViewGoogleChartViewData;
        public readonly ViewGoogleChartViewData ProjectsByProjectTypeViewGoogleChartViewData;
        public readonly ViewGoogleChartViewData ProjectStagesViewGoogleChartViewData;
        public readonly ViewGoogleChartViewData FundingOrganizationsViewGoogleChartViewData;
        public bool UnderservedCommunitiesHasData { get; }
        public bool ProjectsByOwnerOrgTypeHasData { get; }
        public bool ProjectsByCountyAndTribalLandHasData { get; }
        public bool ProjectsByProjectTypeHasData { get; }
        public bool ProjectStagesHasData { get; }
        public bool FundingOrganizationsHasData { get; }

        public ProjectDashboardChartsViewData(GoogleChartJson underservedCommunitiesGoogleChart, GoogleChartJson projectsByOwnerOrgTypeGoogleChart, GoogleChartJson projectsByCountyAndTribalLandGoogleChart, int countyGeospatialAreaTypeID, int tribalLandGeospatialAreaTypeID,
            GoogleChartJson projectsByProjectTypeGoogleChart, int projectTypeClassificationSystemID, GoogleChartJson projectStagesGoogleChart, GoogleChartJson fundingOrganizationGoogleChart)
        {
            UnderservedCommunitiesViewGoogleChartViewData = new ViewGoogleChartViewData(underservedCommunitiesGoogleChart, underservedCommunitiesGoogleChart.GoogleChartConfiguration.Title, 350, true, true);
            UnderservedCommunitiesHasData = false;
            foreach (var slice in ((GooglePieChartConfiguration)underservedCommunitiesGoogleChart.GoogleChartConfiguration).Slices)
            {
                UnderservedCommunitiesHasData = UnderservedCommunitiesHasData || slice.Value > 0;
            }

            ProjectsByOwnerOrgTypeViewGoogleChartViewData = new ViewGoogleChartViewData(projectsByOwnerOrgTypeGoogleChart, projectsByOwnerOrgTypeGoogleChart.GoogleChartConfiguration.Title, 350, true);
            var orgIndexUrl = UrlTemplate.MakeHrefString(SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Index()), $"{FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().GetFieldDefinitionLabel()} Type");
            ProjectsByOwnerOrgTypeViewGoogleChartViewData.ChartTitleWithLink = new HtmlString($"<b>{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by {orgIndexUrl}</b>");
            ProjectsByOwnerOrgTypeHasData = projectsByOwnerOrgTypeGoogleChart.HasData();

            ProjectsByCountyAndTribalLandViewGoogleChartViewData = new ViewGoogleChartViewData(projectsByCountyAndTribalLandGoogleChart, projectsByCountyAndTribalLandGoogleChart.GoogleChartConfiguration.Title, 350, true);
            var countyIndexUrl = UrlTemplate.MakeHrefString(SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(c => c.Index(countyGeospatialAreaTypeID)), "County");
            var tribalLandIndexUrl = UrlTemplate.MakeHrefString(SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(c => c.Index(tribalLandGeospatialAreaTypeID)), "Tribal Land");
            ProjectsByCountyAndTribalLandViewGoogleChartViewData.ChartTitleWithLink = new HtmlString($"<b>{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by {countyIndexUrl} & {tribalLandIndexUrl}</b>");
            ProjectsByCountyAndTribalLandHasData = projectsByCountyAndTribalLandGoogleChart.HasData();

            ProjectsByProjectTypeViewGoogleChartViewData = new ViewGoogleChartViewData(projectsByProjectTypeGoogleChart, projectsByProjectTypeGoogleChart.GoogleChartConfiguration.Title, 350, true);
            var projectTypesIndexUrl = UrlTemplate.MakeHrefString(SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.ClassificationSystem(projectTypeClassificationSystemID)), "Project Types");
            ProjectsByProjectTypeViewGoogleChartViewData.ChartTitleWithLink = new HtmlString($"<b>{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by {projectTypesIndexUrl}</b>");
            ProjectsByProjectTypeHasData = projectsByProjectTypeGoogleChart.HasData();

            ProjectStagesViewGoogleChartViewData = new ViewGoogleChartViewData(projectStagesGoogleChart, projectStagesGoogleChart.GoogleChartConfiguration.Title, 350, true, true);
            ProjectStagesHasData = false;
            foreach (var slice in ((GooglePieChartConfiguration)projectStagesGoogleChart.GoogleChartConfiguration).Slices)
            {
                ProjectStagesHasData = ProjectStagesHasData || slice.Value > 0;
            }

            FundingOrganizationsViewGoogleChartViewData = new ViewGoogleChartViewData(fundingOrganizationGoogleChart, fundingOrganizationGoogleChart.GoogleChartConfiguration.Title, 350, true);
            var fundingSourcesIndexUrl = UrlTemplate.MakeHrefString(SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Index()), $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}");
            FundingOrganizationsViewGoogleChartViewData.ChartTitleWithLink = new HtmlString($"<b>{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by {fundingSourcesIndexUrl}</b>");
            FundingOrganizationsHasData = fundingOrganizationGoogleChart.HasData();
        }
    }
}