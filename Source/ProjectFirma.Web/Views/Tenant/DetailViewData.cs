/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Tenant
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Tenant Tenant;
        public readonly TenantAttribute TenantAttribute;
        public readonly string IndexUrl;
        public string EditUrl;
        public readonly bool UserHasTenantManagePermissions;
        public readonly string PrimaryContactLink;

        public DetailViewData(Person currentPerson, Models.Tenant tenant, TenantAttribute tenantAttribute, string indexUrl, string editUrl, string primaryContactLink) : base(currentPerson)
        {
            PageTitle = tenant.TenantName;
            Tenant = tenant;
            TenantAttribute = tenantAttribute;
            IndexUrl = indexUrl;
            EditUrl = editUrl;
            PrimaryContactLink = primaryContactLink;
            UserHasTenantManagePermissions = new SitkaAdminFeature().HasPermissionByPerson(CurrentPerson);
        }
    }
}
