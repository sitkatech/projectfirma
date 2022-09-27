/*-----------------------------------------------------------------------
<copyright file="ProjectNoteManageFeature.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Proposed {0}", FieldDefinitionEnum.ProjectNote)]
    public class ProjectNoteManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectNote>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectNote> _firmaFeatureWithContextImpl;

        public ProjectNoteManageFeature()
            : base(new List<Role> { Role.Normal, Role.ESAAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectNote>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ProjectNote contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        /// <summary>
        /// TODO: This may well be simplified to be non-context sensitive
        /// </summary>
        /// <param name="person"></param>
        /// <param name="contextModelObject"></param>
        /// <returns></returns>
        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectNote contextModelObject)
        {
            var hasPermissionByFirmaSession = HasPermissionByFirmaSession(firmaSession);
            if (!hasPermissionByFirmaSession)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.Project.GetDisplayName()}");
            }
            return new ProjectCreateFeature().HasPermission(firmaSession, contextModelObject.Project);
        }
    }





}
