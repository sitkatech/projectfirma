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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public enum ProjectUpdateSectionEnum
    {
        Instructions,
        Basics,
        PerformanceMeasures,
        Expenditures,
        Photos,
        LocationSimple,
        LocationDetailed,
        Watershed,
        Notes,
        History,
        Budgets,
        ExternalLinks,
        ExpectedFunding
    }

    public class ProjectUpdateViewData : FirmaViewData
    {
        public readonly ProjectUpdateSectionEnum SelectedProjectUpdateSection;
        public readonly ProjectUpdateBatch ProjectUpdateBatch;
        public readonly Models.Project Project;
        public readonly Person PrimaryContactPerson;
        public readonly string ProjectUpdateMyProjectsUrl;
        public readonly string ProjectUpdateInstructionsUrl;
        public readonly string ProjectUpdateBasicsUrl;
        public readonly string ProjectUpdatePerformanceMeasuresUrl;
        public readonly string ProjectUpdateExpendituresUrl;
        // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//        public readonly string ProjectUpdateBudgetsUrl;
        public readonly string ProjectUpdatePhotosUrl;
        public readonly string ProjectUpdateLocationSimpleUrl;
        public readonly string ProjectUpdateLocationDetailedUrl;
        public readonly string ProjectUpdateWatershedUrl;
        public readonly string ProjectUpdateNotesUrl;
        public readonly string ProjectUpdateExternalLinksUrl;
        public readonly string ProjectUpdateHistoryUrl;
        public readonly string DeleteProjectUpdateUrl;
        public readonly string ProjectUpdateExpectedFundingUrl;
        public readonly string SubmitUrl;
        public readonly string ApproveUrl;
        public readonly string ReturnUrl;
        public readonly string ProvideFeedbackUrl;

        public readonly bool IsEditable;
        public readonly bool IsReadyToApprove;
        public readonly bool ShowApproveAndReturnButton;
        public readonly bool AreProjectBasicsValid;
        public readonly UpdateStatus UpdateStatus;
        public readonly bool HasUpdateStarted;

        public ProjectUpdateViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateSectionEnum selectedProjectUpdateSection, UpdateStatus updateStatus) : base(currentPerson, null)
        {
            SelectedProjectUpdateSection = selectedProjectUpdateSection;
            ProjectUpdateBatch = projectUpdateBatch;
            Project = projectUpdateBatch.Project;
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
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//            ProjectUpdateBudgetsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Budgets(Project));
            ProjectUpdatePhotosUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(Project));
            ProjectUpdateLocationSimpleUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationSimple(Project));
            ProjectUpdateLocationDetailedUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(Project));
            ProjectUpdateWatershedUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Watershed(Project));
            ProjectUpdateExternalLinksUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(Project));
            ProjectUpdateNotesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Notes(Project));
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
            UpdateStatus = CurrentPerson.IsApprover() ? updateStatus : new UpdateStatus(false, false, false, false, false, false, false, false, false, false, false);
            HasUpdateStarted = ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID);
        }
    }
}
