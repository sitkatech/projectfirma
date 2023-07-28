﻿/*-----------------------------------------------------------------------
<copyright file="AttachmentsAndNotesViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectAttachment;
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class AttachmentsAndNotesViewData : ProjectCreateViewData
    {
        public EntityNotesViewData EntityNotesViewData { get; }

        public ProjectAttachmentsDetailViewData ProjectAttachmentsDetailViewData { get; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }

        public AttachmentsAndNotesViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            EntityNotesViewData entityNotesViewData,
            ProjectAttachmentsDetailViewData projectAttachmentsDetailViewData) : base(currentFirmaSession, project, ProjectCreateSection.AttachmentsAndNotes.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            EntityNotesViewData = entityNotesViewData;
            ProjectAttachmentsDetailViewData = projectAttachmentsDetailViewData;
            ShowCommentsSection = project.IsPendingApproval() || (project.AttachmentsNotesComment != null &&
                                                                  project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
        }
    }
}
