﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.User
{
    public class IndexGridSpec : GridSpec<Person>
    {
        public IndexGridSpec(FirmaSession currentFirmaSession)
        {
            var hasDeletePermission = new UserEditFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (hasDeletePermission)
            {
                Add("Delete",
                    x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, true),
                    30, AgGridColumnFilterType.None);
            }

            // Impersonate link
            bool impersonationIsAllowed = FirmaWebConfiguration.ImpersonationAllowedInEnvironment;
            bool hasImpersonationPermission = new FirmaImpersonateUserFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (impersonationIsAllowed && hasImpersonationPermission)
            {
                Add("Imper. User", a => ImpersonateUserButton.MakeImpersonateSinglePageHtmlLink(a), 45, AgGridColumnFilterType.Html);
            }

            Add("Last Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.LastName), 100, AgGridColumnFilterType.Html);
            Add("First Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.FirstName), 100, AgGridColumnFilterType.Html);
            Add("Email", a => a.Email, 200);
            Add($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}", a => a.Organization.GetShortNameAsUrl(), 200);
            Add("Phone", a => a.Phone.ToPhoneNumberString(), 100);
            Add("Username", a => a.LoginName.ToString(), 200);
            Add("Last Activity", a => a.LastActivityDate, 120);
            Add("Role", a => a.Role.GetDisplayNameAsUrl(), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Active?", a => a.IsActive.ToYesNo(), 75, AgGridColumnFilterType.SelectFilterStrict);
            Add("Receives Support Emails?", a => a.ReceiveSupportEmails.ToYesNo(), 100, AgGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} for Organizations", a => a.GetPrimaryContactOrganizations().Count, 120);
        }

        public enum UsersStatusFilterTypeEnum
        {
            ActiveUsers,
            AllUsers
        }
    }
}
