/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.User
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Person Person;
        public readonly string EditPersonOrganizationPrimaryContactUrl;
        public readonly string Index;

        public readonly bool UserHasPersonViewPermissions;
        public readonly bool UserHasPersonManagePermissions;
        public readonly bool UserHasViewEverythingPermissions;
        public readonly bool IsViewingSelf;
        public readonly Project.BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly UserNotificationGridSpec UserNotificationGridSpec;
        public readonly string UserNotificationGridName;
        public readonly string UserNotificationGridDataUrl;
        public readonly string ActivateInactivateUrl;

        public DetailViewData(Person currentPerson,
            Person personToView,
            Project.BasicProjectInfoGridSpec basicProjectInfoGridSpec,
            string basicProjectInfoGridName,
            string basicProjectInfoGridDataUrl,
            UserNotificationGridSpec userNotificationGridSpec,
            string userNotificationGridName,
            string userNotificationGridDataUrl,
            string activateInactivateUrl)
            : base(currentPerson)
        {
            Person = personToView;
            PageTitle = personToView.FullNameFirstLast + (!personToView.IsActive ? " (inactive)" : string.Empty);
            EntityName = "User";
            //TODO: This gets pulled up to root
            EditPersonOrganizationPrimaryContactUrl = SitkaRoute<PersonOrganizationController>.BuildUrlFromExpression(c => c.EditPersonOrganizationPrimaryContacts(personToView));
            Index = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.Index());

            UserHasPersonViewPermissions = new UserViewFeature().HasPermission(currentPerson, personToView).HasPermission;
            UserHasPersonManagePermissions = new UserEditFeature().HasPermissionByPerson(currentPerson);
            UserHasViewEverythingPermissions = new AdminFeature().HasPermissionByPerson(currentPerson);
            IsViewingSelf = currentPerson != null && currentPerson.PersonID == personToView.PersonID;
            EditRolesLink = UserHasPersonManagePermissions
                ? ModalDialogFormHelper.MakeEditIconLink(SitkaRoute<UserController>.BuildUrlFromExpression(c => c.EditRoles(personToView)),
                    string.Format("Edit Roles for User - {0}", personToView.FullNameFirstLast),
                    true)
                : new HtmlString(string.Empty);

            BasicProjectInfoGridSpec = basicProjectInfoGridSpec;
            BasicProjectInfoGridName = basicProjectInfoGridName;
            BasicProjectInfoGridDataUrl = basicProjectInfoGridDataUrl;

            UserNotificationGridSpec = userNotificationGridSpec;
            UserNotificationGridName = userNotificationGridName;
            UserNotificationGridDataUrl = userNotificationGridDataUrl;
            ActivateInactivateUrl = activateInactivateUrl;
        }

        public readonly HtmlString EditRolesLink;
    }
}
