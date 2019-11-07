/*-----------------------------------------------------------------------
<copyright file="UserViewFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View User")]
    public class UserViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Person>
    {
        private readonly FirmaFeatureWithContextImpl<Person> _firmaFeatureWithContextImpl;

        public UserViewFeature()
            : base(Role.All)
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Person>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Person contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }


        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Person contextModelObject)
        {
            if (contextModelObject == null)
            {
                return new PermissionCheckResult("The Person whose details you are requesting to see doesn't exist.");
            }
            var userHasEditPermission = new UserEditFeature().HasPermissionByFirmaSession(firmaSession);
            var userViewingOwnPage = !firmaSession.IsAnonymousUser() && firmaSession.PersonID == contextModelObject.PersonID;

            #pragma warning disable 612
            var userHasAppropriateRole = HasPermissionByFirmaSession(firmaSession);
            #pragma warning restore 612
            if (!userHasAppropriateRole)
            {
                return new PermissionCheckResult("You don't have permissions to view user details. If you aren't logged in, do that and try again.");
            }

            //Only SitkaAdmin users should be able to see other SitkaAdmin users
            if (firmaSession.Role != Role.SitkaAdmin && contextModelObject.Role == Role.SitkaAdmin)
            {
                return new PermissionCheckResult("You don't have permission to view this user.");
            }

            if (userViewingOwnPage || userHasEditPermission)
            {
                return new PermissionCheckResult();
            }

            return new PermissionCheckResult("You don't have permission to view this user.");
        }

        ////This should only ever be called by HasPermission
        //[Obsolete]
        //public new bool HasPermissionByPerson(Person person)
        //{
        //    return base.HasPermissionByPerson(person);
        //}
    }
}
