/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency">
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

using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.OrganizationType
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            PageTitle = "Organization Types";

            var hasOrganizationTypePermissions = new OrganizationTypeManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasOrganizationTypePermissions) { ObjectNameSingular = "Organization Type", ObjectNamePlural = "Organization Types", SaveFiltersInCookie = true };

            if (hasOrganizationTypePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<OrganizationTypeController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new Organization Type"));
            }

            GridName = "taxonomyTierTwosGrid";
            GridDataUrl = SitkaRoute<OrganizationTypeController>.BuildUrlFromExpression(otc => otc.IndexGridJsonData());
        }
    }
}
