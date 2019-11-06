/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class IndexViewData : FirmaViewData
    {
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public bool HasPerformanceMeasureManagePermissions { get; }
        public string NewUrl { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, List<ProjectFirmaModels.Models.FundingSourceCustomAttributeType> fundingSourceCustomAttributeType) :
            base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}";

            GridSpec = new IndexGridSpec(currentFirmaSession, fundingSourceCustomAttributeType)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            GridName = "fundingSourcesGrid";
            GridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            HasPerformanceMeasureManagePermissions = new FundingSourceCreateFeature().HasPermissionByFirmaSession(currentFirmaSession);
            NewUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(t => t.New());
        }
    }
}
