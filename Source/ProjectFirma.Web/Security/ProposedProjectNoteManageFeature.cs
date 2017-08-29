/*-----------------------------------------------------------------------
<copyright file="ProposedProjectNoteManageFeature.cs" company="Tahoe Regional Planning Agency">
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
    [SecurityFeatureDescription("Edit Proposed {0}", FieldDefinitionEnum.ProjectNote)]
    public class ProposedProjectNoteManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProposedProjectNote>
    {
        private readonly FirmaFeatureWithContextImpl<ProposedProjectNote> _firmaFeatureWithContextImpl;

        public ProposedProjectNoteManageFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProposedProjectNote>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProposedProjectNote contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        /// <summary>
        /// TODO: This may well be simplified to be non-context sensitive
        /// </summary>
        /// <param name="person"></param>
        /// <param name="contextModelObject"></param>
        /// <returns></returns>
        public PermissionCheckResult HasPermission(Person person, ProposedProjectNote contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult(string.Format("You don't have permission to edit this note."));
            }

            var projectNoteIsEditableByUser = contextModelObject.ProposedProject.IsEditableToThisPerson(person);
            if (!projectNoteIsEditableByUser)
            {
                return new PermissionCheckResult($"{FieldDefinition.ProposedProject.GetFieldDefinitionLabel()} {contextModelObject.ProposedProjectID} is not editable by you.");
            }

            return new PermissionCheckResult();
        }
    }
}
