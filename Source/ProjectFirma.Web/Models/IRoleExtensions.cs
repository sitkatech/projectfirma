/*-----------------------------------------------------------------------
<copyright file="IRoleExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static class IRoleExtensions
    {
        /// <summary>
        /// Note AnonymousRole should not use this!
        /// </summary>
        public static string GetSummaryUrl(this IRole role)
        {
            if (role is AnonymousRole)
            {
                return SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Anonymous());
            }
            else
            {
                return SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Detail(role.RoleID));
            }

        }

        public static List<FeaturePermission> GetFeaturePermissions(this IRole role, Type baseFeatureType)
        {
            var featurePermissions = new List<FeaturePermission>();

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => baseFeatureType.IsAssignableFrom(p) && p.Name != baseFeatureType.Name && !p.IsAbstract);
            foreach (var type in types)
            {                                           
                string featureDisplayName = FirmaBaseFeatureHelpers.GetDisplayName(type);
                var hasPermission = FirmaBaseFeatureHelpers.DoesRoleHavePermissionsForFeature(role, type);

                //Don't add duplicates to the list
                if (featurePermissions.All(x => x.FeatureName != featureDisplayName))
                {
                    featurePermissions.Add(new FeaturePermission(featureDisplayName, hasPermission));
                }
            }
            return featurePermissions;
        }

    }
}
