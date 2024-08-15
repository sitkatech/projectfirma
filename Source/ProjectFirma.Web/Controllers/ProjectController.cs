﻿/*-----------------------------------------------------------------------
<copyright file="ProjectController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using log4net;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using MoreLinq;
using ProjectFirma.Web.Views.Shared.ProjectPotentialPartner;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using Detail = ProjectFirma.Web.Views.Project.Detail;
using DetailViewData = ProjectFirma.Web.Views.Project.DetailViewData;
using Index = ProjectFirma.Web.Views.Project.Index;
using IndexViewData = ProjectFirma.Web.Views.Project.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectController : FirmaBaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ProjectController));

        /// <summary>
        /// This enum was initially used to separate GoogleCharts scripts on Fact Sheet pages because wkhtmltopdf
        /// uses a version of QT Browser that doesn't support modern javascript. It can also be used to differ
        /// content on the fact sheets (if other pdf/print differences arise). See: https://projects.sitkatech.com/projects/projectfirma/cards/1330
        /// </summary>
        public enum FactSheetPdfEnum
        {
            NoPdf,
            Pdf
        }

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult Edit(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var latestNotApprovedUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new EditProjectViewModel(project, latestNotApprovedUpdateBatch != null);
            return ViewEdit(viewModel, project, EditProjectType.ExistingProject, project.TaxonomyLeaf.GetDisplayName(), project.TotalExpenditures);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectPrimaryKey projectPrimaryKey, EditProjectViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, project, EditProjectType.ExistingProject, project.TaxonomyLeaf.GetDisplayName(), project.TotalExpenditures);
            }

            var oldProjectStage = project.ProjectStage;

            viewModel.UpdateModel(project, CurrentFirmaSession);
            _logger.Info($"Project {project.ProjectID} - {project.GetDisplayName()} edited by {CurrentFirmaSession.Person.GetPersonInformationStringForLogging()}");

            if (oldProjectStage == ProjectStage.Completed && project.ProjectStage != ProjectStage.Completed && MultiTenantHelpers.GetTenantAttributeFromCache().EnableStatusUpdates)
            {
                var projectEntityName = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
                var userHasPermissionToEditTimeline = new ProjectTimelineFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
                var finalStatusReport = project.ProjectProjectStatuses.Where(x => x.IsFinalStatusUpdate)
                    .OrderByDescending(x => x.ProjectProjectStatusUpdateDate).FirstOrDefault();
                var hasFinalStatusReportAndAllowEdit = finalStatusReport != null && userHasPermissionToEditTimeline;
                if (hasFinalStatusReportAndAllowEdit && project.ProjectStage != ProjectStage.Completed)
                {
                    var deleteIconAsModalDialogLinkBootstrap = ModalDialogFormHelper.MakeDeleteLink("Delete Status",
                        finalStatusReport.GetDeleteProjectProjectStatusUrl(), new List<string> { "btn", "btn-firma" }, true);

                    SetWarningForDisplay(
                        $"The {projectEntityName} stage has been changed from {ProjectStage.Completed.GetProjectStageDisplayName()} to {project.ProjectStage.GetProjectStageDisplayName()}. Please confirm that the Final Status Update saved on {finalStatusReport.ProjectProjectStatusUpdateDate.ToShortDateString()} is still accurate. If needed, you can delete the update here; you will be prompted to add a new Final Status Update when this {projectEntityName} is identified as Completed. </br></br> {deleteIconAsModalDialogLinkBootstrap}");
                }
            }

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditProjectViewModel viewModel, Project project, EditProjectType editProjectType, string taxonomyLeafDisplayName, decimal? totalExpenditures)
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().OrderBy(ap => ap.GetDisplayName()).ToList();
            var primaryContactPeople = HttpRequestStorage.DatabaseEntities.People.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            var defaultPrimaryContact = project?.GetPrimaryContact() ?? CurrentPerson.Organization.PrimaryContactPerson;
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().Where(x => x.HasEditPermission(CurrentFirmaSession));
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.TenantAttributes.SingleOrDefault(x => x.TenantID == HttpRequestStorage.DatabaseEntities.TenantID);
            var solicitationOptions = HttpRequestStorage.DatabaseEntities.Solicitations.GetActiveSolicitations().ToSelectListWithEmptyFirstRow(x => x.SolicitationID.ToString(), y => y.SolicitationName).ToList();
            // need to include the current Solicitation if it is inactive so saving the Basics admin editor does not null out the solicitation
            if (project?.Solicitation != null && !project.Solicitation.IsActive)
            {
                solicitationOptions.Add(new SelectListItem{ Value = project.Solicitation.SolicitationID.ToString() , Text = project.Solicitation.SolicitationName });
            }
            var userHasAdminPermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var viewData = new EditProjectViewData(editProjectType,
                taxonomyLeafDisplayName,
                ProjectStage.All.Except(new[] {ProjectStage.Proposal}), organizations,
                primaryContactPeople,
                defaultPrimaryContact,
                totalExpenditures,
                taxonomyLeafs,
                projectCustomAttributeTypes,
                tenantAttribute,
                solicitationOptions,
                userHasAdminPermissions
            );
            return RazorPartialView<EditProject, EditProjectViewData, EditProjectViewModel>(viewData, viewModel);
        }

        [CrossAreaRoute]
        [ProjectViewFeature]
        public PartialViewResult ProjectMapPopup(ProjectPrimaryKey primaryKeyProject)
        {
            var project = primaryKeyProject.EntityObject;
            var projectMapPopupViewData = new ProjectMapPopupViewData(this.CurrentFirmaSession, project, true);
            return RazorPartialView<ProjectMapPopup, ProjectMapPopupViewData>(projectMapPopupViewData);
        }

        [CrossAreaRoute]
        [ProjectViewFeature]
        public PartialViewResult ProjectSimpleMapPopup(ProjectPrimaryKey primaryKeyProject)
        {
            var project = primaryKeyProject.EntityObject;
            var projectMapPopupViewData = new ProjectMapPopupViewData(this.CurrentFirmaSession, project, false);
            return RazorPartialView<ProjectMapPopup, ProjectMapPopupViewData>(projectMapPopupViewData);
        }

        [ProjectViewFeature]
        public ViewResult Detail(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var activeProjectStages = GetActiveProjectStages(project);

            bool userHasProjectAdminPermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            bool userHasEditProjectPermissions = new ProjectEditAsAdminFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
            bool userHasProjectUpdatePermissions = new ProjectUpdateCreateEditSubmitFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
            bool userHasProjectTimelinePermissions = new ProjectTimelineFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
            bool userCanEditProposal = new ProjectCreateFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
            bool userHasPerformanceMeasureActualManagePermissions = new PerformanceMeasureActualFromProjectManageFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
            bool userHasStartUpdateWorkflowPermission = new ProjectStartUpdateWorkflowFeature().HasPermission(CurrentFirmaSession, project).HasPermission;

            var editProjectCustomAttributesUrl = SitkaRoute<ProjectCustomAttributesController>.BuildUrlFromExpression(c => c.EditProjectCustomAttributesForProject(project));
            var editSimpleProjectLocationUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationSimple(project));
            var editDetailedProjectLocationUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationDetailed(project));
            var editOrganizationsUrl = SitkaRoute<ProjectOrganizationController>.BuildUrlFromExpression(c => c.EditOrganizations(project));
            var editPerformanceMeasureExpectedsUrl = SitkaRoute<PerformanceMeasureExpectedController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureExpectedsForProject(project));
            var editPerformanceMeasureActualsUrl = SitkaRoute<PerformanceMeasureActualController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureActualsForProject(project));
            // Use a different editor for Budget and Reported Expenditures if the Tenant's selected BudgetType is Budget by Year and Cost Type
            var budgetType = MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType;
            var reportFinancialsByCostType = budgetType == BudgetType.AnnualBudgetByCostType;
            var editReportedExpendituresUrl = reportFinancialsByCostType ?
                SitkaRoute<ProjectFundingSourceExpenditureController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceExpendituresByCostType(project)) :
                SitkaRoute<ProjectFundingSourceExpenditureController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceExpenditures(project));
            var editExpectedFundingUrl = reportFinancialsByCostType ?
                SitkaRoute<ProjectFundingSourceBudgetController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceBudgetByCostTypeForProject(project)) :
                SitkaRoute<ProjectFundingSourceBudgetController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceBudgetsForProject(project));

            var editExternalLinksUrl = SitkaRoute<ProjectExternalLinkController>.BuildUrlFromExpression(c => c.EditProjectExternalLinks(project));

            var geospatialAreas = project.GetProjectGeospatialAreas().ToList();
            var userCanViewPrivateLocations = CurrentFirmaSession.UserCanViewPrivateLocations(project);
            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(project, CurrentFirmaSession,
                $"project_{project.ProjectID}_Map", geospatialAreas, 
                project.DetailedLocationToGeoJsonFeatureCollection(userCanViewPrivateLocations), 
                project.SimpleLocationToGeoJsonFeatureCollection(userCanViewPrivateLocations, false), true, userCanViewPrivateLocations, true);
            var mapFormID = GenerateEditProjectLocationFormID(project);
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName).ToList();
            var dictionaryGeoNotes = project.ProjectGeospatialAreaTypeNotes.ToDictionary(x => x.GeospatialAreaTypeID, x => x.Notes);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(project, projectLocationSummaryMapInitJson, dictionaryGeoNotes, 
                geospatialAreaTypes, geospatialAreas, project.LocationIsPrivate, userHasEditProjectPermissions);

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var projectBasicsViewData = new ProjectBasicsViewData(project, false, taxonomyLevel, tenantAttribute, userHasProjectAdminPermissions);
            var projectBasicsTagsViewData = new ProjectBasicsTagsViewData(project);
            var performanceMeasureExpectedsSummaryViewData = new PerformanceMeasureExpectedSummaryViewData(new List<IPerformanceMeasureValue>(project.PerformanceMeasureExpecteds.OrderBy(x=>x.PerformanceMeasure.GetSortOrder()).ThenBy(x => x.PerformanceMeasure.GetDisplayName())));
            var performanceMeasureReportedValuesGroupedViewData = BuildPerformanceMeasureReportedValuesGroupedViewData(project);
            // Budget - conditional based on BudgetType
            var projectBudgetSummaryViewData = new ProjectBudgetSummaryViewData(CurrentFirmaSession, project);
            var projectBudgetsAnnualViewData = !reportFinancialsByCostType ? new ProjectBudgetsAnnualViewData(CurrentFirmaSession, project) : null;
            var projectBudgetsAnnualByCostTypeViewData = reportFinancialsByCostType ? BuildProjectBudgetsAnnualByCostTypeViewData(CurrentFirmaSession, project) : null;

            // Expenditures - conditional based on BudgetType
            var projectExpendituresSummaryViewData = !reportFinancialsByCostType ? BuildProjectExpendituresDetailViewData(project) : null;
            var projectExpendituresByCostTypeSummaryViewData = reportFinancialsByCostType ? BuildProjectExpendituresByCostTypeDetailViewData(project) : null;

            var imageGalleryViewData = BuildImageGalleryViewData(project, CurrentFirmaSession);
            var projectNotesViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(project.ProjectNotes),
                SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(x => x.New(project)),
                project.GetDisplayName(),
                userHasEditProjectPermissions);
            var internalNotesViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(project.ProjectInternalNotes),
                SitkaRoute<ProjectInternalNoteController>.BuildUrlFromExpression(x => x.New(project)),  //TODO: clone the ProjectNoteController to the ProjectInternalNoteController
                project.GetDisplayName(),
                userHasEditProjectPermissions);
            var entityExternalLinksViewData = new EntityExternalLinksViewData(ExternalLink.CreateFromEntityExternalLink(new List<IEntityExternalLink>(project.ProjectExternalLinks)));

            var auditLogsGridSpec = new AuditLogsGridSpec(CurrentFirmaSession) {ObjectNameSingular = "Change", ObjectNamePlural = "Changes", SaveFiltersInCookie = true};
            var auditLogsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.AuditLogsGridJsonData(project));

            var projectNotificationGridSpec = new ProjectNotificationGridSpec(CurrentFirmaSession);
            const string projectNotificationGridName = "projectNotifications";
            var projectNotificationGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ProjectNotificationsGridJsonData(project));

            var projectAssociatedOrganizations = project.GetAssociatedOrganizationRelationships(tenantAttribute.ExcludeTargetedFundingOrganizations);
            var projectOrganizationsDetailViewData = new ProjectOrganizationsDetailViewData(projectAssociatedOrganizations, project.GetPrimaryContact(), project.OtherPartners);

            var projectContactsDetailViewData = new ProjectContactsDetailViewData(project.GetAssociatedContactRelationships(), project.PrimaryContactPerson, CurrentFirmaSession, project.PrimaryContactPersonFullName);
            var editContactsUrl = SitkaRoute<ProjectContactController>.BuildUrlFromExpression(c => c.EditContacts(project));

            var classificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList();

            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().Where(x => x.HasViewPermission(CurrentFirmaSession)).OrderBy(x => x.SortOrder).ToList();
            var projectCustomAttributeGroups = projectCustomAttributeTypes.Select(x => x.ProjectCustomAttributeGroup).Where(x => x.ProjectCustomAttributeGroupProjectCategories.Any(pcagpt => pcagpt.ProjectCategoryID == project.ProjectCategoryID)).Distinct().OrderBy(x => x.SortOrder).ToList();
            
            var projectCustomAttributeTypesViewData = new DisplayProjectCustomAttributesViewData(
                projectCustomAttributeTypes,
                new List<IProjectCustomAttribute>(project.ProjectCustomAttributes.ToList()),
                projectCustomAttributeGroups);

            var userHasEditProjectAsAdminPermissions = new ProjectEditAsAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var userHasProjectStatusUpdatePermissions = new ProjectStatusUpdateFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
            var projectTimeline = new ProjectTimeline(project, userHasEditProjectAsAdminPermissions, userHasProjectAdminPermissions);
            var projectStatusesForLegend = HttpRequestStorage.DatabaseEntities.ProjectStatuses.OrderBy(ps => ps.ProjectStatusSortOrder).ToList();
            var projectStatusLegendDisplayViewData = new ProjectStatusLegendDisplayViewData(projectStatusesForLegend);
            var projectTimelineViewData =
                new ProjectTimelineDisplayViewData(project, projectTimeline, userHasProjectStatusUpdatePermissions, projectStatusLegendDisplayViewData);

            var updateStatusUrl = SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(tc => tc.New(project));
            var addProjectProjectStatusButton =
                ModalDialogFormHelper.MakeNewIconButton(updateStatusUrl, "Update Status", true);
            AddWarningForSubmittingFinalStatusReportIfNeeded(project, addProjectProjectStatusButton);

            List<ProjectEvaluation> projectEvaluationsUserHasAccessTo = new List<ProjectEvaluation>();
            foreach (var projectEvaluation in project.ProjectEvaluations)
            {
                if (ProjectEvaluationManageFeature.HasProjectEvaluationManagePermission(CurrentFirmaSession, projectEvaluation))
                {
                    //we only want to show the evaluations that this user has access to
                    projectEvaluationsUserHasAccessTo.Add(projectEvaluation);
                }
            }

            // Potential Match Maker Project Partners (if any)
            ProjectPotentialPartnerDetailViewData projectPotentialPartnerDetailViewData = 
                                                    new ProjectPotentialPartnerDetailViewData(CurrentFirmaSession,
                                                                                              project,
                                                                                              ProjectPotentialPartnerListDisplayMode.ProjectDetailViewPartialList);

            var viewData = new DetailViewData(CurrentFirmaSession,
                project,
                activeProjectStages,
                projectBasicsViewData,
                projectLocationSummaryViewData,
                projectBudgetSummaryViewData,
                projectBudgetsAnnualViewData,
                projectBudgetsAnnualByCostTypeViewData,
                performanceMeasureExpectedsSummaryViewData,
                performanceMeasureReportedValuesGroupedViewData,
                projectExpendituresSummaryViewData,
                projectExpendituresByCostTypeSummaryViewData,
                imageGalleryViewData,
                projectNotesViewData,
                internalNotesViewData,
                entityExternalLinksViewData,
                projectBasicsTagsViewData,
                userHasProjectAdminPermissions,
                userHasEditProjectPermissions,
                userHasProjectUpdatePermissions,
                userHasPerformanceMeasureActualManagePermissions,
                mapFormID,
                editProjectCustomAttributesUrl,
                editSimpleProjectLocationUrl,
                editDetailedProjectLocationUrl,
                editOrganizationsUrl,
                editPerformanceMeasureExpectedsUrl,
                editPerformanceMeasureActualsUrl,
                editReportedExpendituresUrl,
                reportFinancialsByCostType,
                auditLogsGridSpec,
                auditLogsGridDataUrl,
                editExternalLinksUrl,
                projectNotificationGridSpec,
                projectNotificationGridName,
                projectNotificationGridDataUrl,
                userCanEditProposal,
                projectOrganizationsDetailViewData,
                projectPotentialPartnerDetailViewData,
                classificationSystems,
                ProjectLocationController.EditProjectBoundingBoxFormID, 
                geospatialAreaTypes, 
                projectCustomAttributeTypesViewData,
                projectContactsDetailViewData,
                editContactsUrl, 
                editExpectedFundingUrl,
                projectTimelineViewData,
                userHasProjectTimelinePermissions,
                projectEvaluationsUserHasAccessTo,
                userHasStartUpdateWorkflowPermission);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        private void AddWarningForSubmittingFinalStatusReportIfNeeded(Project project, HtmlString addProjectProjectStatusButton)
        {
            var allowEditFinalStatusReport = ProjectProjectStatusController.AllowUserToSetNewStatusReportToFinal(project, CurrentFirmaSession);
            var projectEntityName = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            if (allowEditFinalStatusReport)
            {
                SetWarningForDisplay(
                    $"The {projectEntityName} is completed. Submit a final status update here, or from the {projectEntityName} Update and Status History panel. </br></br> {addProjectProjectStatusButton}");
            }
        }

        private static ProjectBudgetsAnnualByCostTypeViewData BuildProjectBudgetsAnnualByCostTypeViewData(FirmaSession currentFirmaSession, Project project)
        {
            var projectFundingSourceBudgets = project.ProjectFundingSourceBudgets.ToList();
            var projectFundingSourceCostTypeAmounts = ProjectFundingSourceCostTypeAmount.CreateFromProjectFundingSourceBudgets(projectFundingSourceBudgets);
            var projectBudgetsAnnualByCostTypeViewData = new ProjectBudgetsAnnualByCostTypeViewData(currentFirmaSession, project, projectFundingSourceCostTypeAmounts, project.ExpectedFundingUpdateNote);
            return projectBudgetsAnnualByCostTypeViewData;
        }

        private static ProjectExpendituresByCostTypeDetailViewData BuildProjectExpendituresByCostTypeDetailViewData(Project project)
        {
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var projectFundingSourceCostTypeExpenditureAmounts = ProjectFundingSourceCostTypeAmount.CreateFromProjectFundingSourceExpenditures(projectFundingSourceExpenditures);
            var projectExpendituresByCostTypeDetailViewData = new ProjectExpendituresByCostTypeDetailViewData(project.ExpendituresNote, projectFundingSourceCostTypeExpenditureAmounts);
            return projectExpendituresByCostTypeDetailViewData;
        }

        private static ProjectExpendituresDetailViewData BuildProjectExpendituresDetailViewData(Project project)
        {
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearsForFundingSourceExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var fromFundingSourcesAndCalendarYears = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures),
                calendarYearsForFundingSourceExpenditures);
            var projectExpendituresDetailViewData = new ProjectExpendituresDetailViewData(
                fromFundingSourcesAndCalendarYears,
                calendarYearsForFundingSourceExpenditures.Select(x => new CalendarYearString(x)).ToList(),
                project.ExpendituresNote);
            return projectExpendituresDetailViewData;
        }

        private static PerformanceMeasureReportedValuesGroupedViewData BuildPerformanceMeasureReportedValuesGroupedViewData(Project project)
        {
            var performanceMeasureReportedValues = project.GetPerformanceMeasureReportedValues();
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(performanceMeasureReportedValues.OrderBy(x=>x.PerformanceMeasure.GetSortOrder()).ThenBy(x=>x.PerformanceMeasure.GetDisplayName())));
            var performanceMeasureReportedValuesGroupedViewData = new PerformanceMeasureReportedValuesGroupedViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                FirmaHelpers.CalculateYearRanges(project.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear)),
                project.PerformanceMeasureActualYearsExemptionExplanation,
                performanceMeasureReportedValues.Select(x => x.CalendarYear).Distinct().Select(x => new CalendarYearString(x)).ToList(),
                false);
            return performanceMeasureReportedValuesGroupedViewData;
        }

        private static ImageGalleryViewData BuildImageGalleryViewData(Project project, FirmaSession currentFirmaSession)
        {
            var userCanAddPhotosToThisProject = new ProjectEditAsAdminFeature().HasPermission(currentFirmaSession, project).HasPermission;
            var newPhotoForProjectUrl = SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.New(project));
            var selectKeyImageUrl = userCanAddPhotosToThisProject
                ? SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.SetKeyPhoto(UrlTemplate.Parameter1Int))
                : string.Empty;
            var galleryName = $"ProjectImage{project.ProjectID}";
            var imageGalleryViewData = new ImageGalleryViewData(currentFirmaSession,
                galleryName,
                project.ProjectImages.Select(x => new FileResourcePhoto(x)),
                userCanAddPhotosToThisProject,
                newPhotoForProjectUrl,
                selectKeyImageUrl,
                true,
                x => x.CaptionOnFullView,
                "Photo");
            return imageGalleryViewData;
        }

        private static List<ProjectStage> GetActiveProjectStages(Project project)
        {
            var activeProjectStages = new List<ProjectStage> {ProjectStage.Proposal, ProjectStage.PlanningDesign, ProjectStage.Implementation, ProjectStage.Completed, ProjectStage.PostImplementation};

            if (project.ProjectStage == ProjectStage.Terminated)
            {
                activeProjectStages.Remove(ProjectStage.Implementation);
                activeProjectStages.Remove(ProjectStage.Completed);
                activeProjectStages.Remove(ProjectStage.PostImplementation);

                activeProjectStages.Add(project.ProjectStage);
            }
            else if (project.ProjectStage == ProjectStage.Deferred)
            {
                activeProjectStages.Add(project.ProjectStage);
            }

            activeProjectStages = activeProjectStages.OrderBy(p => p.SortOrder).ToList();
            return activeProjectStages;
        }

        [ProjectsViewFullListFeature]
        public ActionResult FactSheet(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            if (project.ProjectStage == ProjectStage.Terminated)
            {
                // This happens often enough that it deserves a friendlier error
                string noFactSheetError = $"There is no Fact Sheet available for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} because it has been terminated.";
                SetErrorForDisplay(noFactSheetError);
                return RedirectToAction(new SitkaRoute<ProjectController>(x => x.Detail(project)));
            }
            return project.IsBackwardLookingFactSheetRelevant() ? 
                ViewBackwardLookingFactSheet(project, false, FactSheetPdfEnum.NoPdf) : 
                ViewForwardLookingFactSheet(project, false, FactSheetPdfEnum.NoPdf);
        }

        [ProjectsViewFullListFeature]
        public ActionResult FactSheetForPdf(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            if (project.ProjectStage == ProjectStage.Terminated)
            {
                // This happens often enough that it deserves a friendlier error
                string noFactSheetError = $"There is no Fact Sheet available for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} because it has been terminated.";
                SetErrorForDisplay(noFactSheetError);
                return RedirectToAction(new SitkaRoute<ProjectController>(x => x.Detail(project)));
            }
            return project.IsBackwardLookingFactSheetRelevant() ? ViewBackwardLookingFactSheet(project, false, FactSheetPdfEnum.Pdf) : ViewForwardLookingFactSheet(project, false, FactSheetPdfEnum.Pdf);
        }

        [ProjectsViewFullListFeature]
        public ViewResult FactSheetWithCustomAttributesForPdf(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            Check.Assert(project.ProjectStage != ProjectStage.Terminated, $"There is no Fact Sheet available for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} because it has been terminated.");
            return project.IsBackwardLookingFactSheetRelevant() ? 
                ViewBackwardLookingFactSheet(project, true, FactSheetPdfEnum.Pdf) : 
                ViewForwardLookingFactSheet(project, true, FactSheetPdfEnum.Pdf);
        }

        private ViewResult ViewBackwardLookingFactSheet(Project project, bool withCustomAttributes, FactSheetPdfEnum factSheetPdfEnum)
        {
            new ProjectViewFeature().DemandPermission(CurrentFirmaSession, project);
            var mapDivID = $"project_{project.ProjectID}_Map";
            var geospatialAreas = project.GetProjectGeospatialAreas().ToList();
            // do not include external map layers
            var projectLocationDetailMapInitJson = new ProjectLocationSummaryMapInitJson(project, CurrentFirmaSession, mapDivID, geospatialAreas, 
                project.DetailedLocationToGeoJsonFeatureCollection(false), 
                project.SimpleLocationToGeoJsonFeatureCollection(false, false), 
                false, false, true);
            var chartName = $"ProjectFactSheet{project.ProjectID}PieChart";
            var expenditureGooglePieChartSlices = ProjectModelExtensions.GetExpenditureGooglePieChartSlices(project);
            var googleChartDataTable = GetProjectFactSheetGoogleChartDataTable(expenditureGooglePieChartSlices);
            var googleChartTitle = $"Investment by Funding Sector for: {project.ProjectName}";
            var googleChartType = GoogleChartType.PieChart;
            var googleChartConfiguration = new GooglePieChartConfiguration(googleChartTitle,
                MeasurementUnitTypeEnum.Dollars, expenditureGooglePieChartSlices, googleChartType,
                googleChartDataTable);
            var googleChartJson = new GoogleChartJson(string.Empty, chartName, googleChartConfiguration,
                googleChartType, googleChartDataTable, null);
            var firmaPageFactSheetCustomText = FirmaPageTypeEnum.FactSheetCustomText.GetFirmaPage();
            var viewData = new BackwardLookingFactSheetViewData(CurrentFirmaSession, project, projectLocationDetailMapInitJson,
                googleChartJson, expenditureGooglePieChartSlices, FirmaHelpers.DefaultColorRange, firmaPageFactSheetCustomText, withCustomAttributes, factSheetPdfEnum);
            return RazorView<BackwardLookingFactSheet, BackwardLookingFactSheetViewData>(viewData);
        }

        private ViewResult ViewForwardLookingFactSheet(Project project, bool withCustomAttributes, FactSheetPdfEnum factSheetPdfEnum)
        {
            new ProjectViewFeature().DemandPermission(CurrentFirmaSession, project);
            var mapDivID = $"project_{project.ProjectID}_Map";
            var geospatialAreas = project.GetProjectGeospatialAreas().ToList();
            // do not include external map layers
            var projectLocationDetailMapInitJson = new ProjectLocationSummaryMapInitJson(project, CurrentFirmaSession, mapDivID, geospatialAreas, 
                project.DetailedLocationToGeoJsonFeatureCollection(false), 
                project.SimpleLocationToGeoJsonFeatureCollection(false, false), false, false, true);
            var chartName = $"ProjectFundingRequestSheet{project.ProjectID}PieChart";
            var fundingSourceRequestAmountGooglePieChartSlices = project.GetRequestAmountGooglePieChartSlices();
            var googleChartDataTable =
                GetProjectFundingRequestSheetGoogleChartDataTable(fundingSourceRequestAmountGooglePieChartSlices);
            var googleChartTitle = $"Funding Request by Organization for: {project.ProjectName}";
            var googleChartType = GoogleChartType.PieChart;
            var googleChartConfiguration = new GooglePieChartConfiguration(googleChartTitle, MeasurementUnitTypeEnum.Dollars,
                fundingSourceRequestAmountGooglePieChartSlices, googleChartType, googleChartDataTable) {PieSliceText = "value"};
            var googleChartJson = new GoogleChartJson(string.Empty, chartName, googleChartConfiguration,
                googleChartType,
                googleChartDataTable, null);
            var firmaPageFactSheetCustomText = FirmaPageTypeEnum.FactSheetCustomText.GetFirmaPage();

            var viewData = new ForwardLookingFactSheetViewData(CurrentFirmaSession, project, projectLocationDetailMapInitJson,
                googleChartJson, fundingSourceRequestAmountGooglePieChartSlices, firmaPageFactSheetCustomText, withCustomAttributes, factSheetPdfEnum);
            return RazorView<ForwardLookingFactSheet, ForwardLookingFactSheetViewData>(viewData);
        }

        public static GoogleChartDataTable GetProjectFundingRequestSheetGoogleChartDataTable(List<GooglePieChartSlice> fundingSourceExpenditureGooglePieChartSlices)
        {
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Funding Source", GoogleChartColumnDataType.String, GoogleChartType.PieChart), new GoogleChartColumn("Expenditures", GoogleChartColumnDataType.Number, GoogleChartType.PieChart) };
            var chartRowCs = fundingSourceExpenditureGooglePieChartSlices.OrderBy(x => x.SortOrder).Select(x =>
            {
                var sectorRowV = new GoogleChartRowV(x.Label);
                var formattedValue = GoogleChartJson.GetFormattedValue(x.Value, MeasurementUnitType.Dollars);
                var expenditureRowV = new GoogleChartRowV(x.Value, formattedValue);
                return new GoogleChartRowC(new List<GoogleChartRowV> { sectorRowV, expenditureRowV });
            });
            var googleChartRowCs = new List<GoogleChartRowC>(chartRowCs);

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        [ProjectsViewFullListFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.FullProjectList.GetFirmaPage();
            var projectCustomFullGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Full.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, projectCustomFullGridConfigurations);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ProjectsInProposalStageViewListFeature]
        public ViewResult Proposed()
        {
            var firmaPage = FirmaPageTypeEnum.Proposals.GetFirmaPage();
            var viewData = new ProposedViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Proposed, ProposedViewData>(viewData);
        }

        [ProjectsInProposalStageViewListFeature]
        public GridJsonNetJObjectResult<Project> ProposedGridJsonData()
        {
            var gridSpec = new ProposalsGridSpec(CurrentFirmaSession);
            var proposals = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetProposalsVisibleToUser(CurrentFirmaSession);

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(proposals, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [PendingProjectsViewListFeature]
        public ViewResult Pending()
        {
            var firmaPage = FirmaPageTypeEnum.PendingProjects.GetFirmaPage();
            var viewData = new PendingViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Pending, PendingViewData>(viewData);
        }

        [PendingProjectsViewListFeature]
        public GridJsonNetJObjectResult<Project> PendingGridJsonData()
        {
            var gridSpec = new PendingGridSpec(CurrentFirmaSession);
            var pendingProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetPendingProjectsVisibleToUser(CurrentFirmaSession);

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(pendingProjects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectsViewFullListFeature]
        public ExcelResult IndexExcelDownload()
        {
            return FullDatabaseExcelDownloadImpl(
                HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects(),
                FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized());
        }

        [ProjectsViewFullListFeature]
        public ExcelResult ProposalsExcelDownload()
        {
            return FullDatabaseExcelDownloadImpl(
                HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .GetProposalsVisibleToUser(CurrentFirmaSession),
                FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized());
        }

        [ProjectsViewFullListFeature]
        public ExcelResult PendingExcelDownload()
        {
            return FullDatabaseExcelDownloadImpl(
                HttpRequestStorage.DatabaseEntities.Projects.ToList()
                .GetPendingProjectsVisibleToUser(CurrentFirmaSession),
                "Pending Projects");
        }

        private ExcelResult FullDatabaseExcelDownloadImpl(List<Project> projects, string workbookTitle)
        {
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList();
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList();
            var projectsSpec = new ProjectExcelSpec(CurrentFirmaSession, geospatialAreaTypes, projectCustomAttributeTypes);
            var wsProjects = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", projectsSpec, projects);

            var workSheets = new List<IExcelWorkbookSheetDescriptor>
            {
                wsProjects
            };

            var projectsDescriptionSpec = new ProjectDescriptionExcelSpec();
            var wsProjectDescriptions = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinitionEnum.ProjectDescription.ToType().GetFieldDefinitionLabelPluralized()}", projectsDescriptionSpec, projects);
            workSheets.Add(wsProjectDescriptions);

            var organizationsSpec = new ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec();
            var projectOrganizations = projects.SelectMany(p => p.GetAssociatedOrganizationRelationships()).ToList();
            var otherPartnersLabel = FieldDefinitionEnum.OtherPartners.ToType().GetFieldDefinitionLabel();
            var projectOtherPartners = projects.Where(x => !string.IsNullOrWhiteSpace(x.OtherPartners)).Select(x => new ProjectOrganizationRelationship(x, x.OtherPartners, otherPartnersLabel)).ToList();
            projectOrganizations.AddRange(projectOtherPartners);
            projectOrganizations = projectOrganizations.OrderBy(x => x.Project.ProjectID).ToList();
            var wsOrganizations = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}", organizationsSpec, projectOrganizations);
            workSheets.Add(wsOrganizations);

            var contactsSpec = new ProjectImplementingContactsExcelSpec();
            var projectContacts = projects.SelectMany(p => p.GetAssociatedContactRelationships()).ToList();
            var wsContacts = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Contacts", contactsSpec, projectContacts);
            workSheets.Add(wsContacts);

            var projectNoteSpec = new ProjectNoteExcelSpec();
            var projectNotes = (projects.SelectMany(p => p.ProjectNotes)).ToList();
            var wsProjectNotes = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinitionEnum.ProjectNote.ToType().GetFieldDefinitionLabelPluralized()}", projectNoteSpec, projectNotes);
            workSheets.Add(wsProjectNotes);

            var performanceMeasureExpectedExcelSpec = new PerformanceMeasureExpectedExcelSpec();
            var performanceMeasureExpecteds = (projects.SelectMany(p => p.PerformanceMeasureExpecteds)).ToList();
            var wsPerformanceMeasureExpecteds = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet(
                $"Expected {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}",
                performanceMeasureExpectedExcelSpec,
                performanceMeasureExpecteds);
            workSheets.Add(wsPerformanceMeasureExpecteds);

            var performanceMeasureActualExcelSpec = new PerformanceMeasureActualExcelSpec();
            var performanceMeasureActuals = (projects.SelectMany(p => p.GetPerformanceMeasureReportedValues())).ToList();
            var wsPerformanceMeasureActuals = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet(
                $"Reported {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}", performanceMeasureActualExcelSpec, performanceMeasureActuals);
            workSheets.Add(wsPerformanceMeasureActuals);

            if (MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                var budgetType = MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType;
                var reportFinancialsByCostType = budgetType == BudgetType.AnnualBudgetByCostType;
                var fundingSourceCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.ToList();

                var projectFundingSourceExpenditureSpec = new ProjectFundingSourceExpenditureExcelSpec(fundingSourceCustomAttributeTypes, reportFinancialsByCostType);
                var projectFundingSourceExpenditures = (projects.SelectMany(p => p.ProjectFundingSourceExpenditures)).ToList();
                var wsProjectFundingSourceExpenditures = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabelPluralized()}", projectFundingSourceExpenditureSpec, projectFundingSourceExpenditures);
                workSheets.Add(wsProjectFundingSourceExpenditures);

                var projectFundingSourceBudgetExcelSpec = new ProjectFundingSourceBudgetExcelSpec(fundingSourceCustomAttributeTypes, reportFinancialsByCostType);
                var projectBudgetFinancialsForExcels = new List<ProjectBudgetFinancialsForExcel>();
                // add ProjectFundingSourceBudgets and ProjectNoFundingSourceIdentifieds for "varies by year" for Tenants that use Annual Budget by Cost Type or Annual Budget (current no tenants use this, but adding for future support)
                if (reportFinancialsByCostType || budgetType == BudgetType.AnnualBudget)
                {
                    projectBudgetFinancialsForExcels = projects.Where(p => p.FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID).SelectMany(p => p.ProjectFundingSourceBudgets.Select(y => new ProjectBudgetFinancialsForExcel(y, reportFinancialsByCostType, null))).ToList();
                    projectBudgetFinancialsForExcels.AddRange(projects.Where(p => p.FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID).SelectMany(p => p.ProjectNoFundingSourceIdentifieds.Select(y => new ProjectBudgetFinancialsForExcel(y, null))).ToList());
                }
                else
                {
                    // add ProjectFundingSourceBudgets and ProjectNoFundingSourceIdentifieds for "varies by year" for Tenants that use Simple Budget. Need to add one row per year of the project, because current CalendarYear not set for these ProjectFundingSourceBudgets
                    projectBudgetFinancialsForExcels.AddRange(projects.Where(p => p.FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID).SelectMany(p =>
                    {
                        var budgetFinancialsForExcels = new List<ProjectBudgetFinancialsForExcel>();
                        for (var i = p.ImplementationStartYear ?? DateTime.Now.Year; i <= (p.CompletionYear ?? DateTime.Now.Year); i++)
                        {
                            budgetFinancialsForExcels.AddRange(p.ProjectFundingSourceBudgets.Select(pfsb => new ProjectBudgetFinancialsForExcel(pfsb, reportFinancialsByCostType, i)).ToList());
                        }
                        return budgetFinancialsForExcels;
                    }).ToList());
                    projectBudgetFinancialsForExcels.AddRange(projects.Where(p => p.FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID).SelectMany(p => p.ProjectNoFundingSourceIdentifieds.SelectMany(y =>
                    {
                        var budgetFinancialsForExcels = new List<ProjectBudgetFinancialsForExcel>();
                        for (var i = p.ImplementationStartYear ?? DateTime.Now.Year; i <= (p.CompletionYear ?? DateTime.Now.Year); i++)
                        {
                            budgetFinancialsForExcels.Add(new ProjectBudgetFinancialsForExcel(y, i));
                        }
                        return budgetFinancialsForExcels;
                    })).ToList());
                }
                // add ProjectFundingSourceBudgets for "same each year"
                projectBudgetFinancialsForExcels.AddRange(projects.Where(p => p.FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID).SelectMany(p =>
                {
                    var budgetFinancialsForExcels = new List<ProjectBudgetFinancialsForExcel>();
                    for (var i = p.ImplementationStartYear ?? DateTime.Now.Year; i <= (p.CompletionYear ?? DateTime.Now.Year); i++)
                    {
                        budgetFinancialsForExcels.AddRange(p.ProjectFundingSourceBudgets.Select(pfsb => new ProjectBudgetFinancialsForExcel(pfsb, reportFinancialsByCostType, i)).ToList());
                    }
                    return budgetFinancialsForExcels;
                }).ToList());
                // add no funding source identified for "same each year"
                projectBudgetFinancialsForExcels.AddRange(projects.Where(p => p.FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID).SelectMany(p => p.ProjectNoFundingSourceIdentifieds.SelectMany(y =>
                {
                    var budgetFinancialsForExcels = new List<ProjectBudgetFinancialsForExcel>();
                    for (var i = p.ImplementationStartYear ?? DateTime.Now.Year; i <= (p.CompletionYear ?? DateTime.Now.Year); i++)
                    {
                        budgetFinancialsForExcels.Add(new ProjectBudgetFinancialsForExcel(y, i));
                    }
                    return budgetFinancialsForExcels;
                })).ToList());
                projectBudgetFinancialsForExcels = projectBudgetFinancialsForExcels.OrderBy(x => x.Project.ProjectID)
                    .ThenBy(x => x.FundingSource).ThenBy(x => x.CalendarYear).ToList();
                var wsProjectFundingSourceBudgets = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Budgets", projectFundingSourceBudgetExcelSpec, projectBudgetFinancialsForExcels);
                workSheets.Add(wsProjectFundingSourceBudgets);
            }

            var projectGeospatialAreaSpec = new ProjectGeospatialAreaExcelSpec();
            var projectGeospatialAreas = projects.SelectMany(p => p.ProjectGeospatialAreas).ToList();
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                var wsProjectGeospatialAreas = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {geospatialAreaType.GeospatialAreaTypeNamePluralized}", projectGeospatialAreaSpec, projectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList());
                workSheets.Add(wsProjectGeospatialAreas);
            }

            MultiTenantHelpers.GetClassificationSystems().ForEach(c =>
            {
                var projectClassificationSpec = new ProjectClassificationExcelSpec();
                var projectClassifications = projects.SelectMany(p => p.ProjectClassifications).Where(x => x.Classification.ClassificationSystem == c).ToList();
                var wsProjectClassifications = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet(
                    ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(c), projectClassificationSpec, projectClassifications);
                workSheets.Add(wsProjectClassifications);
            });

            var wbm = new ExcelWorkbookMaker(workSheets);
            var excelWorkbook = wbm.ToXLWorkbook();

            return new ExcelResult(excelWorkbook, workbookTitle);
        }

        [HttpGet]
        [ProjectDeleteFeature]
        public PartialViewResult DeleteProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(projectPrimaryKey.PrimaryKeyValue);
            return ViewDeleteProject(projectPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteProject(Project project, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{project.GetDisplayName()}'?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProject(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProject(project, viewModel);
            }

            var message = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.GetDisplayName()}\" successfully deleted.";
            project.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            _logger.Info($"Project {project.ProjectID} - {project.GetDisplayName()} deleted by {CurrentFirmaSession.Person.GetPersonInformationStringForLogging()}: {message}");
            return new ModalDialogFormJsonResult();
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<AuditLog> AuditLogsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var gridSpec = new AuditLogsGridSpec(CurrentFirmaSession);
            var auditLogs = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProject(projectPrimaryKey.EntityObject).OrderByDescending(x => x.AuditLogDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AuditLog>(auditLogs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult Search(string searchCriteria)
        {
            if (string.IsNullOrWhiteSpace(searchCriteria))
            {
                searchCriteria = String.Empty;
            }
            var projectsFound = GetViewableProjectsFromSearchCriteria(searchCriteria);
            return SearchImpl(searchCriteria, projectsFound);
        }

        private List<Project> GetViewableProjectsFromSearchCriteria(string searchCriteria)
        {
            var projectIDsFound = HttpRequestStorage.DatabaseEntities.Projects.GetProjectFindResultsForProjectNameAndDescriptionAndNumber(searchCriteria).Select(x => x.ProjectID);
            var projectsFound =
                HttpRequestStorage.DatabaseEntities.Projects.Where(x => projectIDsFound.Contains(x.ProjectID))
                    .ToList().GetActiveProjectsAndProposals(CurrentFirmaSession.CanViewProposals(), CurrentFirmaSession);
            return projectsFound;
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult SearchImpl(string searchCriteria, List<Project> projectsFound)
        {
            if (projectsFound.Count == 1)
            {
                return RedirectToAction(new SitkaRoute<ProjectController>(x => x.Detail(projectsFound.Single())));
            }

            var viewData = new SearchResultsViewData(CurrentFirmaSession, projectsFound, searchCriteria);
            return RazorView<SearchResults, SearchResultsViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public JsonResult Find(string term)
        {
            // Assuming for now that a null search is really a search for everything, but that
            // may not be a good assumption. -- SLG
            if (term == null)
            {
                term = string.Empty;
            }
            var projectFindResults = GetViewableProjectsFromSearchCriteria(term.Trim());
            var results = projectFindResults.Take(ProjectsCountLimit).Select(p => new ListItem(p.GetDisplayName().ToEllipsifiedString(100), p.GetDetailUrl())).ToList();
            if (projectFindResults.Count > ProjectsCountLimit)
            {
                results.Add(
                    new ListItem(
                        $"<span style='font-weight:bold'>Displaying {ProjectsCountLimit} of {projectFindResults.Count}</span><span style='color:blue; margin-left:8px'>See All Results</span>",
                        SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Search(term))));
            }
            return Json(results.Select(pfr => new {label = pfr.Text, value = pfr.Value}), JsonRequestBehavior.AllowGet);
        }

        private const int ProjectsCountLimit = 20;

        [ProjectManageFeaturedFeature]
        public ViewResult FeaturedList()
        {
            var firmaPage = FirmaPageTypeEnum.FeaturedProjectList.GetFirmaPage();
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var viewData = new FeaturedListViewData(CurrentFirmaSession, firmaPage, projectCustomDefaultGridConfigurations);
            return RazorView<FeaturedList, FeaturedListViewData>(viewData);
        }

        [HttpGet]
        [ProjectManageFeaturedFeature]
        public PartialViewResult EditFeaturedProjects()
        {
            var featuredProjectIDs = HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.IsFeatured).ToList().GetActiveProjects().Select(x => x.ProjectID).ToList();
            var viewModel = new EditFeaturedProjectsViewModel(featuredProjectIDs);
            return ViewEditFeaturedProjects(viewModel);
        }

        [HttpPost]
        [ProjectManageFeaturedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditFeaturedProjects(EditFeaturedProjectsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditFeaturedProjects(viewModel);
            }
            var currentFeaturedProjects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.IsFeatured).ToList();
            currentFeaturedProjects.ForEach(x => x.IsFeatured = false);
            if (viewModel.ProjectIDList != null)
            {
                var newlyFeaturedProjects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
                newlyFeaturedProjects.ForEach(proj =>
                {
                    proj.IsFeatured = true;
                    _logger.Info($"Making {proj.ProjectID} - {proj.GetDisplayName()} Featured - done by user {CurrentFirmaSession.Person.GetPersonInformationStringForLogging()}");
                });
                
            }
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditFeaturedProjects(EditFeaturedProjectsViewModel viewModel)
        {
            var allProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Select(x => new ProjectSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var viewData = new EditFeaturedProjectsViewData(allProjects);
            return RazorPartialView<EditFeaturedProjects, EditFeaturedProjectsViewData, EditFeaturedProjectsViewModel>(viewData, viewModel);
        }

        [ProjectsViewFullListFeature]
        public ViewResult FullProjectListSimple()
        {
            var firmaPage = FirmaPageTypeEnum.FullProjectListSimple.GetFirmaPage();
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects();
            var viewData = new FullProjectListSimpleViewData(CurrentFirmaSession, firmaPage, projects);
            return RazorView<FullProjectListSimple, FullProjectListSimpleViewData>(viewData);
        }

        private static string GenerateEditProjectLocationFormID(Project project)
        {
            return $"editMapForProject{project.ProjectID}";
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult ConfirmNonMandatoryUpdate(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel();
            
            var dateDisplayText = string.Empty;
            var latestUpdateSubmittalDate = project.GetLatestUpdateSubmittalDate();
            if (latestUpdateSubmittalDate.HasValue)
            {
                dateDisplayText =
                    $" on <span style='font-weight: bold'>{latestUpdateSubmittalDate.Value.ToShortDateString()}</span>";
            }

            var viewData = new ConfirmDialogFormViewData($@"
<div>
An update for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} was already submitted for this {
                    FieldDefinitionEnum.ReportingYear.ToType().GetFieldDefinitionLabel()
                } {dateDisplayText}. If {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} information has changed, 
any new information you'd like to provide will be added to the {
                    FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()
                }. Thanks for being proactive!
</div>
<div>
<hr />
Continue with a new {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update?
</div>");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult ConfirmNonMandatoryUpdate(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            return new ModalDialogFormJsonResult(project.GetProjectUpdateUrl());
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Notification> ProjectNotificationsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var gridSpec = new ProjectNotificationGridSpec(CurrentFirmaSession);
            var notifications = project.NotificationProjects.Select(x => x.Notification).OrderByDescending(x => x.NotificationDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Notification>(notifications, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ProjectUpdateBatch> ProjectUpdateBatchGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var gridSpec = new ProjectUpdateBatchGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectUpdateBatch>(project.ProjectUpdateBatches.OrderBy(x => x.LastUpdateDate).ToList(), gridSpec);
            return gridJsonNetJObjectResult;
        }

        public static Dictionary<int, GooglePieChartSlice> GetSlicesForGoogleChart(Dictionary<string, decimal> fundingSourceExpenditures)
        {
            var indexMapping = GetConsistentFundingSourceExpendituresIndexDictionary(fundingSourceExpenditures);
            return fundingSourceExpenditures.Select(fund => indexMapping[fund.Key]).ToDictionary(index => index, index => new GooglePieChartSlice {Color = FirmaHelpers.DefaultColorRange[index]});
        }

        public static Dictionary<string, int> GetConsistentFundingSourceExpendituresIndexDictionary(Dictionary<string,decimal> fundingSourceExpenditures)
        {
            var results = new Dictionary<string, int>();
            var index = 0;
            foreach (var fund in fundingSourceExpenditures)
            {
                results.Add(fund.Key, index);
                index++;
            }
            return results;
        }

        public static GoogleChartDataTable GetProjectFactSheetGoogleChartDataTable(List<GooglePieChartSlice> fundingSourceExpenditures)
        {
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn($"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}", GoogleChartColumnDataType.String, GoogleChartType.PieChart), new GoogleChartColumn("Expenditures", GoogleChartColumnDataType.Number, GoogleChartType.PieChart) };
            var chartRowCs = fundingSourceExpenditures.Select(x =>
            {
                var organizationTypeRowV = new GoogleChartRowV(x.Label);
                var formattedValue = GoogleChartJson.GetFormattedValue(x.Value, MeasurementUnitType.Dollars);
                var expenditureRowV = new GoogleChartRowV(x.Value, formattedValue);
                return new GoogleChartRowC(new List<GoogleChartRowV> { organizationTypeRowV, expenditureRowV });
            });
            var googleChartRowCs = new List<GoogleChartRowC>(chartRowCs);

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ViewResult MyOrganizationsProjects()
        {
            var firmaPage = FirmaPageTypeEnum.MyOrganizationsProjects.GetFirmaPage();
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();

            var viewData = new MyOrganizationsProjectsViewData(CurrentFirmaSession, firmaPage, projectCustomDefaultGridConfigurations);
            return RazorView<MyOrganizationsProjects, MyOrganizationsProjectsViewData>(viewData);
        }

        [ProjectsInProposalStageViewListFeature]
        public GridJsonNetJObjectResult<Project> MyOrganizationsProposalsGridJsonData()
        {
            var gridSpec = new ProposalsGridSpec(CurrentFirmaSession);

            var proposals = HttpRequestStorage.DatabaseEntities.Projects.ToList()
                .GetProposalsVisibleToUser(CurrentFirmaSession)
                .Where(x => x.ProposingPerson.OrganizationID == CurrentPerson.OrganizationID)
                .ToList();

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(proposals, gridSpec);
            return gridJsonNetJObjectResult;
        }
        
        [ProjectsViewFullListFeature]
        public PartialViewResult DenyCreateProject()
        {
            var projectStewardLabel = FieldDefinitionEnum.ProjectSteward.ToType().GetFieldDefinitionLabel();
            var projectLabel = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            var organizationLabel = FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel();
            var projectRelationshipTypeLabel = FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel();

            var confirmMessage = CurrentPerson.RoleID == Role.ProjectSteward.RoleID
                ? $"Although you are a {projectStewardLabel}, you do not have the ability to create a {projectLabel} because your {organizationLabel} does not have a \"Can Steward {projectLabel}\" {projectRelationshipTypeLabel}."
                : $"You don't have permission to edit {projectLabel}.";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, false);
            var viewModel = new ConfirmDialogFormViewModel();
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }
        
        [ProjectCreateNewFeature]
        public PartialViewResult ProjectStewardCannotEdit()
        {
            var projectStewardLabel = FieldDefinitionEnum.ProjectSteward.ToType().GetFieldDefinitionLabel();
            var projectLabel = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            var organizationLabel = FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel();

            var confirmMessage = CurrentPerson.RoleID == Role.ProjectSteward.RoleID
                ? $"Although you are a {projectStewardLabel}, you do not have permission to edit this {projectLabel} because it does not belong to your {organizationLabel}."
                : $"You don't have permission to edit this {projectLabel}.";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, false);
            var viewModel = new ConfirmDialogFormViewModel();
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }
        
        [ProjectCreateNewFeature]
        public PartialViewResult ProjectStewardCannotEditPendingApproval(ProjectPrimaryKey projectPrimaryKey)
        {
            var projectCreateUrl =
                SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(projectPrimaryKey));
            var projectStewardLabel = FieldDefinitionEnum.ProjectSteward.ToType().GetFieldDefinitionLabel();
            var proposalLabel = FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabel();

            var confirmMessage = CurrentPerson.RoleID == Role.ProjectSteward.RoleID
                ? $"Although you are a {projectStewardLabel}, you do not have permission to edit this {proposalLabel} through this page because it is pending approval. You can <a href='{projectCreateUrl}'>review, edit, or approve</a> the {proposalLabel}."
                : $"You don't have permission to edit this {proposalLabel}.";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, false);
            var viewModel = new ConfirmDialogFormViewModel();
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult RevertProjectToPendingApproval(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel();

            var viewData = new ConfirmDialogFormViewData($@"
<div>
Are you sure you want to revert this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}, {project.GetDisplayName()}, to a Draft?
</div>");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult RevertProjectToPendingApproval(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            Check.Assert(project.ProjectApprovalStatus == ProjectApprovalStatus.Approved,
                $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is not in Approved state and cannot be returned to a Draft. Actual state is: " + project.ProjectApprovalStatus.ProjectApprovalStatusDisplayName);

            project.ProjectApprovalStatusID = ProjectApprovalStatus.Draft.ProjectApprovalStatusID;
            project.ApprovalDate = null;
            project.ReviewedByPersonID = null;

            var auditLog = new AuditLog(CurrentPerson, DateTime.Now, AuditLogEventType.Added, "Project", project.ProjectID, "ProjectID", project.ProjectID.ToString(), true)
            {
                ProjectID = project.ProjectID,
                AuditDescription = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()} reverted from Approved to Draft."
            };

            HttpRequestStorage.DatabaseEntities.AllAuditLogs.Add(auditLog);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{UrlTemplate.MakeHrefString(project.GetDetailUrl(), project.GetDisplayName())}\" successfully reverted to Pending Approval.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }
    }
}
