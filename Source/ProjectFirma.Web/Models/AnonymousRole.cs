/*-----------------------------------------------------------------------
<copyright file="AnonymousRole.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class AnonymousRole : IRole
    {
        public int RoleID { get { return ModelObjectHelpers.NotYetAssignedID; } }
        public string RoleName { get { return "Anonymous"; } }
        public string RoleDisplayName { get { return "Anonymous (no login required)"; } }
        public string RoleDescription { get { return "This is the default security level for users who do not have a login. Any logged in user can also access all of these features."; } }
        public List<FeaturePermission> GetFeaturePermissions()
        {
            var featurePermissions = IRoleExtensions.GetFeaturePermissions(null, typeof(AnonymousUnclassifiedFeature));
            return featurePermissions;
        }

        public List<Person> GetPeopleWithRole()
        {
            return new List<Person>();
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Anonymous()), RoleDisplayName);
        }
    }
}
