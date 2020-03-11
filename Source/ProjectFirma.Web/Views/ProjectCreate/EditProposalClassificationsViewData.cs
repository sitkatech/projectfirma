/*-----------------------------------------------------------------------
<copyright file="EditProposalClassificationsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class EditProposalClassificationsViewData : ProjectCreateViewData
    {
        public List<ProjectFirmaModels.Models.ClassificationSystem> ClassificationSystems { get; }
        public string ProjectName { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForClassification { get; }
        public string ConfigureClassificationSystemsUrl { get; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }

        public EditProposalClassificationsViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, List<ProjectFirmaModels.Models.ClassificationSystem> classificationSystems, string currentSectionDisplayName, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentFirmaSession, project, currentSectionDisplayName, proposalSectionsStatus)
        {
            ProjectName = project.GetDisplayName();
            ClassificationSystems = classificationSystems;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForClassification = FieldDefinitionEnum.Classification.ToType();
            if (new SitkaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                ConfigureClassificationSystemsUrl = SitkaRoute<TenantController>.BuildUrlFromExpression(tc => tc.Detail());
            }
            ShowCommentsSection = project.IsPendingApproval() || (project.ProposalClassificationsComment != string.Empty &&
                                                                  project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
        }
    }
}
