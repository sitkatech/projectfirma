/*-----------------------------------------------------------------------
<copyright file="RoleController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Role;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class RoleController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [UserEditFeature]
        public GridJsonNetJObjectResult<IRole> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var roleSummaries = GetRoleSummaryData();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<IRole>(roleSummaries, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [UserEditFeature]
        public GridJsonNetJObjectResult<Person> PersonWithRoleGridJsonData(int roleID)
        {
            var role = Role.AllLookupDictionary[roleID];
            var gridSpec = new PersonWithRoleGridSpec();
            var peopleWithRole = role.GetPeopleWithRole();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Person>(peopleWithRole, gridSpec);
            return gridJsonNetJObjectResult;
        }

        public static List<IRole> GetRoleSummaryData()
        {
            var roles = new List<IRole> {new AnonymousRole()};
            roles.AddRange(Role.All);
            return roles.OrderBy(x => x.RoleDisplayName).ToList();
        }

        [FirmaAdminFeature]
        public ViewResult Anonymous()
        {
            return ViewDetail(new AnonymousRole());
        }

        [FirmaAdminFeature]
        public ViewResult Detail(int roleID)
        {
            var role = Role.AllLookupDictionary[roleID];
            return ViewDetail(role);
        }

        private ViewResult ViewDetail(IRole role)
        {
            var viewData = new DetailViewData(CurrentPerson, role);
            return RazorView<Detail, DetailViewData>(viewData);
        }
    }
}
