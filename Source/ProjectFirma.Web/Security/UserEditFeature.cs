/*-----------------------------------------------------------------------
<copyright file="UserEditFeature.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit User")]
    public class UserEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Person>
    {
        private readonly FirmaFeatureWithContextImpl<Person> _firmaFeatureWithContextImpl;

        public UserEditFeature() : base(new List<Role>() {Role.ESAAdmin, Role.Admin, Role.ProjectSteward, Role.Normal})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Person>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Person contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firmaSession"></param>
        /// <param name="contextModelObject"></param>
        /// <returns></returns>
        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Person contextModelObject)
        {
            if (contextModelObject == null)
            {
                return new PermissionCheckResult("The Person whose details you are requesting to see doesn't exist.");
            }

            var userViewingOwnPage = !firmaSession.IsAnonymousUser() && firmaSession.PersonID == contextModelObject.PersonID;


            var userHasAppropriateRole = HasPermissionByFirmaSession(firmaSession);
            if (!userHasAppropriateRole)
            {
                return new PermissionCheckResult("You don't have permissions to view user details. If you aren't logged in, do that and try again.");
            }

            var userHasEditPermission = !firmaSession.IsAnonymousUser() &&
                                        (firmaSession.Person.Role == Role.Admin ||
                                         firmaSession.Person.Role == Role.ESAAdmin);
            if (userViewingOwnPage || userHasEditPermission)
            {
                return new PermissionCheckResult();
            }

            return new PermissionCheckResult("You don't have permission to view this user.");
        }

    }
}
