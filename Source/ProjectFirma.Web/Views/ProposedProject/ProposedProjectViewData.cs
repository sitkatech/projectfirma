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
        public readonly Models.ProposedProject ProposedProject;
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
            Models.ProposedProject proposedProject,
            ProposedProjectSectionEnum selectedProposedProjectSection,
            ProposalSectionsStatus proposalSectionsStatus) : this(currentPerson)
        {
            Check.Assert(proposedProject != null);
            Check.Assert(selectedProposedProjectSection == ProposedProjectSectionEnum.Instructions || selectedProposedProjectSection == ProposedProjectSectionEnum.Basics ||
                         proposalSectionsStatus.IsBasicsSectionComplete, string.Format("Can't access this section of the Proposal - You must complete the basics first ({0})", proposedProject.GetEditUrl()));

            ProposedProject = proposedProject;
            SelectedProposedProjectSection = selectedProposedProjectSection;
            ProposalSectionsStatus = proposalSectionsStatus;
            CanAdvanceStage = proposalSectionsStatus.AreAllSectionsValid;
            ProjectStateIsValidInWizard = proposedProject.ProposedProjectState == ProposedProjectState.Draft || proposedProject.ProposedProjectState == ProposedProjectState.Submitted;

            PageTitle = proposedProject.DisplayName;

            ProposedProjectDetailUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Detail(proposedProject));
            ProposedProjectInstructionsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Instructions(proposedProject.ProposedProjectID));
            ProposedProjectBasicsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditBasics(proposedProject.ProposedProjectID));
            ProposedProjectPerformanceMeasuresUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditExpectedPerformanceMeasureValues(proposedProject));
            ProposedProjectLocationSimpleUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationSimple(proposedProject));
            ProposedProjectLocationDetailedUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationDetailed(proposedProject));
            ProposedProjectWatershedUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditWatershed(proposedProject));
            ProposedProjectClassificationsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditClassifications(proposedProject));
            ProposedProjectAssessmentUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditAssessment(proposedProject));
            ProposedProjectNotesUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Notes(proposedProject.ProposedProjectID));
            ProposedProjectPhotosUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Photos(proposedProject.ProposedProjectID));
            
            SubmitUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Submit(proposedProject));
            ApproveUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Approve(proposedProject));
            ReturnUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Return(proposedProject));
            WithdrawUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Withdraw(proposedProject));
            RejectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Reject(proposedProject));
        }

        //New (not yet created) Proposed Projects use this constructor. Valid only for Instructions and Basics page.

        protected ProposedProjectViewData(Person currentPerson,
            ProposedProjectSectionEnum selectedProposedProjectSection) : this(currentPerson)
        {
            Check.Assert(selectedProposedProjectSection == ProposedProjectSectionEnum.Instructions || selectedProposedProjectSection == ProposedProjectSectionEnum.Basics);

            ProposedProject = null;
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
            ProposedProjectListUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Index());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposedProjectFeedback());
            CurrentPersonIsSubmitter = new ProposedProjectEditFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = new ProposedProjectApproveFeature().HasPermissionByPerson(CurrentPerson);
            HasAssessments = HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Any();
            ClassificationDisplayNamePluralized = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
            ClassificationDisplayName = Models.FieldDefinition.Classification.GetFieldDefinitionLabel();
        }
    }
}
