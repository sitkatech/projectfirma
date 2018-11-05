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
        public readonly Models.Project Project;

        public readonly ProjectCreateSection CurrentSection;
        public readonly List<ProjectCreateSection> ProjectCreateSections;

        public readonly string ProposalListUrl;
        public readonly string ProposalDetailUrl;
        public readonly string ProvideFeedbackUrl;

        public readonly string ProposalInstructionsUrl;
        public readonly string ProposalBasicsUrl;
        public readonly string HistoricProjectBasicsUrl;
        public readonly string ProposalNotesUrl;
        public readonly string ProposalPhotosUrl;
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
        public bool CurrentPersonCanWithdraw { get; set; }
        public ProjectStage ProjectStage { get; set; }


        protected ProjectCreateViewData(Person currentPerson,
            Models.Project project,
            ProjectCreateSection currentSection,
            ProposalSectionsStatus proposalSectionsStatus) : this(currentPerson)
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
            ProjectCreateSection currentSection, string proposalInstructionsUrl) : this(currentPerson)
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

        private ProjectCreateViewData(Person currentPerson) : base(currentPerson)
        {
            EntityName = $"{Models.FieldDefinition.Proposal.GetFieldDefinitionLabel()}";
            ProposalListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Proposed());
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.ProposalFeedback());
            CurrentPersonIsSubmitter = new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = new ProjectApproveFeature().HasPermissionByPerson(CurrentPerson);
                        
        }


    }
}
