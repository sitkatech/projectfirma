/*-----------------------------------------------------------------------
<copyright file="ProjectViewFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View {0}", FieldDefinitionEnum.Project)]
    public class ProjectViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectViewFeature() : base(new List<Role>())
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            if (!HasPermissionByFirmaSession(firmaSession))
            {
                return new PermissionCheckResult($"You don't have permission to view {contextModelObject.GetDisplayName()}");
            }

            if (contextModelObject.IsProposal() && firmaSession.IsAnonymousUser())
            {
                // do not allow if user is anonymous and do not show proposals to public
                if (!MultiTenantHelpers.ShowProposalsToThePublic())
                {
                    return new PermissionCheckResult($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.ProjectID} is not visible to you.");
                }
                // do not allow if user is anonymous and show proposals to public and stage a stage other than pending 
                if (MultiTenantHelpers.ShowProposalsToThePublic() && contextModelObject.ProjectApprovalStatus != ProjectApprovalStatus.PendingApproval)
                {
                    return new PermissionCheckResult($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.ProjectID} is not visible to you.");
                }
            }

            // Allowed
            return new PermissionCheckResult();
        }
    }
}
