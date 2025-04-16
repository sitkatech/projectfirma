/*-----------------------------------------------------------------------
<copyright file="GridSettingsController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Helpers;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;
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
            var columnState = Request.Form["ColumnState"];
            var filterState = Request.Form["FilterState"];
            var gridName = Request.Form["GridName"];
            //var gridSetting = JsonTools.DeserializeObject<GridSetting>(formData);
            var gridSetting = new GridSetting(gridName, filterState, columnState);
            var gridSettingsViewModel = new GridSettingsViewModel(gridSetting);
            gridSettingsViewModel.Save(CurrentFirmaSession);
            return new JsonResult();
        }

        [HttpPost]
        [AnonymousUnclassifiedFeature]
        public JsonResult LoadGridSettings()
        {
            if (!CurrentFirmaSession.PersonID.HasValue)
            {
                return new JsonResult();
            }


            var gridName = Request.Form["GridName"];

            var personGridSetting = HttpRequestStorage.DatabaseEntities.PersonGridSettings.FirstOrDefault(x => x.PersonID == CurrentFirmaSession.PersonID.Value && x.GridName == gridName);
            if (personGridSetting == null)
            {
                return new JsonResult();
            }
            var gridSetting = new GridSetting(personGridSetting);

            return Json(gridSetting);
        }
    }
}