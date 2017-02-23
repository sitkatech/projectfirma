/*-----------------------------------------------------------------------
<copyright file="FirmaBaseFeatureHelpers.cs" company="Sitka Technology Group">
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public static class FirmaBaseFeatureHelpers
    {
        public static readonly List<Role> AllRolesExceptUnassigned = Role.All.Except(new[] { Role.Unassigned }).ToList();

        public static bool DoesRoleHavePermissionsForFeature(IRole role, Type type)
        {
            var firmaBaseFeature = FirmaBaseFeature.InstantiateFeature(type);            
            if (IsContextFeatureByInheritance(firmaBaseFeature))
            {
                return true;
            }
            else
            {
                return firmaBaseFeature.GrantedRoles.Contains(role) || (role == null);
            }
        }

        public static string GetDisplayName(Type type)
        {
            var customAttributes = Attribute.GetCustomAttributes(type);
            var securityFeatureDescriptionAttribute = customAttributes.FirstOrDefault(x => x is SecurityFeatureDescription);            
            if (securityFeatureDescriptionAttribute != null)
            {
                return ((SecurityFeatureDescription)securityFeatureDescriptionAttribute).Name;
            }
            else
            {
                return type.FullName;
            }
        }

        public static bool IsContextFeatureByInheritance(Attribute featureAttribute)
        {
            return featureAttribute is FirmaFeatureWithContext;
        }
    }
}
