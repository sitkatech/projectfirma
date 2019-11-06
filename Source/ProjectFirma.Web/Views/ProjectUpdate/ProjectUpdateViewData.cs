/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateViewData : FirmaViewData
    {
        public ProjectUpdateBatch ProjectUpdateBatch { get; }
        public ProjectFirmaModels.Models.Project Project { get; }
        public Person PrimaryContactPerson { get; }
        public string ProjectUpdateMyProjectsUrl { get; }
        public string ProjectUpdateHistoryUrl { get; }
        public string DeleteProjectUpdateUrl { get; }
        public string SubmitUrl { get; }
        public string ApproveUrl { get; }
        public string ReturnUrl { get; }
        public string ProvideFeedbackUrl { get; }

        public bool IsEditable { get; }
        public bool IsReadyToApprove { get; }
        public bool ShowApproveAndReturnButton { get; }
        public bool AreProjectBasicsValid { get; }
        public ProjectUpdateStatus ProjectUpdateStatus { get; }
        public bool HasUpdateStarted { get; }

        public List<string> ValidationWarnings { get; set; }
        public List<ProjectWorkflowSectionGrouping> ProjectWorkflowSectionGroupings { get; }
        public string CurrentSectionDisplayName { get; }
        public bool IsInstructionsPage { get;  }
        public string InstructionsPageUrl { get; }

        public ProjectUpdateViewData(FirmaSession currentFirmaSession, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, List<string> validationWarnings, string currentSectionDisplayName) : base(currentFirmaSession, null)
        {
            IsInstructionsPage = currentSectionDisplayName.Equals("Instructions", StringComparison.InvariantCultureIgnoreCase);
            InstructionsPageUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Instructions(projectUpdateBatch.Project));
            ProjectWorkflowSectionGroupings = ProjectWorkflowSectionGrouping.All.OrderBy(x => x.SortOrder).ToList();
            ProjectUpdateBatch = projectUpdateBatch;
            Project = projectUpdateBatch.Project;
            PrimaryContactPerson = projectUpdateBatch.Project.GetPrimaryContact();
            EntityName = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update";
            PageTitle = $"Update: {Project.GetDisplayName()}";
            ProjectUpdateMyProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            ProjectUpdateHistoryUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.History(Project));
            DeleteProjectUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DeleteProjectUpdate(Project));
            SubmitUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Submit(Project));
            ApproveUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Approve(Project));
            ReturnUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Return(Project));
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.UpdateFeedback());
            var isApprover = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(currentFirmaSession, Project).HasPermission;
            ShowApproveAndReturnButton = projectUpdateBatch.IsSubmitted() && isApprover;
            IsEditable = projectUpdateBatch.InEditableState() || ShowApproveAndReturnButton;
            IsReadyToApprove = projectUpdateBatch.IsReadyToApprove();
            AreProjectBasicsValid = projectUpdateBatch.AreProjectBasicsValid();

            //Neuter UpdateStatus for non-approver users until we go live with "Show Changes" for all users.
            ProjectUpdateStatus = currentFirmaSession.Person.IsApprover() ? projectUpdateStatus : new ProjectUpdateStatus(false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            HasUpdateStarted = ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID);

            ValidationWarnings = validationWarnings;
            CurrentSectionDisplayName = currentSectionDisplayName;
        }
    }
}
