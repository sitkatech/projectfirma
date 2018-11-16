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

using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public abstract class ProjectCreateViewData : FirmaViewData
    {
        public Models.Project Project { get; }
        public ProjectCreateSection CurrentSection { get; }
        public List<ProjectCreateSection> ProjectCreateSections { get; }
        public string ProposalListUrl { get; }
        public string ProposalDetailUrl { get; }
        public string ProvideFeedbackUrl { get; }
        public string ProposalInstructionsUrl { get; }
        public string ProposalBasicsUrl { get; }
        public string HistoricProjectBasicsUrl { get; }
        public string ProposalNotesUrl { get; }
        public string ProposalPhotosUrl { get; }
        public string SubmitUrl { get; }
        public string ApproveUrl { get; }
        public string ReturnUrl { get; }
        public string WithdrawUrl { get; }
        public string RejectUrl { get; }
        public bool CurrentPersonIsSubmitter { get; }
        public bool CurrentPersonIsApprover { get; }
        public ProposalSectionsStatus ProposalSectionsStatus { get; }
        public bool CanAdvanceStage { get; }
        public bool ProjectStateIsValidInWizard { get; }
        public bool CurrentPersonCanWithdraw { get; set; }
        public ProjectStage ProjectStage { get; set; }

        protected ProjectCreateViewData(Person currentPerson,
            Models.Project project,
            ProjectCreateSection currentSection,
            ProposalSectionsStatus proposalSectionsStatus) : this(project, currentPerson)
        {
            ProjectCreateSections = Models.Project.GetApplicableProposalWizardSections(project);
            Check.Assert(project != null);
            Check.Assert(currentSection == ProjectCreateSection.Instructions || currentSection == ProjectCreateSection.Basics ||
                         proposalSectionsStatus.IsBasicsSectionComplete,
                $"Can't access this section of the Proposal - You must complete the basics first ({project.GetEditUrl()})");

            CurrentPersonCanWithdraw = new ProjectCreateFeature().HasPermission(currentPerson, project).HasPermission;

            Project = project;
            CurrentSection = currentSection;
            ProposalSectionsStatus = proposalSectionsStatus;
            CanAdvanceStage = ProposalSectionsStatus.AreAllSectionsValidForProject(project);
            // ReSharper disable PossibleNullReferenceException
            ProjectStateIsValidInWizard = project.ProjectApprovalStatus == ProjectApprovalStatus.Draft || project.ProjectApprovalStatus == ProjectApprovalStatus.Returned || project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
            // ReSharper restore PossibleNullReferenceException

            var pagetitle = project.ProjectStage == ProjectStage.Proposal ? $"Propose {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}" : $"Add {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}";
            PageTitle = $"{pagetitle}: {project.DisplayName}";

            ProposalDetailUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project));
            ProposalBasicsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
           
            ProposalNotesUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.DocumentsAndNotes(project.ProjectID));
            ProposalPhotosUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Photos(project.ProjectID));
            
            SubmitUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Submit(project));
            ApproveUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Approve(project));
            ReturnUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Return(project));
            WithdrawUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Withdraw(project));
            RejectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Reject(project));

            ProjectStage = project.ProjectStage;
        }

        //New (not yet created) Projects use this constructor. Valid only for Instructions and Basics page.

        protected ProjectCreateViewData(Person currentPerson,
            ProjectCreateSection currentSection, string proposalInstructionsUrl) : this(null, currentPerson)
        {
            Check.Assert(currentSection == ProjectCreateSection.Instructions || currentSection == ProjectCreateSection.Basics);
            ProjectCreateSections = Models.Project.GetApplicableProposalWizardSections(null);

            Project = null;
            CurrentSection = currentSection;
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

        }

        private ProjectCreateViewData(Models.Project project, Person currentPerson) : base(currentPerson)
        {
            EntityName = $"{Models.FieldDefinition.Proposal.GetFieldDefinitionLabel()}";
            ProposalListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Proposed());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposalFeedback());
            CurrentPersonIsSubmitter = new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = project != null && new ProjectApproveFeature().HasPermission(currentPerson, project).HasPermission;

        }


    }
}
