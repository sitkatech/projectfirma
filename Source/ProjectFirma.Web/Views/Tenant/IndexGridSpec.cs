/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Tenant
{
    public class IndexGridSpec : GridSpec<Models.TenantAttribute>
    {
        public IndexGridSpec()
        {
            Add("Tenant Display Name",
                t => new SitkaRoute<TenantController>(c => c.Detail(t.PrimaryKey)).BuildLinkFromExpression(t.TenantDisplayName).ToHTMLFormattedString(),
                150,
                DhtmlxGridColumnFilterType.Html);

            Add("Tenant Name", t => t.Tenant.TenantName, 150);
            Add("Tenant Domain", t => t.Tenant.TenantDomain, 200);

            Add("Primary Contact",
                t =>
                    t.PrimaryContactPerson != null
                        ? new SitkaRoute<UserController>(c => c.Detail(t.PrimaryContactPerson)).BuildLinkFromExpression(t.PrimaryContactPerson.FullNameFirstLast).ToHTMLFormattedString()
                        : new HtmlString(""),
                200,
                DhtmlxGridColumnFilterType.Html);
        }
    }
}
