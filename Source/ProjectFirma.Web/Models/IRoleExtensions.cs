using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using LtInfo.Common;

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
                return SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Summary(role.LTInfoAreaEnum.Value, role.RoleID));
            }

        }

        public static List<FeaturePermission> GetFeaturePermissions(this IRole role, Type baseFeatureType)
        {
            var featurePermissions = new List<FeaturePermission>();

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => baseFeatureType.IsAssignableFrom(p) && p.Name != baseFeatureType.Name && !p.IsAbstract);
            foreach (var type in types)
            {                                           
                string featureDisplayName = LakeTahoeInfoBaseFeatureHelpers.GetDisplayName(type);
                var hasPermission = LakeTahoeInfoBaseFeatureHelpers.DoesRoleHavePermissionsForFeature(role, type);

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