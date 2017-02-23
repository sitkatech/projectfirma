/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class IndexViewData : FirmaViewData
    {
        public readonly PerformanceMeasureGridSpec PerformanceMeasureGridSpec;
        public readonly string PerformanceMeasureGridName;
        public readonly string PerformanceMeasureGridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            PageTitle = MultiTenantHelpers.GetPerformanceMeasureNamePluralized();

            var hasPerformanceMeasureManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);

            PerformanceMeasureGridSpec = new PerformanceMeasureGridSpec (hasPerformanceMeasureManagePermissions) {
                ObjectNameSingular = MultiTenantHelpers.GetPerformanceMeasureName(),
                ObjectNamePlural = MultiTenantHelpers.GetPerformanceMeasureNamePluralized(),
                SaveFiltersInCookie = true
            };

            if (hasPerformanceMeasureManagePermissions)
            {
                var contentUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.New());
                PerformanceMeasureGridSpec.CreateEntityModalDialogForm = new ModalDialogForm(contentUrl, "Create a new Performance Measure");
            }

            PerformanceMeasureGridName = "performanceMeasuresGrid";
            PerformanceMeasureGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.PerformanceMeasureGridJsonData());
        }
    }
}
