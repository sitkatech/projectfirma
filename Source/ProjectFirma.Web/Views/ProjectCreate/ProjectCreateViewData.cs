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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public abstract class ProjectCreateViewData : FirmaViewData
    {
        public readonly ProposalSectionEnum SelectedProposalSection;
        public readonly Models.Project Project;
        public readonly string ProposalListUrl;
        public readonly string ProposalDetailUrl;
        public readonly string ProvideFeedbackUrl;

        public readonly string ProposalInstructionsUrl;
        public readonly string ProposalBasicsUrl;
        public readonly string ProposalPerformanceMeasuresUrl;
        public readonly string ProposalLocationSimpleUrl;
        public readonly string ProposalLocationDetailedUrl;
        public readonly string ProposalWatershedUrl;
        public readonly string ProposalClassificationsUrl;
        public readonly string ProposalAssessmentUrl;
        public readonly string ProposalNotesUrl;
        public readonly string ProposalPhotosUrl;
        public readonly string ProposalExpectedFundingUrl;
        public readonly string SubmitUrl;
        public readonly string ApproveUrl;
        public readonly string ReturnUrl;
        public readonly string WithdrawUrl;
        public readonly string RejectUrl;

        public readonly bool CurrentPersonIsSubmitter;
        public readonly bool CurrentPersonIsApprover;

        public readonly ProposalSectionsStatus ProposalSectionsStatus;
        public readonly bool CanAdvanceStage;
        public readonly bool ProjectStateIsValidInWizard;

        public readonly bool HasAssessments;
        public readonly string ClassificationDisplayName;
        public readonly string ClassificationDisplayNamePluralized;


        protected ProjectCreateViewData(Person currentPerson,
            Models.Project project,
            ProposalSectionEnum selectedProposalSection,
            ProposalSectionsStatus proposalSectionsStatus) : this(currentPerson)
        {
            Check.Assert(project != null);
            Check.Assert(selectedProposalSection == ProposalSectionEnum.Instructions || selectedProposalSection == ProposalSectionEnum.Basics ||
                         proposalSectionsStatus.IsBasicsSectionComplete,
                $"Can't access this section of the Proposal - You must complete the basics first ({project.GetEditUrl()})");

            CurrentPersonCanWithdraw = new ProjectCreateFeature().HasPermission(currentPerson, project).HasPermission;

            Project = project;
            SelectedProposalSection = selectedProposalSection;
            ProposalSectionsStatus = proposalSectionsStatus;
            CanAdvanceStage = proposalSectionsStatus.AreAllSectionsValid;
            // ReSharper disable PossibleNullReferenceException
            ProjectStateIsValidInWizard = project.ProjectApprovalStatus == ProjectApprovalStatus.Draft || project.ProjectApprovalStatus == ProjectApprovalStatus.Returned || project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
            // ReSharper restore PossibleNullReferenceException

            PageTitle = $"Proposal: {project.DisplayName}";

            // TODO: Update controller usage
            ProposalDetailUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project));
            ProposalInstructionsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Instructions(project.ProjectID));
            ProposalBasicsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
            ProposalPerformanceMeasuresUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditExpectedPerformanceMeasureValues(project));
            ProposalLocationSimpleUrl =  SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationSimple(project));
            ProposalLocationDetailedUrl =  SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationDetailed(project));
            ProposalWatershedUrl =  SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditWatershed(project));
            ProposalClassificationsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditClassifications(project));
            ProposalAssessmentUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditAssessment(project));
            ProposalNotesUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Notes(project.ProjectID));
            ProposalPhotosUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Photos(project.ProjectID));
            ProposalExpectedFundingUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ExpectedFunding(project.ProjectID));

            SubmitUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Submit(project));
            ApproveUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Approve(project));
            ReturnUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Return(project));
            WithdrawUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Withdraw(project));
            RejectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Reject(project));
        }

        //New (not yet created) Projects use this constructor. Valid only for Instructions and Basics page.

        protected ProjectCreateViewData(Person currentPerson,
            ProposalSectionEnum selectedProposalSection) : this(currentPerson)
        {
            Check.Assert(selectedProposalSection == ProposalSectionEnum.Instructions || selectedProposalSection == ProposalSectionEnum.Basics);

            Project = null;
            SelectedProposalSection = selectedProposalSection;
            ProposalSectionsStatus = new ProposalSectionsStatus();
            PageTitle = $"New {Models.FieldDefinition.Proposal.GetFieldDefinitionLabel()}";

            ProposalInstructionsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Instructions(null));
            ProposalBasicsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.CreateAndEditBasics());
            ProposalPerformanceMeasuresUrl = string.Empty;
            ProposalLocationSimpleUrl = string.Empty;
            ProposalLocationDetailedUrl = string.Empty;
            ProposalNotesUrl = string.Empty;

            CurrentPersonCanWithdraw = false;

            SubmitUrl = string.Empty;
            ApproveUrl = string.Empty;
            ReturnUrl = string.Empty;
            WithdrawUrl = string.Empty;
            RejectUrl = string.Empty;

        }

        private ProjectCreateViewData(Person currentPerson) : base(currentPerson)
        {
            EntityName = $"{Models.FieldDefinition.Proposal.GetFieldDefinitionLabel()}";
            ProposalListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Proposed());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposalFeedback());
            CurrentPersonIsSubmitter = new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = new ProjectApproveFeature().HasPermissionByPerson(CurrentPerson);
            
            HasAssessments = HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Any();
            ClassificationDisplayNamePluralized = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
            ClassificationDisplayName = Models.FieldDefinition.Classification.GetFieldDefinitionLabel();
        }

        public bool CurrentPersonCanWithdraw { get; set; }
    }
}
