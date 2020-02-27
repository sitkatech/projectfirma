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
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Reports
{
    public class IndexViewData : FirmaViewData
    {
        public ReportTemplateGridSpec GridSpec { get;  }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public bool HasManageReportTemplatePermissions { get; }
        public string NewUrl { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            GridSpec = new ReportTemplateGridSpec(new ReportTemplateViewListFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                ObjectNameSingular = "Report Template",
                ObjectNamePlural = "Report Templates",
                SaveFiltersInCookie = true
            };
            GridName = "ReportTemplates";
            PageTitle = "Report Center";
            GridDataUrl = SitkaRoute<ReportsController>.BuildUrlFromExpression(rcc => rcc.IndexGridJsonData());
            HasManageReportTemplatePermissions = new ReportTemplateManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            NewUrl = SitkaRoute<ReportsController>.BuildUrlFromExpression(t => t.New());
        }
    }
}
