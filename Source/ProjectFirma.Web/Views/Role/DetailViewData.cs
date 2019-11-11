/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using LtInfo.Common;
using Microsoft.Ajax.Utilities;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Role
{
    public class DetailViewData : FirmaViewData
    {
        public PersonWithRoleGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }

        public List<FeaturePermission> ApprovedFeatures { get; }
        public List<FeaturePermission> DeniedFeatures { get; }
        public string RoleName { get; }
        public HtmlString RoleDescription { get; }

        public DetailViewData(FirmaSession currentFirmaSession, IRole role, List<FeaturePermission> featurePermissions, string roleName)
            : base(currentFirmaSession)
        {
            ApprovedFeatures = featurePermissions.Where(x => x.HasPermission).ToList();
            DeniedFeatures = featurePermissions.Where(x => !x.HasPermission).ToList();

            RoleName = roleName;
            RoleDescription = role.GetFieldDefinitionRoleDescription();

            GridSpec = new PersonWithRoleGridSpec {ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true};
            GridName = "PersonWithRoleGrid";
            GridDataUrl = SitkaRoute<RoleController>.BuildUrlFromExpression(tc => tc.PersonWithRoleGridJsonData(role.RoleID));

            PageTitle = $"Role Summary for {roleName}";
            EntityName = "Role Summary";
        }
    }
}
