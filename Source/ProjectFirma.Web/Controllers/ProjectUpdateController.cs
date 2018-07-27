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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.ProjectExternalLink;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using MoreLinq;
using ProjectFirma.Web.ScheduledJobs;
using ProjectFirma.Web.Views.ProjectFunding;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectDocument;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls;
using ProjectFirma.Web.Views.Shared.ProjectWatershedControls;
using ProjectFirma.Web.Views.Shared.SortOrder;
using Basics = ProjectFirma.Web.Views.ProjectUpdate.Basics;
using BasicsViewData = ProjectFirma.Web.Views.ProjectUpdate.BasicsViewData;
using BasicsViewModel = ProjectFirma.Web.Views.ProjectUpdate.BasicsViewModel;
using ExpectedFunding = ProjectFirma.Web.Views.ProjectUpdate.ExpectedFunding;
using ExpectedFundingViewData = ProjectFirma.Web.Views.ProjectUpdate.ExpectedFundingViewData;
using ExpectedFundingViewModel = ProjectFirma.Web.Views.ProjectUpdate.ExpectedFundingViewModel;
using Expenditures = ProjectFirma.Web.Views.ProjectUpdate.Expenditures;
using ExpendituresViewData = ProjectFirma.Web.Views.ProjectUpdate.ExpendituresViewData;
using ExpendituresViewModel = ProjectFirma.Web.Views.ProjectUpdate.ExpendituresViewModel;
using LocationDetailed = ProjectFirma.Web.Views.ProjectUpdate.LocationDetailed;
using LocationDetailedViewData = ProjectFirma.Web.Views.ProjectUpdate.LocationDetailedViewData;
using LocationDetailedViewModel = ProjectFirma.Web.Views.ProjectUpdate.LocationDetailedViewModel;
using LocationSimple = ProjectFirma.Web.Views.ProjectUpdate.LocationSimple;
using LocationSimpleViewData = ProjectFirma.Web.Views.ProjectUpdate.LocationSimpleViewData;
using LocationSimpleViewModel = ProjectFirma.Web.Views.ProjectUpdate.LocationSimpleViewModel;
using PerformanceMeasures = ProjectFirma.Web.Views.ProjectUpdate.PerformanceMeasures;
using PerformanceMeasuresViewData = ProjectFirma.Web.Views.ProjectUpdate.PerformanceMeasuresViewData;
using PerformanceMeasuresViewModel = ProjectFirma.Web.Views.ProjectUpdate.PerformanceMeasuresViewModel;
using Photos = ProjectFirma.Web.Views.ProjectUpdate.Photos;
using WatershedViewData = ProjectFirma.Web.Views.ProjectUpdate.WatershedViewData;
using WatershedViewModel = ProjectFirma.Web.Views.ProjectUpdate.WatershedViewModel;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectUpdateController : FirmaBaseController
    {
        public const string ProjectUpdateBatchDiffLogPartialViewPath = "~/Views/ProjectUpdate/ProjectUpdateBatchDiffLog.cshtml";
        public const string ProjectBasicsPartialViewPath = "~/Views/Shared/ProjectControls/ProjectBasics.cshtml";
        public const string PerformanceMeasureReportedValuesPartialViewPath = "~/Views/Shared/PerformanceMeasureControls/PerformanceMeasureReportedValuesSummary.cshtml";
        public const string ProjectExpendituresPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectExpendituresSummary.cshtml";
        public const string ProjectExpectedFundingPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectFundingRequestsDetail.cshtml";
        public const string TransporationBudgetsPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectBudgetSummary.cshtml";
        public const string ImageGalleryPartialViewPath = "~/Views/Shared/ImageGallery.cshtml";
        public const string ExternalLinksPartialViewPath = "~/Views/Shared/TextControls/EntityExternalLinks.cshtml";
        public const string EntityNotesPartialViewPath = "~/Views/Shared/TextControls/EntityNotes.cshtml";
        public const string ProjectOrganizationsPartialViewPath = "~/Views/Shared/ProjectOrganization/ProjectOrganizationsDetail.cshtml";
        public const string ProjectDocumentsPartialViewPath = "~/Views/Shared/ProjectDocument/ProjectDocumentsDetail.cshtml";

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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.MyProjects);
            var viewData = new MyProjectsViewData(CurrentPerson, firmaPage, projectUpdateStatusFilterTypeEnum, gridDataUrl);
            return RazorView<MyProjects, MyProjectsViewData>(viewData);
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<Project> IndexGridJsonData(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterType)
        {
            var gridSpec = new ProjectUpdateStatusGridSpec(projectUpdateStatusFilterType, CurrentPerson.IsApprover());
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(p => p.IsUpdatableViaProjectUpdateProcess);

            switch (projectUpdateStatusFilterType)
            {
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllMyProjects:
                    projects = projects.Where(p => p.IsMyProject(CurrentPerson));
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MyProjectsRequiringAnUpdate:
                    projects = projects.Where(p => p.IsMyProject(CurrentPerson) && p.IsUpdateMandatory && p.GetLatestUpdateState() != ProjectUpdateState.Submitted);
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects:
                    projects = projects.Where(p => p.IsMyProject(CurrentPerson) && (!p.IsUpdateMandatory || p.GetLatestUpdateState() == ProjectUpdateState.Submitted));
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
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects.OrderBy(x => x.DisplayName).ToList(), gridSpec);
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
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new InstructionsViewData(CurrentPerson, projectUpdateBatch, updateStatus);
            return RazorView<Instructions, InstructionsViewData>(viewData);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        public RedirectResult Instructions(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNewAndSaveToDatabase(project, CurrentPerson);
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
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.BasicsComment = viewModel.Comments;
            }
            //projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            //return RedirectToAction(viewModel.AutoAdvance ? new SitkaRoute<ProjectUpdateController>(x=>x.LocationSimple(project)) : new SitkaRoute<ProjectUpdateController>(x => x.Basics(project)));
            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.Basics);
        }

        private ViewResult ViewBasics(ProjectUpdate projectUpdate, BasicsViewModel viewModel)
        {
            var basicsValidationResult = projectUpdate.ProjectUpdateBatch.ValidateProjectBasics();
            var inflationRate = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest().InflationRate;
            var updateStatus = GetUpdateStatus(projectUpdate.ProjectUpdateBatch); // note, the way the diff for the basics section is built, it will actually "commit" the updated values to the project, so it needs to be done last, or we need to change the current approach

            var projectStages = projectUpdate.ProjectUpdateBatch.Project.ProjectStage.GetProjectStagesThatProjectCanUpdateTo();
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList();
            var viewData = new BasicsViewData(CurrentPerson, projectUpdate, projectStages, inflationRate, updateStatus, basicsValidationResult, projectCustomAttributeTypes);
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
                projectUpdateBatch.DeleteProjectExemptReportingYearUpdates();
                projectUpdateBatch.DeletePerformanceMeasureActualUpdates();
            }
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshBasics(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {FieldDefinition.Project.GetFieldDefinitionLabel()} basics data? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            var performanceMeasureActualUpdateSimples =
                projectUpdateBatch.PerformanceMeasureActualUpdates.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(pam=>pam.PerformanceMeasure.DisplayName)
                    .ThenByDescending(x => x.CalendarYear)
                    .Select(x => new PerformanceMeasureActualUpdateSimple(x))
                    .ToList();
            var projectExemptReportingYearUpdates = projectUpdateBatch.ProjectExemptReportingYearUpdates.Select(x => new ProjectExemptReportingYearUpdateSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList();
            var possibleYearsToExempt = projectUpdateBatch.ProjectUpdate.GetProjectUpdateImplementationStartToCompletionYearRange();
            projectExemptReportingYearUpdates.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x))
                    .Select((x, index) => new ProjectExemptReportingYearUpdateSimple(-(index + 1), projectUpdateBatch.ProjectUpdateBatchID, x)));

            var viewModel = new PerformanceMeasuresViewModel(performanceMeasureActualUpdateSimples,
                projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation,
                projectExemptReportingYearUpdates.OrderBy(x => x.CalendarYear).ToList(),
                projectUpdateBatch.PerformanceMeasuresComment);
            return ViewPerformanceMeasures(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, PerformanceMeasuresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewPerformanceMeasures(projectUpdateBatch, viewModel);
            }
            var currentPerformanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualUpdates.Load();
            var allPerformanceMeasureActualUpdates = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualUpdates.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptionUpdates.Load();
            var allPerformanceMeasureActualSubcategoryOptionUpdates = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptionUpdates.Local;
            viewModel.UpdateModel(currentPerformanceMeasureActualUpdates, allPerformanceMeasureActualUpdates, allPerformanceMeasureActualSubcategoryOptionUpdates, projectUpdateBatch);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.PerformanceMeasuresComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.PerformanceMeasures);
        }

        private ViewResult ViewPerformanceMeasures(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasuresViewModel viewModel)
        {
            var performanceMeasures =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var showExemptYears = projectUpdateBatch.ProjectExemptReportingYearUpdates.Any() ||
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

            var viewDataForAngularEditor = new PerformanceMeasuresViewData.ViewDataForAngularEditor(projectUpdateBatch.ProjectUpdateBatchID,
                performanceMeasureSimples,
                performanceMeasureSubcategorySimples,
                performanceMeasureSubcategoryOptionSimples,
                calendarYearStrings,
                showExemptYears);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new PerformanceMeasuresViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, updateStatus, performanceMeasuresValidationResult);
            return RazorView<PerformanceMeasures, PerformanceMeasuresViewData, PerformanceMeasuresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshPerformanceMeasures(viewModel);
        }

        private static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(Project project)
        {
            return GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project,
                $"We should have a {FieldDefinition.Project.GetFieldDefinitionLabel()} update batch when refreshing; didn't find one for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
        }

        private static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(Project project, string message)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, message);
            return projectUpdateBatch;
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            projectUpdateBatch.DeleteProjectExemptReportingYearUpdates();
            projectUpdateBatch.DeletePerformanceMeasureActualUpdates();

            // refresh the data
            projectUpdateBatch.SyncPerformanceMeasureActualYearsExemptionExplanation();
            ProjectExemptReportingYearUpdate.CreateFromProject(projectUpdateBatch);
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshPerformanceMeasures(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and use the updated start and completion years from the Basics section. Any changes made in this section will be lost.");
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
            var viewModel = new ExpendituresViewModel(projectFundingSourceExpenditureUpdates,
                calendarYearRange,
                projectUpdateBatch.ExpendituresComment);
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
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.ExpendituresComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.Expenditures);
        }

        private ViewResult ViewExpenditures(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearRange, ExpendituresViewModel viewModel)
        {
            var project = projectUpdateBatch.Project;
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var expendituresValidationResult = projectUpdateBatch.ValidateExpenditures();

            var viewDataForAngularEditor = new ExpendituresViewData.ViewDataForAngularClass(project,
                allFundingSources,
                calendarYearRange);
            var projectFundingSourceExpenditures = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var fromFundingSourcesAndCalendarYears = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(
                new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures),
                calendarYearRange);
            var projectExpendituresSummaryViewData = new ProjectExpendituresDetailViewData(fromFundingSourcesAndCalendarYears, calendarYearRange.Select(x => new CalendarYearString(x)).ToList());

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
            projectUpdateBatch.DeleteProjectFundingSourceExpenditureUpdates();
            // refresh data
            ProjectFundingSourceExpenditureUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshExpenditures(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the expenditures for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and use the updated start and completion years from the Basics section. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
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
            var projectFundingSourceRequestUpdates = projectUpdateBatch.ProjectFundingSourceRequestUpdates.ToList();
            var viewModel = new ExpectedFundingViewModel(projectFundingSourceRequestUpdates,
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
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceRequestUpdates.Load();
            var projectFundingSourceRequestUpdates = projectUpdateBatch.ProjectFundingSourceRequestUpdates.ToList();
            var allProjectFundingSourceExpectedFunding = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequestUpdates.Local;
            viewModel.UpdateModel(projectUpdateBatch, projectFundingSourceRequestUpdates, allProjectFundingSourceExpectedFunding);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.ExpectedFundingComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.ExpectedFunding);
        }

        private ViewResult ViewExpectedFunding(ProjectUpdateBatch projectUpdateBatch, ExpectedFundingViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var expectedFundingValidationResult = projectUpdateBatch.ValidateExpectedFunding(viewModel.ProjectFundingSourceRequests);
            var estimatedTotalCost = projectUpdateBatch.ProjectUpdate.EstimatedTotalCost ?? 0;

            var viewDataForAngularEditor = new ExpectedFundingViewData.ViewDataForAngularClass(projectUpdateBatch,
                allFundingSources,
                estimatedTotalCost);
            var projectFundingDetailViewData = new ProjectFundingDetailViewData(CurrentPerson, new List<IFundingSourceRequestAmount>(projectUpdateBatch.ProjectFundingSourceRequestUpdates));

            var viewData = new ExpectedFundingViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectFundingDetailViewData, GetUpdateStatus(projectUpdateBatch), expectedFundingValidationResult);
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
            projectUpdateBatch.DeleteProjectFundingSourceRequestUpdates();
            // refresh data
            ProjectFundingSourceRequestUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshExpectedFunding(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the expected funding for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()}. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        // TODO: Neutered per #1136; most likely will bring back when BOR project starts
        //[HttpGet]
        //[ProjectUpdateCreateEditSubmitFeature]
        //public ActionResult Budgets(ProjectPrimaryKey projectPrimaryKey)
        //{
        //    var project = projectPrimaryKey.EntityObject;
        //    var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
        //    if (projectUpdateBatch == null)
        //    {
        //        return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
        //    }
        //    var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectBudgetUpdates.ToList();
        //    var calendarYearRange = projectFundingSourceBudgetUpdates.CalculateCalendarYearRangeForBudgets(projectUpdateBatch.ProjectUpdate);
        //    var viewModel = new BudgetsViewModel(projectFundingSourceBudgetUpdates,
        //        calendarYearRange,
        //        projectUpdateBatch.BudgetsComment);
        //    return ViewBudgets(projectUpdateBatch, calendarYearRange, viewModel);
        //}

        //[HttpPost]
        //[ProjectUpdateCreateEditSubmitFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult Budgets(ProjectPrimaryKey projectPrimaryKey, BudgetsViewModel viewModel)
        //{
        //    var project = projectPrimaryKey.EntityObject;
        //    var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
        //    if (projectUpdateBatch == null)
        //    {
        //        return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
        //    }
        //    var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectBudgetUpdates.ToList();
        //    var calendarYearRange = projectFundingSourceBudgetUpdates.CalculateCalendarYearRangeForBudgets(projectUpdateBatch.ProjectUpdate);
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewBudgets(projectUpdateBatch, calendarYearRange, viewModel);
        //    }
        //    HttpRequestStorage.DatabaseEntities.ProjectBudgetUpdates.Load();
        //    var allProjectFundingSourceBudgets = HttpRequestStorage.DatabaseEntities.AllProjectBudgetUpdates.Local;
        //    viewModel.UpdateModel(projectUpdateBatch, projectFundingSourceBudgetUpdates, allProjectFundingSourceBudgets);
        //    if (projectUpdateBatch.IsSubmitted)
        //    {
        //        projectUpdateBatch.BudgetsComment = viewModel.Comments;
        //    }
        //    projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
        //    return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Budgets(project)));
        //}

        //private ViewResult ViewBudgets(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearRange, BudgetsViewModel viewModel)
        //{
        //    var project = projectUpdateBatch.Project;
        //    var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
        //    var budgetsValidationResult = projectUpdateBatch.ValidateBudgets();
        //    var projectCostTypeSimples = ProjectCostType.All.Select(x => new ProjectCostTypeSimple(x)).ToList();

        //    var viewDataForAngularEditor = new BudgetsViewData.ViewDataForAngularEditor(project,
        //        allFundingSources,
        //        projectCostTypeSimples,
        //        calendarYearRange,
        //        budgetsValidationResult);

        //    var projectBudgetAmounts =
        //        ProjectBudgetAmount.CreateFromProjectBudgets(new List<IProjectBudgetAmount>(projectUpdateBatch.ProjectBudgetUpdates.ToList()));
        //    var projectBudgetsSummaryViewData = new ProjectBudgetDetailViewData(projectBudgetAmounts, calendarYearRange);
        //    var updateStatus = GetUpdateStatus(projectUpdateBatch);
        //    var viewData = new BudgetsViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectBudgetsSummaryViewData, updateStatus);
        //    return RazorView<Budgets, BudgetsViewData, BudgetsViewModel>(viewData, viewModel);
        //}

        //[HttpGet]
        //[ProjectUpdateCreateEditSubmitFeature]
        //public PartialViewResult RefreshBudgets(ProjectPrimaryKey projectPrimaryKey)
        //{
        //    var project = projectPrimaryKey.EntityObject;
        //    var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
        //    var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
        //    return ViewRefreshBudgets(viewModel);
        //}

        //[HttpPost]
        //[ProjectUpdateCreateEditSubmitFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult RefreshBudgets(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        //{
        //    var project = projectPrimaryKey.EntityObject;
        //    var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
        //    projectUpdateBatch.DeleteProjectBudgetUpdates();
        //    // refresh data
        //    ProjectBudgetUpdate.CreateFromProject(projectUpdateBatch);
        //    projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
        //    return new ModalDialogFormJsonResult();
        //}

        //private PartialViewResult ViewRefreshBudgets(ConfirmDialogFormViewModel viewModel)
        //{
        //    var viewData =
        //        new ConfirmDialogFormViewData(
        //            $"Are you sure you want to refresh the budgets for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and use the updated start and completion years from the Basics section. Any updates made in this section will be lost.");
        //    return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        //}

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
            ProjectImageUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.IsPhotosUpdated = false;
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshPhotos(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the photos for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
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
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.LocationSimpleComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.LocationSimple);
        }

        private ViewResult ViewLocationSimple(Project project, ProjectUpdateBatch projectUpdateBatch, LocationSimpleViewModel viewModel)
        {          
            var projectUpdate = projectUpdateBatch.ProjectUpdate;

            var mapInitJsonForEdit = new MapInitJson($"project_{project.ProjectID}_EditMap",
                10,
                MapInitJson.GetAllWatershedMapLayers(LayerInitialVisibility.Hide),
                BoundingBox.MakeNewDefaultBoundingBox(),
                false) {DisablePopups = true};
            var locationSimpleValidationResult = projectUpdateBatch.ValidateProjectLocationSimple();

            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(projectUpdate,
                $"project_{project.ProjectID}_EditMap", true);

            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var mapPostUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.LocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationFormID(project);

            var editProjectLocationViewData = new ProjectLocationSimpleViewData(CurrentPerson, mapInitJsonForEdit, tenantAttribute, null, mapPostUrl, mapFormID);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(projectUpdate, projectLocationSummaryMapInitJson);
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
                    $"Are you sure you want to refresh the {FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} data? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
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

            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.LocationDetailedComment = viewModel.Comments;
            }

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.LocationDetailed);
        }

        private ViewResult ViewLocationDetailed(ProjectUpdateBatch projectUpdateBatch, LocationDetailedViewModel viewModel)
        {
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            var project = projectUpdateBatch.Project;

            var mapDivID = $"project_{project.ProjectID}_EditDetailedMap";
            var detailedLocationGeoJsonFeatureCollection = projectUpdate.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(projectUpdate);
            var layers = MapInitJson.GetAllWatershedMapLayers(LayerInitialVisibility.Show);
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
                    $"Are you sure you want to refresh the {FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} data? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
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
                projectUpdateBatch.ProjectLocationStagingUpdates.ToList().DeleteProjectLocationStagingUpdate();
                projectUpdateBatch.ProjectLocationStagingUpdates.Clear();
                ProjectLocationStagingUpdate.CreateProjectLocationStagingUpdateListFromGdb(gdbFile, projectUpdateBatch, CurrentPerson);
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
            var projectLocationUpdates = projectUpdateBatch.ProjectLocationUpdates.ToList();
            projectLocationUpdates.DeleteProjectLocationUpdate();
            projectUpdateBatch.ProjectLocationUpdates.Clear();
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
        public ActionResult Watershed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }            
            var viewModel = new WatershedViewModel(projectUpdateBatch,
                projectUpdateBatch.WatershedComment);
            return ViewWatershed(project, projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Watershed(ProjectPrimaryKey projectPrimaryKey, WatershedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            if (projectUpdateBatch == null)
            {
                return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Instructions(project)));
            }
            if (!ModelState.IsValid)
            {
                return ViewWatershed(project, projectUpdateBatch, viewModel);
            }
            var currentProjectUpdateWatersheds = projectUpdateBatch.ProjectWatershedUpdates.ToList();
            var allProjectUpdateWatersheds = HttpRequestStorage.DatabaseEntities.AllProjectWatershedUpdates.Local;
            viewModel.UpdateModelBatch(projectUpdateBatch, currentProjectUpdateWatersheds, allProjectUpdateWatersheds);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.WatershedComment = viewModel.Comments;
            }
            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.Watersheds);
        }

        private ViewResult ViewWatershed(Project project, ProjectUpdateBatch projectUpdateBatch, WatershedViewModel viewModel)
        {
            var projectUpdate = projectUpdateBatch.ProjectUpdate;

            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(projectUpdate);
            var layers = MapInitJson.GetAllWatershedMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(projectUpdate));
            var mapInitJson = new MapInitJson("projectWatershedMap", 0, layers, boundingBox) { AllowFullScreen = false, DisablePopups = true};
           
            var watershedValidationResult = projectUpdateBatch.ValidateProjectWatershed();
            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(projectUpdate,
                $"project_{project.ProjectID}_EditMap", false);
            var watershedIDs = viewModel.WatershedIDs ?? new List<int>();
            var watershedsInViewModel = HttpRequestStorage.DatabaseEntities.Watersheds.Where(x => watershedIDs.Contains(x.WatershedID)).ToList();
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var editProjectWatershedsPostUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.Watershed(project, null));
            var editProjectWatershedsFormId = GenerateEditProjectLocationFormID(project);

            var editProjectLocationViewData = new EditProjectWatershedsViewData(CurrentPerson, mapInitJson, watershedsInViewModel, tenantAttribute, editProjectWatershedsPostUrl, editProjectWatershedsFormId, projectUpdate.HasProjectLocationPoint, projectUpdate.HasProjectLocationDetail);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(projectUpdate, projectLocationSummaryMapInitJson);            
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new WatershedViewData(CurrentPerson, projectUpdate, editProjectLocationViewData, projectLocationSummaryViewData, watershedValidationResult, updateStatus);
            return RazorView<Views.ProjectUpdate.Watershed, WatershedViewData, WatershedViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult RefreshProjectWatershed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshProjectWatershed(viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshProjectWatershed(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project);
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            if (projectUpdate == null)
            {
                return new ModalDialogFormJsonResult();
            }
            projectUpdateBatch.DeleteProjectWatershedUpdates();

            // refresh the data
            projectUpdate.LoadWatershedNotesFromProject(project);
            ProjectWatershedUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshProjectWatershed(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {FieldDefinition.Watershed.GetFieldDefinitionLabel()} data? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
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
            ProjectNoteUpdate.CreateFromProject(projectUpdateBatch);
            ProjectDocumentUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshNotesAndDocuments(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the notes for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
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

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch, ProjectUpdateSection.ExternalLinks);
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
            ProjectExternalLinkUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshExternalLinks(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the notes for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()} and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateAdminFeatureWithProjectContext]
        public PartialViewResult Approve(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to approve for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}!");
            Check.Require(projectUpdateBatch.IsSubmitted, $"The {FieldDefinition.Project.GetFieldDefinitionLabel()} is not in a state to be ready to be approved!");
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewApprove(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateAdminFeatureWithProjectContext]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Approve(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to approve for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}!");
            Check.Require(projectUpdateBatch.IsSubmitted, $"The {FieldDefinition.Project.GetFieldDefinitionLabel()} is not in a state to be ready to be approved!");
            WriteHtmlDiffLogs(projectPrimaryKey, projectUpdateBatch);

            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptReportingYears = HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.Local;
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceRequests.Load();
            var allProjectFundingSourceRequests = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequests.Local;
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //HttpRequestStorage.DatabaseEntities.ProjectBudgets.Load();
            //var allProjectBudgets = HttpRequestStorage.DatabaseEntities.AllProjectBudgets.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            var allPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Load();
            var allPerformanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptions.Local;
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Load();
            var allProjectExternalLinks = HttpRequestStorage.DatabaseEntities.AllProjectExternalLinks.Local;
            HttpRequestStorage.DatabaseEntities.ProjectNotes.Load();
            var allProjectNotes = HttpRequestStorage.DatabaseEntities.AllProjectNotes.Local;
            HttpRequestStorage.DatabaseEntities.ProjectImages.Load();
            var allProjectImages = HttpRequestStorage.DatabaseEntities.AllProjectImages.Local;
            HttpRequestStorage.DatabaseEntities.ProjectLocations.Load();
            var allProjectLocations = HttpRequestStorage.DatabaseEntities.AllProjectLocations.Local;
            HttpRequestStorage.DatabaseEntities.ProjectWatersheds.Load();
            var allProjectWatersheds = HttpRequestStorage.DatabaseEntities.AllProjectWatersheds.Local;
            HttpRequestStorage.DatabaseEntities.ProjectOrganizations.Load();
            var allProjectOrganizations = HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.Local;
            HttpRequestStorage.DatabaseEntities.ProjectDocuments.Load();
            var allProjectDocuments = HttpRequestStorage.DatabaseEntities.AllProjectDocuments.Local;
            HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeUpdates.Load();
            var allProjectCustomAttributes = HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributes.Local;
            HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeUpdateValues.Load();
            var allProjectCustomAttributeValues = HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeValues.Local;

            projectUpdateBatch.Approve(CurrentPerson,
                DateTime.Now,
                allProjectExemptReportingYears,
                allProjectFundingSourceExpenditures,
                // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//                allProjectBudgets,
                allPerformanceMeasureActuals,
                allPerformanceMeasureActualSubcategoryOptions,
                allProjectExternalLinks,
                allProjectNotes,
                allProjectImages,
                allProjectLocations,
                allProjectWatersheds,
                allProjectFundingSourceRequests,
                allProjectOrganizations,
                allProjectDocuments,
                allProjectCustomAttributes,
                allProjectCustomAttributeValues);

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            var peopleToCc = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications().Union(project.GetProjectStewards()).Distinct().OrderBy(ht => ht.FullNameLastFirst).ToList();

            NotificationProject.SendApprovalMessage(peopleToCc, projectUpdateBatch);

            SetMessageForDisplay($"The update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdateBatch.Project.DisplayName} was approved!");
            return new ModalDialogFormJsonResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project)));
        }

        private PartialViewResult ViewApprove(ProjectUpdateBatch projectUpdate, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to approve the updates to {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdate.Project.DisplayName}?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        private void WriteHtmlDiffLogs(ProjectPrimaryKey projectPrimaryKey, ProjectUpdateBatch projectUpdateBatch)
        {
            var basicsDiffContainer = DiffBasicsImpl(projectPrimaryKey);
            if (basicsDiffContainer.HasChanged)
            {
                var basicsDiffHelper = new HtmlDiff.HtmlDiff(basicsDiffContainer.OriginalHtml, basicsDiffContainer.UpdatedHtml);                
                projectUpdateBatch.BasicsDiffLogHtmlString = new HtmlString(basicsDiffHelper.Build());
            }            

            var performanceMeasureDiffContainer = DiffPerformanceMeasuresImpl(projectPrimaryKey);
            if (performanceMeasureDiffContainer.HasChanged)
            {
                var performanceMeasureDiffHelper = new HtmlDiff.HtmlDiff(performanceMeasureDiffContainer.OriginalHtml, performanceMeasureDiffContainer.UpdatedHtml);
                projectUpdateBatch.PerformanceMeasureDiffLogHtmlString = new HtmlString(performanceMeasureDiffHelper.Build());
            }

            var expendituresDiffContainer = DiffExpendituresImpl(projectPrimaryKey);
            if (expendituresDiffContainer.HasChanged)
            {
                var expendituresDiffHelper = new HtmlDiff.HtmlDiff(expendituresDiffContainer.OriginalHtml, expendituresDiffContainer.UpdatedHtml);
                projectUpdateBatch.ExpendituresDiffLogHtmlString = new HtmlString(expendituresDiffHelper.Build());
            }

            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //var budgetsDiffContainer = DiffBudgetsImpl(projectPrimaryKey);
            //if (budgetsDiffContainer.HasChanged)
            //{
            //    var budgetsDiffHelper = new HtmlDiff.HtmlDiff(budgetsDiffContainer.OriginalHtml, budgetsDiffContainer.UpdatedHtml);
            //    projectUpdateBatch.BudgetsDiffLogHtmlString = new HtmlString(budgetsDiffHelper.Build());
            //}

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
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to submit for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewSubmit(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Submit(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to submit for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            projectUpdateBatch.SubmitToReviewer(CurrentPerson, DateTime.Now);
            var peopleToCc = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications().Union(project.GetProjectStewards()).Distinct().OrderBy(ht => ht.FullNameLastFirst).ToList();
            NotificationProject.SendSubmittedMessage(peopleToCc, projectUpdateBatch);
            SetMessageForDisplay($"The update for {FieldDefinition.Project.GetFieldDefinitionLabel()} '{projectUpdateBatch.Project.DisplayName}' was submitted.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        private PartialViewResult ViewSubmit(ProjectUpdateBatch projectUpdate, ConfirmDialogFormViewModel viewModel)
        {
            //TODO: Change "for review" to specific reviewer as determined by tenant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to submit {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdate.Project.DisplayName} for review?");
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
                    .Where(pub => pub.IsReadyToSubmit && pub.Project.ProjectStage.RequiresReportedExpenditures() && pub.Project.IsMyProject(CurrentPerson))
                    .ToList();
            var peopleToCc = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications();
            projectUpdateBatches.ForEach(pub =>
            {
                pub.SubmitToReviewer(CurrentPerson, DateTime.Now);
                var peopleToNotify = peopleToCc.Union(pub.Project.GetProjectStewards()).Distinct().OrderBy(ht => ht.FullNameLastFirst).ToList();
                NotificationProject.SendSubmittedMessage(peopleToNotify, pub);
            });
            SetMessageForDisplay($"The update(s) for {FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} {string.Join(", ", projectUpdateBatches.Select(x => x.Project.DisplayName))} have been submitted.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewSubmitAll(ConfirmDialogFormViewModel viewModel)
        {
            //TODO: Change "for review" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to submit all your {FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} that are ready to be submitted for review?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateAdminFeatureWithProjectContext]
        public PartialViewResult Return(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to return for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            Check.Require(projectUpdateBatch.IsSubmitted, $"You cannot return a {FieldDefinition.Project.GetFieldDefinitionLabel()} Update that has not been submitted!");
            var viewModel = new ReturnDialogFormViewModel();
            return ViewReturn(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateAdminFeatureWithProjectContext]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Return(ProjectPrimaryKey projectPrimaryKey, ReturnDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to return for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            Check.Require(projectUpdateBatch.IsSubmitted, $"You cannot return a {FieldDefinition.Project.GetFieldDefinitionLabel()} Update that has not been submitted!");
            viewModel.UpdateModel(projectUpdateBatch);
            projectUpdateBatch.Return(CurrentPerson, DateTime.Now);
            var peopleToCc = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications().Union(project.GetProjectStewards()).Distinct().OrderBy(ht => ht.FullNameLastFirst).ToList();
            NotificationProject.SendReturnedMessage(peopleToCc, projectUpdateBatch);
            SetMessageForDisplay($"The update submitted for {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdateBatch.Project.DisplayName} has been returned.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewReturn(ProjectUpdateBatch projectUpdate, ReturnDialogFormViewModel viewModel)
        {
            var viewData = new ReturnDialogFormViewData($"Are you sure you want to return {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdate.Project.DisplayName}?");
            return RazorPartialView<ReturnDialogForm, ReturnDialogFormViewData, ReturnDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DeleteProjectUpdate(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to delete for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewDeleteProjectUpdate(viewModel, projectUpdateBatch);
        }

        [HttpPost]
        [ProjectUpdateCreateEditSubmitFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectUpdate(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update to delete for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            projectUpdateBatch.DeleteAll();
            return new ModalDialogFormJsonResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project)));
        }

        private PartialViewResult ViewDeleteProjectUpdate(ConfirmDialogFormViewModel viewModel, ProjectUpdateBatch projectUpdateBatch)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete this update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdateBatch.Project.DisplayName}?");
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
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new HistoryViewData(CurrentPerson, projectUpdateBatch, updateStatus);
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
                ObjectNameSingular = $"{FieldDefinition.Project.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };
            var contactsReceivingReminderGridSpec = new PeopleReceivingReminderGridSpec(true, CurrentPerson) {ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true};
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ManageUpdateNotifications);

            var projectsWithNoContactCount = GetProjectsWithNoContact(CurrentPerson).Count;

            var viewData = new ManageViewData(CurrentPerson,
                firmaPage,
                customNotificationUrl,
                projectsRequiringUpdateGridSpec,
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ProjectsRequiringUpdateGridJsonData()),
                contactsReceivingReminderGridSpec,
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PeopleReceivingReminderGridJsonData(true)),
                projectsWithNoContactCount,
                MultiTenantHelpers.GetProjectUpdateConfiguration());
            return RazorView<Manage, ManageViewData>(viewData);
        }

        private static List<Project> GetProjectsWithNoContact(Person person)
        {
            var projectsRequiringUpdate = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(x => x.IsUpdatableViaProjectUpdateProcess).ToList();
            return projectsRequiringUpdate.Where(x => x.GetPrimaryContact() == null).ToList();
        }

        [ProjectUpdateAdminFeature]
        public GridJsonNetJObjectResult<Project> ProjectsRequiringUpdateGridJsonData()
        {
            var gridSpec = new ProjectUpdateStatusGridSpec(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects, CurrentPerson.IsApprover());
            var projects =
                HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(x => x.IsUpdatableViaProjectUpdateProcess && x.IsEditableToThisPerson(CurrentPerson)).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<Person> PeopleReceivingReminderGridJsonData(bool showCheckbox)
        {
            var gridSpec = new PeopleReceivingReminderGridSpec(showCheckbox, CurrentPerson);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(x => x.IsUpdatableViaProjectUpdateProcess && x.IsEditableToThisPerson(CurrentPerson)).ToList();
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

            Notification.SendMessageAndLogNotification(message, emailsToSendTo, emailsToReplyTo, new List<string>(), peopleToNotify, DateTime.Now, new List<Project>(), NotificationType.Custom);

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
            Notification.SendMessage(message, emailsToSendTo, new List<string>(), new List<string>());
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
            var viewData = new ProjectBasicsViewData(project, false, taxonomyLevel);
            var partialViewAsString = RenderPartialViewToString(ProjectBasicsPartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffPerformanceMeasuresImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffPerformanceMeasuresImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            var performanceMeasureReportedValuesOriginal = new List<IPerformanceMeasureReportedValue>(project.GetReportedPerformanceMeasures());
            var performanceMeasureReportedValuesUpdated = new List<IPerformanceMeasureReportedValue>(projectUpdateBatch.PerformanceMeasureActualUpdates);
            var calendarYearsForPerformanceMeasuresOriginal = performanceMeasureReportedValuesOriginal.Select(x => x.CalendarYear).Distinct().ToList();
            var calendarYearsForPerformanceMeasuresUpdated = performanceMeasureReportedValuesUpdated.Select(x => x.CalendarYear).Distinct().ToList();

            var originalHtml = GeneratePartialViewForOriginalPerformanceMeasures(
                performanceMeasureReportedValuesOriginal,
                performanceMeasureReportedValuesUpdated,
                calendarYearsForPerformanceMeasuresOriginal,
                calendarYearsForPerformanceMeasuresUpdated,
                project.ProjectExemptReportingYears.Select(x => x.CalendarYear).ToList(),
                project.PerformanceMeasureActualYearsExemptionExplanation);

            var updatedHtml = GeneratePartialViewForModifiedPerformanceMeasures(
                performanceMeasureReportedValuesOriginal,
                performanceMeasureReportedValuesUpdated,
                calendarYearsForPerformanceMeasuresOriginal,
                calendarYearsForPerformanceMeasuresUpdated,
                projectUpdateBatch.ProjectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList(),
                projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalPerformanceMeasures(List<IPerformanceMeasureReportedValue> performanceMeasureReportedValuesOriginal,
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
            performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal.Where(x => performanceMeasuresOnlyInOriginal.Contains(x.PerformanceMeasureID))
                .ForEach(x =>
                {
                    ZeroOutReportedValue(x, calendarYearsOriginal);
                    x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
                });
            var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForPerformanceMeasures(performanceMeasureSubcategoriesCalendarYearReportedValuesOriginal, calendarYearStrings, exemptReportingYears, exemptionExplanation);
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

        private string GeneratePartialViewForModifiedPerformanceMeasures(List<IPerformanceMeasureReportedValue> performanceMeasureReportedValuesOriginal,
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
            performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated.Where(x => performanceMeasuresOnlyInUpdated.Contains(x.PerformanceMeasureID))
                .ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForPerformanceMeasures(performanceMeasureSubcategoriesCalendarYearReportedValuesUpdated, calendarYearStrings, exemptReportingYears, exemptionExplanation);
        }

        private string GeneratePartialViewForPerformanceMeasures(List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> performanceMeasureSubcategoriesCalendarYearReportedValues, List<CalendarYearString> calendarYearStrings, List<int> exemptReportingYears, string exemptionExplanation)
        {
            var viewData = new PerformanceMeasureReportedValuesSummaryViewData(performanceMeasureSubcategoriesCalendarYearReportedValues, exemptReportingYears, exemptionExplanation, calendarYearStrings);
            var partialViewToString = RenderPartialViewToString(PerformanceMeasureReportedValuesPartialViewPath, viewData);
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
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");

            var projectFundingSourceExpendituresOriginal = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearsOriginal = projectFundingSourceExpendituresOriginal.CalculateCalendarYearRangeForExpenditures(project);
            var projectFundingSourceExpendituresUpdated = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var calendarYearsUpdated = projectFundingSourceExpendituresUpdated.CalculateCalendarYearRangeForExpenditures(projectUpdateBatch.ProjectUpdate);

            var originalHtml = GeneratePartialViewForOriginalExpenditures(new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresOriginal),
                calendarYearsOriginal,
                new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresUpdated),
                calendarYearsUpdated);

            var updatedHtml = GeneratePartialViewForModifiedExpenditures(new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresOriginal),
                calendarYearsOriginal,
                new List<IFundingSourceExpenditure>(projectFundingSourceExpendituresUpdated),
                calendarYearsUpdated);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalExpenditures(List<IFundingSourceExpenditure> projectFundingSourceExpendituresOriginal,
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
            fundingSourceCalendarYearExpendituresOriginal.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID)).ForEach(x =>
            {
                ZeroOutExpenditure(x, calendarYearsOriginal);
                x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
            });

            var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForExpendituresAsString(fundingSourceCalendarYearExpendituresOriginal, calendarYearStrings);
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
            fundingSourceCalendarYearExpendituresUpdated.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForExpendituresAsString(fundingSourceCalendarYearExpendituresUpdated, calendarYearStrings);
        }

        private string GeneratePartialViewForExpendituresAsString(List<FundingSourceCalendarYearExpenditure> fundingSourceCalendarYearExpenditures, List<CalendarYearString> calendarYearStrings)
        {
            var viewData = new ProjectExpendituresSummaryViewData(fundingSourceCalendarYearExpenditures, calendarYearStrings);
            var partialViewAsString = RenderPartialViewToString(ProjectExpendituresPartialViewPath, viewData);
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
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current Project Update for Project {project.DisplayName}");
            var projectFundingSourceRequestsOriginal = new List<IFundingSourceRequestAmount>(project.ProjectFundingSourceRequests.ToList());
            var projectFundingSourceRequestsUpdated = new List<IFundingSourceRequestAmount>(projectUpdateBatch.ProjectFundingSourceRequestUpdates.ToList());
            var originalHtml = GeneratePartialViewForOriginalFundingRequests(projectFundingSourceRequestsOriginal, projectFundingSourceRequestsUpdated);
            var updatedHtml = GeneratePartialViewForModifiedFundingRequests(projectFundingSourceRequestsOriginal, projectFundingSourceRequestsUpdated);
            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForOriginalFundingRequests(List<IFundingSourceRequestAmount> projectFundingSourceRequestsOriginal,
            List<IFundingSourceRequestAmount> projectFundingSourceRequestsUpdated)
        {
            var fundingSourcesInOriginal = projectFundingSourceRequestsOriginal.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesInUpdated = projectFundingSourceRequestsUpdated.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesOnlyInOriginal = fundingSourcesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x)).ToList();
            var fundingSourceRequestAmounts = projectFundingSourceRequestsOriginal.Select(x => new FundingSourceRequestAmount(x)).ToList();
            fundingSourceRequestAmounts.AddRange(projectFundingSourceRequestsUpdated.Where(x => !fundingSourcesInOriginal.Contains(x.FundingSource.FundingSourceID)).Select(x =>
                new FundingSourceRequestAmount(x.FundingSource, x.SecuredAmount, x.UnsecuredAmount, HtmlDiffContainer.DisplayCssClassAddedElement)));
            fundingSourceRequestAmounts.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);
            return GeneratePartialViewForExpectedFundingAsString(fundingSourceRequestAmounts);
        }

        private string GeneratePartialViewForModifiedFundingRequests(List<IFundingSourceRequestAmount> projectFundingSourceRequestsOriginal,
            List<IFundingSourceRequestAmount> projectFundingSourceRequestsUpdated)
        {
            var fundingSourcesInOriginal = projectFundingSourceRequestsOriginal.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesInUpdated = projectFundingSourceRequestsUpdated.Select(x => x.FundingSource.FundingSourceID).ToList();
            var fundingSourcesOnlyInUpdated = fundingSourcesInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x)).ToList();
            var fundingSourceRequestAmounts = projectFundingSourceRequestsUpdated.Select(x => new FundingSourceRequestAmount(x)).ToList();
            fundingSourceRequestAmounts.AddRange(projectFundingSourceRequestsOriginal.Where(x => !fundingSourcesInUpdated.Contains(x.FundingSource.FundingSourceID)).Select(x =>
                new FundingSourceRequestAmount(x.FundingSource, x.SecuredAmount, x.UnsecuredAmount, HtmlDiffContainer.DisplayCssClassDeletedElement)));
            fundingSourceRequestAmounts.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);
            return GeneratePartialViewForExpectedFundingAsString(fundingSourceRequestAmounts);
        }

        private string GeneratePartialViewForExpectedFundingAsString(List<FundingSourceRequestAmount> fundingSourceRequestAmounts)
        {
            var viewData = new ProjectFundingRequestsDetailViewData(fundingSourceRequestAmounts);
            var partialViewAsString = RenderPartialViewToString(ProjectExpectedFundingPartialViewPath, viewData);
            return partialViewAsString;
        }

        //[HttpGet]
        //[ProjectUpdateCreateEditSubmitFeature]
        //public PartialViewResult DiffBudgets(ProjectPrimaryKey projectPrimaryKey)
        //{
        //    var htmlDiffContainer = DiffBudgetsImpl(projectPrimaryKey);
        //    var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
        //    return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        //}

        //private HtmlDiffContainer DiffBudgetsImpl(ProjectPrimaryKey projectPrimaryKey)
        //{
        //    var project = projectPrimaryKey.EntityObject;
        //    var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");

        //    var projectBudgetsOriginal = project.ProjectBudgets.ToList();
        //    var calendarYearsOriginal = projectBudgetsOriginal.CalculateCalendarYearRangeForBudgets(project);
        //    var projectBudgetsUpdated = projectUpdateBatch.ProjectBudgetUpdates.ToList();
        //    var calendarYearsUpdated = projectBudgetsUpdated.CalculateCalendarYearRangeForBudgets(projectUpdateBatch.ProjectUpdate);

        //    var originalHtml = GeneratePartialViewForOriginalBudgets(new List<IProjectBudgetAmount>(projectBudgetsOriginal),
        //        calendarYearsOriginal,
        //        new List<IProjectBudgetAmount>(projectBudgetsUpdated),
        //        calendarYearsUpdated);

        //    var updatedHtml = GeneratePartialViewForModifiedBudgets(new List<IProjectBudgetAmount>(projectBudgetsOriginal),
        //        calendarYearsOriginal,
        //        new List<IProjectBudgetAmount>(projectBudgetsUpdated),
        //        calendarYearsUpdated);
        //    var htmlDiffContainer = new HtmlDiffContainer(originalHtml, updatedHtml);
        //    return htmlDiffContainer;
        //}

        //private string GeneratePartialViewForBudgetsAsString(List<ProjectBudgetAmount2> projectBudgetAmounts, List<CalendarYearString> calendarYearStrings)
        //{
        //    var viewData = new Views.Shared.ProjectUpdateDiffControls.ProjectBudgetSummaryViewData(projectBudgetAmounts, calendarYearStrings);
        //    var partialViewAsString = RenderPartialViewToString(TransporationBudgetsPartialViewPath, viewData);
        //    return partialViewAsString;
        //}

        //private string GeneratePartialViewForOriginalBudgets(List<IProjectBudgetAmount> projectBudgetAmountsOriginal,
        //    List<int> calendarYearsOriginal,
        //    List<IProjectBudgetAmount> projectBudgetAmountsUpdated,
        //    List<int> calendarYearsUpdated)
        //{
        //    var fundingSourcesInOriginal = projectBudgetAmountsOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
        //    var fundingSourcesInUpdated = projectBudgetAmountsUpdated.Select(x => x.FundingSourceID).Distinct().ToList();
        //    var fundingSourcesOnlyInOriginal = fundingSourcesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x)).ToList();

        //    var projectBudgetAmountsInOriginal = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsOriginal,
        //        calendarYearsOriginal);
        //    // we need to zero out calendar year values only in original
        //    foreach (var projectBudgetAmount2 in projectBudgetAmountsInOriginal)
        //    {
        //        ZeroOutBudget(projectBudgetAmount2, calendarYearsOriginal.Except(calendarYearsUpdated).ToList());
        //    }

        //    var projectBudgetAmountsInUpdated = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsUpdated, calendarYearsUpdated);

        //    // find the ones that are only in the modified set and add them and mark them as "added"
        //    projectBudgetAmountsInOriginal.AddRange(
        //        projectBudgetAmountsInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x.FundingSourceID))
        //            .Select(x => ProjectBudgetAmount2.Clone(x, HtmlDiffContainer.DisplayCssClassAddedElement))
        //            .ToList());
        //    // find the ones only in original and mark them as "deleted"
        //    projectBudgetAmountsInOriginal.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID))
        //        .ForEach(x =>
        //        {
        //            ZeroOutBudget(x, calendarYearsOriginal);
        //            x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
        //        });

        //    var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
        //    return GeneratePartialViewForBudgetsAsString(projectBudgetAmountsInOriginal, calendarYearStrings);
        //}

        //private static void ZeroOutBudget(ProjectBudgetAmount2 projectBudgetAmount2, List<int> calendarYearsToZeroOut)
        //{
        //    foreach (var projectCostTypeCalendarYearBudget in projectBudgetAmount2.ProjectCostTypeCalendarYearBudgets)
        //    {
        //        foreach (var calendarYear in calendarYearsToZeroOut)
        //        {
        //            projectCostTypeCalendarYearBudget.CalendarYearBudget[calendarYear] = 0;
        //        }                
        //    }
        //}

        //private string GeneratePartialViewForModifiedBudgets(List<IProjectBudgetAmount> projectBudgetAmountsOriginal,
        //    List<int> calendarYearsOriginal,
        //    List<IProjectBudgetAmount> projectBudgetAmountsUpdated,
        //    List<int> calendarYearsUpdated)
        //{
        //    var fundingSourcesInOriginal = projectBudgetAmountsOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
        //    var fundingSourcesInUpdated = projectBudgetAmountsUpdated.Select(x => x.FundingSourceID).Distinct().ToList();
        //    var fundingSourcesOnlyInUpdated = fundingSourcesInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x)).ToList();

        //    var projectBudgetAmountsInOriginal = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsOriginal, calendarYearsOriginal);
        //    var projectBudgetAmountsInUpdated = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsUpdated, calendarYearsUpdated);

        //    // find the ones that are only in the original set and add them and mark them as "deleted"
        //    projectBudgetAmountsInUpdated.AddRange(
        //        projectBudgetAmountsInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x.FundingSourceID))
        //            .Select(x => ProjectBudgetAmount2.Clone(x, HtmlDiffContainer.DisplayCssClassDeletedElement))
        //            .ToList());
        //    // find the ones only in modified and mark them as "added"
        //    projectBudgetAmountsInUpdated.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

        //    var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
        //    return GeneratePartialViewForBudgetsAsString(projectBudgetAmountsInUpdated, calendarYearStrings);
        //}

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public PartialViewResult DiffPhotos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            var htmlDiffContainer = DiffPhotosImpl(projectUpdateBatch);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffPhotosImpl(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;

            var originalImages = new List<IFileResourcePhoto>(project.ProjectImages);
            var updatedImages = new List<IFileResourcePhoto>(projectUpdateBatch.ProjectImageUpdates);

            var dummyProject = Project.CreateNewBlank(TaxonomyLeaf.CreateNewBlank(TaxonomyBranch.CreateNewBlank(TaxonomyTrunk.CreateNewBlank())),
                ProjectStage.Completed,
                ProjectLocationSimpleType.None,
                FundingType.Capital,
                ProjectApprovalStatus.Approved);

            var dummyProjectUpdateBatch = ProjectUpdateBatch.CreateNewBlank(dummyProject, CurrentPerson, ProjectUpdateState.Created);

            foreach (var updatedImage in projectUpdateBatch.ProjectImageUpdates)
            {
                var matchingOriginalImage = originalImages.SingleOrDefault(x => updatedImage.ProjectImageID.HasValue && updatedImage.ProjectImageID == x.EntityImageIDAsNullable);
                if (matchingOriginalImage == null)
                {
                    var placeHolderImage = new ProjectImage(updatedImage.FileResource,
                        dummyProject,
                        updatedImage.ProjectImageTiming,
                        updatedImage.Caption,
                        updatedImage.Credit,
                        updatedImage.IsKeyPhoto,
                        updatedImage.ExcludeFromFactSheet) {AdditionalCssClasses = new List<string>() {"added-photo"},};
                    updatedImage.AdditionalCssClasses = new List<string>() { "added-photo" };
                    originalImages.Add(placeHolderImage);
                }
            }

            foreach (var originalImage in project.ProjectImages)
            {
                var matchingUpdatedImage = updatedImages.SingleOrDefault(x => originalImage.ProjectImageID == x.EntityImageIDAsNullable);
                if (matchingUpdatedImage == null)
                {
                    var placeHolderImage = new ProjectImageUpdate(dummyProjectUpdateBatch,
                        originalImage.ProjectImageTiming,
                        originalImage.Caption,
                        originalImage.Credit,
                        originalImage.IsKeyPhoto,
                        originalImage.ExcludeFromFactSheet)
                    {
                        FileResource = originalImage.FileResource,
                        ProjectImageID = originalImage.ProjectImageID,
                        AdditionalCssClasses = new List<string>() { "deleted-photo" }
                    };
                    originalImage.AdditionalCssClasses = new List<string>() { "deleted-photo" };
                    updatedImages.Add(placeHolderImage);
                }
                else
                {
                    originalImage.OrderBy = matchingUpdatedImage.CaptionOnFullView;
                }
            }

            var original = GeneratePartialViewForPhotos(originalImages);
            var updated = GeneratePartialViewForPhotos(updatedImages);

            var htmlDiff = new HtmlDiffContainer(original, updated);
            return htmlDiff;
        }

        private string GeneratePartialViewForPhotos(IEnumerable<IFileResourcePhoto> images)
        {
            var viewData = new ImageGalleryViewData(CurrentPerson, "ProjectImageDiff", images, false, string.Empty, string.Empty, false, x => x.CaptionOnFullView, "Photo");
            var partialViewAsString = RenderPartialViewToString(ImageGalleryPartialViewPath, viewData);
            return partialViewAsString;
        }

        private static bool IsLocationSimpleUpdated(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");

            if (project.ProjectLocationSimpleTypeID != projectUpdateBatch.ProjectUpdate.ProjectLocationSimpleTypeID)
                return true;

            if (project.ProjectLocationNotes != projectUpdateBatch.ProjectUpdate.ProjectLocationNotes)
                return true;

            switch (project.ProjectLocationSimpleType.ToEnum)
            {
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                    if (project.ProjectLocationPoint == null || projectUpdateBatch.ProjectUpdate.ProjectLocationPoint == null)
                    {
                        SitkaLogger.Instance.LogDetailedErrorMessage($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {project.ProjectID} appears to have inconsistent simple location configuration.");
                        return true;
                    }
                    return project.ProjectLocationPoint.ToSqlGeometry().STEquals(projectUpdateBatch.ProjectUpdate.ProjectLocationPoint.ToSqlGeometry()).IsFalse;
            }

            return false;
        }

        private static bool IsLocationDetailedUpdated(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");

            var originalLocationDetailed = project.GetProjectLocationDetails().ToList();
            var updatedLocationDetailed = projectUpdateBatch.ProjectLocationUpdates;

            if (!originalLocationDetailed.Any() && !updatedLocationDetailed.Any())
                return false;

            if (originalLocationDetailed.Count != updatedLocationDetailed.Count)
                return true;

            var originalLocationAsListOfStrings = originalLocationDetailed.Select(x => x.ProjectLocationGeometry.ToString() + x.Annotation).ToList();
            var updatedLocationAsListOfStrings = updatedLocationDetailed.Select(x => x.ProjectLocationGeometry.ToString() + x.Annotation).ToList();

            var enumerable = originalLocationAsListOfStrings.Except(updatedLocationAsListOfStrings);
            return enumerable.Any();
        }

        private static bool IsWatershedUpdated(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");

            var originalWatershedIDs = project.GetProjectWatersheds().Select(x => x.WatershedID).ToList();
            var updatedWatershedIDs = projectUpdateBatch.ProjectWatershedUpdates.Select(x => x.WatershedID).ToList();

            if (!originalWatershedIDs.Any() && !updatedWatershedIDs.Any())
                return false;

            if (originalWatershedIDs.Count != updatedWatershedIDs.Count)
                return true;
            
            var enumerable = originalWatershedIDs.Except(updatedWatershedIDs);
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
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
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
            externalLinksOriginal.Where(x => urlsOnlyInOriginal.Contains(x.GetExternalLinkAsUrl())).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);
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
            externalLinksUpdated.Where(x => urlsOnlyInUpdated.Contains(x.GetExternalLinkAsUrl())).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);
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
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project,$"There is no current {FieldDefinition.Project.GetFieldDefinitionLabel()} Update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {project.DisplayName}");
            var entityNotesOriginal = new List<IEntityNote>(project.ProjectNotes);
            var entityNotesUpdated = new List<IEntityNote>(projectUpdateBatch.ProjectNoteUpdates);

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

        private string GeneratePartialViewForOriginalNotes(List<IEntityNote> entityNotesOriginal, List<IEntityNote> entityNotesUpdated)
        {
            var urlsInOriginal = entityNotesOriginal.Select(x => x.Note).Distinct().ToList();
            var urlsInModified = entityNotesUpdated.Select(x => x.Note).Distinct().ToList();
            var urlsOnlyInOriginal = urlsInOriginal.Where(x => !urlsInModified.Contains(x)).ToList();

            var externalLinksOriginal = EntityNote.CreateFromEntityNote(entityNotesOriginal);
            var externalLinksUpdated = EntityNote.CreateFromEntityNote(entityNotesUpdated);
            // find the ones that are only in the modified set and add them and mark them as "added"
            externalLinksOriginal.AddRange(
                externalLinksUpdated.Where(x => !urlsInOriginal.Contains(x.Note))
                    .Select(x => new EntityNote(x.LastUpdated, x.LastUpdatedBy, x.DeleteUrl, x.EditUrl, x.Note, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            externalLinksOriginal.Where(x => urlsOnlyInOriginal.Contains(x.Note)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);
            return GeneratePartialViewForNotes(externalLinksOriginal);
        }

        private string GeneratePartialViewForModifiedNotes(List<IEntityNote> entityNotesOriginal, List<IEntityNote> entityNotesUpdated)
        {
            var urlsInOriginal = entityNotesOriginal.Select(x => x.Note).Distinct().ToList();
            var urlsInUpdated = entityNotesUpdated.Select(x => x.Note).Distinct().ToList();
            var urlsOnlyInUpdated = urlsInUpdated.Where(x => !urlsInOriginal.Contains(x)).ToList();

            var externalLinksOriginal = EntityNote.CreateFromEntityNote(entityNotesOriginal);
            var externalLinksUpdated = EntityNote.CreateFromEntityNote(entityNotesUpdated);
            // find the ones that are only in the original set and add them and mark them as "deleted"
            externalLinksUpdated.AddRange(
                externalLinksOriginal.Where(x => !urlsInUpdated.Contains(x.Note))
                    .Select(x => new EntityNote(x.LastUpdated, x.LastUpdatedBy, x.DeleteUrl, x.EditUrl, x.Note, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            externalLinksUpdated.Where(x => urlsOnlyInUpdated.Contains(x.Note)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);
            return GeneratePartialViewForNotes(externalLinksUpdated);
        }

        private string GeneratePartialViewForNotes(List<EntityNote> entityNotes)
        {
            var viewData = new EntityNotesViewData(entityNotes, null, $"{FieldDefinition.Project.GetFieldDefinitionLabel()}", false);
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
        private string GeneratePartialViewForDocuments(List<EntityDocument> entityDocuments)
        {
            var viewData = new ProjectDocumentsDetailViewData(entityDocuments, null, $"{FieldDefinition.Project.GetFieldDefinitionLabel()}", false, false);
            var partialViewToString = RenderPartialViewToString(ProjectDocumentsPartialViewPath, viewData);
            return partialViewToString;
        }


        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public PartialViewResult ProjectUpdateBatchDiff(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            var viewData = new ProjectUpdateBatchDiffLogViewData(CurrentPerson, projectUpdateBatch);
            var partialViewToString = RenderPartialViewToString(ProjectUpdateBatchDiffLogPartialViewPath, viewData);
            return ViewHtmlDiff(partialViewToString,$"{FieldDefinition.Project.GetFieldDefinitionLabel()} Update from {projectUpdateBatch.LastUpdateDate.ToLongDateString()}");
        }

        [HttpGet]
        [ProjectUpdateCreateEditSubmitFeature]
        public ActionResult Organizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();

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

            if (!ModelState.IsValid)
            {
                return ViewOrganizations(projectUpdateBatch, viewModel);
            }

            

            HttpRequestStorage.DatabaseEntities.ProjectOrganizationUpdates.Load();
            var projectOrganizationUpdates = projectUpdateBatch.ProjectOrganizationUpdates.ToList();
            var allProjectOrganizationUpdates = HttpRequestStorage.DatabaseEntities.AllProjectOrganizationUpdates.Local;

            viewModel.UpdateModel(projectUpdateBatch,projectOrganizationUpdates, allProjectOrganizationUpdates);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.OrganizationsComment = viewModel.Comments;
            }

            SetMessageForDisplay($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()} successfully saved.");

            return TickleLastUpdateDateAndGoToNextSection(viewModel, projectUpdateBatch,
                ProjectUpdateSection.Organizations);
        }

        private ActionResult ViewOrganizations(ProjectUpdateBatch projectUpdateBatch, OrganizationsViewModel viewModel)
        {
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var organizationsValidationResult = projectUpdateBatch.ValidateOrganizations();

            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.FullNameFirstLastAndOrg).ToList();
            if (!allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allRelationshipTypes = HttpRequestStorage.DatabaseEntities.RelationshipTypes.ToList();
            var defaultPrimaryContact = projectUpdateBatch.Project?.GetPrimaryContact() ?? CurrentPerson.Organization.PrimaryContactPerson;
            
            var editOrganizationsViewData = new EditOrganizationsViewData(allOrganizations, allPeople, allRelationshipTypes, defaultPrimaryContact);

            var projectOrganizationsDetailViewData = new ProjectOrganizationsDetailViewData(projectUpdateBatch.ProjectOrganizationUpdates.Select(x => new ProjectOrganizationRelationship(x.ProjectUpdateBatch.Project, x.Organization, x.RelationshipType)).ToList(), projectUpdateBatch.ProjectUpdate.GetPrimaryContact());
            var viewData = new OrganizationsViewData(CurrentPerson, projectUpdateBatch,
                ProjectUpdateSection.Organizations, updateStatus, editOrganizationsViewData, organizationsValidationResult,projectOrganizationsDetailViewData);

            return RazorView<Organizations, OrganizationsViewData, OrganizationsViewModel>(viewData, viewModel);
        }

        private UpdateStatus GetUpdateStatus(ProjectUpdateBatch projectUpdateBatch)
        {
            var isPerformanceMeasuresUpdated = DiffPerformanceMeasuresImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isExpendituresUpdated = DiffExpendituresImpl(projectUpdateBatch.ProjectID).HasChanged;
//            var isBudgetsUpdated = DiffBudgetsImpl(projectUpdateBatch.ProjectID).HasChanged;
            // ReSharper disable once ConvertToConstant.Local
            var isBudgetsUpdated = false;
            var isLocationSimpleUpdated = IsLocationSimpleUpdated(projectUpdateBatch.ProjectID);
            var isLocationDetailUpdated = IsLocationDetailedUpdated(projectUpdateBatch.ProjectID);
            var isWatershedUpdated = IsWatershedUpdated(projectUpdateBatch.ProjectID);
            var isExternalLinksUpdated = DiffExternalLinksImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isNotesUpdated = DiffNotesAndDocumentsImpl(projectUpdateBatch.ProjectID).HasChanged;

            //Must be called last, since basics actually changes the Project object which can break the other Diff functions
            var isBasicsUpdated = DiffBasicsImpl(projectUpdateBatch.ProjectID).HasChanged;

            var isExpectedFundingUpdated = DiffExpectedFundingImpl(projectUpdateBatch.ProjectID).HasChanged;

            var isOrganizationsUpdated = DiffOrganizationsImpl(projectUpdateBatch.ProjectID).HasChanged;

            return new UpdateStatus(isBasicsUpdated,
                isPerformanceMeasuresUpdated,
                isExpendituresUpdated,
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                isBudgetsUpdated,
                projectUpdateBatch.IsPhotosUpdated,
                isLocationSimpleUpdated,
                isLocationDetailUpdated,
                isWatershedUpdated,
                isExternalLinksUpdated,
                isNotesUpdated,
                isExpectedFundingUpdated,
                isOrganizationsUpdated);
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
            calendarYearsUpdated.Where(x => !calendarYearsOriginal.Contains(x)).ForEach(x => calendarYearStrings.Add(new CalendarYearString(x, AddedDeletedOrRealElement.AddedElement)));
            // now go through all the original calendar years and mark them as either "deleted" or an update, with "deleted" meaning not being in the modified set
            calendarYearStrings.AddRange(calendarYearsOriginal.Select(x => new CalendarYearString(x, !calendarYearsUpdated.Contains(x) ? AddedDeletedOrRealElement.DeletedElement : AddedDeletedOrRealElement.RealElement)));
            return calendarYearStrings;
        }

        private static List<CalendarYearString> GetCalendarYearStringsForDiffForUpdated(List<int> calendarYearsOriginal, List<int> calendarYearsUpdated)
        {
            var calendarYearStrings = new List<CalendarYearString>();
            // get the calendar years that are not in the modified and add them and mark as "deleted"
            calendarYearsOriginal.Where(x => !calendarYearsUpdated.Contains(x)).ForEach(x => calendarYearStrings.Add(new CalendarYearString(x, AddedDeletedOrRealElement.DeletedElement)));
            // now go through all the modified calendar years and mark them as either "added" or an update, with "added" meaning not being in the original set
            calendarYearStrings.AddRange(calendarYearsUpdated.Select(i => new CalendarYearString(i, !calendarYearsOriginal.Contains(i) ? AddedDeletedOrRealElement.AddedElement : AddedDeletedOrRealElement.RealElement)));
            return calendarYearStrings;
        }

        private ActionResult TickleLastUpdateDateAndGoToNextSection(FormViewModel viewModel, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateSection currentSection)
        {
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            var applicableWizardSections = projectUpdateBatch.GetApplicableWizardSections();
            var nextProjectUpdateSection = applicableWizardSections.Where(x => x.SortOrder > currentSection.SortOrder).OrderBy(x => x.SortOrder).FirstOrDefault();
            var nextSection = viewModel.AutoAdvance && nextProjectUpdateSection != null ? nextProjectUpdateSection.GetSectionUrl(projectUpdateBatch.Project) : currentSection.GetSectionUrl(projectUpdateBatch.Project);
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
            ProjectOrganizationUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshOrganizations(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    $"Are you sure you want to refresh the {FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()} for this {FieldDefinition.Project.GetFieldDefinitionLabel()}? This will pull the most recently approved information for the {FieldDefinition.Project.GetFieldDefinitionLabel()}. Any updates made in this section will be lost.");
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
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchAndThrowIfNoneFound(project, $"There is no current Project Update for Project {project.DisplayName}");

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
                new ProjectOrganization(x.Organization, x.RelationshipType, HtmlDiffContainer.DisplayCssClassAddedElement)));
            projectOrganizations
                .Where(x => organizationsOnlyInOriginal.Contains(x, comparer))
                .ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement);

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
                new ProjectOrganization(x.Organization, x.RelationshipType, HtmlDiffContainer.DisplayCssClassDeletedElement)));
            projectOrganizations
                .Where(x => organizationsOnlyInUpdated.Contains(x, comparer))
                .ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            return GeneratePartialViewForOrganizationsAsString(projectOrganizations, project.GetPrimaryContact());
        }

        private string GeneratePartialViewForOrganizationsAsString(IEnumerable<ProjectOrganization> projectOrganizations, Person primaryContactPerson)
        {
            var viewData = new ProjectOrganizationsDetailViewData(projectOrganizations.Select(x => new ProjectOrganizationRelationship(x.Project, x.Organization, x.RelationshipType, x.DisplayCssClass)).ToList(), primaryContactPerson);
            var partialViewAsString = RenderPartialViewToString(ProjectOrganizationsPartialViewPath, viewData);
            return partialViewAsString;
        }

        public class ProjectOrganizationEqualityComparer : EqualityComparerByProperty<IProjectOrganization>
        {

            public ProjectOrganizationEqualityComparer() : base(x => new {x.Organization.OrganizationID, x.RelationshipType.RelationshipTypeID})
            {
                
            }
            public ProjectOrganizationEqualityComparer(Func<IProjectOrganization, object> f) : base(f)
            {
            }
        }

        // BootstrapHtmlHelper's alert modal dialog method isn't great at dealing with near-arbitrary HTML like we expect these "Intro Content" strings to be, so we're using the From Url version instead, which seems to work better.

        public ContentResult KickOffIntroPreview()
        {
            return new ContentResult
            {
                Content = EmailContentPreview(MultiTenantHelpers.GetProjectUpdateConfiguration().ProjectUpdateKickOffIntroContent)
            };
        }

        public ContentResult ReminderIntroPreview()
        {
            return new ContentResult
            {
                Content = EmailContentPreview(MultiTenantHelpers.GetProjectUpdateConfiguration().ProjectUpdateReminderIntroContent) 
            };
        }

        public ContentResult CloseOutIntroPreview()
        {
            return new ContentResult
            {
                Content = EmailContentPreview(MultiTenantHelpers.GetProjectUpdateConfiguration().ProjectUpdateCloseOutIntroContent)
            };
        }

        private static string EmailContentPreview(string introContent)
        {
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();

            var emailContentPreview = new ProjectUpdateNotificationHelper(
                tenantAttribute.PrimaryContactPerson.Email, introContent, "",
                tenantAttribute.TenantSquareLogoFileResource,
                MultiTenantHelpers.GetToolDisplayName()).GetEmailContentPreview();

            return emailContentPreview;
        }
    }
}
