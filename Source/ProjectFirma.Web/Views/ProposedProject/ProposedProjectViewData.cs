using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public abstract class ProposedProjectViewData : FirmaViewData
    {
        public readonly ProposedProjectSectionEnum SelectedProposedProjectSection;
        public readonly Models.ProposedProject ProposedProject;
        public readonly string ProposedProjectListUrl;
        public readonly string ProvideFeedbackUrl;

        public readonly string ProjectUpdateInstructionsUrl;
        public readonly string ProjectUpdateBasicsUrl;
        public readonly string ProjectUpdatePerformanceMeasuresUrl;
        public readonly string ProjectUpdateLocationSimpleUrl;
        public readonly string ProjectUpdateLocationDetailedUrl;
        public readonly string ProjectUpdateThresholdCategoriesUrl;
        public readonly string ProjectUpdateAssessmentUrl;
        public readonly string ProjectUpdateNotesUrl;
        public readonly string ProjectUpdatePhotosUrl;
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


        protected ProposedProjectViewData(Person currentPerson,
            Models.ProposedProject proposedProject,
            ProposedProjectSectionEnum selectedProposedProjectSection,
            ProposalSectionsStatus proposalSectionsStatus) : base(currentPerson)
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
            EntityName = "Proposed Project";

            ProposedProjectListUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Index());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposedProjectFeedback());
            

            ProjectUpdateInstructionsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Instructions(proposedProject.ProposedProjectID));
            ProjectUpdateBasicsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditBasics(proposedProject.ProposedProjectID));
            ProjectUpdatePerformanceMeasuresUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditExpectedPerformanceMeasureValues(proposedProject));
            ProjectUpdateLocationSimpleUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationSimple(proposedProject));
            ProjectUpdateLocationDetailedUrl =  SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationDetailed(proposedProject));
            ProjectUpdateThresholdCategoriesUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditThresholdCategories(proposedProject));
            ProjectUpdateAssessmentUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditAssessment(proposedProject));
            ProjectUpdateNotesUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditNotes(proposedProject.ProposedProjectID));
            ProjectUpdatePhotosUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditPhotos(proposedProject.ProposedProjectID));
            
            SubmitUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Submit(proposedProject));
            ApproveUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Approve(proposedProject));
            ReturnUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Return(proposedProject));
            WithdrawUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Withdraw(proposedProject));
            RejectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Reject(proposedProject));

            CurrentPersonIsSubmitter = new ProposedProjectEditFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = new ProposedProjectApproveFeature().HasPermissionByPerson(CurrentPerson);
        }

        //New (not yet created) Proposed Projects use this constructor. Valid only for Instructions and Basics page.
        protected ProposedProjectViewData(Person currentPerson,
            ProposedProjectSectionEnum selectedProposedProjectSection) : base(currentPerson)
        {
            Check.Assert(selectedProposedProjectSection == ProposedProjectSectionEnum.Instructions || selectedProposedProjectSection == ProposedProjectSectionEnum.Basics);

            ProposedProject = null;
            SelectedProposedProjectSection = selectedProposedProjectSection;
            ProposalSectionsStatus = new ProposalSectionsStatus();
            PageTitle = "New Proposed Project";
            EntityName = "Proposed Project";

            ProposedProjectListUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Index());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposedProjectFeedback());
            
            ProjectUpdateInstructionsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Instructions(null));
            ProjectUpdateBasicsUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.CreateAndEditBasics());
            ProjectUpdatePerformanceMeasuresUrl = string.Empty;
            ProjectUpdateLocationSimpleUrl = string.Empty;
            ProjectUpdateLocationDetailedUrl = string.Empty;
            ProjectUpdateNotesUrl = string.Empty;

            SubmitUrl = string.Empty;
            ApproveUrl = string.Empty;
            ReturnUrl = string.Empty;
            WithdrawUrl = string.Empty;
            RejectUrl = string.Empty;

            CurrentPersonIsSubmitter = new ProposedProjectEditFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = new ProposedProjectApproveFeature().HasPermissionByPerson(CurrentPerson);

        }
    }
}