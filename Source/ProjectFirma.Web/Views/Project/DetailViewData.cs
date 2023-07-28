﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectContact;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Views.Shared.ProjectAttachment;
using ProjectFirma.Web.Views.Shared.ProjectPotentialPartner;

namespace ProjectFirma.Web.Views.Project
{
    public class DetailViewData : ProjectViewData
    {
        public bool UserHasProjectAdminPermissions { get; }
        public bool UserHasEditProjectPermissions { get; }
        public bool UserHasPerformanceMeasureActualManagePermissions { get; }
        public bool UserHasProjectTimelinePermissions { get; }

        public string EditProjectUrl { get; }
        public string EditProjectOrganizationsUrl { get; }
        public List<GeospatialAreaType> GeospatialAreaTypes { get; }
        public string EditSimpleProjectLocationUrl { get; }
        public string EditDetailedProjectLocationUrl { get; }
        public string EditProjectBoundingBoxUrl { get; }
        public string EditPerformanceMeasureExpectedsUrl { get; }
        public string EditPerformanceMeasureActualsUrl { get; }
        public string EditReportedExpendituresUrl { get; }
        public string EditExternalLinksUrl { get; }
        public string EditExpectedFundingUrl { get; }
        public string EditProjectCustomAttributesUrl { get; }

        public ProjectBasicsViewData ProjectBasicsViewData { get; }
        public ProjectLocationSummaryViewData ProjectLocationSummaryViewData { get; }
        public PerformanceMeasureExpectedSummaryViewData PerformanceMeasureExpectedSummaryViewData { get; }
        public PerformanceMeasureReportedValuesGroupedViewData PerformanceMeasureReportedValuesGroupedViewData { get; }
        public ProjectExpendituresDetailViewData ProjectExpendituresDetailViewData { get; }
        public ProjectExpendituresByCostTypeDetailViewData ProjectExpendituresByCostTypeDetailViewData { get; }
        public ImageGalleryViewData ImageGalleryViewData { get; }
        public EntityNotesViewData ProjectNotesViewData { get; }
        public EntityNotesViewData InternalNotesViewData { get; }
        public EntityExternalLinksViewData EntityExternalLinksViewData { get; }

        public bool ReportFinancialsByCostType { get; }

        public ProjectBasicsTagsViewData ProjectBasicsTagsViewData { get; }

        public List<ProjectStage> ProjectStages { get; }
        public string MapFormID { get; }

        public ProjectUpdateBatchGridSpec ProjectUpdateBatchGridSpec { get; }
        public string ProjectUpdateBatchGridName { get; }
        public string ProjectUpdateBatchGridDataUrl { get; }

        public AuditLogsGridSpec AuditLogsGridSpec { get; }
        public string AuditLogsGridName { get; }
        public string AuditLogsGridDataUrl { get; }

        public ProjectNotificationGridSpec ProjectNotificationGridSpec { get; }
        public string ProjectNotificationGridName { get; }
        public string ProjectNotificationGridDataUrl { get; }

        public string EditProjectGeospatialAreaFormID { get; }
        public string EditProjectBoundingBoxFormID { get; }
        public string ProjectStewardCannotEditUrl { get; }
        public string ProjectStewardCannotEditPendingApprovalUrl { get; }
        public ProjectBudgetSummaryViewData ProjectBudgetSummaryViewData { get; }
        public ProjectBudgetsAnnualViewData ProjectBudgetsAnnualViewData { get; }
        public ProjectBudgetsAnnualByCostTypeViewData ProjectBudgetsAnnualByCostTypeViewData { get; }


        public string ProjectUpdateButtonText { get; }
        public bool CanLaunchProjectOrProposalWizard { get; }
        public bool ShowFactSheetButton { get; }
        public bool ShowWithdrawProjectButton { get; }
        public string WithdrawUrl { get; }
        public string ProjectWizardUrl { get; }
        public string ProjectListUrl { get; }
        public string BackToProjectsText { get; }
        public List<string> ProjectAlerts { get; }
        public ProjectOrganizationsDetailViewData ProjectOrganizationsDetailViewData { get; }
        public ProjectPotentialPartnerDetailViewData ProjectPotentialPartnerDetailViewData { get; }
        public ProjectContactsDetailViewData ProjectContactsDetailViewData { get; }
        public string EditProjectContactsUrl { get; }
        public List<ProjectFirmaModels.Models.ClassificationSystem> ClassificationSystems { get; }
        public ProjectAttachmentsDetailViewData ProjectAttachmentsDetailViewData { get; }
        public DisplayProjectCustomAttributesViewData DisplayProjectCustomAttributeTypesViewData { get; private set; }
        public ProjectTimelineDisplayViewData ProjectTimelineDisplayViewData { get; }

        public List<ProjectEvaluation> ProjectEvaluationsUserHasAccessTo { get; }

        public string UpdateStatusUrl { get; set; }

        public ProjectFirmaModels.Models.ProjectAttachment QuickAccessAttachment { get; }
        public string RevertApprovedProjectUrl { get; }
        public string RevertApprovedProjectButtonText { get; }

        public DetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project,
            List<ProjectStage> projectStages,
            ProjectBasicsViewData projectBasicsViewData, ProjectLocationSummaryViewData projectLocationSummaryViewData,
            ProjectBudgetSummaryViewData projectBudgetSummaryViewData,
            ProjectBudgetsAnnualViewData projectBudgetsAnnualViewData,
            ProjectBudgetsAnnualByCostTypeViewData projectBudgetsAnnualByCostTypeViewData,
            PerformanceMeasureExpectedSummaryViewData performanceMeasureExpectedSummaryViewData,
            PerformanceMeasureReportedValuesGroupedViewData performanceMeasureReportedValuesGroupedViewData,
            ProjectExpendituresDetailViewData projectExpendituresDetailViewData,
            ProjectExpendituresByCostTypeDetailViewData projectExpendituresByCostTypeDetailViewData,
            ImageGalleryViewData imageGalleryViewData, EntityNotesViewData projectNotesViewData,
            EntityNotesViewData internalNotesViewData,
            EntityExternalLinksViewData entityExternalLinksViewData,
            ProjectBasicsTagsViewData projectBasicsTagsViewData, bool userHasProjectAdminPermissions,
            bool userHasEditProjectPermissions, bool userHasProjectUpdatePermissions,
            bool userHasPerformanceMeasureActualManagePermissions, string mapFormID,
            string editProjectCustomAttributesUrl,
            string editSimpleProjectLocationUrl, string editDetailedProjectLocationUrl,
            string editProjectOrganizationsUrl, string editPerformanceMeasureExpectedsUrl,
            string editPerformanceMeasureActualsUrl, string editReportedExpendituresUrl,
            bool reportFinancialsByCostType, AuditLogsGridSpec auditLogsGridSpec, string auditLogsGridDataUrl,
            string editExternalLinksUrl, ProjectNotificationGridSpec projectNotificationGridSpec,
            string projectNotificationGridName, string projectNotificationGridDataUrl, bool userCanEditProposal,
            ProjectOrganizationsDetailViewData projectOrganizationsDetailViewData,
            ProjectPotentialPartnerDetailViewData projectPotentialPartnerDetailViewData,
            List<ProjectFirmaModels.Models.ClassificationSystem> classificationSystems,
            string editProjectBoundingBoxFormID, List<GeospatialAreaType> geospatialAreaTypes,
            DisplayProjectCustomAttributesViewData displayProjectCustomAttributeTypesViewData,
            ProjectContactsDetailViewData projectContactsDetailViewData, string editProjectContactsUrl,
            string editExpectedFundingUrl, ProjectTimelineDisplayViewData projectTimelineDisplayViewData,
            bool userHasProjectTimelinePermissions, List<ProjectEvaluation> projectEvaluationsUserHasAccessTo,
            bool userHasStartUpdateWorkflowPermission)
            : base(currentFirmaSession, project)
        {
            PageTitle = project.GetDisplayName();
            BreadCrumbTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Detail";
            ProjectStages = projectStages;

            EditProjectUrl = project.GetEditUrl();
            UserHasProjectAdminPermissions = userHasProjectAdminPermissions;
            UserHasEditProjectPermissions = userHasEditProjectPermissions;
            UserHasPerformanceMeasureActualManagePermissions = userHasPerformanceMeasureActualManagePermissions;
            UserHasProjectTimelinePermissions = userHasProjectTimelinePermissions;
            CanLaunchProjectOrProposalWizard = userHasStartUpdateWorkflowPermission;
            WithdrawUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.Withdraw(project));

            var projectAlerts = new List<string>();
            var proposedProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Proposed());
            var backToAllProposalsText = "Back to all Proposals";
            var pendingProjectsListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Pending());
            var backToAllPendingProjectsText = $"Back to all Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}";

            var currentPerson = currentFirmaSession.Person;

            if (project.IsRejected())
            {
                var projectApprovalStatus = project.ProjectApprovalStatus;
                ProjectUpdateButtonText =
                    projectApprovalStatus == ProjectApprovalStatus.Draft ||
                    projectApprovalStatus == ProjectApprovalStatus.Returned
                        ? $"Edit Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}"
                        : $"Review Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}";
                ProjectWizardUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
                if (project.IsProposal())
                {
                    ProjectListUrl = proposedProjectListUrl;
                    BackToProjectsText = backToAllProposalsText;
                }
                else if (project.IsPendingProject())
                {
                    ProjectListUrl = pendingProjectsListUrl;
                    BackToProjectsText = backToAllPendingProjectsText;
                }

                if (userHasProjectAdminPermissions || currentPerson.CanStewardProject(project))
                {
                    projectAlerts.Add(
                        $"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} was rejected and can no longer be edited. It can be deleted, or preserved for archival purposes.");
                }
            }
            else if (project.IsProposal())
            {
                var projectApprovalStatus = project.ProjectApprovalStatus;
                ProjectUpdateButtonText =
                    projectApprovalStatus == ProjectApprovalStatus.Draft ||
                    projectApprovalStatus == ProjectApprovalStatus.Returned
                        ? "Edit Proposal"
                        : "Review Proposal";
                ProjectWizardUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
                ProjectListUrl = proposedProjectListUrl;
                BackToProjectsText = backToAllProposalsText;
                if ((projectApprovalStatus == ProjectApprovalStatus.Draft || projectApprovalStatus == ProjectApprovalStatus.Returned) && (userHasProjectAdminPermissions || userHasStartUpdateWorkflowPermission))
                {
                    projectAlerts.Add(
                        $"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the Proposal stage. Any edits to this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} must be made using the Add New {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} workflow.");
                } 
                else if (projectApprovalStatus == ProjectApprovalStatus.PendingApproval)
                {
                    if (userHasProjectAdminPermissions || currentPerson.IsPersonAProjectOwnerWhoCanStewardProjects() && currentPerson.CanStewardProject(project))
                    {
                        projectAlerts.Add($"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} has been submitted and is awaiting review.");
                    }
                    else if (userHasStartUpdateWorkflowPermission)
                    {
                        projectAlerts.Add($"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} has been submitted, no change can be made.");
                        CanLaunchProjectOrProposalWizard = false;
                        ShowWithdrawProjectButton = true;
                    }
                }
            }
            else if (project.IsPendingProject())
            {
                var projectApprovalStatus = project.ProjectApprovalStatus;
                ProjectUpdateButtonText =
                    projectApprovalStatus == ProjectApprovalStatus.Draft ||
                    projectApprovalStatus == ProjectApprovalStatus.Returned
                        ? $"Edit Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}"
                        : $"Review Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}";
                ProjectWizardUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
                ProjectListUrl = pendingProjectsListUrl;
                BackToProjectsText = backToAllPendingProjectsText;
                if ((projectApprovalStatus == ProjectApprovalStatus.Draft || projectApprovalStatus == ProjectApprovalStatus.Returned) && (userHasProjectAdminPermissions || userHasStartUpdateWorkflowPermission))
                {
                    projectAlerts.Add(
                        $"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is pending. Any edits to this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} must be made using the Add New {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} workflow.");
                }
                else if (projectApprovalStatus == ProjectApprovalStatus.PendingApproval)
                {
                    if (userHasProjectAdminPermissions || currentPerson.IsPersonAProjectOwnerWhoCanStewardProjects() && currentPerson.CanStewardProject(project))
                    {
                        projectAlerts.Add($"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} has been submitted and is awaiting review.");

                    }
                    else if (userHasStartUpdateWorkflowPermission)
                    {
                        projectAlerts.Add($"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is pending, no change can be made.");
                        CanLaunchProjectOrProposalWizard = false;
                        ShowWithdrawProjectButton = true;
                    }
                }
            }
            else
            {
                var latestUpdateState = project.GetLatestUpdateStateResilientToDuplicateUpdateBatches();
                ProjectUpdateButtonText =
                    latestUpdateState == ProjectUpdateState.Submitted ||
                    latestUpdateState == ProjectUpdateState.Returned
                        ? "Review Update"
                        : $"Update {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}";
                ProjectWizardUrl = project.GetProjectUpdateUrl();
                ProjectListUrl = FullProjectListUrl;
                BackToProjectsText = $"Back to all {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}";


                if (currentPerson.IsPersonAProjectOwnerWhoCanStewardProjects())
                {
                    if (currentPerson.CanStewardProject(project))
                    {
                        projectAlerts.Add(
                            $"You are a {FieldDefinitionEnum.ProjectSteward.ToType().GetFieldDefinitionLabel()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. You may edit this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} by using the <i class=\"glyphicon glyphicon-edit\"></i> icon on each panel.<br/>");
                    }
                    else
                    {
                        projectAlerts.Add(
                            $"You are a {FieldDefinitionEnum.ProjectSteward.ToType().GetFieldDefinitionLabel()}, but not for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. You may only edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} that are associated with your {FieldDefinitionEnum.ProjectStewardshipArea.ToType().GetFieldDefinitionLabel()}.");
                    }
                }
            }

            if (ProjectModelExtensions.GetLatestNotApprovedUpdateBatch(project) != null)
            {
                if (userHasEditProjectPermissions)
                {
                    projectAlerts.Add($"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} has an Update in progress. Changes made through this page will be overwritten when the Update is approved.");
                }
                else
                {
                    projectAlerts.Add($"This {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} has an Update in progress.");
                }
            }

            ProjectAlerts = projectAlerts;

            ProjectBasicsViewData = projectBasicsViewData;
            ProjectBasicsTagsViewData = projectBasicsTagsViewData;

            EditProjectCustomAttributesUrl = editProjectCustomAttributesUrl;

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            MapFormID = mapFormID;
            EditSimpleProjectLocationUrl = editSimpleProjectLocationUrl;
            EditDetailedProjectLocationUrl = editDetailedProjectLocationUrl;

            EditProjectBoundingBoxUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectBoundingBox(project));
            EditProjectBoundingBoxFormID = editProjectBoundingBoxFormID;

            EditProjectOrganizationsUrl = editProjectOrganizationsUrl;

            PerformanceMeasureExpectedSummaryViewData = performanceMeasureExpectedSummaryViewData;
            EditPerformanceMeasureExpectedsUrl = editPerformanceMeasureExpectedsUrl;

            PerformanceMeasureReportedValuesGroupedViewData = performanceMeasureReportedValuesGroupedViewData;
            EditPerformanceMeasureActualsUrl = editPerformanceMeasureActualsUrl;

            ProjectBudgetSummaryViewData = projectBudgetSummaryViewData;
            ProjectBudgetsAnnualViewData = projectBudgetsAnnualViewData;
            ProjectBudgetsAnnualByCostTypeViewData = projectBudgetsAnnualByCostTypeViewData;
            EditExpectedFundingUrl = editExpectedFundingUrl;

            ProjectExpendituresDetailViewData = projectExpendituresDetailViewData;
            ProjectExpendituresByCostTypeDetailViewData = projectExpendituresByCostTypeDetailViewData;
            EditReportedExpendituresUrl = editReportedExpendituresUrl;
            GeospatialAreaTypes = geospatialAreaTypes;
            DisplayProjectCustomAttributeTypesViewData = displayProjectCustomAttributeTypesViewData;
            EditExternalLinksUrl = editExternalLinksUrl;
            ImageGalleryViewData = imageGalleryViewData;

            ProjectNotesViewData = projectNotesViewData;
            InternalNotesViewData = internalNotesViewData;

            EntityExternalLinksViewData = entityExternalLinksViewData;

            ProjectUpdateBatchGridSpec = new ProjectUpdateBatchGridSpec
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Updates",
                SaveFiltersInCookie = true
            };
            ProjectUpdateBatchGridName = "projectUpdateBatch";
            ProjectUpdateBatchGridDataUrl =
                SitkaRoute<ProjectController>.BuildUrlFromExpression(x =>
                    x.ProjectUpdateBatchGridJsonData(project.ProjectID));

            ReportFinancialsByCostType = reportFinancialsByCostType;

            AuditLogsGridSpec = auditLogsGridSpec;
            AuditLogsGridName = "projectAuditLogsGrid";
            AuditLogsGridDataUrl = auditLogsGridDataUrl;

            ProjectNotificationGridSpec = projectNotificationGridSpec;
            ProjectNotificationGridName = projectNotificationGridName;
            ProjectNotificationGridDataUrl = projectNotificationGridDataUrl;
            ProjectOrganizationsDetailViewData = projectOrganizationsDetailViewData;

            // Potential Partner panel
            ProjectPotentialPartnerDetailViewData = projectPotentialPartnerDetailViewData;

            ProjectContactsDetailViewData = projectContactsDetailViewData;
            EditProjectContactsUrl = editProjectContactsUrl;

            EditProjectGeospatialAreaFormID = ProjectGeospatialAreaController.GetEditProjectGeospatialAreasFormID();

            ProjectStewardCannotEditUrl =
                SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.ProjectStewardCannotEdit());
            ProjectStewardCannotEditPendingApprovalUrl =
                SitkaRoute<ProjectController>.BuildUrlFromExpression(c =>
                    c.ProjectStewardCannotEditPendingApproval(project));

            ClassificationSystems = classificationSystems;

            ProjectAttachmentsDetailViewData = new ProjectAttachmentsDetailViewData(
                EntityAttachment.CreateFromProjectAttachment(project.ProjectAttachments),
                SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(x => x.New(project)), 
                project.ProjectName,
                new ProjectEditAsAdminFeature().HasPermission(currentFirmaSession, project).HasPermission,
                project.GetAllAttachmentTypes().ToList(),
                currentFirmaSession);

            ProjectTimelineDisplayViewData = projectTimelineDisplayViewData;

            ProjectEvaluationsUserHasAccessTo = projectEvaluationsUserHasAccessTo;

            ShowFactSheetButton = OfferProjectFactSheetLinkFeature.OfferProjectFactSheetLink(currentFirmaSession, project);

            QuickAccessAttachment =
                project.ProjectAttachments.SingleOrDefault(x => x.AttachmentType.IsQuickAccessAttachment);

            RevertApprovedProjectButtonText = $"Revert {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} to Pending Approval";
            RevertApprovedProjectUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.RevertProjectToPendingApproval(project));
        }
    }
}
