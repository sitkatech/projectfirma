/*-----------------------------------------------------------------------
<copyright file="FirmaBaseFeatureHelpers.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    public static class FirmaBaseFeatureHelpers
    {
        public static readonly List<Role> AllRolesExceptUnassigned = Role.All.Except(new[] { Role.Unassigned }).ToList();

        public static bool DoesRoleHavePermissionsForFeature(IRole role, FirmaBaseFeature firmaBaseFeature)
        {

            if (!firmaBaseFeature.GrantedRoles.Any()) // AnonymousUnclassifiedFeature case
            {
                return true;
            }

            return firmaBaseFeature.GrantedRoles.Contains(role) || (role == null);

        }

        public static string GetDisplayName(Type type)
        {
            var customAttributes = Attribute.GetCustomAttributes(type);
            var securityFeatureDescriptionAttribute = customAttributes.FirstOrDefault(x => x is SecurityFeatureDescription);            
            if (securityFeatureDescriptionAttribute != null)
            {
                return ((SecurityFeatureDescription)securityFeatureDescriptionAttribute).DescriptionMessage;
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

        public static Type GetFeatureWithContextType(Attribute featureAttribute)
        {
            var genericTypeInterface = featureAttribute.GetType().GetInterfaces().FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IFirmaBaseFeatureWithContext<>));
            if (genericTypeInterface != null)
            {
                return genericTypeInterface.GetGenericArguments()[0];
            }

            //not a firma feature with context
            return null;
            
        }

    }
}
