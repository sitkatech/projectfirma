/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.ScheduledJobs;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.ProjectExternalLink;
//using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectContact;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Views.ProjectUpdate;
using Basics = ProjectFirma.Web.Views.ProjectUpdate.Basics;
using BasicsViewData = ProjectFirma.Web.Views.ProjectUpdate.BasicsViewData;
using BasicsViewModel = ProjectFirma.Web.Views.ProjectUpdate.BasicsViewModel;
using ExpectedFunding = ProjectFirma.Web.Views.ProjectUpdate.ExpectedFunding;
using ExpectedFundingViewData = ProjectFirma.Web.Views.ProjectUpdate.ExpectedFundingViewData;
using ExpectedFundingViewModel = ProjectFirma.Web.Views.ProjectUpdate.ExpectedFundingViewModel;
using Expenditures = ProjectFirma.Web.Views.ProjectUpdate.Expenditures;
using ExpendituresViewData = ProjectFirma.Web.Views.ProjectUpdate.ExpendituresViewData;
using ExpendituresViewModel = ProjectFirma.Web.Views.ProjectUpdate.ExpendituresViewModel;
using GeospatialArea = ProjectFirmaModels.Models.GeospatialArea;
using GeospatialAreaViewData = ProjectFirma.Web.Views.ProjectUpdate.GeospatialAreaViewData;
using GeospatialAreaViewModel = ProjectFirma.Web.Views.ProjectUpdate.GeospatialAreaViewModel;
using LocationDetailed = ProjectFirma.Web.Views.ProjectUpdate.LocationDetailed;
using LocationDetailedViewData = ProjectFirma.Web.Views.ProjectUpdate.LocationDetailedViewData;
using LocationDetailedViewModel = ProjectFirma.Web.Views.ProjectUpdate.LocationDetailedViewModel;
using LocationSimple = ProjectFirma.Web.Views.ProjectUpdate.LocationSimple;
using LocationSimpleViewData = ProjectFirma.Web.Views.ProjectUpdate.LocationSimpleViewData;
using LocationSimpleViewModel = ProjectFirma.Web.Views.ProjectUpdate.LocationSimpleViewModel;
using Photos = ProjectFirma.Web.Views.ProjectUpdate.Photos;
using ReportedPerformanceMeasures = ProjectFirma.Web.Views.ProjectUpdate.ReportedPerformanceMeasures;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectUpdateController : FirmaBaseController
    {
        public const string ProjectUpdateBatchDiffLogPartialViewPath = "~/Views/ProjectUpdate/ProjectUpdateBatchDiffLog.cshtml";
        public const string ProjectBasicsPartialViewPath = "~/Views/Shared/ProjectControls/ProjectBasics.cshtml";
        public const string PerformanceMeasureReportedValuesPartialViewPath = "~/Views/Shared/PerformanceMeasureControls/PerformanceMeasureReportedValuesSummary.cshtml";
        public const string ProjectExpendituresPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectExpendituresSummary.cshtml";
        public const string ProjectBudgetPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectBudgetsDetail.cshtml";
        public const string ProjectBudgetByCostTypePartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectBudgetsByCostTypeSummary.cshtml";
        public const string ImageGalleryPartialViewPath = "~/Views/Shared/ImageGallery.cshtml";
        public const string ExternalLinksPartialViewPath = "~/Views/Shared/TextControls/EntityExternalLinks.cshtml";
        public const string EntityNotesPartialViewPath = "~/Views/Shared/TextControls/EntityNotes.cshtml";
        public const string ProjectOrganizationsPartialViewPath = "~/Views/Shared/ProjectOrganization/ProjectOrganizationsDetail.cshtml";
        public const string ProjectContactsPartialViewPath = "~/Views/Shared/ProjectContact/ProjectContactsDetail.cshtml";
        public const string PerformanceMeasureExpectedSummaryPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/PerformanceMeasureExpectedValuesSummary.cshtml";
        public const string ProjectExpendituresByCostTypeSummaryPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectExpendituresByCostTypeSummary.cshtml";

        //public const string ProjectDocumentsPartialViewPath = "~/Views/Shared/ProjectDocument/ProjectDocumentsDetail.cshtml";

        private static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(Project project)
        {
            return GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project,
                $"We should have a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update batch when refreshing; didn't find one for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
        }

        private static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(Project project, string message)
        {
            var projectUpdateBatch = ProjectModelExtensions.GetLatestNotApprovedUpdateBatch(project);
            Check.RequireNotNull(projectUpdateBatch, message);
            return projectUpdateBatch;
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ViewResult AllMyProjects()
        {
            const ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum filterTypeEnum = ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllMyProjects;
            var gridDataUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(filterTypeEnum));
            return ViewIndex(gridDataUrl, filterTypeEnum);
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ViewResult MySubmittedProjects()
        {
            const ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum filterTypeEnum = ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects;
            var gridDataUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(filterTypeEnum));
            return ViewIndex(gridDataUrl, filterTypeEnum);
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ViewResult MyProjectsRequiringAnUpdate()
        {
            const ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum filterTypeEnum = ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MyProjectsRequiringAnUpdate;
            var gridDataUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(filterTypeEnum));
            return ViewIndex(gridDataUrl, filterTypeEnum);
        }

        [ProjectUpdateAdminFeature]
        public ViewResult AllProjects()
        {
            const ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum filterTypeEnum = ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects;
            var gridDataUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(filterTypeEnum));
            return ViewIndex(gridDataUrl, filterTypeEnum);
        }

        [ProjectUpdateAdminFeature]
        public ViewResult SubmittedProjects()
        {
            const ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum filterTypeEnum = ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.SubmittedProjects;
            var gridDataUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(filterTypeEnum));
            return ViewIndex(gridDataUrl, filterTypeEnum);
        }

        private ViewResult ViewIndex(string gridDataUrl, ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterTypeEnum)
        {
            var firmaPage = FirmaPageTypeEnum.MyProjects.GetFirmaPage();
            var viewData = new MyProjectsViewData(CurrentPerson, firmaPage, projectUpdateStatusFilterTypeEnum, gridDataUrl);
            return RazorView<MyProjects, MyProjectsViewData>(viewData);
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<Project> IndexGridJsonData(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterType)
        {
            var gridSpec = new ProjectUpdateStatusGridSpec(projectUpdateStatusFilterType, CurrentPerson.IsApprover());
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(p => p.IsUpdatableViaProjectUpdateProcess());

            switch (projectUpdateStatusFilterType)
            {
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllMyProjects:
                    projects = projects.Where(p => p.IsMyProject(CurrentPerson));
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MyProjectsRequiringAnUpdate:
                    projects = projects.Where(p => p.IsMyProject(CurrentPerson) && p.IsUpdateMandatory() && p.GetLatestUpdateState() != ProjectUpdateState.Submitted);
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects:
                    projects = projects.Where(p => p.IsMyProject(CurrentPerson) && (!p.IsUpdateMandatory() || p.GetLatestUpdateState() == ProjectUpdateState.Submitted));
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.SubmittedProjects:
                    projects = projects.Where(p =>
                    {
                        var latestUpdateState = p.GetLatestUpdateState();
                        return latestUpdateState != null && latestUpdateState == ProjectUpdateState.Submitted;
                    });
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects:
                    break;
            }
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects.OrderBy(x => x.GetDisplayName()).ToList(), gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [ProjectUpdateAdminFeature]
        public PartialViewResult EditProjectUpdateConfiguration()
        {
            EditProjectUpdateConfigurationViewModel viewModel = new EditProjectUpdateConfigurationViewModel(MultiTenantHelpers.GetProjectUpdateConfiguration());
            return ViewEditProjectUpdateConfiguration(viewModel);
        }

        private PartialViewResult ViewEditProjectUpdateConfiguration(EditProjectUpdateConfigurationViewModel viewModel)
        {
            var viewData = new EditProjectUpdateConfigurationViewData(CurrentPerson);
            return RazorPartialView<EditProjectUpdateConfiguration, EditProjectUpdateConfigurationViewData, EditProjectUpdateConfigurationViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectUpdateAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectUpdateConfiguration(EditProjectUpdateConfigurationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditProjectUpdateConfiguration(viewModel);
            }

            viewModel.UpdateModel(MultiTenantHelpers.GetProjectUpdateConfiguration());
            SetMessageForDisplay("Notifications configured successfully.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ViewResult Instructions(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatchModelExtensions.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var firmaPage = FirmaPageTypeEnum.ProjectUpdateInstructions.GetFirmaPage();
            var viewData = new InstructionsViewData(CurrentPerson, projectUpdateBatch, updateStatus, firmaPage);
            return RazorView<Instructions, InstructionsViewData>(viewData);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        public RedirectResult Instructions(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            ProjectUpdateBatchModelExtensions.GetLatestNotApprovedProjectUpdateBatchOrCreateNewAndSaveToDatabase(project, CurrentPerson);
            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Basics(project)));
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult Basics(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            var viewModel = new BasicsViewModel(projectUpdate, projectUpdateBatch.BasicsComment);
            return ViewBasics(projectUpdate, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Basics(ProjectPrimaryKey projectPrimaryKey, BasicsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            if (!ModelState.IsValid)
            {
                return ViewBasics(projectUpdate, viewModel);
            }
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdate.ProjectUpdateID))
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdates.Add(projectUpdate);
            }
            viewModel.UpdateModel(projectUpdate, CurrentPerson);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.BasicsComment = viewModel.Comments;
            }
            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Basics.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewBasics(ProjectUpdate projectUpdate, BasicsViewModel viewModel)
        {
            var basicsValidationResult = projectUpdate.ProjectUpdateBatch.ValidateProjectBasics();
            var updateStatus = GetUpdateStatus(projectUpdate.ProjectUpdateBatch); // note, the way the diff for the basics section is built, it will actually "commit" the updated values to the project, so it needs to be done last, or we need to change the current approach

            var projectStages = projectUpdate.ProjectUpdateBatch.Project.ProjectStage.GetProjectStagesThatProjectCanUpdateTo();
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().Where(x => x.HasEditPermission(CurrentPerson)).ToList();
            var projectCustomAttributeTypesViewData = new DisplayProjectCustomAttributesViewData(
                projectCustomAttributeTypes,
                new List<IProjectCustomAttribute>(projectUpdate.ProjectUpdateBatch.ProjectCustomAttributeUpdates.ToList()));

            var viewData = new BasicsViewData(CurrentPerson, projectUpdate, projectStages, updateStatus, basicsValidationResult, projectCustomAttributeTypes, projectCustomAttributeTypesViewData);
            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshBasics(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshBasics(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshBasics(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            if (projectUpdate != null)
            {
                projectUpdate.LoadUpdateFromProject(project);
                projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            }
            if (!projectUpdateBatch.AreAccomplishmentsRelevant())
            {
                projectUpdateBatch.DeletePerformanceMeasuresProjectExemptReportingYearUpdates();
                projectUpdateBatch.DeletePerformanceMeasureActualUpdates();
            }
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshBasics(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} basics data? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult ReportedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var performanceMeasureActualUpdateSimples =
                projectUpdateBatch.PerformanceMeasureActualUpdates.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(pam=>pam.PerformanceMeasure.GetDisplayName())
                    .ThenByDescending(x => x.CalendarYear)
                    .Select(x => new PerformanceMeasureActualUpdateSimple(x))
                    .ToList();
            var projectExemptReportingYearUpdates = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => new ProjectExemptReportingYearUpdateSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList();
            var possibleYearsToExempt = projectUpdateBatch.ProjectUpdate.GetProjectUpdateImplementationStartToCompletionYearRange();
            projectExemptReportingYearUpdates.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x))
                    .Select((x, index) => new ProjectExemptReportingYearUpdateSimple(-(index + 1), projectUpdateBatch.ProjectUpdateBatchID, x)));

            var viewModel = new ReportedPerformanceMeasuresViewModel(performanceMeasureActualUpdateSimples,
                projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation,
                projectExemptReportingYearUpdates.OrderBy(x => x.CalendarYear).ToList(),
                projectUpdateBatch.ReportedPerformanceMeasuresComment);
            return ViewReportedPerformanceMeasures(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ReportedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, ReportedPerformanceMeasuresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewReportedPerformanceMeasures(projectUpdateBatch, viewModel);
            }
            var currentPerformanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualUpdates.Load();
            var allPerformanceMeasureActualUpdates = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualUpdates.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptionUpdates.Load();
            var allPerformanceMeasureActualSubcategoryOptionUpdates = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptionUpdates.Local;
            viewModel.UpdateModel(currentPerformanceMeasureActualUpdates, allPerformanceMeasureActualUpdates, allPerformanceMeasureActualSubcategoryOptionUpdates, projectUpdateBatch);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.ReportedPerformanceMeasuresComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.ReportedAccomplishments.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewReportedPerformanceMeasures(ProjectUpdateBatch projectUpdateBatch, ReportedPerformanceMeasuresViewModel viewModel)
        {
            var performanceMeasures =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var showExemptYears = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Any() ||
                                  ModelState.Values.SelectMany(x => x.Errors)
                                      .Any(
                                          x =>
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears ||
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears);

            var performanceMeasureSubcategories = performanceMeasures.SelectMany(x => x.PerformanceMeasureSubcategories).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureSubcategory>()).ToList();
            var performanceMeasureSimples = performanceMeasures.Select(x => new PerformanceMeasureSimple(x)).ToList();
            var performanceMeasureSubcategorySimples = performanceMeasureSubcategories.Select(y => new PerformanceMeasureSubcategorySimple(y)).ToList();

            var performanceMeasureSubcategoryOptionSimples = performanceMeasureSubcategories.SelectMany(y => y.PerformanceMeasureSubcategoryOptions.Select(z => new PerformanceMeasureSubcategoryOptionSimple(z))).ToList();
            
            var calendarYearStrings = FirmaDateUtilities.ReportingYearsForUserInput().OrderByDescending(x => x.CalendarYear).ToList();
            var performanceMeasuresValidationResult = projectUpdateBatch.ValidatePerformanceMeasures();

            var viewDataForAngularEditor = new ReportedPerformanceMeasuresViewData.ViewDataForAngularEditor(projectUpdateBatch.ProjectUpdateBatchID,
                performanceMeasureSimples,
                performanceMeasureSubcategorySimples,
                performanceMeasureSubcategoryOptionSimples,
                calendarYearStrings,
                showExemptYears);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new ReportedPerformanceMeasuresViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, updateStatus, performanceMeasuresValidationResult);
            return RazorView<ReportedPerformanceMeasures, ReportedPerformanceMeasuresViewData, ReportedPerformanceMeasuresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshReportedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshReportedPerformanceMeasures(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshReportedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeletePerformanceMeasuresProjectExemptReportingYearUpdates();
            projectUpdateBatch.DeletePerformanceMeasureActualUpdates();

            // refresh the data
            projectUpdateBatch.SyncPerformanceMeasureActualYearsExemptionExplanation();
            ProjectExemptReportingYearUpdateModelExtensions.CreatePerformanceMeasuresExemptReportingYearsFromProject(projectUpdateBatch);
            PerformanceMeasureActualUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshReportedPerformanceMeasures(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and use the updated start and completion years from the Basics section. Any changes made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult ExpectedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var performanceMeasureExpectedUpdateSimples =
                projectUpdateBatch.PerformanceMeasureExpectedUpdates.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(pam=>pam.PerformanceMeasure.GetDisplayName())
                    .Select(x => new PerformanceMeasureExpectedSimple(x))
                    .ToList();
            var projectExemptReportingYearUpdates = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => new ProjectExemptReportingYearUpdateSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList();
            var possibleYearsToExempt = projectUpdateBatch.ProjectUpdate.GetProjectUpdateImplementationStartToCompletionYearRange();
            projectExemptReportingYearUpdates.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x))
                    .Select((x, index) => new ProjectExemptReportingYearUpdateSimple(-(index + 1), projectUpdateBatch.ProjectUpdateBatchID, x)));

            var viewModel = new ExpectedPerformanceMeasuresViewModel(performanceMeasureExpectedUpdateSimples, projectUpdateBatch.ExpectedPerformanceMeasuresComment);
            return ViewExpectedPerformanceMeasures(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpectedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, ExpectedPerformanceMeasuresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewExpectedPerformanceMeasures(projectUpdateBatch, viewModel);
            }
            var currentPerformanceMeasureExpectedUpdates = projectUpdateBatch.PerformanceMeasureExpectedUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedUpdates.Load();
            var allPerformanceMeasureExpectedUpdates = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedUpdates.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptionUpdates.Load();
            var allPerformanceMeasureExpectedSubcategoryOptionUpdates = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptionUpdates.Local;
            viewModel.UpdateModel(currentPerformanceMeasureExpectedUpdates, allPerformanceMeasureExpectedUpdates, allPerformanceMeasureExpectedSubcategoryOptionUpdates, projectUpdateBatch);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.ExpectedPerformanceMeasuresComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.ExpectedAccomplishments.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewExpectedPerformanceMeasures(ProjectUpdateBatch projectUpdateBatch, ExpectedPerformanceMeasuresViewModel viewModel)
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var performanceMeasureSubcategories = performanceMeasures.SelectMany(x => x.PerformanceMeasureSubcategories).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureSubcategory>()).ToList();
            var performanceMeasureSimples = performanceMeasures.Select(x => new PerformanceMeasureSimple(x)).ToList();
            var performanceMeasureSubcategorySimples = performanceMeasureSubcategories.Select(y => new PerformanceMeasureSubcategorySimple(y)).ToList();
            var performanceMeasureSubcategoryOptionSimples = performanceMeasureSubcategories.SelectMany(y => y.PerformanceMeasureSubcategoryOptions.Select(z => new PerformanceMeasureSubcategoryOptionSimple(z))).ToList();
            
            var viewDataForAngularEditor = new ExpectedPerformanceMeasuresViewData.ViewDataForAngularEditor(performanceMeasureSimples, performanceMeasureSubcategorySimples, performanceMeasureSubcategoryOptionSimples);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);

            var performanceMeasureSubcategoriesExpectedValues =
                PerformanceMeasureSubcategoriesExpectedValue.CreateFromPerformanceMeasures(new List<IPerformanceMeasureValue>(projectUpdateBatch.PerformanceMeasureExpectedUpdates));
            var performanceMeasureExpectedValuesSummaryViewData = new PerformanceMeasureExpectedValuesSummaryViewData(performanceMeasureSubcategoriesExpectedValues);

            var viewData = new ExpectedPerformanceMeasuresViewData(CurrentPerson, projectUpdateBatch, updateStatus, viewDataForAngularEditor, performanceMeasureExpectedValuesSummaryViewData);
            return RazorView<ExpectedPerformanceMeasures, ExpectedPerformanceMeasuresViewData, ExpectedPerformanceMeasuresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshExpectedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshPerformanceMeasures(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshExpectedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeletePerformanceMeasureExpectedUpdates();

            // refresh the data
            PerformanceMeasureExpectedUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshPerformanceMeasures(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the expected {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. Any changes made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult Expenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var projectFundingSourceExpenditureUpdates = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var calendarYearRange = projectFundingSourceExpenditureUpdates.CalculateCalendarYearRangeForExpenditures(projectUpdateBatch.ProjectUpdate);
            var projectExemptReportingYears = projectUpdateBatch.GetExpendituresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            projectExemptReportingYears.AddRange(
                calendarYearRange.Where(x => !currentExemptedYears.Contains(x))
                    .Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), projectUpdateBatch.ProjectUpdateBatchID, x)));

            var viewModel = new ExpendituresViewModel(projectUpdateBatch, calendarYearRange, projectExemptReportingYears);
            return ViewExpenditures(projectUpdateBatch, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Expenditures(ProjectPrimaryKey projectPrimaryKey, ExpendituresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var projectFundingSourceExpenditureUpdates = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var calendarYearRange = projectFundingSourceExpenditureUpdates.CalculateCalendarYearRangeForExpenditures(projectUpdateBatch.ProjectUpdate);
            if (!ModelState.IsValid)
            {
                return ViewExpenditures(projectUpdateBatch, calendarYearRange, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureUpdates.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditureUpdates.Local;
            viewModel.UpdateModel(projectUpdateBatch, projectFundingSourceExpenditureUpdates, allProjectFundingSourceExpenditures);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.ExpendituresComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Expenditures.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewExpenditures(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearRange, ExpendituresViewModel viewModel)
        {
            var project = projectUpdateBatch.Project;
            var projectExemptReportingYearUpdates = projectUpdateBatch.GetExpendituresExemptReportingYears();
            var showNoExpendituresExplanation = projectExemptReportingYearUpdates.Any();
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var expendituresValidationResult = projectUpdateBatch.ValidateExpenditures();

            var viewDataForAngularEditor = new ExpendituresViewData.ViewDataForAngularClass(project, allFundingSources, calendarYearRange, showNoExpendituresExplanation);
            var projectFundingSourceExpenditures = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var fromFundingSourcesAndCalendarYears = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(
                new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures),
                calendarYearRange);
            var projectExpendituresSummaryViewData = new ProjectExpendituresDetailViewData(
                fromFundingSourcesAndCalendarYears, calendarYearRange.Select(x => new CalendarYearString(x)).ToList(),
                FirmaHelpers.CalculateYearRanges(projectExemptReportingYearUpdates.Select(x => x.CalendarYear)),
                projectUpdateBatch.NoExpendituresToReportExplanation);

            var viewData = new ExpendituresViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectExpendituresSummaryViewData, GetUpdateStatus(projectUpdateBatch), expendituresValidationResult);
            return RazorView<Expenditures, ExpendituresViewData, ExpendituresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshExpenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshExpenditures(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshExpenditures(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteExpendituresProjectExemptReportingYearUpdates();
            projectUpdateBatch.DeleteExpendituresProjectRelevantCostTypeUpdates();
            projectUpdateBatch.DeleteProjectFundingSourceExpenditureUpdates();

            // refresh the data
            projectUpdateBatch.SyncExpendituresYearsExemptionExplanation();
            ProjectExemptReportingYearUpdateModelExtensions.CreateExpendituresExemptReportingYearsFromProject(projectUpdateBatch);
            ProjectRelevantCostTypeUpdateModelExtensions.CreateExpendituresRelevantCostTypesFromProject(projectUpdateBatch);
            ProjectFundingSourceExpenditureUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshExpenditures(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the expenditures for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and use the updated start and completion years from the Basics section. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult ExpendituresByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var calendarYearRange = projectUpdateBatch.ProjectUpdate.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
            var costTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList();
            var projectRelevantCostTypes = projectUpdateBatch.GetExpendituresRelevantCostTypes().Select(x => new ProjectRelevantCostTypeSimple(x)).ToList();
            var currentRelevantCostTypeIDs = projectRelevantCostTypes.Select(x => x.CostTypeID).ToList();
            projectRelevantCostTypes.AddRange(
                costTypes.Where(x => !currentRelevantCostTypeIDs.Contains(x.CostTypeID))
                    .Select((x, index) => new ProjectRelevantCostTypeSimple(-(index + 1), projectUpdateBatch.ProjectUpdateBatchID, x.CostTypeID, x.CostTypeName)));

            var viewModel = new ExpendituresByCostTypeViewModel(projectUpdateBatch, calendarYearRange, projectRelevantCostTypes);
            return ViewExpendituresByCostType(projectUpdateBatch, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpendituresByCostType(ProjectPrimaryKey projectPrimaryKey, ExpendituresByCostTypeViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                var calendarYearRange = projectUpdateBatch.ProjectUpdate.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
                return ViewExpendituresByCostType(projectUpdateBatch, calendarYearRange, viewModel);
            }
            viewModel.UpdateModel(projectUpdateBatch, HttpRequestStorage.DatabaseEntities);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.ExpendituresComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Expenditures.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewExpendituresByCostType(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearRange, ExpendituresByCostTypeViewModel viewModel)
        {
            var project = projectUpdateBatch.Project;
            var projectExemptReportingYearUpdates = projectUpdateBatch.GetExpendituresExemptReportingYears();
            var showNoExpendituresExplanation = projectExemptReportingYearUpdates.Any();
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var expendituresValidationResult = projectUpdateBatch.ValidateExpendituresByCostType();

            var viewDataForAngularEditor = new ExpendituresByCostTypeViewData.ViewDataForAngularClass(project, allFundingSources, calendarYearRange, showNoExpendituresExplanation);
            var projectFundingSourceExpenditures = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var projectFundingSourceCostTypeExpenditureAmounts = ProjectFundingSourceCostTypeAmount.CreateFromProjectFundingSourceExpenditures(projectFundingSourceExpenditures);
            var projectExpendituresSummaryViewData = new ProjectExpendituresByCostTypeDetailViewData(projectUpdateBatch.NoExpendituresToReportExplanation,
                projectFundingSourceCostTypeExpenditureAmounts);
            var viewData = new ExpendituresByCostTypeViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectExpendituresSummaryViewData, 
                GetUpdateStatus(projectUpdateBatch), expendituresValidationResult);
            return RazorView<ExpendituresByCostType, ExpendituresByCostTypeViewData, ExpendituresByCostTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult ExpectedFunding(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList();
            var viewModel = new ExpectedFundingViewModel(projectUpdateBatch, projectFundingSourceBudgetUpdates,
                projectUpdateBatch.ExpectedFundingComment);
            return ViewExpectedFunding(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpectedFunding(ProjectPrimaryKey projectPrimaryKey, ExpectedFundingViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewExpectedFunding(projectUpdateBatch, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceBudgetUpdates.Load();
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList();
            var allProjectFundingSourceExpectedFunding = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceBudgetUpdates.Local;
            viewModel.UpdateModel(projectUpdateBatch, projectFundingSourceBudgetUpdates, allProjectFundingSourceExpectedFunding);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.ExpectedFundingComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Budget.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewExpectedFunding(ProjectUpdateBatch projectUpdateBatch, ExpectedFundingViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var fundingTypes = FundingType.All.ToList().ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            var expectedFundingValidationResult = projectUpdateBatch.ValidateExpectedFunding(viewModel.ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples);

            var viewDataForAngularEditor = new ExpectedFundingViewData.ViewDataForAngularClass(projectUpdateBatch,
                allFundingSources,
                fundingTypes,
                projectUpdateBatch.ProjectUpdate.PlanningDesignStartYear,
                projectUpdateBatch.ProjectUpdate.CompletionYear);
            var projectBudgetSummaryViewData = new ProjectBudgetSummaryViewData(CurrentPerson, projectUpdateBatch);
            var projectBudgetsAnnualViewData = new ProjectBudgetsAnnualViewData(CurrentPerson, projectUpdateBatch);


            var viewData = new ExpectedFundingViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectBudgetSummaryViewData, projectBudgetsAnnualViewData, GetUpdateStatus(projectUpdateBatch), expectedFundingValidationResult);
            return RazorView<ExpectedFunding, ExpectedFundingViewData, ExpectedFundingViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshExpectedFunding(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshExpectedFunding(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshExpectedFunding(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectFundingSourceBudgetUpdates();
            // refresh data
            ProjectFundingSourceBudgetUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            ProjectNoFundingSourceIdentifiedUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            // Need to revert project-level budget data too
            projectUpdateBatch.ProjectUpdate.FundingTypeID = project.FundingTypeID;
            projectUpdateBatch.ProjectUpdate.NoFundingSourceIdentifiedYet = project.NoFundingSourceIdentifiedYet;

            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshExpectedFunding(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the budget for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult ExpectedFundingByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();

            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }

            var calendarYearRange = projectUpdateBatch.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
            var costTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList();
            var projectUpdateRelevantCostTypes = projectUpdateBatch.GetBudgetsRelevantCostTypes().Select(x => new ProjectRelevantCostTypeSimple(x)).ToList();
            var currentRelevantCostTypeIDs = projectUpdateRelevantCostTypes.Select(x => x.CostTypeID).ToList();
            projectUpdateRelevantCostTypes.AddRange(
                costTypes.Where(x => !currentRelevantCostTypeIDs.Contains(x.CostTypeID))
                    .Select((x, index) => new ProjectRelevantCostTypeSimple(-(index + 1), project.ProjectID, x.CostTypeID, x.CostTypeName)));
            var viewModel = new ExpectedFundingByCostTypeViewModel(projectUpdateBatch, calendarYearRange, projectUpdateRelevantCostTypes);
            return ViewExpectedFundingByCostType(projectUpdateBatch, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpectedFundingByCostType(ProjectPrimaryKey projectPrimaryKey, ExpectedFundingByCostTypeViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }

            if (!ModelState.IsValid)
            {
                var calendarYearRange = project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
                return ViewExpectedFundingByCostType(projectUpdateBatch, calendarYearRange, viewModel);
            }
            viewModel.UpdateModel(projectUpdateBatch, HttpRequestStorage.DatabaseEntities);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.ExpectedFundingComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Budget.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewExpectedFundingByCostType(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearRange, ExpectedFundingByCostTypeViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var allCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList().Select(x => new CostTypeSimple(x)).OrderBy(p => p.CostTypeName).ToList();
            var fundingTypes = FundingType.All.ToList().ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            var viewDataForAngularEditor = new ExpectedFundingByCostTypeViewData.ViewDataForAngularClass(projectUpdateBatch, 
                allFundingSources, 
                allCostTypes, 
                calendarYearRange, 
                fundingTypes);

            var expectedFundingUpdateValidationResult = new ExpectedFundingValidationResult();
            var reportFinancialsByCostType = MultiTenantHelpers.GetTenantAttribute().BudgetType == BudgetType.AnnualBudgetByCostType;
            var projectBudgetSummaryViewData = new ProjectBudgetSummaryViewData(CurrentPerson, projectUpdateBatch);
            var projectBudgetsAnnualByCostTypeViewData = reportFinancialsByCostType ? BuildProjectBudgetsAnnualByCostTypeViewData(CurrentPerson, projectUpdateBatch) : null;


            var viewData = new ExpectedFundingByCostTypeViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectBudgetSummaryViewData, projectBudgetsAnnualByCostTypeViewData, GetUpdateStatus(projectUpdateBatch), expectedFundingUpdateValidationResult);
            return RazorView<ExpectedFundingByCostType, ExpectedFundingByCostTypeViewData, ExpectedFundingByCostTypeViewModel>(viewData, viewModel);
        }

        private static ProjectBudgetsAnnualByCostTypeViewData BuildProjectBudgetsAnnualByCostTypeViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch)
        {
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList();
            var projectFundingSourceCostTypeAmounts = ProjectFundingSourceCostTypeAmount.CreateFromProjectFundingSourceBudgets(projectFundingSourceBudgetUpdates);
            var projectBudgetsAnnualByCostTypeViewData = new ProjectBudgetsAnnualByCostTypeViewData(currentPerson, projectUpdateBatch.Project, projectFundingSourceCostTypeAmounts, projectUpdateBatch.ExpectedFundingUpdateNote);
            return projectBudgetsAnnualByCostTypeViewData;
        }
        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshExpectedFundingByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshExpectedFundingByCostType(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshExpectedFundingByCostType(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectFundingSourceBudgetUpdates();
            projectUpdateBatch.DeleteProjectNoFundingSourceIdentifiedUpdates();
            // refresh data
            ProjectFundingSourceBudgetUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            // Need to revert project-level budget data too
            projectUpdateBatch.ProjectUpdate.FundingTypeID = project.FundingTypeID;
            if (project.FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID)
            {
                projectUpdateBatch.ProjectUpdate.NoFundingSourceIdentifiedYet = project.NoFundingSourceIdentifiedYet;
            }
            else
            {
                ProjectNoFundingSourceIdentifiedUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            }
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshExpectedFundingByCostType(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the budget for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }


        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult Photos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new PhotosViewData(CurrentPerson, projectUpdateBatch, updateStatus);
            return RazorView<Photos, PhotosViewData>(viewData);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshPhotos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshPhotos(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshPhotos(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectImageUpdates();
            // finally create a new project update record, refreshing with the current project data at this point in time
            ProjectImageUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.IsPhotosUpdated = false;
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshPhotos(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the photos for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult LocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            var viewModel = new LocationSimpleViewModel(projectUpdate.ProjectLocationPoint,
                projectUpdate.ProjectLocationSimpleType.ToEnum,
                projectUpdate.ProjectLocationNotes,
                projectUpdateBatch.LocationSimpleComment);
            return ViewLocationSimple(project, projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult LocationSimple(ProjectPrimaryKey projectPrimaryKey, LocationSimpleViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewLocationSimple(project, projectUpdateBatch, viewModel);
            }
            viewModel.UpdateModelBatch(projectUpdateBatch);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.LocationSimpleComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.LocationSimple.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewLocationSimple(Project project, ProjectUpdateBatch projectUpdateBatch, LocationSimpleViewModel viewModel)
        {          
            var projectUpdate = projectUpdateBatch.ProjectUpdate;

            var mapInitJsonForEdit = new MapInitJson($"project_{project.ProjectID}_EditMap",
                10,
                MapInitJson.GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Hide),
                BoundingBox.MakeNewDefaultBoundingBox(),
                false) {DisablePopups = true};
            var locationSimpleValidationResult = projectUpdateBatch.ValidateProjectLocationSimple();

            var geospatialAreas = projectUpdate.GetProjectGeospatialAreas().ToList();
            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(projectUpdate,
                $"project_{project.ProjectID}_EditMap", true, geospatialAreas, projectUpdate.DetailedLocationToGeoJsonFeatureCollection(), projectUpdate.SimpleLocationToGeoJsonFeatureCollection(true));

            var mapPostUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.LocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationFormID(project);
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName).ToList();            
            var editProjectLocationViewData = new ProjectLocationSimpleViewData(CurrentPerson, mapInitJsonForEdit, geospatialAreaTypes, null, mapPostUrl, mapFormID);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(projectUpdate, projectLocationSummaryMapInitJson, new Dictionary<int, string>(), new List<GeospatialAreaType>(), new List<GeospatialArea>());
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new LocationSimpleViewData(CurrentPerson, projectUpdate, editProjectLocationViewData, projectLocationSummaryViewData, locationSimpleValidationResult, updateStatus);
            return RazorView<LocationSimple, LocationSimpleViewData, LocationSimpleViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshProjectLocationSimple(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            if (projectUpdate == null)
            {
                return new ModalDialogFormJsonResult();
            }
            projectUpdate.LoadSimpleLocationFromProject(project);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshProjectLocationSimple(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} data? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult LocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var viewModel = new LocationDetailedViewModel(projectUpdateBatch.LocationDetailedComment);
            return ViewLocationDetailed(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult LocationDetailed(ProjectPrimaryKey projectPrimaryKey, LocationDetailedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewLocationDetailed(projectUpdateBatch, viewModel);
            }
            SaveProjectLocationUpdates(viewModel, projectUpdateBatch);

            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.LocationDetailedComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.LocationDetailed.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewLocationDetailed(ProjectUpdateBatch projectUpdateBatch, LocationDetailedViewModel viewModel)
        {
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            var project = projectUpdateBatch.Project;

            var mapDivID = $"project_{project.ProjectID}_EditDetailedMap";
            var detailedLocationGeoJsonFeatureCollection = projectUpdate.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(projectUpdate);
            var layers = MapInitJson.GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleMapLayer(projectUpdate));
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, boundingBox) {AllowFullScreen = false, DisablePopups = true};
            var mapFormID = ProjectLocationController.GenerateEditProjectLocationFormID(projectUpdateBatch.ProjectID);
            var uploadGisFileUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.ProjectID));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(project.ProjectID, null));

            var hasSimpleLocationPoint = projectUpdate.ProjectLocationPoint != null;

            var projectLocationDetailViewData = new ProjectLocationDetailViewData(projectUpdateBatch.ProjectID,
                mapInitJson,
                editableLayerGeoJson,
                uploadGisFileUrl,
                mapFormID,
                saveFeatureCollectionUrl,
                ProjectLocationUpdate.FieldLengths.Annotation,
                hasSimpleLocationPoint);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new LocationDetailedViewData(CurrentPerson, projectUpdateBatch, projectLocationDetailViewData, uploadGisFileUrl, updateStatus);
            return RazorView<LocationDetailed, LocationDetailedViewData, LocationDetailedViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshProjectLocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshProjectLocationDetailed(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshProjectLocationDetailed(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectLocationStagingUpdates();
            projectUpdateBatch.DeleteProjectLocationUpdates();

            // refresh the data
            ProjectLocationUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshProjectLocationDetailed(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} data? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ImportGdbFileViewModel();
            return ViewImportGdbFile(project, viewModel);
        }

        private PartialViewResult ViewImportGdbFile(ProjectPrimaryKey projectPrimaryKey, ImportGdbFileViewModel viewModel)
        {
            var projectID = projectPrimaryKey.EntityObject.ProjectID;
            var mapFormID = ProjectLocationController.GenerateEditProjectLocationFormID(projectID);
            var newGisUploadUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ImportGdbFile(projectID, null));
            var approveGisUploadUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ApproveGisUpload(projectID, null));
            var viewData = new ImportGdbFileViewData(mapFormID, newGisUploadUrl, approveGisUploadUrl);
            return RazorPartialView<ImportGdbFile, ImportGdbFileViewData, ImportGdbFileViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey, ImportGdbFileViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewImportGdbFile(project, viewModel);
            }

            var httpPostedFileBase = viewModel.FileResourceData;
            var fileEnding = ".gdb.zip";
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var gdbFile = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(gdbFile.FullName);
                projectUpdateBatch.DeleteProjectLocationStagingUpdates();
                ProjectLocationStagingUpdateModelExtensions.CreateProjectLocationStagingUpdateListFromGdb(gdbFile, projectUpdateBatch, CurrentPerson);
            }
            return ApproveGisUpload(project);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ProjectLocationDetailViewModel();
            return ViewApproveGisUpload(projectUpdateBatch, viewModel);
        }

        private PartialViewResult ViewApproveGisUpload(ProjectUpdateBatch projectUpdateBatch, ProjectLocationDetailViewModel viewModel)
        {
            var projectLocationStagingUpdates = projectUpdateBatch.ProjectLocationStagingUpdates.ToList();
            var layerGeoJsons =
                projectLocationStagingUpdates.Select(
                    (projectLocationStaging, i) =>
                        new LayerGeoJson(projectLocationStaging.FeatureClassName,
                            projectLocationStaging.ToGeoJsonFeatureCollection(),
                            FirmaHelpers.DefaultColorRange[i],
                            1,
                            LayerInitialVisibility.Show)).ToList();

            var boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layerGeoJsons);

            var mapInitJson = new MapInitJson($"project_{projectUpdateBatch.ProjectID}_PreviewMap", 10, layerGeoJsons, boundingBox, false) {AllowFullScreen = false, DisablePopups = true};
            var mapFormID = ProjectLocationController.GenerateEditProjectLocationFormID(projectUpdateBatch.ProjectID);
            var approveGisUploadUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ApproveGisUpload(projectUpdateBatch.Project, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagingUpdates), mapInitJson, mapFormID, approveGisUploadUrl);
            return RazorPartialView<ApproveGisUpload, ApproveGisUploadViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            if (!ModelState.IsValid)
            {
                return ViewApproveGisUpload(projectUpdateBatch, viewModel);
            }
            SaveProjectLocationUpdates(viewModel, projectUpdateBatch);
            DbSpatialHelper.Reduce(new List<IHaveSqlGeometry>(projectUpdateBatch.ProjectLocationUpdates.ToList()));
            return new ModalDialogFormJsonResult();
        }

        private static void SaveProjectLocationUpdates(ProjectLocationDetailViewModel viewModel, ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.DeleteProjectLocationUpdates();
            if (viewModel.WktAndAnnotations != null)
            {
                foreach (var wktAndAnnotation in viewModel.WktAndAnnotations)
                {
                    projectUpdateBatch.ProjectLocationUpdates.Add(new ProjectLocationUpdate(projectUpdateBatch, DbGeometry.FromText(wktAndAnnotation.Wkt), wktAndAnnotation.Annotation));
                }
            }
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult GeospatialArea(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var geospatialAreaIDs = projectUpdateBatch.ProjectGeospatialAreaUpdates.Where(x => x.GeospatialArea.GeospatialAreaType.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).Select(x => x.GeospatialAreaID).ToList();
            var geospatialAreaNotes = projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID)?.Notes;
            var viewModel = new GeospatialAreaViewModel(geospatialAreaIDs, geospatialAreaNotes, projectUpdateBatch.GeospatialAreaComment);
            return ViewGeospatialArea(project, projectUpdateBatch, viewModel, geospatialAreaType);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult GeospatialArea(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey, GeospatialAreaViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewGeospatialArea(project, projectUpdateBatch, viewModel, geospatialAreaType);
            }
            var currentProjectUpdateGeospatialAreas = projectUpdateBatch.ProjectGeospatialAreaUpdates.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList();
            var allProjectUpdateGeospatialAreas = HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaUpdates.Local;
            viewModel.UpdateModelBatch(projectUpdateBatch, currentProjectUpdateGeospatialAreas, allProjectUpdateGeospatialAreas);
            var projectGeospatialAreaTypeNoteUpdate = projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);
            if (!string.IsNullOrWhiteSpace(viewModel.ProjectGeospatialAreaNotes))
            {
                if (projectGeospatialAreaTypeNoteUpdate == null)
                {
                    projectGeospatialAreaTypeNoteUpdate = new ProjectGeospatialAreaTypeNoteUpdate(projectUpdateBatch, geospatialAreaType, viewModel.ProjectGeospatialAreaNotes);
                }
                projectGeospatialAreaTypeNoteUpdate.Notes = viewModel.ProjectGeospatialAreaNotes;
            }
            else
            {
                projectGeospatialAreaTypeNoteUpdate?.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.GeospatialAreaComment = viewModel.Comments;
            }
            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, geospatialAreaType.GeospatialAreaTypeNamePluralized);
        }

        private ViewResult ViewGeospatialArea(Project project, ProjectUpdateBatch projectUpdateBatch, GeospatialAreaViewModel viewModel, GeospatialAreaType geospatialAreaType)
        {
            var projectUpdate = projectUpdateBatch.ProjectUpdate;

            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(projectUpdate);
            var layers = MapInitJson.GetGeospatialAreaMapLayersForGeospatialAreaType(geospatialAreaType, LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(projectUpdate));
            var mapInitJson = new MapInitJson("projectGeospatialAreaMap", 0, layers, boundingBox) { AllowFullScreen = false, DisablePopups = true};
           
            var geospatialAreaValidationResult = projectUpdateBatch.ValidateProjectGeospatialArea(geospatialAreaType);
            var geospatialAreas = projectUpdate.GetProjectGeospatialAreas().ToList();
            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(projectUpdate,
                $"project_{project.ProjectID}_EditMap", false, geospatialAreas, projectUpdate.DetailedLocationToGeoJsonFeatureCollection(), projectUpdate.SimpleLocationToGeoJsonFeatureCollection(false));
            var geospatialAreaIDs = viewModel.GeospatialAreaIDs ?? new List<int>();
            var geospatialAreasInViewModel = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => geospatialAreaIDs.Contains(x.GeospatialAreaID)).ToList();
            var editProjectGeospatialAreasPostUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.GeospatialArea(project, geospatialAreaType, null));
            var editProjectGeospatialAreasFormId = GenerateEditProjectLocationFormID(project);

            var geospatialAreasContainingProjectSimpleLocation =
                HttpRequestStorage.DatabaseEntities.GeospatialAreas
                    .Where(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList()
                    .GetGeospatialAreasContainingProjectLocation(projectUpdate).ToList();

            var editProjectLocationViewData = new EditProjectGeospatialAreasViewData(CurrentPerson, mapInitJson,
                geospatialAreasInViewModel, editProjectGeospatialAreasPostUrl, editProjectGeospatialAreasFormId,
                projectUpdate.HasProjectLocationPoint, projectUpdate.HasProjectLocationDetail, geospatialAreaType,
                geospatialAreasContainingProjectSimpleLocation);

            var dictionaryGeoNotes = projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates
                .Where(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID)
                .ToDictionary(x => x.GeospatialAreaTypeID, x => x.Notes);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(projectUpdate, projectLocationSummaryMapInitJson, dictionaryGeoNotes, new List<GeospatialAreaType> {geospatialAreaType}, geospatialAreas);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new GeospatialAreaViewData(CurrentPerson, projectUpdate, editProjectLocationViewData, projectLocationSummaryViewData, geospatialAreaValidationResult, updateStatus, geospatialAreaType);
            return RazorView<Views.ProjectUpdate.GeospatialArea, GeospatialAreaViewData, GeospatialAreaViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshProjectGeospatialArea(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshProjectGeospatialArea(viewModel, geospatialAreaType);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshProjectGeospatialArea(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            if (projectUpdate == null)
            {
                return new ModalDialogFormJsonResult();
            }
            projectUpdateBatch.DeleteProjectGeospatialAreaUpdates();

            // refresh the data
            ProjectGeospatialAreaUpdate.CreateFromProject(projectUpdateBatch);
            ProjectGeospatialAreaTypeNoteUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshProjectGeospatialArea(ConfirmDialogFormViewModel viewModel, GeospatialAreaType geospatialAreaType)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {geospatialAreaType.GeospatialAreaTypeName} data? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }       

        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult DocumentsAndNotes(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var diffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffNotesAndDocuments(projectPrimaryKey));
            var viewData = new DocumentsAndNotesViewData(CurrentPerson, projectUpdateBatch, updateStatus, diffUrl);
            return RazorView<DocumentsAndNotes, DocumentsAndNotesViewData>(viewData);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshNotesAndDocuments(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshNotesAndDocuments(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshNotesAndDocuments(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectNoteUpdates();
            projectUpdateBatch.DeleteProjectDocumentUpdates();
            // finally create a new project update record, refreshing with the current project data at this point in time
            ProjectNoteUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            ProjectDocumentUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshNotesAndDocuments(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the notes for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult ExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var viewModel =
                new EditProjectExternalLinksViewModel(
                    projectUpdateBatch.ProjectExternalLinkUpdates.Select(
                        x => new ProjectExternalLinkSimple(x.ProjectExternalLinkUpdateID, x.ProjectUpdateBatchID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList());
            return ViewExternalLinks(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExternalLinks(ProjectPrimaryKey projectPrimaryKey, EditProjectExternalLinksViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewExternalLinks(projectUpdateBatch, viewModel);
            }
            var currentProjectExternalLinkUpdates = projectUpdateBatch.ProjectExternalLinkUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinkUpdates.Load();
            var allProjectExternalLinkUpdates = HttpRequestStorage.DatabaseEntities.AllProjectExternalLinkUpdates.Local;
            viewModel.UpdateModel(currentProjectExternalLinkUpdates, allProjectExternalLinkUpdates);

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.ExternalLinks.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewExternalLinks(ProjectUpdateBatch projectUpdateBatch, EditProjectExternalLinksViewModel viewModel)
        {
            var refreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExternalLinks(projectUpdateBatch.Project));
            var diffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExternalLinks(projectUpdateBatch.Project));
            var entityExternalLinksViewData = new EntityExternalLinksViewData(ExternalLink.CreateFromEntityExternalLink(new List<IEntityExternalLink>(projectUpdateBatch.ProjectExternalLinkUpdates)));
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewDataForAngularClass = new ExternalLinksViewData.ViewDataForAngularClass(projectUpdateBatch.ProjectUpdateBatchID);
            var viewData = new ExternalLinksViewData(CurrentPerson,
                projectUpdateBatch,
                updateStatus,
                viewDataForAngularClass,
                entityExternalLinksViewData,
                refreshUrl,
                diffUrl);
            return RazorView<ExternalLinks, ExternalLinksViewData, EditProjectExternalLinksViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshExternalLinks(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshExternalLinks(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectExternalLinkUpdates();
            // finally create a new project update record, refreshing with the current project data at this point in time
            ProjectExternalLinkUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshExternalLinks(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the notes for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult TechnicalAssistanceRequests(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var technicalAssistanceRequestUpdateSimples =
                projectUpdateBatch.TechnicalAssistanceRequestUpdates.OrderByDescending(x => x.FiscalYear).ThenByDescending(x => x.TechnicalAssistanceRequestUpdateID).Select(x => new TechnicalAssistanceRequestSimple(x))
                    .ToList();
            var viewModel = new TechnicalAssistanceRequestsViewModel(technicalAssistanceRequestUpdateSimples, projectUpdateBatch.TechnicalAssistanceRequestsComment);
            return ViewTechnicalAssistanceRequests(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult TechnicalAssistanceRequests(ProjectPrimaryKey projectPrimaryKey, TechnicalAssistanceRequestsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewTechnicalAssistanceRequests(projectUpdateBatch, viewModel);
            }
            var currentTechnicalAssistanceRequestUpdates = projectUpdateBatch.TechnicalAssistanceRequestUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.TechnicalAssistanceRequestUpdates.Load();
            var allTechnicalAssistanceRequestUpdates = HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceRequestUpdates.Local;
            viewModel.UpdateModel(CurrentPerson, currentTechnicalAssistanceRequestUpdates, allTechnicalAssistanceRequestUpdates, projectUpdateBatch);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.TechnicalAssistanceRequestsComment = viewModel.TechnicalAssistanceRequestsComment;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.TechnicalAssistanceRequests.ProjectUpdateSectionDisplayName);
        }

        private ViewResult ViewTechnicalAssistanceRequests(ProjectUpdateBatch projectUpdateBatch, TechnicalAssistanceRequestsViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.TechnicalAssistanceInstructions.GetFirmaPage();
            var technicalAssistanceTypes = TechnicalAssistanceType.All;
            var fiscalYearStrings = FirmaDateUtilities.GetRangeOfYears(MultiTenantHelpers.GetMinimumYear(), FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting() + 2).OrderByDescending(x => x).Select(x => new CalendarYearString(x)).ToList();
            var personDictionary = HttpRequestStorage.DatabaseEntities.People.Where(x => x.RoleID == Role.Admin.RoleID || x.RoleID == Role.ProjectSteward.RoleID).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList().Select(x => new PersonSimple(x)).ToList();
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new TechnicalAssistanceRequestsViewData(CurrentPerson, firmaPage, projectUpdateBatch, updateStatus, technicalAssistanceTypes, fiscalYearStrings, personDictionary);
            return RazorView<TechnicalAssistanceRequests, TechnicalAssistanceRequestsViewData, TechnicalAssistanceRequestsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshTechnicalAssistanceRequests(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshTechnicalAssistanceRequests(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshTechnicalAssistanceRequests(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteTechnicalAssistanceRequestsUpdates();
            // refresh the data
            TechnicalAssistanceRequestUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshTechnicalAssistanceRequests(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the Technical Support Requests for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. Any changes made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateAdminFeatureWithProjectContext]
        public PartialViewResult Approve(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to approve for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}!");
            Check.Require(projectUpdateBatch.IsSubmitted(), $"The {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is not in a state to be ready to be approved!");
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewApprove(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateAdminFeatureWithProjectContext]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Approve(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to approve for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}!");
            Check.Require(projectUpdateBatch.IsSubmitted(), $"The {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is not in a state to be ready to be approved!");
            WriteHtmlDiffLogs(projectPrimaryKey, projectUpdateBatch);

            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptReportingYears = HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.Local;
            HttpRequestStorage.DatabaseEntities.ProjectRelevantCostTypes.Load();
            var allProjectRelevantCostTypes = HttpRequestStorage.DatabaseEntities.AllProjectRelevantCostTypes.Local;
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceBudgets.Load();
            var allProjectFundingSourceBudgets = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceBudgets.Local;
            HttpRequestStorage.DatabaseEntities.ProjectNoFundingSourceIdentifieds.Load();
            var allProjectNoFundingSourceIdentifieds = HttpRequestStorage.DatabaseEntities.AllProjectNoFundingSourceIdentifieds.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            var allPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Load();
            var allPerformanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptions.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Load();
            var allPerformanceMeasureExpecteds = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpecteds.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptions.Load();
            var allPerformanceMeasureExpectedSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptions.Local;
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Load();
            var allProjectExternalLinks = HttpRequestStorage.DatabaseEntities.AllProjectExternalLinks.Local;
            HttpRequestStorage.DatabaseEntities.ProjectNotes.Load();
            var allProjectNotes = HttpRequestStorage.DatabaseEntities.AllProjectNotes.Local;
            HttpRequestStorage.DatabaseEntities.ProjectImages.Load();
            var allProjectImages = HttpRequestStorage.DatabaseEntities.AllProjectImages.Local;
            HttpRequestStorage.DatabaseEntities.ProjectLocations.Load();
            var allProjectLocations = HttpRequestStorage.DatabaseEntities.AllProjectLocations.Local;
            HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreas.Load();
            var allProjectGeospatialAreas = HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.Local;
            HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreaTypeNotes.Load();
            var allProjectGeospatialAreaTypeNotes = HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaTypeNotes.Local;
            HttpRequestStorage.DatabaseEntities.ProjectOrganizations.Load();
            var allProjectOrganizations = HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.Local;
            HttpRequestStorage.DatabaseEntities.ProjectDocuments.Load();
            var allProjectDocuments = HttpRequestStorage.DatabaseEntities.AllProjectDocuments.Local;
            HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeUpdates.Load();
            var allProjectCustomAttributes = HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributes.Local;
            HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeUpdateValues.Load();
            var allProjectCustomAttributeValues = HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeValues.Local;
            // Technical Assistance Requests for Idaho
            HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceRequests.Load();
            var allTechnicalAssistanceRequests = HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceRequests.Local;
            HttpRequestStorage.DatabaseEntities.ProjectContacts.Load();
            var allProjectContacts = HttpRequestStorage.DatabaseEntities.AllProjectContacts.Local;

            projectUpdateBatch.Approve(CurrentPerson,
                DateTime.Now,
                allProjectExemptReportingYears,
                allProjectRelevantCostTypes,
                allProjectFundingSourceExpenditures,
                allPerformanceMeasureActuals,
                allPerformanceMeasureActualSubcategoryOptions,
                allPerformanceMeasureExpecteds,
                allPerformanceMeasureExpectedSubcategoryOptions,
                allProjectExternalLinks,
                allProjectNotes,
                allProjectImages,
                allProjectLocations,
                allProjectGeospatialAreas,
                allProjectGeospatialAreaTypeNotes,
                allProjectFundingSourceBudgets,
                allProjectNoFundingSourceIdentifieds,
                allProjectOrganizations,
                allProjectDocuments,
                allProjectCustomAttributes,
                allProjectCustomAttributeValues,
                allTechnicalAssistanceRequests,
                allProjectContacts);

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            var peopleToCc = project.GetProjectStewardPeople();
            NotificationProjectModelExtensions.SendApprovalMessage(peopleToCc, projectUpdateBatch);

            SetMessageForDisplay($"The update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {projectUpdateBatch.Project.GetDisplayName()} was approved!");
            return new ModalDialogFormJsonResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project)));
        }

        private PartialViewResult ViewApprove(ProjectUpdateBatch projectUpdate, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to approve the updates to {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {projectUpdate.Project.GetDisplayName()}?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        private void WriteHtmlDiffLogs(ProjectPrimaryKey projectPrimaryKey, ProjectUpdateBatch projectUpdateBatch)
        {
            var budgetType = MultiTenantHelpers.GetTenantAttribute().BudgetType;
            var basicsDiffContainer = DiffBasicsImpl(projectPrimaryKey);
            if (basicsDiffContainer.HasChanged)
            {
                var basicsDiffHelper = new HtmlDiff.HtmlDiff(basicsDiffContainer.OriginalHtml, basicsDiffContainer.UpdatedHtml);                
                projectUpdateBatch.BasicsDiffLogHtmlString = new HtmlString(basicsDiffHelper.Build());
            }            

            var performanceMeasureDiffContainer = DiffReportedPerformanceMeasuresImpl(projectPrimaryKey);
            if (performanceMeasureDiffContainer.HasChanged)
            {
                var performanceMeasureDiffHelper = new HtmlDiff.HtmlDiff(performanceMeasureDiffContainer.OriginalHtml, performanceMeasureDiffContainer.UpdatedHtml);
                projectUpdateBatch.PerformanceMeasureDiffLogHtmlString = new HtmlString(performanceMeasureDiffHelper.Build());
            }

            // Call the correct diff format based on BudgetType
            var expendituresDiffContainer = budgetType == BudgetType.AnnualBudgetByCostType ? DiffExpendituresByCostTypeImpl(projectPrimaryKey) : DiffExpendituresImpl(projectPrimaryKey);
            if (expendituresDiffContainer.HasChanged)
            {
                var expendituresDiffHelper = new HtmlDiff.HtmlDiff(expendituresDiffContainer.OriginalHtml, expendituresDiffContainer.UpdatedHtml);
                projectUpdateBatch.ExpendituresDiffLogHtmlString = new HtmlString(expendituresDiffHelper.Build());
            }

            // Call the correct diff format based on BudgetType
            var budgetsDiffContainer = budgetType == BudgetType.AnnualBudgetByCostType ? DiffExpectedFundingByCostTypeImpl(projectPrimaryKey) : DiffExpectedFundingImpl(projectPrimaryKey);
            if (budgetsDiffContainer.HasChanged)
            {
                var budgetsDiffHelper = new HtmlDiff.HtmlDiff(budgetsDiffContainer.OriginalHtml, budgetsDiffContainer.UpdatedHtml);
                projectUpdateBatch.BudgetsDiffLogHtmlString = new HtmlString(budgetsDiffHelper.Build());
            }

            var externalLinksDiffContainer = DiffExternalLinksImpl(projectPrimaryKey);
            if (externalLinksDiffContainer.HasChanged)
            {
                var externalLinksDiffHelper = new HtmlDiff.HtmlDiff(externalLinksDiffContainer.OriginalHtml, externalLinksDiffContainer.UpdatedHtml);
                projectUpdateBatch.ExternalLinksDiffLogHtmlString = new HtmlString(externalLinksDiffHelper.Build());
            }

            var notesDiffContainer = DiffNotesAndDocumentsImpl(projectPrimaryKey);
            if (notesDiffContainer.HasChanged)
            {
                var notesDiffHelper = new HtmlDiff.HtmlDiff(notesDiffContainer.OriginalHtml, notesDiffContainer.UpdatedHtml);
                projectUpdateBatch.NotesDiffLogHtmlString = new HtmlString(notesDiffHelper.Build());
            }
        }


        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult Submit(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to submit for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewSubmit(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Submit(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to submit for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            projectUpdateBatch.SubmitToReviewer(CurrentPerson, DateTime.Now);
            var peopleToCc = project.GetProjectStewardPeople();
            NotificationProjectModelExtensions.SendSubmittedMessage(peopleToCc, projectUpdateBatch);
            SetMessageForDisplay($"The update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectUpdateBatch.Project.GetDisplayName()}' was submitted.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        private PartialViewResult ViewSubmit(ProjectUpdateBatch projectUpdate, ConfirmDialogFormViewModel viewModel)
        {
            //TODO: Change "for review" to specific reviewer as determined by tenant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to submit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {projectUpdate.Project.GetDisplayName()} for review?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public PartialViewResult SubmitAll()
        {
            var viewModel = new ConfirmDialogFormViewModel(CurrentPerson.PersonID);
            return ViewSubmitAll(viewModel);
        }

        [HttpPost]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult SubmitAll(ConfirmDialogFormViewModel viewModel)
        {
            var projectUpdateBatches =
                HttpRequestStorage.DatabaseEntities.ProjectUpdateBatches.ToList()
                    .Where(pub => pub.IsReadyToSubmit() && pub.Project.ProjectStage.RequiresReportedExpenditures() && pub.Project.IsMyProject(CurrentPerson))
                    .ToList();
            projectUpdateBatches.ForEach(pub =>
            {
                pub.SubmitToReviewer(CurrentPerson, DateTime.Now);
                var peopleToNotify = pub.Project.GetProjectStewardPeople();
                NotificationProjectModelExtensions.SendSubmittedMessage(peopleToNotify, pub);
            });
            SetMessageForDisplay($"The update(s) for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} {string.Join(", ", projectUpdateBatches.Select(x => x.Project.GetDisplayName()))} have been submitted.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewSubmitAll(ConfirmDialogFormViewModel viewModel)
        {
            //TODO: Change "for review" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to submit all your {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} that are ready to be submitted for review?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateAdminFeatureWithProjectContext]
        public PartialViewResult Return(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to return for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            Check.Require(projectUpdateBatch.IsSubmitted(), $"You cannot return a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update that has not been submitted!");
            var viewModel = new ReturnDialogFormViewModel();
            return ViewReturn(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateAdminFeatureWithProjectContext]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Return(ProjectPrimaryKey projectPrimaryKey, ReturnDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to return for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            Check.Require(projectUpdateBatch.IsSubmitted(), $"You cannot return a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update that has not been submitted!");
            viewModel.UpdateModel(projectUpdateBatch);
            projectUpdateBatch.Return(CurrentPerson, DateTime.Now);
            var peopleToCc = project.GetProjectStewardPeople();
            NotificationProjectModelExtensions.SendReturnedMessage(peopleToCc, projectUpdateBatch);
            SetMessageForDisplay($"The update submitted for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {projectUpdateBatch.Project.GetDisplayName()} has been returned.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewReturn(ProjectUpdateBatch projectUpdate, ReturnDialogFormViewModel viewModel)
        {
            var viewData = new ReturnDialogFormViewData($"Are you sure you want to return {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {projectUpdate.Project.GetDisplayName()}?");
            return RazorPartialView<ReturnDialogForm, ReturnDialogFormViewData, ReturnDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DeleteProjectUpdate(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to delete for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewDeleteProjectUpdate(viewModel, projectUpdateBatch);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectUpdate(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update to delete for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            projectUpdateBatch.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update successfully deleted.");
            return new ModalDialogFormJsonResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project)));
        }

        private PartialViewResult ViewDeleteProjectUpdate(ConfirmDialogFormViewModel viewModel, ProjectUpdateBatch projectUpdateBatch)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete this update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {projectUpdateBatch.Project.GetDisplayName()}?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult History(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var viewData = new HistoryViewData(projectUpdateBatch);
            return RazorPartialView<History, HistoryViewData>(viewData);
        }

        private static string GenerateEditProjectLocationFormID(Project project)
        {
            return $"editMapForProposal{project.ProjectID}";
        }

        [ProjectUpdateAdminFeature]
        public ViewResult Manage()
        {
            var customNotificationUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.CreateCustomNotification(null));
            var projectsRequiringUpdateGridSpec = new ProjectUpdateStatusGridSpec(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects, CurrentPerson.IsApprover())
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };
            var contactsReceivingReminderGridSpec = new PeopleReceivingReminderGridSpec(true, CurrentPerson) {ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true};
            var firmaPage = FirmaPageTypeEnum.ManageUpdateNotifications.GetFirmaPage();

            var projectsWithNoContactCount = GetProjectsWithNoContact().Count;

            var viewData = new ManageViewData(CurrentPerson,
                firmaPage,
                customNotificationUrl,
                projectsRequiringUpdateGridSpec,
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ProjectsRequiringUpdateGridJsonData()),
                contactsReceivingReminderGridSpec,
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PeopleReceivingReminderGridJsonData(true)),
                projectsWithNoContactCount,
                MultiTenantHelpers.GetProjectUpdateConfiguration() ?? ProjectUpdateSetting.CreateNewBlank());
            return RazorView<Manage, ManageViewData>(viewData);
        }

        private static List<Project> GetProjectsWithNoContact()
        {
            var projectsRequiringUpdate = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(x => x.IsUpdatableViaProjectUpdateProcess()).ToList();
            return projectsRequiringUpdate.Where(x => x.GetPrimaryContact() == null).ToList();
        }

        [ProjectUpdateAdminFeature]
        public GridJsonNetJObjectResult<Project> ProjectsRequiringUpdateGridJsonData()
        {
            var gridSpec = new ProjectUpdateStatusGridSpec(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects, CurrentPerson.IsApprover());
            var projects =
                HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(x => x.IsUpdatableViaProjectUpdateProcess() && x.IsEditableToThisPerson(CurrentPerson)).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<Person> PeopleReceivingReminderGridJsonData(bool showCheckbox)
        {
            var gridSpec = new PeopleReceivingReminderGridSpec(showCheckbox, CurrentPerson);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(x => x.IsUpdatableViaProjectUpdateProcess() && x.IsEditableToThisPerson(CurrentPerson)).ToList();
            var people = projects.GetPrimaryContactPeople();            
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Person>(people, gridSpec);
            return gridJsonNetJObjectResult;
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [ProjectUpdateAdminFeature]
        public ContentResult CreateCustomNotification()
        {
            return new ContentResult();
        }

        [HttpPost]
        [ProjectUpdateAdminFeature]
        public PartialViewResult CreateCustomNotification(CustomNotificationViewModel viewModel)
        {
            var peopleToNotify = HttpRequestStorage.DatabaseEntities.People.Where(x => viewModel.PersonIDList.Contains(x.PersonID)).ToList();
            var sendPreviewEmailUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.SendPreviewOfCustomNotification(null));
            var viewData = new CustomNotificationViewData(CurrentPerson, peopleToNotify, sendPreviewEmailUrl);
            return RazorPartialView<CustomNotification, CustomNotificationViewData, CustomNotificationViewModel>(viewData, viewModel);
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [ProjectUpdateAdminFeature]
        public ContentResult SendCustomNotification()
        {
            return new ContentResult();
        }

        [HttpPost]
        [ProjectUpdateAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult SendCustomNotification(CustomNotificationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return CreateCustomNotification(viewModel);
            }

            var peopleToNotify = HttpRequestStorage.DatabaseEntities.People.Where(x => viewModel.PersonIDList.Contains(x.PersonID)).ToList();
            var emailsToSendTo = peopleToNotify.Select(x => x.Email).ToList();
            var emailsToReplyTo = new List<string> { FirmaWebConfiguration.DoNotReplyEmail };

            var message = new MailMessage {Subject = viewModel.Subject, AlternateViews = {AlternateView.CreateAlternateViewFromString(viewModel.NotificationContent ?? string.Empty, null, "text/html")}};

            NotificationModelExtensions.SendMessageAndLogNotification(message, emailsToSendTo, emailsToReplyTo, new List<string>(), peopleToNotify, DateTime.Now, new List<Project>(), NotificationType.Custom);

            SetMessageForDisplay($"Custom notification sent to: {string.Join("; ", emailsToSendTo)}");

            return new ModalDialogFormJsonResult();
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [ProjectUpdateAdminFeature]
        public ContentResult SendPreviewOfCustomNotification()
        {
            return new ContentResult();
        }

        [HttpPost]
        [ProjectUpdateAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult SendPreviewOfCustomNotification(CustomNotificationViewModel viewModel)
        {
            var emailsToSendTo = new List<string> {CurrentPerson.Email};
            var message = new MailMessage { Subject = viewModel.Subject, AlternateViews = { AlternateView.CreateAlternateViewFromString(viewModel.NotificationContent, null, "text/html") } };
            NotificationModelExtensions.SendMessage(message, emailsToSendTo, new List<string>(), new List<string>());
            return CreateCustomNotification(viewModel);
        }
        
        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffBasics(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffBasicsImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffBasicsImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            var originalHtml = GeneratePartialViewForProjectBasics(project);            
            projectUpdate.CommitChangesToProject(project);
            var updatedHtml = GeneratePartialViewForProjectBasics(project);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForProjectBasics(Project project)
        {
            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
            var viewData = new ProjectBasicsViewData(project, false, taxonomyLevel, tenantAttribute);
            var partialViewAsString = RenderPartialViewToString(ProjectBasicsPartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffReportedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffReportedPerformanceMeasuresImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffReportedPerformanceMeasuresImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var performanceMeasureReportedValuesOriginal = new List<IPerformanceMeasureReportedValue>(project.GetReportedPerformanceMeasures());
            var performanceMeasureReportedValuesUpdated = new List<IPerformanceMeasureReportedValue>(projectUpdateBatch.PerformanceMeasureActualUpdates);
            var calendarYearsForPerformanceMeasuresOriginal = performanceMeasureReportedValuesOriginal.Select(x => x.CalendarYear).Distinct().ToList();
            var calendarYearsForPerformanceMeasuresUpdated = performanceMeasureReportedValuesUpdated.Select(x => x.CalendarYear).Distinct().ToList();

            var originalHtml = GeneratePartialViewForOriginalReportedPerformanceMeasures(
                performanceMeasureReportedValuesOriginal,
                performanceMeasureReportedValuesUpdated,
                calendarYearsForPerformanceMeasuresOriginal,
                calendarYearsForPerformanceMeasuresUpdated,
                project.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList(),
                project.PerformanceMeasureActualYearsExemptionExplanation);

            var updatedHtml = GeneratePartialViewForModifiedReportedPerformanceMeasures(
                performanceMeasureReportedValuesOriginal,
                performanceMeasureReportedValuesUpdated,
                calendarYearsForPerformanceMeasuresOriginal,
                calendarYearsForPerformanceMeasuresUpdated,
                projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList(),
                projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalReportedPerformanceMeasures(List<IPerformanceMeasureReportedValue> performanceMeasureReportedValuesOriginal,
            List<IPerformanceMeasureReportedValue> performanceMeasureReportedValuesUpdated,
            List<int> calendarYearsOriginal,
            List<int> calendarYearsUpdated,
            List<int> exemptReportingYears,
            string exemptionExplanation)
        {
            var performanceMeasuresInOriginal = performanceMeasureReportedValuesOriginal.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresInUpdated = performanceMeasureReportedValuesUpdated.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresOnlyInOriginal = performanceMeasuresInOriginal.Where(x => !performanceMeasuresInUpdated.Contains(x)).ToList();

            var performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(performanceMeasureReportedValuesOriginal);
            // we need to zero out calendar year values only in original
            foreach (var performanceMeasureSubcategoriesCalendarYearReportedValue in performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal)
            {
                ZeroOutReportedValue(performanceMeasureSubcategoriesCalendarYearReportedValue, calendarYearsOriginal.Except(calendarYearsUpdated).ToList());
            }
            var performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(performanceMeasureReportedValuesUpdated);

            // find the ones that are only in the modified set and add them and mark them as "added"
            performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal.AddRange(
                performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated.Where(x => !performanceMeasuresInOriginal.Contains(x.PerformanceMeasureID))
                    .Select(x => PerformanceMeasureSubcategoriesCalendarYearReportedValue.Clone(x, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal.Where(x => performanceMeasuresOnlyInOriginal.Contains(x.PerformanceMeasureID)).ToList()
                .ForEach(x =>
                {
                    ZeroOutReportedValue(x, calendarYearsOriginal);
                    x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
                });
            var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForReportedPerformanceMeasures(performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal, calendarYearStrings, exemptReportingYears, exemptionExplanation);
        }

        private static void ZeroOutReportedValue(PerformanceMeasureSubcategoriesCalendarYearReportedValue performanceMeasureSubcategoriesCalendarYearReportedValue, List<int> calendarYearsToZeroOut)
        {
            foreach (var subcategoriesReportedValue in performanceMeasureSubcategoriesCalendarYearReportedValue.SubcategoriesReportedValues)
            {
                foreach (var calendarYear in calendarYearsToZeroOut)
                {
                    subcategoriesReportedValue.CalendarYearReportedValue[calendarYear] = 0;
                }
            }
        }

        private string GeneratePartialViewForModifiedReportedPerformanceMeasures(List<IPerformanceMeasureReportedValue> performanceMeasureReportedValuesOriginal,
            List<IPerformanceMeasureReportedValue> performanceMeasureReportedValuesUpdated,
            List<int> calendarYearsOriginal,
            List<int> calendarYearsUpdated,
            List<int> exemptReportingYears,
            string exemptionExplanation)
        {
            var performanceMeasuresInOriginal = performanceMeasureReportedValuesOriginal.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresInUpdated = performanceMeasureReportedValuesUpdated.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresOnlyInUpdated = performanceMeasuresInUpdated.Where(x => !performanceMeasuresInOriginal.Contains(x)).ToList();

            var performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(performanceMeasureReportedValuesOriginal);
            var performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(performanceMeasureReportedValuesUpdated);

            // find the ones that are only in the original set and add them and mark them as "deleted"
            performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated.AddRange(
                performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal.Where(x => !performanceMeasuresInUpdated.Contains(x.PerformanceMeasureID))
                    .Select(x => PerformanceMeasureSubcategoriesCalendarYearReportedValue.Clone(x, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            // find the ones only in modified and mark them as "added"
            performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated.Where(x => performanceMeasuresOnlyInUpdated.Contains(x.PerformanceMeasureID)).ToList()
                .ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForReportedPerformanceMeasures(performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated, calendarYearStrings, exemptReportingYears, exemptionExplanation);
        }

        private string GeneratePartialViewForReportedPerformanceMeasures(List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> performanceMeasureSubcategoriesCalendarYearReportedValues, List<CalendarYearString> calendarYearStrings, List<int> exemptReportingYears, string exemptionExplanation)
        {
            var viewData = new PerformanceMeasureReportedValuesSummaryViewData(performanceMeasureSubcategoriesCalendarYearReportedValues, exemptReportingYears, exemptionExplanation, calendarYearStrings);
            var partialViewToString = RenderPartialViewToString(PerformanceMeasureReportedValuesPartialViewPath, viewData);
            return partialViewToString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffExpectedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExpectedPerformanceMeasuresImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExpectedPerformanceMeasuresImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var performanceMeasureExpectedValuesOriginal = new List<IPerformanceMeasureValue>(project.PerformanceMeasureExpecteds);
            var performanceMeasureExpectedValuesUpdated = new List<IPerformanceMeasureValue>(projectUpdateBatch.PerformanceMeasureExpectedUpdates);

            var originalHtml = GeneratePartialViewForOriginalExpectedPerformanceMeasures(
                performanceMeasureExpectedValuesOriginal,
                performanceMeasureExpectedValuesUpdated);

            var updatedHtml = GeneratePartialViewForModifiedExpectedPerformanceMeasures(
                performanceMeasureExpectedValuesOriginal,
                performanceMeasureExpectedValuesUpdated);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalExpectedPerformanceMeasures(List<IPerformanceMeasureValue> performanceMeasureExpectedValuesOriginal,
            List<IPerformanceMeasureValue> performanceMeasureExpectedValuesUpdated)
        {
            var performanceMeasuresInOriginal = performanceMeasureExpectedValuesOriginal.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresInUpdated = performanceMeasureExpectedValuesUpdated.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresOnlyInOriginal = performanceMeasuresInOriginal.Where(x => !performanceMeasuresInUpdated.Contains(x)).ToList();

            var performanceMeasureSubcategoriesExpectedValuesOriginal =
                PerformanceMeasureSubcategoriesExpectedValue.CreateFromPerformanceMeasures(performanceMeasureExpectedValuesOriginal);
            var performanceMeasureSubcategoriesExpectedValuesUpdated =
                PerformanceMeasureSubcategoriesExpectedValue.CreateFromPerformanceMeasures(performanceMeasureExpectedValuesUpdated);

            // find the ones that are only in the modified set and add them and mark them as "added"
            performanceMeasureSubcategoriesExpectedValuesOriginal.AddRange(
                performanceMeasureSubcategoriesExpectedValuesUpdated.Where(x => !performanceMeasuresInOriginal.Contains(x.PerformanceMeasureID))
                    .Select(x => PerformanceMeasureSubcategoriesExpectedValue.Clone(x, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            performanceMeasureSubcategoriesExpectedValuesOriginal.Where(x => performanceMeasuresOnlyInOriginal.Contains(x.PerformanceMeasureID)).ToList()
                .ForEach(x =>
                {
                    x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
                });
            return GeneratePartialViewForExpectedPerformanceMeasures(performanceMeasureSubcategoriesExpectedValuesOriginal);
        }

        private string GeneratePartialViewForModifiedExpectedPerformanceMeasures(List<IPerformanceMeasureValue> performanceMeasureExpectedValuesOriginal,
            List<IPerformanceMeasureValue> performanceMeasureExpectedValuesUpdated)
        {
            var performanceMeasuresInOriginal = performanceMeasureExpectedValuesOriginal.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresInUpdated = performanceMeasureExpectedValuesUpdated.Select(x => x.PerformanceMeasureID).Distinct().ToList();
            var performanceMeasuresOnlyInUpdated = performanceMeasuresInUpdated.Where(x => !performanceMeasuresInOriginal.Contains(x)).ToList();

            var performanceMeasureSubcategoriesExpectedValuesOriginal =
                PerformanceMeasureSubcategoriesExpectedValue.CreateFromPerformanceMeasures(performanceMeasureExpectedValuesOriginal);
            var performanceMeasureSubcategoriesExpectedValuesUpdated =
                PerformanceMeasureSubcategoriesExpectedValue.CreateFromPerformanceMeasures(performanceMeasureExpectedValuesUpdated);

            // find the ones that are only in the original set and add them and mark them as "deleted"
            performanceMeasureSubcategoriesExpectedValuesUpdated.AddRange(
                performanceMeasureSubcategoriesExpectedValuesOriginal.Where(x => !performanceMeasuresInUpdated.Contains(x.PerformanceMeasureID))
                    .Select(x => PerformanceMeasureSubcategoriesExpectedValue.Clone(x, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            // find the ones only in modified and mark them as "added"
            performanceMeasureSubcategoriesExpectedValuesUpdated.Where(x => performanceMeasuresOnlyInUpdated.Contains(x.PerformanceMeasureID)).ToList()
                .ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            return GeneratePartialViewForExpectedPerformanceMeasures(performanceMeasureSubcategoriesExpectedValuesUpdated);
        }

        private string GeneratePartialViewForExpectedPerformanceMeasures(List<PerformanceMeasureSubcategoriesExpectedValue> performanceMeasureSubcategoriesExpectedValues)
        {
            var viewData = new PerformanceMeasureExpectedValuesSummaryViewData(performanceMeasureSubcategoriesExpectedValues);
            var partialViewToString = RenderPartialViewToString(PerformanceMeasureExpectedSummaryPartialViewPath, viewData);
            return partialViewToString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffExpenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExpendituresImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExpendituresImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");

            var projectExemptReportingYearsOriginal = project.ProjectExemptReportingYears.Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.Expenditures).Select(x => x.CalendarYear).ToList();
            var projectHasNoExpendituresToReportOriginal = project.NoExpendituresToReportExplanation;
            var projectFundingSourceExpendituresOriginal = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearsOriginal = projectFundingSourceExpendituresOriginal.CalculateCalendarYearRangeForExpenditures(project);

            var projectExemptReportingYearsUpdated = projectUpdateBatch.ProjectExemptReportingYearUpdates.Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.Expenditures).Select(x => x.CalendarYear).ToList();
            var projectHasNoExpendituresToReportUpdated = projectUpdateBatch.NoExpendituresToReportExplanation;
            var projectFundingSourceExpendituresUpdated = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var calendarYearsUpdated = projectFundingSourceExpendituresUpdated.CalculateCalendarYearRangeForExpenditures(projectUpdateBatch.ProjectUpdate);

            var originalHtml = GeneratePartialViewForOriginalExpenditures(projectExemptReportingYearsOriginal, projectHasNoExpendituresToReportOriginal, new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresOriginal),
                calendarYearsOriginal,
                new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresUpdated),
                calendarYearsUpdated);

            var updatedHtml = GeneratePartialViewForModifiedExpenditures(new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresOriginal),
                calendarYearsOriginal,
                projectExemptReportingYearsUpdated,
                projectHasNoExpendituresToReportUpdated,
                new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresUpdated),
                calendarYearsUpdated);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalExpenditures(List<int> projectExemptReportingYearsOriginal, string projectHasNoExpendituresToReportOriginal, List<IFundingSourceExpenditure> projectFundingSourceExpendituresOriginal,
            List<int> calendarYearsOriginal,
            List<IFundingSourceExpenditure> projectFundingSourceExpendituresUpdated,
            List<int> calendarYearsUpdated)
        {
            var fundingSourcesInOriginal = projectFundingSourceExpendituresOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = projectFundingSourceExpendituresUpdated.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInOriginal = fundingSourcesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x)).ToList();

            var fundingSourceCalendarYearExpendituresOriginal = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(projectFundingSourceExpendituresOriginal, calendarYearsOriginal);
            // we need to zero out calendar year values only in original
            foreach (var fundingSourceCalendarYearExpenditure in fundingSourceCalendarYearExpendituresOriginal)
            {
                ZeroOutExpenditure(fundingSourceCalendarYearExpenditure, calendarYearsOriginal.Except(calendarYearsUpdated));
            }

            var fundingSourceCalendarYearExpendituresUpdated = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(projectFundingSourceExpendituresUpdated, calendarYearsUpdated);

            // find the ones that are only in the modified set and add them and mark them as "added"
            fundingSourceCalendarYearExpendituresOriginal.AddRange(
                fundingSourceCalendarYearExpendituresUpdated.Where(x => !fundingSourcesInOriginal.Contains(x.FundingSourceID))
                    .Select(x => FundingSourceCalendarYearExpenditure.Clone(x, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            fundingSourceCalendarYearExpendituresOriginal.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID)).ToList().ForEach(x =>
            {
                ZeroOutExpenditure(x, calendarYearsOriginal);
                x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
            });

            var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForExpendituresAsString(projectExemptReportingYearsOriginal, projectHasNoExpendituresToReportOriginal, fundingSourceCalendarYearExpendituresOriginal, calendarYearStrings);
        }

        private static void ZeroOutExpenditure(FundingSourceCalendarYearExpenditure fundingSourceCalendarYearExpenditure, IEnumerable<int> calendarYearsToZeroOut)
        {
            foreach (var calendarYear in calendarYearsToZeroOut)
            {
                fundingSourceCalendarYearExpenditure.CalendarYearExpenditure[calendarYear] = 0;
            }
        }

        private string GeneratePartialViewForModifiedExpenditures(List<IFundingSourceExpenditure> projectFundingSourceExpendituresOriginal,
            List<int> calendarYearsOriginal,
            List<int> projectExemptReportingYearsUpdated,
            string projectHasNoExpendituresToReportUpdated,
            List<IFundingSourceExpenditure> projectFundingSourceExpendituresUpdated,
            List<int> calendarYearsUpdated)
        {
            var fundingSourcesInOriginal = projectFundingSourceExpendituresOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = projectFundingSourceExpendituresUpdated.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInUpdated = fundingSourcesInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x)).ToList();

            var fundingSourceCalendarYearExpendituresOriginal = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(projectFundingSourceExpendituresOriginal, calendarYearsOriginal);
            var fundingSourceCalendarYearExpendituresUpdated = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(projectFundingSourceExpendituresUpdated, calendarYearsUpdated);

            // find the ones that are only in the original set and add them and mark them as "deleted"
            fundingSourceCalendarYearExpendituresUpdated.AddRange(
                fundingSourceCalendarYearExpendituresOriginal.Where(x => !fundingSourcesInUpdated.Contains(x.FundingSourceID))
                    .Select(x => FundingSourceCalendarYearExpenditure.Clone(x, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            // find the ones only in modified and mark them as "added"
            fundingSourceCalendarYearExpendituresUpdated.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForExpendituresAsString(projectExemptReportingYearsUpdated, projectHasNoExpendituresToReportUpdated, fundingSourceCalendarYearExpendituresUpdated, calendarYearStrings);
        }

        private string GeneratePartialViewForExpendituresAsString(List<int> projectExemptReportingYears, string projectHasNoExpendituresToReport, List<FundingSourceCalendarYearExpenditure> fundingSourceCalendarYearExpenditures, List<CalendarYearString> calendarYearStrings)
        {
            var viewData = new ProjectExpendituresSummaryViewData(projectExemptReportingYears, projectHasNoExpendituresToReport, fundingSourceCalendarYearExpenditures, calendarYearStrings);
            var partialViewAsString = RenderPartialViewToString(ProjectExpendituresPartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffExpendituresByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExpendituresByCostTypeImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExpendituresByCostTypeImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current Project Update for Project {project.GetDisplayName()}");

            var projectFundingSourceExpendituresOriginal = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearsOriginal = projectFundingSourceExpendituresOriginal.CalculateCalendarYearRangeForExpenditures(project);
            var projectFundingSourceExpendituresModified = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var calendarYearsUpdated = projectFundingSourceExpendituresModified.CalculateCalendarYearRangeForExpenditures(projectUpdateBatch.ProjectUpdate);

            var originalHtml = GeneratePartialViewForOriginalExpendituresByCostType(new List<ICostTypeFundingSourceExpenditure>(projectFundingSourceExpendituresOriginal),
                calendarYearsOriginal,
                new List<ICostTypeFundingSourceExpenditure>(projectFundingSourceExpendituresModified),
                calendarYearsUpdated);

            var updatedHtml = GeneratePartialViewForModifiedExpendituresByCostType(new List<ICostTypeFundingSourceExpenditure>(projectFundingSourceExpendituresOriginal),
                calendarYearsOriginal,
                new List<ICostTypeFundingSourceExpenditure>(projectFundingSourceExpendituresModified),
                calendarYearsUpdated);
            var htmlDiffContainer = new HtmlDiffContainer(originalHtml, updatedHtml);
            return htmlDiffContainer;
        }

        private string GeneratePartialViewForOriginalExpendituresByCostType(List<ICostTypeFundingSourceExpenditure> costTypeFundingSourceExpendituresOriginal,
            List<int> calendarYearsOriginal,
            List<ICostTypeFundingSourceExpenditure> costTypeFundingSourceExpendituresModified,
            List<int> calendarYearsUpdated)
        {
            var fundingSourcesInOriginal = costTypeFundingSourceExpendituresOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = costTypeFundingSourceExpendituresModified.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInOriginal = fundingSourcesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x)).ToList();

            var projectExpenditureByCostTypesInOriginal = ProjectExpenditureByCostType.CreateFromProjectFundingSourceExpenditures(costTypeFundingSourceExpendituresOriginal,
                calendarYearsOriginal);
            var projectExpenditureByCostTypesInModified = ProjectExpenditureByCostType.CreateFromProjectFundingSourceExpenditures(costTypeFundingSourceExpendituresModified, calendarYearsUpdated);

            // find the ones that are only in the modified set and add them and mark them as "added"
            projectExpenditureByCostTypesInOriginal.AddRange(
                projectExpenditureByCostTypesInModified.Where(x => !fundingSourcesInOriginal.Contains(x.FundingSourceID))
                    .Select(x => ProjectExpenditureByCostType.Clone(x, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            projectExpenditureByCostTypesInOriginal.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID)).ToList()
                .ForEach(x =>
                {
                    x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
                });

            var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForExpendituresByCostTypeAsString(projectExpenditureByCostTypesInOriginal, calendarYearStrings);
        }

        private string GeneratePartialViewForModifiedExpendituresByCostType(List<ICostTypeFundingSourceExpenditure> costTypeFundingSourceExpendituresOriginal,
            List<int> calendarYearsOriginal,
            List<ICostTypeFundingSourceExpenditure> costTypeFundingSourceExpendituresModified,
            List<int> calendarYearsUpdated)
        {
            var fundingSourcesInOriginal = costTypeFundingSourceExpendituresOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = costTypeFundingSourceExpendituresModified.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInUpdated = fundingSourcesInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x)).ToList();

            var projectExpenditureByCostTypesInOriginal = ProjectExpenditureByCostType.CreateFromProjectFundingSourceExpenditures(costTypeFundingSourceExpendituresOriginal, calendarYearsOriginal);
            var projectExpenditureByCostTypesInUpdated = ProjectExpenditureByCostType.CreateFromProjectFundingSourceExpenditures(costTypeFundingSourceExpendituresModified, calendarYearsUpdated);

            // find the ones that are only in the original set and add them and mark them as "deleted"
            projectExpenditureByCostTypesInUpdated.AddRange(
                projectExpenditureByCostTypesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x.FundingSourceID))
                    .Select(x => ProjectExpenditureByCostType.Clone(x, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            // find the ones only in modified and mark them as "added"
            projectExpenditureByCostTypesInUpdated.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForExpendituresByCostTypeAsString(projectExpenditureByCostTypesInUpdated, calendarYearStrings);
        }

        private string GeneratePartialViewForExpendituresByCostTypeAsString(List<ProjectExpenditureByCostType> projectExpenditureByCostTypes, List<CalendarYearString> calendarYearStrings)
        {
            var costTypes = projectExpenditureByCostTypes.SelectMany(x => x.ProjectCostTypeCalendarYearAmounts.Select(y => y.CostType)).Distinct(new HavePrimaryKeyComparer<CostType>()).ToList();
            var viewData = new ProjectExpendituresByCostTypeSummaryViewData(projectExpenditureByCostTypes, calendarYearStrings, costTypes);
            var partialViewAsString = RenderPartialViewToString(ProjectExpendituresByCostTypeSummaryPartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffExpectedFunding(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExpectedFundingImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExpectedFundingImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var projectFundingSourceBudgetsOriginal = new List<IFundingSourceBudgetAmount>(project.ProjectFundingSourceBudgets.ToList());
            var projectFundingSourceBudgetsUpdated = new List<IFundingSourceBudgetAmount>(projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList());
            var originalHtml = GeneratePartialViewForOriginalFundingRequests(project.FundingTypeID, project.FundingType?.FundingTypeDisplayName, projectFundingSourceBudgetsOriginal, projectFundingSourceBudgetsUpdated, project.NoFundingSourceIdentifiedYet, project.PlanningDesignStartYear, project.CompletionYear, project.ExpectedFundingUpdateNote);
            var updatedHtml = GeneratePartialViewForModifiedFundingRequests(projectUpdateBatch.ProjectUpdate.FundingTypeID, projectUpdateBatch.ProjectUpdate.FundingType?.FundingTypeDisplayName, projectFundingSourceBudgetsOriginal, projectFundingSourceBudgetsUpdated, 
                projectUpdateBatch.ProjectUpdate.NoFundingSourceIdentifiedYet, projectUpdateBatch.ProjectUpdate.PlanningDesignStartYear, projectUpdateBatch.ProjectUpdate.CompletionYear, projectUpdateBatch.ExpectedFundingUpdateNote);
            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalFundingRequests(int? fundingTypeIdOriginal, string fundingTypeDisplayName, List<IFundingSourceBudgetAmount> projectFundingSourceBudgetsOriginal,
    List<IFundingSourceBudgetAmount> projectFundingSourceBudgetsUpdated, decimal? noFundingSourceIdentifiedYetOriginal, int? planningDesignStartYear, int? completionYear, string expectedFundingUpdateNote)
        {
            var fundingSourcesInOriginal = projectFundingSourceBudgetsOriginal.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesInUpdated = projectFundingSourceBudgetsUpdated.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesOnlyInOriginal = fundingSourcesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x)).ToList();
            var fundingSourceRequestAmounts = projectFundingSourceBudgetsOriginal.Select(x => new FundingSourceBudgetAmount(x)).ToList();
            fundingSourceRequestAmounts.AddRange(projectFundingSourceBudgetsUpdated.Where(x => !fundingSourcesInOriginal.Contains(x.FundingSource.FundingSourceID)).Select(x =>
                new FundingSourceBudgetAmount(x.FundingSource, x.SecuredAmount, x.TargetedAmount, HtmlDiffContainer.DisplayCssClassAddedElement)));
            fundingSourceRequestAmounts.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID)).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);
            return GeneratePartialViewForExpectedFundingAsString(fundingTypeIdOriginal, fundingTypeDisplayName, fundingSourceRequestAmounts, noFundingSourceIdentifiedYetOriginal, planningDesignStartYear, completionYear, expectedFundingUpdateNote);
        }

        private string GeneratePartialViewForModifiedFundingRequests(int? fundingTypeIdUpdated, string fundingTypeDisplayName, List<IFundingSourceBudgetAmount> projectFundingSourceBudgetsOriginal,
            List<IFundingSourceBudgetAmount> projectFundingSourceBudgetsUpdated, decimal? noFundingSourceIdentifiedYetUpdated, int? planningDesignStartYear, int? completionYear, string expectedFundingUpdateNote)
        {
            var fundingSourcesInOriginal = projectFundingSourceBudgetsOriginal.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesInUpdated = projectFundingSourceBudgetsUpdated.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesOnlyInUpdated = fundingSourcesInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x)).ToList();
            var fundingSourceRequestAmounts = projectFundingSourceBudgetsUpdated.Select(x => new FundingSourceBudgetAmount(x)).ToList();
            fundingSourceRequestAmounts.AddRange(projectFundingSourceBudgetsOriginal.Where(x => !fundingSourcesInUpdated.Contains(x.FundingSource.FundingSourceID)).Select(x =>
                new FundingSourceBudgetAmount(x.FundingSource, x.SecuredAmount, x.TargetedAmount, HtmlDiffContainer.DisplayCssClassDeletedElement)));
            fundingSourceRequestAmounts.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);
            return GeneratePartialViewForExpectedFundingAsString(fundingTypeIdUpdated, fundingTypeDisplayName, fundingSourceRequestAmounts, noFundingSourceIdentifiedYetUpdated, planningDesignStartYear, completionYear, expectedFundingUpdateNote);
        }

        private string GeneratePartialViewForExpectedFundingAsString(int? fundingTypeID, string fundingTypeDisplayName, List<FundingSourceBudgetAmount> fundingSourceRequestAmounts, decimal? noFundingSourceIdentifiedYet, int? planningDesignStartYear, int? completionYear, string expectedFundingUpdateNote)
        {
            var viewData = new ProjectBudgetsDetailViewData(fundingTypeID, fundingTypeDisplayName, fundingSourceRequestAmounts, noFundingSourceIdentifiedYet, planningDesignStartYear, completionYear, expectedFundingUpdateNote);
            var partialViewAsString = RenderPartialViewToString(ProjectBudgetPartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffExpectedFundingByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExpectedFundingByCostTypeImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExpectedFundingByCostTypeImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");

            var fundingTypeOriginal = project.FundingType;
            var fundingTypeUpdated = projectUpdateBatch.ProjectUpdate.FundingType;

            var projectFundingSourceBudgets = project.ProjectFundingSourceBudgets.ToList();
            var projectFundingSourceCostTypeAmountsOriginal = ProjectFundingSourceCostTypeAmount.CreateFromProjectFundingSourceBudgets(projectFundingSourceBudgets);
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList();
            var projectFundingSourceCostTypeAmountsUpdated = ProjectFundingSourceCostTypeAmount.CreateFromProjectFundingSourceBudgets(projectFundingSourceBudgetUpdates);

            var noFundingSourceIdentifiedOriginal = project.GetNoFundingSourceIdentifiedAmount();
            var noFundingSourceIdentifiedUpdated = projectUpdateBatch.ProjectUpdate.GetNoFundingSourceIdentifiedAmount();

            var estimatedTotalOriginal = project.GetEstimatedTotalRegardlessOfFundingType();
            var estimatedTotalUpdated = projectUpdateBatch.ProjectUpdate.GetEstimatedTotalRegardlessOfFundingType();

            var projectFundingSourceBudgetsByCostTypeOriginal = new List<ICostTypeFundingSourceBudgetAmount>(project.ProjectFundingSourceBudgets.ToList());
            var calendarYearsOriginal = project.FundingType == FundingType.BudgetVariesByYear ? project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears() : new List<int>();
            var projectFundingSourceBudgetsByCostTypeUpdated = new List<ICostTypeFundingSourceBudgetAmount>(projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList());
            var calendarYearsUpdated = projectUpdateBatch.ProjectUpdate.FundingType == FundingType.BudgetVariesByYear ? projectUpdateBatch.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears() : new List<int>();

            var originalHtml = GeneratePartialViewForOriginalBudgetsByCostType(fundingTypeOriginal, new List<ICostTypeFundingSourceBudgetAmount>(projectFundingSourceBudgetsByCostTypeOriginal), 
                calendarYearsOriginal, new List<ICostTypeFundingSourceBudgetAmount>(projectFundingSourceBudgetsByCostTypeUpdated), calendarYearsUpdated, noFundingSourceIdentifiedOriginal, estimatedTotalOriginal, projectFundingSourceCostTypeAmountsOriginal, project.ExpectedFundingUpdateNote);
            var updatedHtml = GeneratePartialViewForModifiedBudgetsByCostType(fundingTypeUpdated, new List<ICostTypeFundingSourceBudgetAmount>(projectFundingSourceBudgetsByCostTypeOriginal), 
                calendarYearsOriginal, new List<ICostTypeFundingSourceBudgetAmount>(projectFundingSourceBudgetsByCostTypeUpdated), calendarYearsUpdated, noFundingSourceIdentifiedUpdated, estimatedTotalUpdated, projectFundingSourceCostTypeAmountsUpdated, projectUpdateBatch.ExpectedFundingUpdateNote);
            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalBudgetsByCostType(FundingType fundingTypeOriginal, List<ICostTypeFundingSourceBudgetAmount> projectFundingSourceBudgetsByCostTypeOriginal,
            List<int> calendarYearsOriginal,
            List<ICostTypeFundingSourceBudgetAmount> projectFundingSourceBudgetsByCostTypeUpdated,
            List<int> calendarYearsUpdated, decimal? noFundingSourceIdentifiedOriginal, decimal? estimatedTotalOriginal,
            List<ProjectFundingSourceCostTypeAmount> projectFundingSourceCostTypeAmountsOriginal,
            string expectedFundingUpdateNote)
        {
            var fundingSourcesInOriginal = projectFundingSourceBudgetsByCostTypeOriginal.Select(x => x.FundingSource.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = projectFundingSourceBudgetsByCostTypeUpdated.Select(x => x.FundingSource.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInOriginal = fundingSourcesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x)).ToList();

            var projectBudgetByCostTypesInOriginal = ProjectBudgetByCostType.CreateFromProjectBudgets(projectFundingSourceBudgetsByCostTypeOriginal, calendarYearsOriginal);
            var projectBudgetByCostTypesInModified = ProjectBudgetByCostType.CreateFromProjectBudgets(projectFundingSourceBudgetsByCostTypeUpdated, calendarYearsUpdated);

            // find the ones that are only in the modified set and add them and mark them as "added"
            projectBudgetByCostTypesInOriginal.AddRange(
                projectBudgetByCostTypesInModified.Where(x => !fundingSourcesInOriginal.Contains(x.FundingSourceID))
                    .Select(x => ProjectBudgetByCostType.Clone(x, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            projectBudgetByCostTypesInOriginal.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID)).ToList()
                .ForEach(x =>
                {
                    x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
                });


            var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForBudgetsByCostTypeAsString(fundingTypeOriginal, projectBudgetByCostTypesInOriginal, calendarYearStrings, noFundingSourceIdentifiedOriginal, estimatedTotalOriginal, projectFundingSourceCostTypeAmountsOriginal, expectedFundingUpdateNote);
        }

        private string GeneratePartialViewForModifiedBudgetsByCostType(FundingType fundingTypeUpdated, List<ICostTypeFundingSourceBudgetAmount> projectFundingSourceBudgetsByCostTypeOriginal,
            List<int> calendarYearsOriginal,
            List<ICostTypeFundingSourceBudgetAmount> projectFundingSourceBudgetsByCostTypeUpdated,
            List<int> calendarYearsUpdated, decimal? noFundingSourceIdentifiedUpdated, decimal? estimatedTotalUpdated, List<ProjectFundingSourceCostTypeAmount> projectFundingSourceCostTypeAmountsUpdated, string expectedFundingUpdateNote)
        {
            var fundingSourcesInOriginal = projectFundingSourceBudgetsByCostTypeOriginal.Select(x => x.FundingSource.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = projectFundingSourceBudgetsByCostTypeUpdated.Select(x => x.FundingSource.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInUpdated = fundingSourcesInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x)).ToList();

            var projectBudgetByCostTypesInOriginal = ProjectBudgetByCostType.CreateFromProjectBudgets(projectFundingSourceBudgetsByCostTypeOriginal, calendarYearsOriginal);
            var projectBudgetByCostTypesInModified = ProjectBudgetByCostType.CreateFromProjectBudgets(projectFundingSourceBudgetsByCostTypeUpdated, calendarYearsUpdated);

            // find the ones that are only in the original set and add them and mark them as "deleted"
            projectBudgetByCostTypesInModified.AddRange(
                projectBudgetByCostTypesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x.FundingSourceID))
                    .Select(x => ProjectBudgetByCostType.Clone(x, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            // find the ones only in modified and mark them as "added"
            projectBudgetByCostTypesInModified.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForBudgetsByCostTypeAsString(fundingTypeUpdated, projectBudgetByCostTypesInModified, calendarYearStrings, noFundingSourceIdentifiedUpdated, estimatedTotalUpdated, projectFundingSourceCostTypeAmountsUpdated, expectedFundingUpdateNote);
        }

        private string GeneratePartialViewForBudgetsByCostTypeAsString(FundingType fundingType, List<ProjectBudgetByCostType> projectBudgetsByCostTypes, List<CalendarYearString> calendarYearStrings, decimal? noFundingSourceIdentified, decimal? estimatedTotal, List<ProjectFundingSourceCostTypeAmount> projectFundingSourceCostTypeAmounts, string expectedFundingUpdateNote)
        {
            var costTypes = projectBudgetsByCostTypes.Any(x => x.ProjectCostTypeCalendarYearBudgetAmounts != null) ? projectBudgetsByCostTypes.SelectMany(x => x.ProjectCostTypeCalendarYearBudgetAmounts.Select(y => y.CostType)).Distinct(new HavePrimaryKeyComparer<CostType>()).ToList() : projectFundingSourceCostTypeAmounts.Select(x => x.CostType).Distinct().ToList();

            var viewData = new ProjectBudgetsByCostTypeSummaryViewData(fundingType, projectBudgetsByCostTypes, calendarYearStrings, costTypes, noFundingSourceIdentified, estimatedTotal, projectFundingSourceCostTypeAmounts, expectedFundingUpdateNote);
            var partialViewAsString = RenderPartialViewToString(ProjectBudgetByCostTypePartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffPhotos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var htmlDiffContainer = DiffPhotosImpl(projectUpdateBatch);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffPhotosImpl(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;

            var originalImages = project.ProjectImages.Select(x => new FileResourcePhoto(x)).ToList();
            var updatedImages = projectUpdateBatch.ProjectImageUpdates.Select(x => new FileResourcePhoto(x)).ToList();

            foreach (var updatedImage in updatedImages)
            {
                var matchingOriginalImage = originalImages.SingleOrDefault(x => updatedImage.EntityImageIDAsNullable.HasValue && updatedImage.EntityImageIDAsNullable == x.PrimaryKey);
                if (matchingOriginalImage == null)
                {
                    var placeHolderImage = new FileResourcePhoto(updatedImage, new List<string> {"added-photo"});
                    updatedImage.AdditionalCssClasses = new List<string>() { "added-photo" };
                    originalImages.Add(placeHolderImage);
                }
            }

            foreach (var originalImage in originalImages)
            {
                var matchingUpdatedImage = updatedImages.SingleOrDefault(x => originalImage.PrimaryKey == x.EntityImageIDAsNullable);
                if (matchingUpdatedImage == null)
                {
                    var placeHolderImage = new FileResourcePhoto(originalImage, new List<string> { "deleted-photo" });
                    updatedImages.Add(placeHolderImage);
                }
                //else
                //{
                //    originalImage.OrderBy = matchingUpdatedImage.CaptionOnFullView;
                //}
            }

            var original = GeneratePartialViewForPhotos(originalImages);
            var updated = GeneratePartialViewForPhotos(updatedImages);

            var htmlDiff = new HtmlDiffContainer(original, updated);
            return htmlDiff;
        }

        private string GeneratePartialViewForPhotos(IEnumerable<FileResourcePhoto> images)
        {
            var viewData = new ImageGalleryViewData(CurrentPerson, "ProjectImageDiff", images, false, string.Empty, string.Empty, false, x => x.CaptionOnFullView, "Photo");
            var partialViewAsString = RenderPartialViewToString(ImageGalleryPartialViewPath, viewData);
            return partialViewAsString;
        }

        private static bool IsLocationSimpleUpdated(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");

            if (project.ProjectLocationSimpleTypeID != projectUpdateBatch.ProjectUpdate.ProjectLocationSimpleTypeID)
                return true;

            if (project.ProjectLocationNotes != projectUpdateBatch.ProjectUpdate.ProjectLocationNotes)
                return true;

            switch (project.ProjectLocationSimpleType.ToEnum)
            {
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                case ProjectLocationSimpleTypeEnum.LatLngInput:
                    if (project.ProjectLocationPoint == null || projectUpdateBatch.ProjectUpdate.ProjectLocationPoint == null)
                    {
                        SitkaLogger.Instance.LogDetailedErrorMessage($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.ProjectID} appears to have inconsistent simple location configuration.");
                        return true;
                    }
                    return project.ProjectLocationPoint.ToSqlGeometry().STEquals(projectUpdateBatch.ProjectUpdate.ProjectLocationPoint.ToSqlGeometry()).IsFalse;
            }

            return false;
        }

        private static bool IsLocationDetailedUpdated(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");

            var originalLocationDetailed = project.ProjectLocations;
            var updatedLocationDetailed = projectUpdateBatch.ProjectLocationUpdates;

            if (!originalLocationDetailed.Any() && !updatedLocationDetailed.Any())
                return false;

            if (originalLocationDetailed.Count != updatedLocationDetailed.Count)
                return true;

            var originalLocationAsListOfStrings = originalLocationDetailed.Select(x => x.ProjectLocationGeometry.ToString() + x.Annotation).ToList();
            var updatedLocationAsListOfStrings = updatedLocationDetailed.Select(x => x.ProjectLocationUpdateGeometry.ToString() + x.Annotation).ToList();

            var enumerable = originalLocationAsListOfStrings.Except(updatedLocationAsListOfStrings);
            return enumerable.Any();
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExternalLinksImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExternalLinksImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var entityExternalLinksOriginal = new List<IEntityExternalLink>(project.ProjectExternalLinks);
            var entityExternalLinksUpdated = new List<IEntityExternalLink>(projectUpdateBatch.ProjectExternalLinkUpdates);

            var originalHtml = GeneratePartialViewForOriginalExternalLinks(entityExternalLinksOriginal, entityExternalLinksUpdated);
            var updatedHtml = GeneratePartialViewForModifiedExternalLinks(entityExternalLinksOriginal, entityExternalLinksUpdated);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalExternalLinks(List<IEntityExternalLink> entityExternalLinksOriginal, List<IEntityExternalLink> entityExternalLinksUpdated)
        {
            var urlsInOriginal = entityExternalLinksOriginal.Select(x => x.GetExternalLinkAsUrl()).Distinct().ToList();
            var urlsInModified = entityExternalLinksUpdated.Select(x => x.GetExternalLinkAsUrl()).Distinct().ToList();
            var urlsOnlyInOriginal = urlsInOriginal.Where(x => !urlsInModified.Contains(x)).ToList();

            var externalLinksOriginal = ExternalLink.CreateFromEntityExternalLink(entityExternalLinksOriginal);
            var externalLinksUpdated = ExternalLink.CreateFromEntityExternalLink(entityExternalLinksUpdated);
            // find the ones that are only in the modified set and add them and mark them as "added"
            externalLinksOriginal.AddRange(
                externalLinksUpdated.Where(x => !urlsInOriginal.Contains(x.GetExternalLinkAsUrl()))
                    .Select(x => new ExternalLink(x.ExternalLinkLabel, x.ExternalLinkUrl, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            externalLinksOriginal.Where(x => urlsOnlyInOriginal.Contains(x.GetExternalLinkAsUrl())).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);
            return GeneratePartialViewForExternalLinks(externalLinksOriginal);
        }

        private string GeneratePartialViewForModifiedExternalLinks(List<IEntityExternalLink> entityExternalLinksOriginal, List<IEntityExternalLink> entityExternalLinksUpdated)
        {
            var urlsInOriginal = entityExternalLinksOriginal.Select(x => x.GetExternalLinkAsUrl()).Distinct().ToList();
            var urlsInUpdated = entityExternalLinksUpdated.Select(x => x.GetExternalLinkAsUrl()).Distinct().ToList();
            var urlsOnlyInUpdated = urlsInUpdated.Where(x => !urlsInOriginal.Contains(x)).ToList();

            var externalLinksOriginal = ExternalLink.CreateFromEntityExternalLink(entityExternalLinksOriginal);
            var externalLinksUpdated = ExternalLink.CreateFromEntityExternalLink(entityExternalLinksUpdated);
            // find the ones that are only in the original set and add them and mark them as "deleted"
            externalLinksUpdated.AddRange(
                externalLinksOriginal.Where(x => !urlsInUpdated.Contains(x.GetExternalLinkAsUrl()))
                    .Select(x => new ExternalLink(x.ExternalLinkLabel, x.ExternalLinkUrl, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            externalLinksUpdated.Where(x => urlsOnlyInUpdated.Contains(x.GetExternalLinkAsUrl())).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);
            return GeneratePartialViewForExternalLinks(externalLinksUpdated);
        }

        private string GeneratePartialViewForExternalLinks(List<ExternalLink> entityExternalLinks)
        {
            var viewData = new EntityExternalLinksViewData(entityExternalLinks);
            var partialViewToString = RenderPartialViewToString(ExternalLinksPartialViewPath, viewData);
            return partialViewToString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffNotesAndDocuments(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffNotesAndDocumentsImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffNotesAndDocumentsImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project,$"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");
            var entityNotesOriginal = project.ProjectNotes.ToList();
            var entityNotesUpdated = projectUpdateBatch.ProjectNoteUpdates.ToList();

            var originalHtmlNotes = GeneratePartialViewForOriginalNotes(entityNotesOriginal, entityNotesUpdated);
            var updatedHtmlNotes = GeneratePartialViewForModifiedNotes(entityNotesOriginal, entityNotesUpdated);
            // TODO: Commented out until such time as it is appropriate to take this feature live
            //var entityDocumentsOriginal = new List<IEntityDocument>(project.ProjectDocuments);
            //var entityDocumentsUpdated = new List<IEntityDocument>(projectUpdateBatch.ProjectDocumentUpdates);
            //var originalHtmlDocuments = GeneratePartialViewForOriginalDocuments(entityDocumentsOriginal, entityDocumentsUpdated);
            //var updatedHtmlDocuments = GeneratePartialViewForModifiedDocuments(entityDocumentsOriginal, entityDocumentsUpdated);

            var originalHtml = originalHtmlNotes;//+ originalHtmlDocuments;
            var updatedHtml = updatedHtmlNotes; //updatedHtmlDocuments;

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalNotes(List<ProjectNote> entityNotesOriginal, List<ProjectNoteUpdate> entityNotesUpdated)
        {
            var urlsInOriginal = entityNotesOriginal.Select(x => x.Note).Distinct().ToList();
            var urlsInModified = entityNotesUpdated.Select(x => x.Note).Distinct().ToList();
            var urlsOnlyInOriginal = urlsInOriginal.Where(x => !urlsInModified.Contains(x)).ToList();

            var externalLinksOriginal = EntityNote.CreateFromEntityNote(entityNotesOriginal);
            var externalLinksUpdated = EntityNote.CreateFromEntityNote(entityNotesUpdated);
            // find the ones that are only in the modified set and add them and mark them as "added"
            externalLinksOriginal.AddRange(
                externalLinksUpdated.Where(x => !urlsInOriginal.Contains(x.Note))
                    .Select(x => new EntityNote(x.GetLastUpdated(), x.GetLastUpdatedBy(), x.GetDeleteUrl(), x.GetEditUrl(), x.Note, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            externalLinksOriginal.Where(x => urlsOnlyInOriginal.Contains(x.Note)).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);
            return GeneratePartialViewForNotes(externalLinksOriginal);
        }

        private string GeneratePartialViewForModifiedNotes(List<ProjectNote> entityNotesOriginal, List<ProjectNoteUpdate> entityNotesUpdated)
        {
            var urlsInOriginal = entityNotesOriginal.Select(x => x.Note).Distinct().ToList();
            var urlsInUpdated = entityNotesUpdated.Select(x => x.Note).Distinct().ToList();
            var urlsOnlyInUpdated = urlsInUpdated.Where(x => !urlsInOriginal.Contains(x)).ToList();

            var externalLinksOriginal = EntityNote.CreateFromEntityNote(entityNotesOriginal);
            var externalLinksUpdated = EntityNote.CreateFromEntityNote(entityNotesUpdated);
            // find the ones that are only in the original set and add them and mark them as "deleted"
            externalLinksUpdated.AddRange(
                externalLinksOriginal.Where(x => !urlsInUpdated.Contains(x.Note))
                    .Select(x => new EntityNote(x.GetLastUpdated(), x.GetLastUpdatedBy(), x.GetDeleteUrl(), x.GetEditUrl(), x.Note, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            externalLinksUpdated.Where(x => urlsOnlyInUpdated.Contains(x.Note)).ToList().ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);
            return GeneratePartialViewForNotes(externalLinksUpdated);
        }

        private string GeneratePartialViewForNotes(List<EntityNote> entityNotes)
        {
            var viewData = new EntityNotesViewData(entityNotes, null, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", false);
            var partialViewToString = RenderPartialViewToString(EntityNotesPartialViewPath, viewData);
            return partialViewToString;
        }

        // TODO: Commented out until such time as it is appropriate to take this feature live
        //private string GeneratePartialViewForOriginalDocuments(List<IEntityDocument> entityDocumentsOriginal, List<IEntityDocument> entityDocumentsUpdated)
        //{
        //    var fileResourceIDsInOriginal = entityDocumentsOriginal.Select(x=>x.FileResource.FileResourceID).ToList();
        //    var fileResourceIDsInModified = entityDocumentsUpdated.Select(x => x.FileResource.FileResourceID).ToList();
        //    var urlsOnlyInOriginal = fileResourceIDsInOriginal.Where(x => !fileResourceIDsInModified.Contains(x)).ToList();

        //    var externalLinksOriginal = EntityDocument.CreateFromEntityDocument(entityDocumentsOriginal);
        //    var externalLinksUpdated = EntityDocument.CreateFromEntityDocument(entityDocumentsUpdated);
        //    // find the ones that are only in the modified set and add them and mark them as "added"
        //    externalLinksOriginal.AddRange(
        //        externalLinksUpdated.Where(x => !fileResourceIDsInOriginal.Contains(x.FileResource.FileResourceID))
        //            .Select(x => new EntityDocument(x.DeleteUrl,x.EditUrl,x.FileResource,HtmlDiffContainer.DisplayCssClassAddedElement, x.DisplayName, x.Description))
        //            .ToList());
        //    // find the ones only in original and mark them as "deleted"
        //    externalLinksOriginal.Where(x => urlsOnlyInOriginal.Contains(x.FileResource.FileResourceID)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);
        //    return GeneratePartialViewForDocuments(externalLinksOriginal.OrderBy(x => x.FileResource.FileResourceID).ToList());
        ////}

        //private string GeneratePartialViewForModifiedDocuments(List<IEntityDocument> entityDocumentsOriginal, List<IEntityDocument> entityDocumentsUpdated)
        //{
        //     var fileResouceIDsInOriginal = entityDocumentsOriginal.Select(x => x.FileResource.FileResourceID).ToList();
        //    var fileResourceIDsInModified = entityDocumentsUpdated.Select(x => x.FileResource.FileResourceID).ToList();
        //    var urlsOnlyInUpdated = fileResourceIDsInModified.Where(x => !fileResouceIDsInOriginal.Contains(x)).ToList();

        //    var externalLinksOriginal = EntityDocument.CreateFromEntityDocument(entityDocumentsOriginal);
        //    var externalLinksUpdated = EntityDocument.CreateFromEntityDocument(entityDocumentsUpdated);
        //    // find the ones that are only in the original set and add them and mark them as "deleted"
        //    externalLinksUpdated.AddRange(
        //        externalLinksOriginal.Where(x => !fileResourceIDsInModified.Contains(x.FileResource.FileResourceID))
        //            .Select(x => new EntityDocument(x.DeleteUrl, x.EditUrl, x.FileResource, HtmlDiffContainer.DisplayCssClassDeletedElement, x.DisplayName, x.Description))
        //            .ToList());
        //    externalLinksUpdated.Where(x => urlsOnlyInUpdated.Contains(x.FileResource.FileResourceID)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);
        //    return GeneratePartialViewForDocuments(externalLinksUpdated.OrderBy(x=>x.FileResource.FileResourceID).ToList());
        //}
        //private string GeneratePartialViewForDocuments(List<EntityDocument> entityDocuments)
        //{
        //    var viewData = new ProjectDocumentsDetailViewData(entityDocuments, null, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", false, false);
        //    var partialViewToString = RenderPartialViewToString(ProjectDocumentsPartialViewPath, viewData);
        //    return partialViewToString;
        //}


        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public PartialViewResult ProjectUpdateBatchDiff(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            var viewData = new ProjectUpdateBatchDiffLogViewData(CurrentPerson, projectUpdateBatch);
            var partialViewToString = RenderPartialViewToString(ProjectUpdateBatchDiffLogPartialViewPath, viewData);
            return ViewHtmlDiff(partialViewToString,$"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update from {projectUpdateBatch.LastUpdateDate.ToLongDateString()}");
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult Organizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }

            var viewModel = new OrganizationsViewModel(projectUpdateBatch);

            return ViewOrganizations(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Organizations(ProjectPrimaryKey projectPrimaryKey, OrganizationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }

            if (!ModelState.IsValid)
            {
                return ViewOrganizations(projectUpdateBatch, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ProjectOrganizationUpdates.Load();
            var projectOrganizationUpdates = projectUpdateBatch.ProjectOrganizationUpdates.ToList();
            var allProjectOrganizationUpdates = HttpRequestStorage.DatabaseEntities.AllProjectOrganizationUpdates.Local;

            viewModel.UpdateModel(projectUpdateBatch,projectOrganizationUpdates, allProjectOrganizationUpdates);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.OrganizationsComment = viewModel.Comments;
            }

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()} successfully saved.");

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Organizations.ProjectUpdateSectionDisplayName);
        }

        private ActionResult ViewOrganizations(ProjectUpdateBatch projectUpdateBatch, OrganizationsViewModel viewModel)
        {
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var organizationsValidationResult = projectUpdateBatch.ValidateOrganizations();

            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.GetFullNameFirstLastAndOrg()).ToList();
            if (!allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allOrganizationRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.ToList();
            var defaultPrimaryContact = projectUpdateBatch.Project?.GetPrimaryContact() ?? CurrentPerson.Organization.PrimaryContactPerson;
            
            var editOrganizationsViewData = new EditOrganizationsViewData(projectUpdateBatch.ProjectUpdate, allOrganizations, allPeople, allOrganizationRelationshipTypes, defaultPrimaryContact);

            var projectOrganizationsDetailViewData = new ProjectOrganizationsDetailViewData(projectUpdateBatch.ProjectOrganizationUpdates.Select(x => new ProjectOrganizationRelationship(x.ProjectUpdateBatch.Project, x.Organization, x.OrganizationRelationshipType)).ToList(), projectUpdateBatch.ProjectUpdate.GetPrimaryContact());
            var viewData = new OrganizationsViewData(CurrentPerson, projectUpdateBatch, updateStatus, editOrganizationsViewData, organizationsValidationResult,projectOrganizationsDetailViewData);

            return RazorView<Organizations, OrganizationsViewData, OrganizationsViewModel>(viewData, viewModel);
        }

        private ProjectUpdateStatus GetUpdateStatus(ProjectUpdateBatch projectUpdateBatch)
        {
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID))
            {
                return new ProjectUpdateStatus(false, false, false, false, false, false, false, false, false, false, false, false, false);
            }
            var isPerformanceMeasuresUpdated = DiffReportedPerformanceMeasuresImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isExpendituresUpdated = MultiTenantHelpers.GetTenantAttribute().BudgetType == BudgetType.AnnualBudgetByCostType ? DiffExpendituresByCostTypeImpl(projectUpdateBatch.ProjectID).HasChanged : DiffExpendituresImpl(projectUpdateBatch.ProjectID).HasChanged; 
            var isBudgetsUpdated = MultiTenantHelpers.GetTenantAttribute().BudgetType == BudgetType.AnnualBudgetByCostType ? DiffExpectedFundingByCostTypeImpl(projectUpdateBatch.ProjectID).HasChanged : DiffExpectedFundingImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isLocationSimpleUpdated = IsLocationSimpleUpdated(projectUpdateBatch.ProjectID);
            var isLocationDetailUpdated = IsLocationDetailedUpdated(projectUpdateBatch.ProjectID);
            var isExternalLinksUpdated = DiffExternalLinksImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isNotesUpdated = DiffNotesAndDocumentsImpl(projectUpdateBatch.ProjectID).HasChanged;

            //Must be called last, since basics actually changes the Project object which can break the other Diff functions
            var isBasicsUpdated = DiffBasicsImpl(projectUpdateBatch.ProjectID).HasChanged;


            var isOrganizationsUpdated = DiffOrganizationsImpl(projectUpdateBatch.ProjectID).HasChanged;

            var isContactsUpdated = DiffContactsImpl(projectUpdateBatch.ProjectID).HasChanged;

            var isExpectedPerformanceMeasuresUpdated = DiffExpectedPerformanceMeasuresImpl(projectUpdateBatch.ProjectID).HasChanged;

            var isTechnicalAssistanceRequestsUpdated = projectUpdateBatch.TenantID == Tenant.IdahoAssociatonOfSoilConservationDistricts.TenantID;

            return new ProjectUpdateStatus(isBasicsUpdated,
                isPerformanceMeasuresUpdated,
                isExpendituresUpdated,
                isBudgetsUpdated,
                projectUpdateBatch.IsPhotosUpdated,
                isLocationSimpleUpdated,
                isLocationDetailUpdated,
                isExternalLinksUpdated,
                isNotesUpdated,
                isOrganizationsUpdated,
                isExpectedPerformanceMeasuresUpdated,
                isTechnicalAssistanceRequestsUpdated,
                isContactsUpdated);
        }

        private PartialViewResult ViewHtmlDiff(string htmlDiff, string diffTitle)
        {
            var viewData = new HtmlDiffSummaryViewData(htmlDiff, diffTitle);
            return RazorPartialView<HtmlDiffSummary, HtmlDiffSummaryViewData>(viewData);
        }

        private static List<CalendarYearString> GetCalendarYearStringsForDiffForOriginal(List<int> calendarYearsOriginal, List<int> calendarYearsUpdated)
        {
            var calendarYearStrings = new List<CalendarYearString>();
            // get the calendar years that are not in the original and add them and mark as "added"
            calendarYearsUpdated.Where(x => !calendarYearsOriginal.Contains(x)).ToList().ForEach(x => calendarYearStrings.Add(new CalendarYearString(x, AddedDeletedOrRealElement.AddedElement)));
            // now go through all the original calendar years and mark them as either "deleted" or an update, with "deleted" meaning not being in the modified set
            calendarYearStrings.AddRange(calendarYearsOriginal.Select(x => new CalendarYearString(x, !calendarYearsUpdated.Contains(x) ? AddedDeletedOrRealElement.DeletedElement : AddedDeletedOrRealElement.RealElement)));
            return calendarYearStrings;
        }

        private static List<CalendarYearString> GetCalendarYearStringsForDiffForUpdated(List<int> calendarYearsOriginal, List<int> calendarYearsUpdated)
        {
            var calendarYearStrings = new List<CalendarYearString>();
            // get the calendar years that are not in the modified and add them and mark as "deleted"
            calendarYearsOriginal.Where(x => !calendarYearsUpdated.Contains(x)).ToList().ForEach(x => calendarYearStrings.Add(new CalendarYearString(x, AddedDeletedOrRealElement.DeletedElement)));
            // now go through all the modified calendar years and mark them as either "added" or an update, with "added" meaning not being in the original set
            calendarYearStrings.AddRange(calendarYearsUpdated.Select(i => new CalendarYearString(i, !calendarYearsOriginal.Contains(i) ? AddedDeletedOrRealElement.AddedElement : AddedDeletedOrRealElement.RealElement)));
            return calendarYearStrings;
        }

        private ActionResult TickleLastUpdateDateAndGoToNextSection(FormViewModel viewModel, ProjectUpdateBatch projectUpdateBatch, string currentSectionName)
        {
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            var applicableWizardSections = projectUpdateBatch.GetApplicableWizardSections(true);
            var currentSection = applicableWizardSections.Single(x => x.SectionDisplayName.Equals(currentSectionName, StringComparison.InvariantCultureIgnoreCase));
            var nextProjectUpdateSection = applicableWizardSections.Where(x => x.SortOrder > currentSection.SortOrder).OrderBy(x => x.SortOrder).FirstOrDefault();
            var nextSection = viewModel.AutoAdvance && nextProjectUpdateSection != null ? nextProjectUpdateSection.SectionUrl : currentSection.SectionUrl;
            return Redirect(nextSection);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult RefreshOrganizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshOrganizations(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshOrganizations(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectOrganizationUpdates();
            // refresh data
            ProjectOrganizationUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshOrganizations(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffOrganizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffOrganizationsImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffOrganizationsImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");

            var projectOrganizationsOriginal = new List<IProjectOrganization>(project.ProjectOrganizations.ToList());
            var projectOrganizationsUpdated = new List<IProjectOrganization>(projectUpdateBatch.ProjectOrganizationUpdates.ToList());

            var updatedHtml = GeneratePartialViewForModifiedOrganizations(projectOrganizationsOriginal, projectOrganizationsUpdated, projectUpdateBatch.ProjectUpdate);
            var originalHtml = GeneratePartialViewForOriginalOrganizations(projectOrganizationsOriginal, projectOrganizationsUpdated, projectUpdateBatch.Project);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForModifiedOrganizations(
            List<IProjectOrganization> projectOrganizationsOriginal,
            List<IProjectOrganization> projectOrganizationsUpdated, ProjectUpdate projectUpdate)
        {
            var organizationsInOriginal = projectOrganizationsOriginal;
            var organizationsInUpdated = projectOrganizationsUpdated;
            var comparer = new ProjectOrganizationEqualityComparer();

            var organizationsOnlyInOriginal = organizationsInOriginal.Where(x => !organizationsInUpdated.Contains(x, comparer)).ToList();
            var projectOrganizations = projectOrganizationsOriginal.Select(x => new ProjectOrganization(x)).ToList();


            projectOrganizations.AddRange(projectOrganizationsUpdated.Where(x => !organizationsInOriginal.Contains(x, comparer)).Select(x =>
                new ProjectOrganization(x.Organization, x.OrganizationRelationshipType, HtmlDiffContainer.DisplayCssClassAddedElement)));
            projectOrganizations
                .Where(x => organizationsOnlyInOriginal.Contains(x, comparer)).ToList()
                .ForEach(x => x.SetDisplayCssClass(HtmlDiffContainer.DisplayCssClassDeletedElement));

            return GeneratePartialViewForOrganizationsAsString(projectOrganizations, projectUpdate.GetPrimaryContact());
        }

        private string GeneratePartialViewForOriginalOrganizations(
            List<IProjectOrganization> projectOrganizationsOriginal,
            List<IProjectOrganization> projectOrganizationsUpdated, Project project)
        {
            var organizationsInOriginal = projectOrganizationsOriginal;
            var organizationsInUpdated = projectOrganizationsUpdated;
            var comparer = new ProjectOrganizationEqualityComparer();

            var organizationsOnlyInUpdated = organizationsInUpdated.Where(x => !organizationsInOriginal.Contains(x, comparer)).ToList();
            var projectOrganizations = projectOrganizationsUpdated.Select(x => new ProjectOrganization(x)).ToList();

            projectOrganizations.AddRange(projectOrganizationsOriginal.Where(x => !organizationsInUpdated.Contains(x, comparer)).Select(x =>
                new ProjectOrganization(x.Organization, x.OrganizationRelationshipType, HtmlDiffContainer.DisplayCssClassDeletedElement)));
            projectOrganizations
                .Where(x => organizationsOnlyInUpdated.Contains(x, comparer)).ToList()
                .ForEach(x => x.SetDisplayCssClass(HtmlDiffContainer.DisplayCssClassAddedElement));

            return GeneratePartialViewForOrganizationsAsString(projectOrganizations, project.GetPrimaryContact());
        }

        private string GeneratePartialViewForOrganizationsAsString(IEnumerable<ProjectOrganization> projectOrganizations, Person primaryContactPerson)
        {
            var viewData = new ProjectOrganizationsDetailViewData(projectOrganizations.Select(x => new ProjectOrganizationRelationship(x.Project, x.Organization, x.OrganizationRelationshipType, x.GetDisplayCssClass())).ToList(), primaryContactPerson);
            var partialViewAsString = RenderPartialViewToString(ProjectOrganizationsPartialViewPath, viewData);
            return partialViewAsString;
        }

        public class ProjectOrganizationEqualityComparer : EqualityComparerByProperty<IProjectOrganization>
        {
            public ProjectOrganizationEqualityComparer() : base(x => new {x.Organization.OrganizationID, x.OrganizationRelationshipType.OrganizationRelationshipTypeID })
            {
            }
        }


        #region 'Contacts'
        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult Contacts(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }

            var viewModel = new ContactsViewModel(projectUpdateBatch);

            return ViewContacts(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Contacts(ProjectPrimaryKey projectPrimaryKey, ContactsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }

            if (!ModelState.IsValid)
            {
                return ViewContacts(projectUpdateBatch, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ProjectContactUpdates.Load();
            var projectContactUpdates = projectUpdateBatch.ProjectContactUpdates.ToList();
            var allProjectContactUpdates = HttpRequestStorage.DatabaseEntities.AllProjectContactUpdates.Local;

            viewModel.UpdateModel(projectUpdateBatch, projectContactUpdates, allProjectContactUpdates);
            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatch.ContactsComment = viewModel.Comments;
            }

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Contact successfully saved.");

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Contacts.ProjectUpdateSectionDisplayName);
        }

        private ActionResult ViewContacts(ProjectUpdateBatch projectUpdateBatch, ContactsViewModel viewModel)
        {
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var contactsValidationResult = projectUpdateBatch.ValidateContacts();

            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.GetFullNameLastFirst()).ToList();
            if (!allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allContactRelationshipTypes = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.ToList();

            var editContactsViewData = new EditContactsViewData(allPeople, allContactRelationshipTypes);

            var projectContactsDetailViewData = new ProjectContactsDetailViewData(projectUpdateBatch.ProjectContactUpdates.Select(x => new ProjectContactRelationship(x.ProjectUpdateBatch.Project, x.Contact, x.ContactRelationshipType)).ToList(), projectUpdateBatch.ProjectUpdate.GetPrimaryContact());
            var viewData = new ContactsViewData(CurrentPerson, projectUpdateBatch, updateStatus, editContactsViewData, contactsValidationResult, projectContactsDetailViewData);

            return RazorView<Contacts, ContactsViewData, ContactsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult RefreshContacts(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshContacts(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshContacts(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectContactUpdates();
            // refresh data
            ProjectContactUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshContacts(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the Contacts for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffContacts(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffContactsImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffContactsImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {project.GetDisplayName()}");

            var projectContactsOriginal = new List<IProjectContact>(project.ProjectContacts.ToList());
            var projectContactsUpdated = new List<IProjectContact>(projectUpdateBatch.ProjectContactUpdates.ToList());

            var updatedHtml = GeneratePartialViewForModifiedContacts(projectContactsOriginal, projectContactsUpdated, projectUpdateBatch.ProjectUpdate);
            var originalHtml = GeneratePartialViewForOriginalContacts(projectContactsOriginal, projectContactsUpdated, projectUpdateBatch.Project);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForModifiedContacts(
            List<IProjectContact> projectContactsOriginal,
            List<IProjectContact> projectContactsUpdated, ProjectUpdate projectUpdate)
        {
            var contactsInOriginal = projectContactsOriginal;
            var contactsInUpdated = projectContactsUpdated;
            var comparer = new ProjectContactEqualityComparer();

            var contactsOnlyInOriginal = contactsInOriginal.Where(x => !contactsInUpdated.Contains(x, comparer)).ToList();
            var projectContacts = projectContactsOriginal.Select(x => new ProjectContact(x)).ToList();


            projectContacts.AddRange(projectContactsUpdated.Where(x => !contactsInOriginal.Contains(x, comparer)).Select(x =>
                new ProjectContact(x.Contact, x.ContactRelationshipType, HtmlDiffContainer.DisplayCssClassAddedElement)));
            projectContacts
                .Where(x => contactsOnlyInOriginal.Contains(x, comparer)).ToList()
                .ForEach(x => x.SetDisplayCssClass(HtmlDiffContainer.DisplayCssClassDeletedElement));

            return GeneratePartialViewForContactsAsString(projectContacts, projectUpdate.GetPrimaryContact());
        }

        private string GeneratePartialViewForOriginalContacts(
            List<IProjectContact> projectContactsOriginal,
            List<IProjectContact> projectContactsUpdated, Project project)
        {
            var contactsInOriginal = projectContactsOriginal;
            var contactsInUpdated = projectContactsUpdated;
            var comparer = new ProjectContactEqualityComparer();

            var contactsOnlyInUpdated = contactsInUpdated.Where(x => !contactsInOriginal.Contains(x, comparer)).ToList();
            var projectContacts = projectContactsUpdated.Select(x => new ProjectContact(x)).ToList();

            projectContacts.AddRange(projectContactsOriginal.Where(x => !contactsInUpdated.Contains(x, comparer)).Select(x =>
                new ProjectContact(x.Contact, x.ContactRelationshipType, HtmlDiffContainer.DisplayCssClassDeletedElement)));
            projectContacts
                .Where(x => contactsOnlyInUpdated.Contains(x, comparer)).ToList()
                .ForEach(x => x.SetDisplayCssClass(HtmlDiffContainer.DisplayCssClassAddedElement));

            return GeneratePartialViewForContactsAsString(projectContacts, project.GetPrimaryContact());
        }

        private string GeneratePartialViewForContactsAsString(IEnumerable<ProjectContact> projectContacts, Person primaryContactPerson)
        {
            var viewData = new ProjectContactsDetailViewData(projectContacts.Select(x => new ProjectContactRelationship(x.Project, x.Contact, x.ContactRelationshipType, x.GetDisplayCssClass())).ToList(), primaryContactPerson);
            var partialViewAsString = RenderPartialViewToString(ProjectContactsPartialViewPath, viewData);
            return partialViewAsString;
        }

        public class ProjectContactEqualityComparer : EqualityComparerByProperty<IProjectContact>
        {
            public ProjectContactEqualityComparer() : base(x => new { x.Contact.PersonID, x.ContactRelationshipType.ContactRelationshipTypeID })
            {
            }
        }
        #endregion 'Contacts'




        // BootstrapHtmlHelper's alert modal dialog method isn't great at dealing with near-arbitrary HTML like we expect these "Intro Content" strings to be, so we're using the From Url version instead, which seems to work better.

        [ProjectUpdateAdminFeature]
        public ContentResult KickOffIntroPreview()
        {
            return new ContentResult
            {
                Content = EmailContentPreview(MultiTenantHelpers.GetProjectUpdateConfiguration().ProjectUpdateKickOffIntroContent)
            };
        }

        [ProjectUpdateAdminFeature]
        public ContentResult ReminderIntroPreview()
        {
            return new ContentResult
            {
                Content = EmailContentPreview(MultiTenantHelpers.GetProjectUpdateConfiguration().ProjectUpdateReminderIntroContent) 
            };
        }

        [ProjectUpdateAdminFeature]
        public ContentResult CloseOutIntroPreview()
        {
            return new ContentResult
            {
                Content = EmailContentPreview(MultiTenantHelpers.GetProjectUpdateConfiguration().ProjectUpdateCloseOutIntroContent)
            };
        }

        private static string EmailContentPreview(string introContent)
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();

            var emailContentPreview = new ProjectUpdateNotificationHelper(
                tenantAttribute.PrimaryContactPerson.Email, introContent, "",
                tenantAttribute.TenantSquareLogoFileResource,
                MultiTenantHelpers.GetToolDisplayName()).GetEmailContentPreview();

            return emailContentPreview;
        }
    }
}
