/*-----------------------------------------------------------------------
<copyright file="LocationSimpleViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class LocationSimpleViewData : ProjectCreateViewData
    {
        public ProjectLocationSimpleViewData ProjectLocationSimpleViewData { get; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }
        public LocationSimpleViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            ProjectLocationSimpleViewData projectLocationSimpleViewData) : base(currentFirmaSession, project, ProjectCreateSection.LocationSimple.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            ProjectLocationSimpleViewData = projectLocationSimpleViewData;
            ShowCommentsSection = project.IsPendingApproval() || (project.BasicsComment != null &&
                                                                  project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
        }
    }
}
