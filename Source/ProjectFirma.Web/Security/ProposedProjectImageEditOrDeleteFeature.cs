/*-----------------------------------------------------------------------
<copyright file="ProposedProjectImageEditOrDeleteFeature.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit/Delete {0} Image", FieldDefinitionEnum.ProposedProject)]
    public class ProposedProjectImageEditOrDeleteFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProposedProjectImage>
    {
        private readonly FirmaFeatureWithContextImpl<ProposedProjectImage> _firmaFeatureWithContextImpl;

        public ProposedProjectImageEditOrDeleteFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectApprover })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProposedProjectImage>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProposedProjectImage contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProposedProjectImage contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult($"You don't have permission to edit {contextModelObject.ProposedProject.DisplayName}");
            }

            var projectIsEditableByUser = contextModelObject.ProposedProject.IsEditableToThisPerson(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult($"{FieldDefinition.ProposedProject.GetFieldDefinitionLabel()} {contextModelObject.ProposedProjectImageID} is not editable by you.");
            }

            return new PermissionCheckResult();
        }
    }
}
