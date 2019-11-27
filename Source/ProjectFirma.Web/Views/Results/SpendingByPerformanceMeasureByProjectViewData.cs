/*-----------------------------------------------------------------------
<copyright file="SpendingByPerformanceMeasureByProjectViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectViewData : FirmaViewData
    {        
        public ProjectFirmaModels.Models.PerformanceMeasure SelectedPerformanceMeasure { get; }
        public List<ProjectFirmaModels.Models.PerformanceMeasure> PerformanceMeasures { get; }
        public string SpendingByPerformanceMeasureByProjectUrl { get; }

        public PerformanceMeasureChartViewData PerformanceMeasureChartViewData { get; }

        public SpendingByPerformanceMeasureByProjectGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }

        public SpendingByPerformanceMeasureByProjectViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.FirmaPage firmaPage,
            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures,
            ProjectFirmaModels.Models.PerformanceMeasure selectedPerformanceMeasure,
            PerformanceMeasureChartViewData performanceMeasureChartViewData) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Spending by {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} for Selected {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}";

            PerformanceMeasures = performanceMeasures;
            SelectedPerformanceMeasure = selectedPerformanceMeasure;
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;

            SpendingByPerformanceMeasureByProjectUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProject(UrlTemplate.Parameter1Int));

            GridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(SelectedPerformanceMeasure)
            {
                ObjectNameSingular = $"record by {MultiTenantHelpers.GetPerformanceMeasureName()} {SelectedPerformanceMeasure.PerformanceMeasureID}: {SelectedPerformanceMeasure.PerformanceMeasureDisplayName}",
                ObjectNamePlural = $"records by {MultiTenantHelpers.GetPerformanceMeasureName()} {SelectedPerformanceMeasure.PerformanceMeasureID}: {SelectedPerformanceMeasure.PerformanceMeasureDisplayName}",
                SaveFiltersInCookie = true
            };

            GridName = "projectFundingSourceExpendituresByOrganizationTypeGrid";
            GridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProjectGridJsonData(selectedPerformanceMeasure.PerformanceMeasureID));
        }
    }
}
