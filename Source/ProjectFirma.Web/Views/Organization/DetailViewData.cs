/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using ProjectFirma.Web.Views.PerformanceMeasure;

namespace ProjectFirma.Web.Views.Organization
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Organization Organization;
        public readonly bool UserHasOrganizationManagePermissions;
        public readonly string EditOrganizationUrl;
        public readonly string EditBoundaryUrl;
        public readonly string DeleteOrganizationBoundaryUrl;
        public readonly ProjectsIncludingLeadImplementingGridSpec ProjectsIncludingLeadImplementingGridSpec;
        public readonly string ProjectOrganizationsGridName;
        public readonly string ProjectOrganizationsGridDataUrl;
        public readonly CalendarYearExpendituresLineChartViewData CalendarYearExpendituresLineChartViewData;

        public readonly string ManageFundingSourcesUrl;
        public readonly string IndexUrl;

        public readonly MapInitJson MapInitJson;
        public readonly bool HasSpatialData;

        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;
        public readonly string NewFundingSourceUrl;
        public readonly bool CanCreateNewFundingSource; 

        public DetailViewData(Person currentPerson,
            Models.Organization organization,
            CalendarYearExpendituresLineChartViewData calendarYearExpendituresLineChartViewData,
            MapInitJson mapInitJson,
            bool hasSpatialData,
            List<Models.PerformanceMeasure> performanceMeasures) : base(currentPerson)
        {
            Organization = organization;
            CalendarYearExpendituresLineChartViewData = calendarYearExpendituresLineChartViewData;
            PageTitle = organization.DisplayName;
            EntityName = $"{Models.FieldDefinition.Organization.GetFieldDefinitionLabel()}";
            UserHasOrganizationManagePermissions = new OrganizationManageFeature().HasPermissionByPerson(CurrentPerson);

            EditOrganizationUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Edit(organization));
            EditBoundaryUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditBoundary(organization));
            DeleteOrganizationBoundaryUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(
                    c => c.DeleteOrganizationBoundary(organization));

            ProjectsIncludingLeadImplementingGridSpec =
                new ProjectsIncludingLeadImplementingGridSpec(organization)
                {
                    ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}",
                    ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} associated with {organization.DisplayName}",
                    SaveFiltersInCookie = true
                };

            ProjectOrganizationsGridName = "projectOrganizationsFromOrganizationGrid";
            ProjectOrganizationsGridDataUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(
                    tc => tc.ProjectsIncludingLeadImplementingGridJsonData(organization));
            ManageFundingSourcesUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Index());
            IndexUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Index());

            MapInitJson = mapInitJson;
            HasSpatialData = hasSpatialData;

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(organization.GetPerformanceMeasureChartViewData).ToList();

            NewFundingSourceUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.New());
            CanCreateNewFundingSource = new FundingSourceCreateFeature().HasPermissionByPerson(CurrentPerson) && CurrentPerson.OrganizationID == organization.OrganizationID;
        }
    }
}
