/*-----------------------------------------------------------------------
<copyright file="GridSettingsController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Net.Http.Formatting;
using System.Web.Helpers;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class GridSettingsController : FirmaBaseController
    {
        [HttpPost]
        [AnonymousUnclassifiedFeature]
        public JsonResult SaveGridSettings()
        {
            var gridTable = JsonTools.DeserializeObject<GridTable>(Request.Form["Data"]);
            var gridSettingsViewModel = new GridSettingsViewModel(gridTable);
            gridSettingsViewModel.Save(CurrentFirmaSession);
            return new JsonResult();
        }
    }
}