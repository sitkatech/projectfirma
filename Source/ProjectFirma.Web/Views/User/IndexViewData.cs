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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.User
{
    public class IndexViewData : FirmaViewData
    {
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }

        public string PullUserFromKeystoneUrl { get; }
        public bool UserIsSitkaAdmin { get; }

        public IndexViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Users";
            GridSpec = new IndexGridSpec(currentPerson) {ObjectNameSingular = "User", ObjectNamePlural = "Users", SaveFiltersInCookie = true};
            GridName = "UserGrid";
            GridDataUrl = SitkaRoute<UserController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());

            PullUserFromKeystoneUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.PullUserFromKeystone());
            UserIsSitkaAdmin = new SitkaAdminFeature().HasPermissionByPerson(currentPerson);
        }
    }
}
