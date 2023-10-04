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
        public bool UnderservedCommunitiesHasData { get; }

        public ProjectDashboardChartsViewData(GoogleChartJson underservedCommunitiesGoogleChart, GoogleChartJson projectsByOwnerOrgTypeGoogleChart)
        {
            UnderservedCommunitiesViewGoogleChartViewData = new ViewGoogleChartViewData(underservedCommunitiesGoogleChart, underservedCommunitiesGoogleChart.GoogleChartConfiguration.Title, 350, true, true);
            UnderservedCommunitiesHasData = false;
            foreach (var slice in ((GooglePieChartConfiguration)underservedCommunitiesGoogleChart.GoogleChartConfiguration).Slices)
            {
                UnderservedCommunitiesHasData = UnderservedCommunitiesHasData || slice.Value > 0;
            }

            ProjectsByOwnerOrgTypeViewGoogleChartViewData = new ViewGoogleChartViewData(projectsByOwnerOrgTypeGoogleChart, projectsByOwnerOrgTypeGoogleChart.GoogleChartConfiguration.Title, 350, true);
            var orgIndexUrl = UrlTemplate.MakeHrefString(SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Index()), $"{FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().GetFieldDefinitionLabel()} Type");
            ProjectsByOwnerOrgTypeViewGoogleChartViewData.ChartTitleWithLink = new HtmlString($"<b>{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by " + orgIndexUrl + "</b>");
        }
    }
}