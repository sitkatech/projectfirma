/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Reports
{
    public class ReportTemplateGridSpec : GridSpec<ProjectFirmaModels.Models.ReportTemplate>
    {
        public ReportTemplateGridSpec(bool hasManagePermissions)
        {
            if (hasManagePermissions)
            {
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(SitkaRoute<ReportsController>.BuildUrlFromExpression(t => t.Delete(a)), true), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(SitkaRoute<ReportsController>.BuildUrlFromExpression(t => t.Edit(a)), "Edit Report Template"), 30, DhtmlxGridColumnFilterType.None);
            }
            Add("Display Name", a => a.DisplayName, 200);
            Add("Description", a => a.Description, 400);
            Add("Model", a => a.ReportTemplateModel.ReportTemplateModelDisplayName, 100);
            //Add("Model Type", a => a.ReportTemplateModelType.ReportTemplateModelTypeDisplayName, 100);
            Add("Template File", a => a.DownloadTemplateLink(), 200, DhtmlxGridColumnFilterType.Html);
        }
    }
}
