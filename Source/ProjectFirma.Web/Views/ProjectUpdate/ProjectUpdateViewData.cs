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

using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateViewData : FirmaViewData
    {
        public ProjectUpdateSection CurrentSection { get; }
        public List<ProjectUpdateSection> ProjectUpdateSections { get; }
        public ProjectUpdateBatch ProjectUpdateBatch { get; }
        public Models.Project Project { get; }
        public Person PrimaryContactPerson { get; }
        public string ProjectUpdateMyProjectsUrl { get; }
        public string ProjectUpdateInstructionsUrl { get; }
        public string ProjectUpdateBasicsUrl { get; }
        public string ProjectUpdatePerformanceMeasuresUrl { get; }
        public string ProjectUpdateExpendituresUrl { get; }
        public string ProjectUpdatePhotosUrl { get; }
        public string ProjectUpdateLocationSimpleUrl { get; }
        public string ProjectUpdateLocationDetailedUrl { get; }
        public string ProjectUpdateWatershedUrl { get; }
        public string ProjectUpdateNotesUrl { get; }
        public string ProjectUpdateExternalLinksUrl { get; }
        public string ProjectUpdateHistoryUrl { get; }
        public string DeleteProjectUpdateUrl { get; }
        public string ProjectUpdateExpectedFundingUrl { get; }
        public string SubmitUrl { get; }
        public string ApproveUrl { get; }
        public string ReturnUrl { get; }
        public string ProvideFeedbackUrl { get; }

        public bool IsEditable { get; }
        public bool IsReadyToApprove { get; }
        public bool ShowApproveAndReturnButton { get; }
        public bool AreProjectBasicsValid { get; }
        public UpdateStatus UpdateStatus { get; }
        public bool HasUpdateStarted { get; }

        public ProjectUpdateViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateSection currentSection, UpdateStatus updateStatus, List<string> validationWarnings) : base(currentPerson, null)
        {
            CurrentSection = currentSection;
            ProjectUpdateBatch = projectUpdateBatch;
            Project = projectUpdateBatch.Project;

            ProjectUpdateSections = projectUpdateBatch.GetApplicableWizardSections();

            PrimaryContactPerson = projectUpdateBatch.Project.GetPrimaryContact();
            HtmlPageTitle += $" - {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Updates";
            EntityName = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {Models.FieldDefinition.ReportingYear.GetFieldDefinitionLabel()}: {FirmaDateUtilities.CalculateCurrentYearToUseForReporting()}";
            PageTitle = $"Update: {Project.DisplayName}";
            ProjectUpdateMyProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            ProjectUpdateInstructionsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Instructions(Project));
            ProjectUpdateBasicsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Basics(Project));
            ProjectUpdatePerformanceMeasuresUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PerformanceMeasures(Project));
            ProjectUpdateExpectedFundingUrl =
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedFunding((Project)));
            ProjectUpdateExpendituresUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Expenditures(Project));
            ProjectUpdatePhotosUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(Project));
            ProjectUpdateLocationSimpleUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationSimple(Project));
            ProjectUpdateLocationDetailedUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(Project));
            ProjectUpdateWatershedUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Watershed(Project));
            ProjectUpdateExternalLinksUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(Project));
            ProjectUpdateNotesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DocumentsAndNotes(Project));
            ProjectUpdateHistoryUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.History(Project));
            DeleteProjectUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DeleteProjectUpdate(Project));
            SubmitUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Submit(Project));
            ApproveUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Approve(Project));
            ReturnUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Return(Project));
            ProvideFeedbackUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.UpdateFeedback());
            var isApprover = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(CurrentPerson, Project).HasPermission;
            ShowApproveAndReturnButton = projectUpdateBatch.IsSubmitted && isApprover;
            IsEditable = projectUpdateBatch.InEditableState || ShowApproveAndReturnButton;
            IsReadyToApprove = projectUpdateBatch.IsReadyToApprove;
            AreProjectBasicsValid = projectUpdateBatch.AreProjectBasicsValid;

            //Neuter UpdateStatus for non-approver users until we go live with "Show Changes" for all users.
            UpdateStatus = CurrentPerson.IsApprover() ? updateStatus : new UpdateStatus(false, false, false, false, false, false, false, false, false, false, false, false);
            HasUpdateStarted = ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID);

            ValidationWarnings = validationWarnings;
        }

        public List<string> ValidationWarnings { get; set; }
    }
}
