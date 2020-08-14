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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Formatting;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office.Word;
using LtInfo.Common.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{

    public class GridSettingsViewModel : FormViewModel, IValidatableObject
    {
        public string GridName { get; set; }
        public string Data { get; set; }

        public GridSettingsViewModel()
        {

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }

    public class GridSettingsController : FirmaBaseController
    {
        [HttpPost]
        [AnonymousUnclassifiedFeature]
        public JsonResult SaveGridSettings()
        {
            // todo: handle the saved grid settings that were posted
            
            return new JsonResult();
        }
    }
}