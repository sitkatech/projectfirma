/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Role
{
    public class DetailViewData : FirmaViewData
    {
        public readonly PersonWithRoleGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public List<FeaturePermission> ApprovedFeatures;
        public List<FeaturePermission> DeniedFeatures;
        public List<Person> PeopleWithRole;
        public readonly string RoleName;
        public readonly string RoleDescription;

        public DetailViewData(Person currentPerson, IRole role)
            : base(currentPerson)
        {
            var featurePermissions = role.GetFeaturePermissions();
            ApprovedFeatures = featurePermissions.Where(x => x.HasPermission).ToList();
            DeniedFeatures = featurePermissions.Where(x => !x.HasPermission).ToList();

            RoleName = role.RoleDisplayName;
            RoleDescription = role.RoleDescription;

            GridSpec = new PersonWithRoleGridSpec() {ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true};
            GridName = "PersonWithRoleGrid";
            GridDataUrl = SitkaRoute<RoleController>.BuildUrlFromExpression(tc => tc.PersonWithRoleGridJsonData(role.RoleID));

            PageTitle = String.Format("Role Summary for {0}", RoleName);
            EntityName = "Role Summary";
        }
    }
}
