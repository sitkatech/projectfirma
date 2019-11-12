/*-----------------------------------------------------------------------
<copyright file="ProjectNoteManageFeature.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage {0}", FieldDefinitionEnum.ProjectNote)]
    public class ProjectNoteManageAsAdminFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectNote>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectNote> _firmaFeatureWithContextImpl;

        public ProjectNoteManageAsAdminFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectNote>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ProjectNote contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectNote contextModelObject)
        {
            if (contextModelObject.Project.IsProposal() || contextModelObject.Project.IsPendingProject())
            {
                return new ProjectCreateFeature().HasPermission(firmaSession, contextModelObject.Project);
            }

            return new ProjectEditAsAdminFeature().HasPermission(firmaSession, contextModelObject.Project);
        }
    }
}
