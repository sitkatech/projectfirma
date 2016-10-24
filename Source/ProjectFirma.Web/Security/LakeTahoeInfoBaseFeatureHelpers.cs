using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Areas.Sustainability.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Security
{
    public static class LakeTahoeInfoBaseFeatureHelpers
    {
        public static readonly List<EIPRole> AllEIPRolesExceptUnassigned = EIPRole.All.Except(new[] { EIPRole.Unassigned }).ToList();
        public static readonly List<SustainabilityRole> AllSustainabilityRolesExceptUnassigned = SustainabilityRole.All.Except(new[] { SustainabilityRole.Unassigned }).ToList();
        public static readonly List<LTInfoRole> AllLTInfoRolesExceptUnassigned = LTInfoRole.All.Except(new[] { LTInfoRole.Unassigned }).ToList();

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
            return (featureAttribute is EIPFeatureWithContext
                 || featureAttribute is SustainabilityFeatureWithContext
                 || featureAttribute is LakeTahoeInfoFeatureWithContext);
        }

        public static LTInfoArea GetFeatureAreaByInheritance(Attribute featureAttribute)
        {
            if (featureAttribute is EIPFeature || featureAttribute is EIPFeatureWithContext)
            {
                return LTInfoArea.EIP;
            }
            else if (featureAttribute is SustainabilityFeature || featureAttribute is SustainabilityFeatureWithContext)
            {
                return LTInfoArea.Sustainability;
            }
            else if (featureAttribute is LakeTahoeInfoFeature || featureAttribute is LakeTahoeInfoFeatureWithContext)
            {
                return LTInfoArea.LTInfo;
            }
            else if (featureAttribute is AnonymousUnclassifiedFeature)
            {
                return null; //Indicates a shared feature
            }
            else
            {
                throw new Exception("All features must inherit from LakeTahoeInfoBaseFeature or one of it's children.");
            }
        }
    }
}