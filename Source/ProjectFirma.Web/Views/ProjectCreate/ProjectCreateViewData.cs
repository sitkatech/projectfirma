/*-----------------------------------------------------------------------
<copyright file="ProjectCreateViewData.cs" company="Tahoe Regional Planning Agency">
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

using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public abstract class ProjectCreateViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Project Project { get; }
        public string CurrentSectionDisplayName { get; }
        public string ProposalListUrl { get; }
        public string ProposalDetailUrl { get; }
        public string ProvideFeedbackUrl { get; }
        public string ProposalInstructionsUrl { get; }
        public string ProposalBasicsUrl { get; }
        public string HistoricProjectBasicsUrl { get; }
        public string ProposalAttachmentsAndNotesUrl { get; }
        public string ProposalPhotosUrl { get; }
        public string SubmitUrl { get; }
        public string ApproveUrl { get; }
        public string ReturnUrl { get; }
        public string WithdrawUrl { get; }
        public string RejectUrl { get; }
        public string TrainingUrl { get; }
        public bool CurrentPersonIsSubmitter { get; }
        public bool CurrentPersonIsApprover { get; }
        public ProposalSectionsStatus ProposalSectionsStatus { get; }
        public bool CanAdvanceStage { get; }
        public bool ProjectStateIsValidInWizard { get; }
        public bool CurrentPersonCanWithdraw { get; set; }
        public bool IsInstructionsPage { get; }
        public string InstructionsPageUrl { get;  }
        public List<ProjectWorkflowSectionGrouping> ProjectWorkflowSectionGroupings { get; }
        public ProjectStage ProjectStage { get; set; }

        protected ProjectCreateViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Project project,
            string currentSectionDisplayName,
            ProposalSectionsStatus proposalSectionsStatus) : this(currentFirmaSession, project, currentSectionDisplayName, false)
        {
            Check.Assert(project != null, "Project should be created in database by this point so it cannot be null.");
            Check.Assert(currentSectionDisplayName.Equals("Instructions", StringComparison.InvariantCultureIgnoreCase) || currentSectionDisplayName.Equals("Basics", StringComparison.InvariantCultureIgnoreCase) ||
                         proposalSectionsStatus.IsBasicsSectionComplete,
                $"Can't access this section of the Proposal - You must complete the basics first ({project.GetEditUrl()})");

            CurrentPersonCanWithdraw = new ProjectCreateFeature().HasPermission(currentFirmaSession, project).HasPermission;

            Project = project;
            ProposalSectionsStatus = proposalSectionsStatus;
            CanAdvanceStage = ProposalSectionsStatus.AreAllSectionsValidForProject(project);
            // ReSharper disable PossibleNullReferenceException
            ProjectStateIsValidInWizard = project.ProjectApprovalStatus == ProjectApprovalStatus.Draft || project.ProjectApprovalStatus == ProjectApprovalStatus.Returned || project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
            // ReSharper restore PossibleNullReferenceException
            IsInstructionsPage = currentSectionDisplayName.Equals("Instructions", StringComparison.InvariantCultureIgnoreCase);

            InstructionsPageUrl = project.ProjectStage == ProjectStage.Proposal
                ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x =>
                    x.InstructionsProposal(project.ProjectID))
                : SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x =>
                    x.InstructionsEnterHistoric(project.ProjectID));

            var fieldDefinitionLabelForProject = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            var pageTitle = project.ProjectStage == ProjectStage.Proposal ? $"Propose {fieldDefinitionLabelForProject}" : $"Add {fieldDefinitionLabelForProject}";
            PageTitle = $"{pageTitle}: {project.GetDisplayName()}";

            ProposalDetailUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project));
            ProposalBasicsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
           
            ProposalAttachmentsAndNotesUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.AttachmentsAndNotes(project.ProjectID));
            ProposalPhotosUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Photos(project.ProjectID));
            
            SubmitUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Submit(project));
            ApproveUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Approve(project));
            ReturnUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Return(project));
            WithdrawUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Withdraw(project));
            RejectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Reject(project));
            TrainingUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Training());

            ProjectStage = project.ProjectStage;
        }

        //New (not yet created) Projects use this constructor. Valid only for Instructions and Basics page.

        protected ProjectCreateViewData(FirmaSession currentFirmaSession, string currentSectionDisplayName, string proposalInstructionsUrl) : this(currentFirmaSession, null, currentSectionDisplayName, false)
        {
            Check.Assert(currentSectionDisplayName.Equals("Instructions", StringComparison.InvariantCultureIgnoreCase) || currentSectionDisplayName.Equals("Basics", StringComparison.InvariantCultureIgnoreCase));

            Project = null;
            ProposalSectionsStatus = new ProposalSectionsStatus();

            ProposalInstructionsUrl = proposalInstructionsUrl;
            ProposalBasicsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.CreateAndEditBasics(true));
            HistoricProjectBasicsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.CreateAndEditBasics(false));

            CurrentPersonCanWithdraw = false;

            SubmitUrl = string.Empty;
            ApproveUrl = string.Empty;
            ReturnUrl = string.Empty;
            WithdrawUrl = string.Empty;
            RejectUrl = string.Empty;
            TrainingUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Training());
        }

        private ProjectCreateViewData(FirmaSession currentFirmaSession,
                                      ProjectFirmaModels.Models.Project project,
                                      string currentSectionDisplayName,
                                      // This just here to distinguish this signature uniquely. This is a hack, and deserves fixing.
                                      bool bogusParm) :
                                      base(currentFirmaSession)
        {
            EntityName = $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabel()}";
            ProposalListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Proposed());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposalFeedback());
            CurrentPersonIsSubmitter = new ProjectCreateFeature().HasPermissionByFirmaSession(currentFirmaSession);
            CurrentPersonIsApprover = project != null && new ProjectApproveFeature().HasPermission(currentFirmaSession, project).HasPermission;
            ProjectWorkflowSectionGroupings = ProjectWorkflowSectionGrouping.All.OrderBy(x => x.SortOrder).ToList();
            CurrentSectionDisplayName = currentSectionDisplayName;
            TrainingUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Training());
        }
    }
}
