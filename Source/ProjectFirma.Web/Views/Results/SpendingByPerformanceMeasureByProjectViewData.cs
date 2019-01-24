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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectViewData : FirmaViewData
    {        
        public readonly ProjectFirmaModels.Models.PerformanceMeasure SelectedPerformanceMeasure;
        public readonly List<ProjectFirmaModels.Models.PerformanceMeasure> PerformanceMeasures;
        public readonly string SpendingByPerformanceMeasureByProjectUrl;

        public readonly PerformanceMeasureChartViewData PerformanceMeasureChartViewData;
        
        public readonly SpendingByPerformanceMeasureByProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public SpendingByPerformanceMeasureByProjectViewData(Person currentPerson,
            ProjectFirmaModels.Models.FirmaPage firmaPage,
            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures,
            ProjectFirmaModels.Models.PerformanceMeasure selectedPerformanceMeasure,
            PerformanceMeasureChartViewData performanceMeasureChartViewData) : base(currentPerson, firmaPage)
        {
            PageTitle = string.Format("Spending by {0} for Selected {1}", FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel(), MultiTenantHelpers.GetPerformanceMeasureNamePluralized());

            PerformanceMeasures = performanceMeasures;
            SelectedPerformanceMeasure = selectedPerformanceMeasure;
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;

            SpendingByPerformanceMeasureByProjectUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProject(UrlTemplate.Parameter1Int));

            GridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(SelectedPerformanceMeasure)
            {
                ObjectNameSingular = string.Format("record by {0} {1}: {2}", MultiTenantHelpers.GetPerformanceMeasureName(), SelectedPerformanceMeasure.PerformanceMeasureID, SelectedPerformanceMeasure.PerformanceMeasureDisplayName),
                ObjectNamePlural = string.Format("records by {0} {1}: {2}", MultiTenantHelpers.GetPerformanceMeasureName(), SelectedPerformanceMeasure.PerformanceMeasureID, SelectedPerformanceMeasure.PerformanceMeasureDisplayName),
                SaveFiltersInCookie = true
            };

            GridName = "projectFundingSourceExpendituresByOrganizationTypeGrid";
            GridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByPerformanceMeasureByProjectGridJsonData(selectedPerformanceMeasure.PerformanceMeasureID));
        }
    }
}
