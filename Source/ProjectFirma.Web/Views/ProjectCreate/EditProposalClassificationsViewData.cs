/*-----------------------------------------------------------------------
<copyright file="EditProposalClassificationsViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class EditProposalClassificationsViewData : ProjectCreateViewData
    {
        public ProjectFirmaModels.Models.ClassificationSystem ClassificationSystem { get; }
        public string ProjectName { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForClassification { get; }
        public string ConfigureClassificationSystemsUrl { get; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }

        public EditProposalClassificationsViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, ProjectFirmaModels.Models.ClassificationSystem classificationSystem, string currentSectionDisplayName, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentFirmaSession, project, currentSectionDisplayName, proposalSectionsStatus)
        {
            ProjectName = project.GetDisplayName();
            ClassificationSystem = classificationSystem;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForClassification = FieldDefinitionEnum.Classification.ToType();
            if (new SitkaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                ConfigureClassificationSystemsUrl = SitkaRoute<TenantController>.BuildUrlFromExpression(tc => tc.Detail());
            }
            ShowCommentsSection = project.IsPendingApproval() || (project.ProposalClassificationsComment != null &&
                                                                  project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
        }
    }
}
