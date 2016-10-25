using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public static class FirmaBaseFeatureHelpers
    {
        public static readonly List<Role> AllEIPRolesExceptUnassigned = Role.All.Except(new[] { Role.Unassigned }).ToList();

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