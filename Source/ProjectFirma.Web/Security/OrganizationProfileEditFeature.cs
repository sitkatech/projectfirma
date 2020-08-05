/*-----------------------------------------------------------------------
<copyright file="OrganizationProfileViewEditFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit an Organization's Profile")]
    public class OrganizationProfileViewEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Organization>
    {
        private readonly FirmaFeatureWithContextImpl<Organization> _firmaFeatureWithContextImpl;

        public OrganizationProfileViewEditFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Organization>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Organization contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Organization contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByFirmaSession(firmaSession);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            var organizationIsEditableByUser = new FirmaAdminFeature().HasPermission(firmaSession).HasPermission || contextModelObject.PrimaryContactPerson != null && firmaSession.PersonID == contextModelObject.PrimaryContactPerson.PersonID;
            if (!organizationIsEditableByUser)
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} {contextModelObject.OrganizationID} is not editable by you.");
            }

            return new PermissionCheckResult();
        }
    }
}
