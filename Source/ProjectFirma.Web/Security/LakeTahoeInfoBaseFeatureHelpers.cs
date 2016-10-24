using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public static class LakeTahoeInfoBaseFeatureHelpers
    {
        public static readonly List<EIPRole> AllEIPRolesExceptUnassigned = EIPRole.All.Except(new[] { EIPRole.Unassigned }).ToList();

        public static bool DoesRoleHavePermissionsForFeature(IRole role, Type type)
        {
            var lakeTahoeInfoBaseFeature = LakeTahoeInfoBaseFeature.InstantiateFeature(type);            
            if (IsContextFeatureByInheritance(lakeTahoeInfoBaseFeature))
            {
                return true;
            }
            else
            {
                return lakeTahoeInfoBaseFeature.GrantedRoles.Contains(role) || (role == null);
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
            return featureAttribute is EIPFeatureWithContext;
        }
    }
}