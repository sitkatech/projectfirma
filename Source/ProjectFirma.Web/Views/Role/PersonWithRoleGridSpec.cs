﻿/*-----------------------------------------------------------------------
<copyright file="PersonWithRoleGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Web;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Role
{
    public class PersonWithRoleGridSpec : GridSpec<Person>
    {
        public PersonWithRoleGridSpec()
        {
            Add("Last Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.LastName), 200, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add("First Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.FirstName), 200, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", a => a.Organization.GetDisplayName(), 200, AgGridColumnFilterType.SelectFilterStrict);
            Add("Last Activity", a => a.LastActivityDate.ToString(), 200, AgGridColumnFilterType.SelectFilterStrict);
        }
    }
}
