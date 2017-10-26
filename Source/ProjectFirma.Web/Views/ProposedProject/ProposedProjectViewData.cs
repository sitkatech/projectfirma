/*-----------------------------------------------------------------------
<copyright file="ProposedProjectViewData.cs" company="Tahoe Regional Planning Agency">
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

namespace ProjectFirma.Web.Views.ProposedProject
{
    public abstract class ProposedProjectViewData : FirmaViewData
    {
        public readonly ProposedProjectSectionEnum SelectedProposedProjectSection;
        public readonly Models.Project Project;
        public readonly string ProposedProjectListUrl;
        public readonly string ProposedProjectDetailUrl;
        public readonly string ProvideFeedbackUrl;

        public readonly string ProposedProjectInstructionsUrl;
        public readonly string ProposedProjectBasicsUrl;
        public readonly string ProposedProjectPerformanceMeasuresUrl;
        public readonly string ProposedProjectLocationSimpleUrl;
        public readonly string ProposedProjectLocationDetailedUrl;
        public readonly string ProposedProjectWatershedUrl;
        public readonly string ProposedProjectClassificationsUrl;
        public readonly string ProposedProjectAssessmentUrl;
        public readonly string ProposedProjectNotesUrl;
        public readonly string ProposedProjectPhotosUrl;
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


        protected ProposedProjectViewData(Person currentPerson,
            Models.Project project,
            ProposedProjectSectionEnum selectedProposedProjectSection,
            ProposalSectionsStatus proposalSectionsStatus) : this(currentPerson)
        {
            Check.Assert(project != null);
            Check.Assert(selectedProposedProjectSection == ProposedProjectSectionEnum.Instructions || selectedProposedProjectSection == ProposedProjectSectionEnum.Basics ||
                         proposalSectionsStatus.IsBasicsSectionComplete,
                $"Can't access this section of the Proposal - You must complete the basics first ({project.GetEditUrl()})");

            Project = project;
            SelectedProposedProjectSection = selectedProposedProjectSection;
            ProposalSectionsStatus = proposalSectionsStatus;
            CanAdvanceStage = proposalSectionsStatus.AreAllSectionsValid;
            // ReSharper disable PossibleNullReferenceException
            ProjectStateIsValidInWizard = project.ProposedProjectState == ProposedProjectState.Draft || project.ProposedProjectState == ProposedProjectState.Submitted;
            // ReSharper restore PossibleNullReferenceException

            PageTitle = project.DisplayName;

            // TODO: Update controller usage
            ProposedProjectDetailUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project));
            ProposedProjectInstructionsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Instructions(project.ProposedProjectID));
            ProposedProjectBasicsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditBasics(project.ProposedProjectID));
            ProposedProjectPerformanceMeasuresUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditExpectedPerformanceMeasureValues(project));
            ProposedProjectLocationSimpleUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationSimple(project));
            ProposedProjectLocationDetailedUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationDetailed(project));
            ProposedProjectWatershedUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditWatershed(project));
            ProposedProjectClassificationsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditClassifications(project));
            ProposedProjectAssessmentUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditAssessment(project));
            ProposedProjectNotesUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Notes(project.ProposedProjectID));
            ProposedProjectPhotosUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Photos(project.ProposedProjectID));
            
            SubmitUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Submit(project));
            ApproveUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Approve(project));
            ReturnUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Return(project));
            WithdrawUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Withdraw(project));
            RejectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Reject(project));
        }

        //New (not yet created) Proposed Projects use this constructor. Valid only for Instructions and Basics page.

        protected ProposedProjectViewData(Person currentPerson,
            ProposedProjectSectionEnum selectedProposedProjectSection) : this(currentPerson)
        {
            Check.Assert(selectedProposedProjectSection == ProposedProjectSectionEnum.Instructions || selectedProposedProjectSection == ProposedProjectSectionEnum.Basics);

            Project = null;
            SelectedProposedProjectSection = selectedProposedProjectSection;
            ProposalSectionsStatus = new ProposalSectionsStatus();
            PageTitle = $"New {Models.FieldDefinition.ProposedProject.GetFieldDefinitionLabel()}";

            ProposedProjectInstructionsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Instructions(null));
            ProposedProjectBasicsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.CreateAndEditBasics());
            ProposedProjectPerformanceMeasuresUrl = string.Empty;
            ProposedProjectLocationSimpleUrl = string.Empty;
            ProposedProjectLocationDetailedUrl = string.Empty;
            ProposedProjectNotesUrl = string.Empty;

            SubmitUrl = string.Empty;
            ApproveUrl = string.Empty;
            ReturnUrl = string.Empty;
            WithdrawUrl = string.Empty;
            RejectUrl = string.Empty;

        }

        private ProposedProjectViewData(Person currentPerson) : base(currentPerson)
        {
            EntityName = $"{Models.FieldDefinition.ProposedProject.GetFieldDefinitionLabel()}";
            ProposedProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Proposed());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposedProjectFeedback());
            CurrentPersonIsSubmitter = new ProjectEditFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = new ProposedProjectApproveFeature().HasPermissionByPerson(CurrentPerson);
            HasAssessments = HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Any();
            ClassificationDisplayNamePluralized = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
            ClassificationDisplayName = Models.FieldDefinition.Classification.GetFieldDefinitionLabel();
        }
    }
}
