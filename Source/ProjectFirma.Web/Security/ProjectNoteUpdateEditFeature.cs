/*-----------------------------------------------------------------------
<copyright file="ProjectNoteUpdateEditFeature.cs" company="Tahoe Regional Planning Agency">
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
    [SecurityFeatureDescription("Edit Notes for Project Updates")]
    public class ProjectNoteUpdateEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectNoteUpdate>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectNoteUpdate> _firmaFeatureWithContextImpl;

        public ProjectNoteUpdateEditFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectNoteUpdate>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectNoteUpdate contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectNoteUpdate contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            var project = contextModelObject.ProjectUpdateBatch.Project;
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to Edit {FieldDefinition.ProjectNote.GetFieldDefinitionLabel()} for Project {project.DisplayName}");
            }

            var projectIsEditableByUser = new FirmaAdminFeature().HasPermissionByPerson(person) || project.IsMyProject(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult(string.Format("Project {0} is not editable by you.", project.ProjectID));
            }

            return new PermissionCheckResult();
        }
    }
}
