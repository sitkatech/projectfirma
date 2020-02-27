/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Reports
{
    public class EditViewData : FirmaViewData
    {
        public readonly ProjectFirmaModels.Models.ReportTemplate ReportTemplate;
        public IEnumerable<SelectListItem> AllReportTemplateModelTypeSelectItems;
        public IEnumerable<SelectListItem> AllReportTemplateModelSelectItems;

        public EditViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base (currentFirmaSession, firmaPage)
        {
            AllReportTemplateModelTypeSelectItems = ReportTemplateModelType.All.ToSelectList(x => x.ReportTemplateModelTypeID.ToString(),x => x.ReportTemplateModelTypeDisplayName);
            AllReportTemplateModelSelectItems = ReportTemplateModel.All.ToSelectList(x => x.ReportTemplateModelID.ToString(),x => x.ReportTemplateModelDisplayName);
        }

        public EditViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, ProjectFirmaModels.Models.ReportTemplate reportTemplate) : this(currentFirmaSession, firmaPage)
        {
            ReportTemplate = reportTemplate;
        }


    }
}
