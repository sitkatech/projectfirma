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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class IRoleExtensions
    {
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

        public static List<Person> GetPeopleWithRole(this IRole role)
        {
            if (role.RoleID == ModelObjectHelpers.NotYetAssignedID)
            {
                return new List<Person>();
            }
            return HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.RoleID == role.RoleID).ToList();
        }
        public static HtmlString GetDisplayNameWithUrl(this IRole role)
        {
            return UrlTemplate.MakeHrefString(
                role.RoleID == ModelObjectHelpers.NotYetAssignedID
                    ? SitkaRoute<RoleController>.BuildUrlFromExpression(x => x.Anonymous())
                    : SitkaRoute<RoleController>.BuildUrlFromExpression(x => x.Detail(role.RoleID)),
                role.RoleDisplayName);
        }

        public static HtmlString GetFieldDefinitionRoleDescription(this IRole role)
        {
            var normalUser = FieldDefinitionEnum.NormalUser.ToType();
            var projectSteward = FieldDefinitionEnum.ProjectSteward.ToType();

            if (role.RoleID == Role.Normal.RoleID && normalUser.HasCustomFieldDefinition())
            {
                return normalUser.GetFieldDefinitionData().FieldDefinitionDataValueHtmlString;
            }
            if (role.RoleID == Role.Normal.RoleID && !normalUser.HasCustomFieldDefinition())
            {
                return normalUser.DefaultDefinitionHtmlString;
            }
            if (role.RoleID == Role.ProjectSteward.RoleID && projectSteward.HasCustomFieldDefinition())
            {
                return projectSteward.GetFieldDefinitionData().FieldDefinitionDataValueHtmlString;
            }
            if (role.RoleID == Role.ProjectSteward.RoleID && projectSteward.HasCustomFieldDefinition())
            {
                return projectSteward.DefaultDefinitionHtmlString;
            }

            return role.RoleDescription.ToHTMLFormattedString();
        }
    }
}
