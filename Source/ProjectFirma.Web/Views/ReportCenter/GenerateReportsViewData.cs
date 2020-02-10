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
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ReportCenter
{
    public class GenerateReportsViewData : FirmaViewData
    {

        public List<ProjectFirmaModels.Models.Project> Projects { get; set; }
        public IEnumerable<SelectListItem> ReportTemplates { get; set; }

        public GenerateReportsViewData(FirmaSession currentFirmaSession, List<ProjectFirmaModels.Models.Project> projectsList,  IEnumerable<SelectListItem> reportTemplateSelectListItems) : base(currentFirmaSession)
        {
            PageTitle = "Generate Reports Testing title";
            Projects = projectsList;
            ReportTemplates = reportTemplateSelectListItems;
        }

    }
}
