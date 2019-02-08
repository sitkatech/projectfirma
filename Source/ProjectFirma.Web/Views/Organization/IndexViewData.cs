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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class IndexViewData : FirmaViewData
    {
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string PullOrganizationFromKeystoneUrl { get; }
        public bool UserIsSitkaAdmin { get; }
        public bool HasOrganizationManagePermissions { get; }
        public string NewUrl { get; }

        public IndexViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage)
            : base(currentPerson, firmaPage)
        {
            PageTitle = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}";

            var hasOrganizationManagePermissions = new OrganizationManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(currentPerson, hasOrganizationManagePermissions)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            GridName = "organizationsGrid";
            GridDataUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());

            PullOrganizationFromKeystoneUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.PullOrganizationFromKeystone());
            UserIsSitkaAdmin = new SitkaAdminFeature().HasPermissionByPerson(currentPerson);
            HasOrganizationManagePermissions = hasOrganizationManagePermissions;
            NewUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.New());
        }
    }
}
