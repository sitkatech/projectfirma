﻿/*-----------------------------------------------------------------------
<copyright file="DetailGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Mvc;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Tenant
{
    public class DetailGridSpec : GridSpec<ProjectFirmaModels.Models.TenantAttribute>
    {
        public DetailGridSpec()
        {
            Add("Tenant Display Name", t => t.TenantShortDisplayName, 150);
            Add("Tenant Name", t => t.Tenant.TenantName, 150);
            Add("Tenant Domain", t => string.Format("<a href=\"http://{0}\" target=\"_blank\">{0}</a>", FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(t.Tenant)).ToHTMLFormattedString(), 200, AgGridColumnFilterType.Html);

            Add("Primary Contact",
                t =>
                    t.PrimaryContactPerson != null
                        ? new SitkaRoute<UserController>(c => c.Detail(t.PrimaryContactPerson)).BuildLinkFromExpression(t.PrimaryContactPerson.GetFullNameFirstLast()).ToHTMLFormattedString()
                        : new HtmlString(""),
                200,
                AgGridColumnFilterType.Html);
            Add("Is Tenant Enabled", t => t.Tenant.TenantEnabled.ToYesNo(), 60, AgGridColumnFilterType.SelectFilterStrict);
            Add("Is Tenant Active", t => t.IsActive.ToYesNo(), 60, AgGridColumnFilterType.SelectFilterStrict);
        }
    }
}
