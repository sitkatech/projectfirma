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
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectUpdateController : FirmaBaseController
    {
        public const string ProjectUpdateBatchDiffLogPartialViewPath = "~/Views/ProjectUpdate/ProjectUpdateBatchDiffLog.cshtml";
        public const string ProjectBasicsPartialViewPath = "~/Views/Shared/ProjectControls/ProjectBasics.cshtml";
        public const string PerformanceMeasureReportedValuesPartialViewPath = "~/Views/Shared/PerformanceMeasureControls/PerformanceMeasureReportedValuesSummary.cshtml";
        public const string ProjectExpendituresPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectExpendituresSummary.cshtml";
        public const string TransporationBudgetsPartialViewPath = "~/Views/Shared/ProjectUpdateDiffControls/ProjectBudgetSummary.cshtml";
        public const string ImageGalleryPartialViewPath = "~/Views/Shared/ImageGallery.cshtml";
        public const string ExternalLinksPartialViewPath = "~/Views/Shared/TextControls/EntityExternalLinks.cshtml";
        public const string EntityNotesPartialViewPath = "~/Views/Shared/TextControls/EntityNotes.cshtml";

        [ProjectUpdateViewFeature]
        public ViewResult AllMyProjects()
        {
            const ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum filterTypeEnum = ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllMyProjects;
            var gridDataUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(filterTypeEnum));
            return ViewIndex(gridDataUrl, filterTypeEnum);
        }

        [ProjectUpdateViewFeature]
        public ViewResult MySubmittedProjects()
        {
            const ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum filterTypeEnum = ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects;
            var gridDataUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(filterTypeEnum));
            return ViewIndex(gridDataUrl, filterTypeEnum);
        }

        [ProjectUpdateViewFeature]
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

        [ProjectUpdateViewFeature]
        public GridJsonNetJObjectResult<Project> IndexGridJsonData(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterType)
        {
            ProjectUpdateStatusGridSpec gridSpec;
            var projects = GetProjectUpdateStatusGridSpec(out gridSpec, CurrentPerson, projectUpdateStatusFilterType);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Project> GetProjectUpdateStatusGridSpec(out ProjectUpdateStatusGridSpec gridSpec, Person currentPerson, ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterTypeEnum)
        {
            gridSpec = new ProjectUpdateStatusGridSpec(projectUpdateStatusFilterTypeEnum, currentPerson.IsApprover());
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().Where(p => p.IsUpdatableViaProjectUpdateProcess);

            switch (projectUpdateStatusFilterTypeEnum)
            {
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllMyProjects:
                    projects = projects.Where(p => p.IsMyProject(currentPerson));
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MyProjectsRequiringAnUpdate:
                    projects = projects.Where(p => p.IsMyProject(currentPerson) && p.IsUpdateMandatory && p.GetLatestUpdateState() != ProjectUpdateState.Submitted);
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects:
                    projects = projects.Where(p => p.IsMyProject(currentPerson) && (!p.IsUpdateMandatory || p.GetLatestUpdateState() == ProjectUpdateState.Submitted));
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
            return projects.OrderBy(x => x.DisplayName).ToList();
        }

        [ProjectUpdateManageFeature]
        public ViewResult Instructions(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new InstructionsViewData(CurrentPerson, projectUpdateBatch, updateStatus);
            return RazorView<Instructions, InstructionsViewData>(viewData);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public ViewResult Basics(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdate = ProjectUpdate.GetCurrentProjectUpdateForProject(project, CurrentPerson);
            var showValidationWarnings = projectUpdate.ProjectUpdateBatch.ShowBasicsValidationWarnings;
            var viewModel = new BasicsViewModel(projectUpdate, showValidationWarnings, projectUpdate.ProjectUpdateBatch.BasicsComment);
            return ViewBasics(projectUpdate, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Basics(ProjectPrimaryKey projectPrimaryKey, BasicsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdate = ProjectUpdate.GetCurrentProjectUpdateForProject(project, CurrentPerson);
            if (!ModelState.IsValid)
            {
                return ViewBasics(projectUpdate, viewModel);
            }
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdate.ProjectUpdateID))
            {
                HttpRequestStorage.DatabaseEntities.ProjectUpdates.Add(projectUpdate);
            }
            viewModel.UpdateModel(projectUpdate.ProjectUpdateBatch);
            if (projectUpdate.ProjectUpdateBatch.IsSubmitted)
            {
                projectUpdate.ProjectUpdateBatch.BasicsComment = viewModel.Comments;
            }
            projectUpdate.ProjectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Basics(project)));
        }

        private ViewResult ViewBasics(ProjectUpdate projectUpdate, BasicsViewModel viewModel)
        {
            var basicsValidationResult = projectUpdate.ProjectUpdateBatch.ValidateProjectBasics();
            var viewDataForAngularClass = new BasicsViewData.ViewDataForAngularClass(basicsValidationResult.GetWarningMessages());
            var inflationRate = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest().InflationRate;
            var updateStatus = GetUpdateStatus(projectUpdate.ProjectUpdateBatch);

            var viewData = new BasicsViewData(CurrentPerson, projectUpdate, ProjectStage.All, viewDataForAngularClass, inflationRate, updateStatus);
            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshBasics(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshBasics(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshBasics(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            if (projectUpdate != null)
            {
                projectUpdate.LoadUpdateFromProject(project);
                projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            }
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshBasics(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    "Are you sure you want to refresh the Project basics data? This will pull the most recently approved information for the project and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public ViewResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var performanceMeasureActualUpdateSimples =
                projectUpdateBatch.PerformanceMeasureActualUpdates.OrderBy(pam => pam.PerformanceMeasureID)
                    .ThenByDescending(x => x.CalendarYear)
                    .Select(x => new PerformanceMeasureActualUpdateSimple(x))
                    .ToList();
            var projectExemptReportingYearUpdates = projectUpdateBatch.ProjectExemptReportingYearUpdates.Select(x => new ProjectExemptReportingYearUpdateSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList();
            var possibleYearsToExempt = ProjectUpdateBatch.GetProjectUpdateImplementationStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            projectExemptReportingYearUpdates.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x))
                    .Select((x, index) => new ProjectExemptReportingYearUpdateSimple(-(index + 1), projectUpdateBatch.ProjectUpdateBatchID, x)));

            var viewModel = new PerformanceMeasuresViewModel(performanceMeasureActualUpdateSimples,
                projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation,
                projectExemptReportingYearUpdates.OrderBy(x => x.CalendarYear).ToList(),
                projectUpdateBatch.ShowPerformanceMeasuresValidationWarnings,
                projectUpdateBatch.PerformanceMeasuresComment);
            return ViewPerformanceMeasures(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, PerformanceMeasuresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            if (!ModelState.IsValid)
            {
                return ViewPerformanceMeasures(projectUpdateBatch, viewModel);
            }
            var currentPerformanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualUpdates.Load();
            var allPerformanceMeasureActualUpdates = HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualUpdates.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptionUpdates.Load();
            var allPerformanceMeasureActualSubcategoryOptionUpdates = HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptionUpdates.Local;
            viewModel.UpdateModel(currentPerformanceMeasureActualUpdates, allPerformanceMeasureActualUpdates, allPerformanceMeasureActualSubcategoryOptionUpdates, projectUpdateBatch);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.PerformanceMeasuresComment = viewModel.Comments;
            }
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);

            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.PerformanceMeasures(project)));
        }

        private ViewResult ViewPerformanceMeasures(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasuresViewModel viewModel)
        {
            var performanceMeasures =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var showExemptYears = projectUpdateBatch.ProjectExemptReportingYearUpdates.Any() ||
                                  ModelState.Values.SelectMany(x => x.Errors)
                                      .Any(
                                          x =>
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears ||
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears);

            var performanceMeasureSubcategories = performanceMeasures.SelectMany(x => x.PerformanceMeasureSubcategories).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureSubcategory>()).ToList();
            var performanceMeasureSimples = performanceMeasures.Select(x => new PerformanceMeasureSimple(x)).OrderBy(p => p.PerformanceMeasureID).ToList();
            var performanceMeasureSubcategorySimples = performanceMeasureSubcategories.Select(y => new PerformanceMeasureSubcategorySimple(y)).ToList();

            var performanceMeasureSubcategoryOptionSimples = performanceMeasureSubcategories.SelectMany(y => y.PerformanceMeasureSubcategoryOptions.Select(z => new PerformanceMeasureSubcategoryOptionSimple(z))).ToList();
            
            var calendarYears = FirmaDateUtilities.ReportingYearsForUserInput().OrderByDescending(x => x).ToList();
            var performanceMeasuresValidationResult = projectUpdateBatch.ValidatePerformanceMeasures();

            var viewDataForAngularEditor = new PerformanceMeasuresViewData.ViewDataForAngularEditor(projectUpdateBatch.ProjectUpdateBatchID,
                performanceMeasureSimples,
                performanceMeasureSubcategorySimples,
                performanceMeasureSubcategoryOptionSimples,
                calendarYears,
                showExemptYears,
                performanceMeasuresValidationResult);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new PerformanceMeasuresViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, updateStatus);
            return RazorView<PerformanceMeasures, PerformanceMeasuresViewData, PerformanceMeasuresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshPerformanceMeasures(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
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
                    "Are you sure you want to refresh the performance measures for this Project? This will pull the most recently approved information for the project and use the updated Start Year and Completion Year from the Basics section. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public ViewResult Expenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var projectFundingSourceExpenditureUpdates = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var calendarYearRange = projectFundingSourceExpenditureUpdates.CalculateCalendarYearRangeForExpenditures(projectUpdateBatch.ProjectUpdate);
            var viewModel = new ExpendituresViewModel(projectFundingSourceExpenditureUpdates,
                calendarYearRange,
                projectUpdateBatch.ShowExpendituresValidationWarnings,
                projectUpdateBatch.ExpendituresComment);
            return ViewExpenditures(projectUpdateBatch, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Expenditures(ProjectPrimaryKey projectPrimaryKey, ExpendituresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var projectFundingSourceExpenditureUpdates = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var calendarYearRange = projectFundingSourceExpenditureUpdates.CalculateCalendarYearRangeForExpenditures(projectUpdateBatch.ProjectUpdate);
            if (!ModelState.IsValid)
            {
                return ViewExpenditures(projectUpdateBatch, calendarYearRange, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureUpdates.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureUpdates.Local;
            viewModel.UpdateModel(projectUpdateBatch, projectFundingSourceExpenditureUpdates, allProjectFundingSourceExpenditures);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.ExpendituresComment = viewModel.Comments;
            }
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Expenditures(project)));
        }

        private ViewResult ViewExpenditures(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearRange, ExpendituresViewModel viewModel)
        {
            var project = projectUpdateBatch.Project;
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var projectFundingOrganizationFundingSourceIDs = project.ProjectFundingOrganizations.SelectMany(x => x.Organization.FundingSources.Select(y => y.FundingSourceID));
            var expendituresValidationResult = projectUpdateBatch.ValidateExpenditures();

            var viewDataForAngularEditor = new ExpendituresViewData.ViewDataForAngularClass(project,
                allFundingSources,
                calendarYearRange,
                projectFundingOrganizationFundingSourceIDs,
                expendituresValidationResult);
            var projectFundingSourceExpenditures = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            var fromFundingSourcesAndCalendarYears = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(
                new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures),
                calendarYearRange);
            var projectExpendituresSummaryViewData = new ProjectExpendituresDetailViewData(fromFundingSourcesAndCalendarYears, calendarYearRange);

            var viewData = new ExpendituresViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectExpendituresSummaryViewData, GetUpdateStatus(projectUpdateBatch));
            return RazorView<Expenditures, ExpendituresViewData, ExpendituresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshExpenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshExpenditures(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshExpenditures(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
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
                    "Are you sure you want to refresh the expenditures for this Project? This will pull the most recently approved information for the project and use the updated Start Year and Completion Year from the Basics section. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public ViewResult Budgets(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectBudgetUpdates.ToList();
            var calendarYearRange = projectFundingSourceBudgetUpdates.CalculateCalendarYearRangeForBudgets(projectUpdateBatch.ProjectUpdate);
            var viewModel = new BudgetsViewModel(projectFundingSourceBudgetUpdates,
                calendarYearRange,
                projectUpdateBatch.ShowBudgetsValidationWarnings,
                projectUpdateBatch.BudgetsComment);
            return ViewBudgets(projectUpdateBatch, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Budgets(ProjectPrimaryKey projectPrimaryKey, BudgetsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectBudgetUpdates.ToList();
            var calendarYearRange = projectFundingSourceBudgetUpdates.CalculateCalendarYearRangeForBudgets(projectUpdateBatch.ProjectUpdate);
            if (!ModelState.IsValid)
            {
                return ViewBudgets(projectUpdateBatch, calendarYearRange, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectBudgetUpdates.Load();
            var allProjectFundingSourceBudgets = HttpRequestStorage.DatabaseEntities.ProjectBudgetUpdates.Local;
            viewModel.UpdateModel(projectUpdateBatch, projectFundingSourceBudgetUpdates, allProjectFundingSourceBudgets);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.BudgetsComment = viewModel.Comments;
            }
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.Budgets(project)));
        }

        private ViewResult ViewBudgets(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearRange, BudgetsViewModel viewModel)
        {
            var project = projectUpdateBatch.Project;
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var projectFundingOrganizationFundingSourceIDs = project.ProjectFundingOrganizations.SelectMany(x => x.Organization.FundingSources.Select(y => y.FundingSourceID));
            var budgetsValidationResult = projectUpdateBatch.ValidateBudgets();
            var projectCostTypeSimples = ProjectCostType.All.Select(x => new ProjectCostTypeSimple(x)).ToList();

            var viewDataForAngularEditor = new BudgetsViewData.ViewDataForAngularEditor(project, 
                allFundingSources,
                projectCostTypeSimples,
                calendarYearRange,
                projectFundingOrganizationFundingSourceIDs,
                budgetsValidationResult);

            var projectBudgetAmounts =
                ProjectBudgetAmount.CreateFromProjectBudgets(new List<IProjectBudgetAmount>(projectUpdateBatch.ProjectBudgetUpdates.ToList()));
            var projectBudgetsSummaryViewData = new ProjectBudgetDetailViewData(projectBudgetAmounts, calendarYearRange);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new BudgetsViewData(CurrentPerson, projectUpdateBatch, viewDataForAngularEditor, projectBudgetsSummaryViewData, updateStatus);
            return RazorView<Budgets, BudgetsViewData, BudgetsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshBudgets(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshBudgets(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshBudgets(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
            projectUpdateBatch.DeleteProjectBudgetUpdates();
            // refresh data
            ProjectBudgetUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshBudgets(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    "Are you sure you want to refresh the budgets for this Project? This will pull the most recently approved information for the project and use the updated Start Year and Completion Year from the Basics section. Any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [ProjectUpdateManageFeature]
        public ViewResult Photos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNewAndSaveToDatabase(project, CurrentPerson);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new PhotosViewData(CurrentPerson, projectUpdateBatch, updateStatus);
            return RazorView<Photos, PhotosViewData>(viewData);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshPhotos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshPhotos(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshPhotos(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();

            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
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
                    "Are you sure you want to refresh the photos for this Project? This will pull the most recently approved information for the project and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public ViewResult LocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdate = ProjectUpdate.GetCurrentProjectUpdateForProject(project, CurrentPerson);
            var viewModel = new LocationSimpleViewModel(projectUpdate.ProjectLocationPoint,
                projectUpdate.ProjectLocationAreaID,
                projectUpdate.ProjectLocationSimpleType.ToEnum,
                projectUpdate.ProjectLocationNotes,
                projectUpdate.ProjectUpdateBatch.LocationSimpleComment,
                projectUpdate.ProjectUpdateBatch.ShowLocationSimpleValidationWarnings);
            return ViewLocationSimple(project, projectUpdate, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult LocationSimple(ProjectPrimaryKey projectPrimaryKey, LocationSimpleViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdate = ProjectUpdate.GetCurrentProjectUpdateForProject(project, CurrentPerson);
            if (!ModelState.IsValid)
            {
                return ViewLocationSimple(project, projectUpdate, viewModel);
            }
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;
            viewModel.UpdateModelBatch(projectUpdateBatch);
            if (projectUpdateBatch.IsSubmitted)
            {
                projectUpdateBatch.LocationSimpleComment = viewModel.Comments;
            }
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.LocationSimple(project)));
        }

        private ViewResult ViewLocationSimple(Project project, ProjectUpdate projectUpdate, LocationSimpleViewModel viewModel)
        {
            var mapInitJsonForEdit = new MapInitJson(string.Format("project_{0}_EditMap", project.ProjectID),
                10,
                MapInitJson.GetWatershedAndJurisdictionMapLayers(),
                BoundingBox.MakeNewDefaultBoundingBox(),
                false);
            var locationSimpleValidationResult = projectUpdate.ProjectUpdateBatch.ValidateProjectLocationSimple();

            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(projectUpdate, string.Format("project_{0}_EditMap", project.ProjectID));
            var projectLocationAreas = HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.ToSelectList();
            var mapPostUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationFormID(project);
            var editProjectLocationViewData = new EditProjectLocationSimpleViewData(CurrentPerson, mapInitJsonForEdit, projectLocationAreas, mapPostUrl, mapFormID);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(projectUpdate, projectLocationSummaryMapInitJson);
            var viewDataForAngularClass = new LocationSimpleViewData.ViewDataForAngularClass(locationSimpleValidationResult.GetWarningMessages());
            var updateStatus = GetUpdateStatus(projectUpdate.ProjectUpdateBatch);
            var viewData = new LocationSimpleViewData(CurrentPerson, projectUpdate, editProjectLocationViewData, projectLocationSummaryViewData, viewDataForAngularClass, updateStatus);
            return RazorView<LocationSimple, LocationSimpleViewData, LocationSimpleViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshProjectLocationSimple(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
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
                    "Are you sure you want to refresh the Project location data? This will pull the most recently approved information for the project and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public ViewResult LocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdate = ProjectUpdate.GetCurrentProjectUpdateForProject(project, CurrentPerson);
            var viewModel = new LocationDetailedViewModel(projectUpdate.ProjectUpdateBatch.LocationDetailedComment);
            return ViewLocationDetailed(projectUpdate, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult LocationDetailed(ProjectPrimaryKey projectPrimaryKey, LocationDetailedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdate = ProjectUpdate.GetCurrentProjectUpdateForProject(project, CurrentPerson);
            if (!ModelState.IsValid)
            {
                return ViewLocationDetailed(projectUpdate, viewModel);
            }
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;
            SaveProjectLocationUpdates(viewModel, projectUpdateBatch);

            if (projectUpdate.ProjectUpdateBatch.IsSubmitted)
            {
                projectUpdate.ProjectUpdateBatch.LocationDetailedComment = viewModel.Comments;
            }
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.LocationDetailed(project)));
        }

        private ViewResult ViewLocationDetailed(ProjectUpdate projectUpdate, LocationDetailedViewModel viewModel)
        {
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;
            var project = projectUpdateBatch.Project;

            var mapDivID = string.Format("project_{0}_EditDetailedMap", project.ProjectID);
            var detailedLocationGeoJsonFeatureCollection = projectUpdate.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson("Project Location Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var boundingBox = new BoundingBox(projectUpdate.GetProjectLocationDetails().Select(x => x.ProjectLocationGeometry));
            var mapInitJson = new MapInitJson(mapDivID, 10, MapInitJson.GetWatershedAndJurisdictionMapLayers(), boundingBox) {AllowFullScreen = false};
            var mapFormID = ProjectLocationController.GenerateEditProjectLocationFormID(projectUpdateBatch.ProjectID);
            var uploadGisFileUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.ProjectID));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(project.ProjectID, null));
            var projectLocationDetailViewData = new ProjectLocationDetailViewData(projectUpdateBatch.ProjectID,
                mapInitJson,
                editableLayerGeoJson,
                uploadGisFileUrl,
                mapFormID,
                saveFeatureCollectionUrl,
                ProjectLocationUpdate.FieldLengths.Annotation);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new LocationDetailedViewData(CurrentPerson, projectUpdateBatch, projectLocationDetailViewData, uploadGisFileUrl, updateStatus);
            return RazorView<LocationDetailed, LocationDetailedViewData, LocationDetailedViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshProjectLocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshProjectLocationDetailed(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshProjectLocationDetailed(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
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
                    "Are you sure you want to refresh the Project location data? This will pull the most recently approved information for the project and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
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
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey, ImportGdbFileViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewImportGdbFile(project, viewModel);
            }

            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var httpPostedFileBase = viewModel.FileResourceData;
            var fileEnding = ".gdb.zip";
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var gdbFile = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(gdbFile.FullName);
                HttpRequestStorage.DatabaseEntities.ProjectLocationStagingUpdates.RemoveRange(projectUpdateBatch.ProjectLocationStagingUpdates.ToList());
                projectUpdateBatch.ProjectLocationStagingUpdates.Clear();
                ProjectLocationStagingUpdate.CreateProjectLocationStagingUpdateListFromGdb(gdbFile, projectUpdateBatch, CurrentPerson);
            }
            return ApproveGisUpload(project);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
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

            var mapInitJson = new MapInitJson(string.Format("project_{0}_PreviewMap", projectUpdateBatch.ProjectID), 10, layerGeoJsons, boundingBox, false) {AllowFullScreen = false};
            var mapFormID = ProjectLocationController.GenerateEditProjectLocationFormID(projectUpdateBatch.ProjectID);
            var approveGisUploadUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ApproveGisUpload(projectUpdateBatch.Project, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagingUpdates), mapInitJson, mapFormID, approveGisUploadUrl);
            return RazorPartialView<ApproveGisUpload, ApproveGisUploadViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var projectUpdateBatch = projectPrimaryKey.EntityObject.GetLatestNotApprovedUpdateBatch();
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
            HttpRequestStorage.DatabaseEntities.ProjectLocationUpdates.RemoveRange(projectLocationUpdates);
            projectUpdateBatch.ProjectLocationUpdates.Clear();
            if (viewModel.WktAndAnnotations != null)
            {
                foreach (var wktAndAnnotation in viewModel.WktAndAnnotations)
                {
                    projectUpdateBatch.ProjectLocationUpdates.Add(new ProjectLocationUpdate(projectUpdateBatch, DbGeometry.FromText(wktAndAnnotation.Wkt), wktAndAnnotation.Annotation));
                }
            }
        }

        [ProjectUpdateManageFeature]
        public ViewResult Notes(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNewAndSaveToDatabase(project, CurrentPerson);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var diffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffNotes(projectPrimaryKey));
            var viewData = new NotesViewData(CurrentPerson, projectUpdateBatch, updateStatus, diffUrl);
            return RazorView<Notes, NotesViewData>(viewData);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshNotes(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshNotes(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshNotes(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
            projectUpdateBatch.DeleteProjectNoteUpdates();
            // finally create a new project update record, refreshing with the current project data at this point in time
            ProjectNoteUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewRefreshNotes(ConfirmDialogFormViewModel viewModel)
        {
            var viewData =
                new ConfirmDialogFormViewData(
                    "Are you sure you want to refresh the notes for this Project? This will pull the most recently approved information for the project and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public ViewResult ExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var viewModel =
                new EditProjectExternalLinksViewModel(
                    projectUpdateBatch.ProjectExternalLinkUpdates.Select(
                        x => new ProjectExternalLinkSimple(x.ProjectExternalLinkUpdateID, x.ProjectUpdateBatchID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList());
            return ViewExternalLinks(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExternalLinks(ProjectPrimaryKey projectPrimaryKey, EditProjectExternalLinksViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            if (!ModelState.IsValid)
            {
                return ViewExternalLinks(projectUpdateBatch, viewModel);
            }
            var currentProjectExternalLinkUpdates = projectUpdateBatch.ProjectExternalLinkUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinkUpdates.Load();
            var allProjectExternalLinkUpdates = HttpRequestStorage.DatabaseEntities.ProjectExternalLinkUpdates.Local;
            viewModel.UpdateModel(currentProjectExternalLinkUpdates, allProjectExternalLinkUpdates);
            projectUpdateBatch.TickleLastUpdateDate(CurrentPerson);
            return RedirectToAction(new SitkaRoute<ProjectUpdateController>(x => x.ExternalLinks(project)));
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
        [ProjectUpdateManageFeature]
        public PartialViewResult RefreshExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewRefreshExternalLinks(viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RefreshExternalLinks(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("We should have a project update batch when refreshing; didn't find one for Project {0}", project.DisplayName));
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
                    "Are you sure you want to refresh the notes for this Project? This will pull the most recently approved information for the project and any updates made in this section will be lost.");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult Approve(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);

            Check.RequireNotNull(projectUpdateBatch, string.Format("There is no current Project Update to approve for Project {0}", project.DisplayName));
            Check.Require(projectUpdateBatch.IsSubmitted, "The project is not in a state to be ready to be approved!");
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewApprove(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Approve(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("There is no current Project Update to approve for Project {0}", project.DisplayName));
            Check.Require(projectUpdateBatch.IsSubmitted, "The project is not in a state to be ready to be approved!");

            WriteHtmlDiffLogs(projectPrimaryKey, projectUpdateBatch);

            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptReportingYears = HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Local;
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Local;
            HttpRequestStorage.DatabaseEntities.ProjectBudgets.Load();
            var allProjectBudgets = HttpRequestStorage.DatabaseEntities.ProjectBudgets.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            var allPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Load();
            var allPerformanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Local;
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Load();
            var allProjectExternalLinks = HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Local;
            HttpRequestStorage.DatabaseEntities.ProjectNotes.Load();
            var allProjectNotes = HttpRequestStorage.DatabaseEntities.ProjectNotes.Local;
            HttpRequestStorage.DatabaseEntities.ProjectImages.Load();
            var allProjectImages = HttpRequestStorage.DatabaseEntities.ProjectImages.Local;
            HttpRequestStorage.DatabaseEntities.ProjectLocations.Load();
            var allProjectLocations = HttpRequestStorage.DatabaseEntities.ProjectLocations.Local;

            projectUpdateBatch.Approve(CurrentPerson,
                DateTime.Now,
                allProjectExemptReportingYears,
                allProjectFundingSourceExpenditures,
                allProjectBudgets,
                allPerformanceMeasureActuals,
                allPerformanceMeasureActualSubcategoryOptions,
                allProjectExternalLinks,
                allProjectNotes,
                allProjectImages,
                allProjectLocations);

            // we need to sync funding source updates
            ProjectFundingOrganization.SyncProjectFundingOrganizationsWithProjectFundingSourceExpenditures(new List<int> {projectUpdateBatch.ProjectID},
                projectUpdateBatch.Project.ProjectFundingSourceExpenditures.ToList(),
                projectUpdateBatch.Project.ProjectFundingOrganizations.ToList());

            var peopleToCc = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications();
            Notification.SendApprovalMessage(peopleToCc, projectUpdateBatch);

            SetMessageForDisplay(string.Format("The update for project {0} was approved", projectUpdateBatch.Project.DisplayName));
            return new ModalDialogFormJsonResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(project)));
        }

        private PartialViewResult ViewApprove(ProjectUpdateBatch projectUpdate, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData(string.Format("Are you sure you want to approve the updates to Project {0}?", projectUpdate.Project.DisplayName));
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

            var budgetsDiffContainer = DiffBudgetsImpl(projectPrimaryKey);
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

            var notesDiffContainer = DiffNotesImpl(projectPrimaryKey);
            if (notesDiffContainer.HasChanged)
            {
                var notesDiffHelper = new HtmlDiff.HtmlDiff(notesDiffContainer.OriginalHtml, notesDiffContainer.UpdatedHtml);
                projectUpdateBatch.NotesDiffLogHtmlString = new HtmlString(notesDiffHelper.Build());
            }
        }


        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult Submit(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            Check.RequireNotNull(projectUpdateBatch, string.Format("There is no current Project Update to submit for Project {0}", project.DisplayName));
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewSubmit(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Submit(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("There is no current Project Update to submit for Project {0}", project.DisplayName));
            projectUpdateBatch.SubmitToReviewer(CurrentPerson, DateTime.Now);
            var peopleToCc = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications();
            Notification.SendSubmittedMessage(peopleToCc, projectUpdateBatch);
            SetMessageForDisplay(string.Format("The update for project {0} has been submitted.", projectUpdateBatch.Project.DisplayName));
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewSubmit(ProjectUpdateBatch projectUpdate, ConfirmDialogFormViewModel viewModel)
        {
            //TODO: Change "for review" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData(string.Format("Are you sure you want to submit Project {0} for review?", projectUpdate.Project.DisplayName));
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateViewFeature]
        public PartialViewResult SubmitAll()
        {
            var viewModel = new ConfirmDialogFormViewModel(CurrentPerson.PersonID);
            return ViewSubmitAll(viewModel);
        }

        [HttpPost]
        [ProjectUpdateViewFeature]
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
                Notification.SendSubmittedMessage(peopleToCc, pub);
            });
            SetMessageForDisplay(string.Format("The update(s) for project(s) {0} have been submitted.", string.Join(", ", projectUpdateBatches.Select(x => x.Project.DisplayName))));
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewSubmitAll(ConfirmDialogFormViewModel viewModel)
        {
            //TODO: Change "for review" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData("Are you sure you want to submit all your Projects that are ready to be submitted for review?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult Return(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            Check.RequireNotNull(projectUpdateBatch, string.Format("There is no current Project Update to return for Project {0}", project.DisplayName));
            Check.Require(projectUpdateBatch.IsSubmitted, "You cannot return a project update that has not been submitted!");
            var viewModel = new ReturnDialogFormViewModel();
            return ViewReturn(projectUpdateBatch, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Return(ProjectPrimaryKey projectPrimaryKey, ReturnDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            Check.RequireNotNull(projectUpdateBatch, string.Format("There is no current Project Update to return for Project {0}", project.DisplayName));
            Check.Require(projectUpdateBatch.IsSubmitted, "You cannot return a project update that has not been submitted!");
            viewModel.UpdateModel(projectUpdateBatch);
            projectUpdateBatch.Return(CurrentPerson, DateTime.Now);
            var peopleToCc = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications();
            Notification.SendReturnedMessage(peopleToCc, projectUpdateBatch);
            SetMessageForDisplay(string.Format("The update submitted for project {0} has been returned.", projectUpdateBatch.Project.DisplayName));
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewReturn(ProjectUpdateBatch projectUpdate, ReturnDialogFormViewModel viewModel)
        {
            var viewData = new ReturnDialogFormViewData(string.Format("Are you sure you want to return Project {0}?", projectUpdate.Project.DisplayName));
            return RazorPartialView<ReturnDialogForm, ReturnDialogFormViewData, ReturnDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult DeleteProjectUpdate(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new ConfirmDialogFormViewModel(projectUpdateBatch.ProjectUpdateBatchID);
            return ViewDeleteProjectUpdate(viewModel, projectUpdateBatch);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectUpdate(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            projectUpdateBatch.DeleteAll();
            return new ModalDialogFormJsonResult(SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate()));
        }

        private PartialViewResult ViewDeleteProjectUpdate(ConfirmDialogFormViewModel viewModel, ProjectUpdateBatch projectUpdateBatch)
        {
            var viewData = new ConfirmDialogFormViewData(string.Format("Are you sure you want to delete this update for Project {0}?", projectUpdateBatch.Project.DisplayName));
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [ProjectUpdateManageFeature]
        public ViewResult History(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = ProjectUpdateBatch.GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, CurrentPerson);
            var updateStatus = GetUpdateStatus(projectUpdateBatch);
            var viewData = new HistoryViewData(CurrentPerson, projectUpdateBatch, updateStatus);
            return RazorView<History, HistoryViewData>(viewData);
        }

        private static string GenerateEditProjectLocationFormID(Project project)
        {
            return String.Format("editMapForProposedProject{0}", project.ProjectID);
        }

        [ProjectUpdateAdminFeature]
        public ViewResult Manage()
        {
            var customNotificationUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.CreateCustomNotification(null));
            var projectsRequiringUpdateGridSpec = new ProjectUpdateStatusGridSpec(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects, CurrentPerson.IsApprover())
            {
                ObjectNameSingular = "Project",
                ObjectNamePlural = "Projects",
                SaveFiltersInCookie = true
            };
            var contactsReceivingReminderGridSpec = new PeopleReceivingReminderGridSpec(true) {ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true};
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ManageUpdateNotifications);

            var projectsWithNoContactCount = GetProjectsWithNoContact().Count;

            var viewData = new ManageViewData(CurrentPerson,
                firmaPage,
                customNotificationUrl,
                projectsRequiringUpdateGridSpec,
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ProjectsRequiringUpdateGridJsonData()),
                contactsReceivingReminderGridSpec,
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PeopleReceivingReminderGridJsonData(true)),
                projectsWithNoContactCount);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        private List<Project> GetProjectsWithNoContact()
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            var projectsRequiringUpdate = projects.Where(x => x.IsUpdatableViaProjectUpdateProcess).ToList();
            var projectsWithPrimaryContact = projectsRequiringUpdate.GetPrimaryContactPeople().SelectMany(x => x.GetPrimaryContactProjects());

            return projectsRequiringUpdate.Except(projectsWithPrimaryContact).ToList();
        }

        [ProjectUpdateAdminFeature]
        public GridJsonNetJObjectResult<Project> ProjectsRequiringUpdateGridJsonData()
        {
            var gridSpec = new ProjectUpdateStatusGridSpec(ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects, CurrentPerson.IsApprover());
            var projects =
                HttpRequestStorage.DatabaseEntities.Projects.ToList().Where(x => x.IsUpdatableViaProjectUpdateProcess).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectUpdateViewFeature]
        public GridJsonNetJObjectResult<Person> PeopleReceivingReminderGridJsonData(bool showCheckbox)
        {
            var gridSpec = new PeopleReceivingReminderGridSpec(showCheckbox);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().Where(x => x.IsUpdatableViaProjectUpdateProcess).ToList();
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
            var emailsToCc = new List<string>();

            var message = new MailMessage {Subject = viewModel.Subject, AlternateViews = {AlternateView.CreateAlternateViewFromString(viewModel.NotificationContent ?? string.Empty, null, "text/html")}};

            Notification.SendMessageAndLogNotification(message, emailsToSendTo, emailsToReplyTo, emailsToCc, peopleToNotify, DateTime.Now, new List<Project>(), NotificationType.Custom);

            SetMessageForDisplay(string.Format("Custom notification sent to: {0}", string.Join("; ", emailsToSendTo)));

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
            var emailsToReplyTo = new List<string>();
            var emailsToCc = new List<string>();
            var message = new MailMessage { Subject = viewModel.Subject, AlternateViews = { AlternateView.CreateAlternateViewFromString(viewModel.NotificationContent, null, "text/html") } };
            Notification.SendMessage(message, emailsToSendTo, emailsToReplyTo, emailsToCc);
            return CreateCustomNotification(viewModel);
        }


        [ProjectUpdateViewFeature]
        public ViewResult ProjectUpdateStatus()
        {
            var contactsReceivingReminderGridSpec = new PeopleReceivingReminderGridSpec(false) { ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true };
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ProjectUpdateStatus);

            var viewData = new ProjectUpdateStatusViewData(CurrentPerson,
                firmaPage,
                contactsReceivingReminderGridSpec,
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PeopleReceivingReminderGridJsonData(false)));
            return RazorView<ProjectUpdateStatus, ProjectUpdateStatusViewData>(viewData);
        }
        
        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult DiffBasics(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffBasicsImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffBasicsImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdate = ProjectUpdate.GetCurrentProjectUpdateForProject(project, CurrentPerson);
            var originalHtml = GeneratePartialViewForProjectBasics(project);
            
            projectUpdate.CommitChangesToProject(project);
            var updatedHtml = GeneratePartialViewForProjectBasics(project);

            return new HtmlDiffContainer(originalHtml, updatedHtml);
        }

        private string GeneratePartialViewForProjectBasics(Project project)
        {
            var viewData = new ProjectBasicsViewData(project, false, false, null);

            var partialViewAsString = RenderPartialViewToString(ProjectBasicsPartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult DiffPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffPerformanceMeasuresImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffPerformanceMeasuresImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
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
        [ProjectUpdateManageFeature]
        public PartialViewResult DiffExpenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExpendituresImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExpendituresImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();

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
            var viewData = new Views.Shared.ProjectUpdateDiffControls.ProjectExpendituresSummaryViewData(fundingSourceCalendarYearExpenditures, calendarYearStrings);
            var partialViewAsString = RenderPartialViewToString(ProjectExpendituresPartialViewPath, viewData);
            return partialViewAsString;
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult DiffBudgets(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffBudgetsImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffBudgetsImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();

            var projectBudgetsOriginal = project.ProjectBudgets.ToList();
            var calendarYearsOriginal = projectBudgetsOriginal.CalculateCalendarYearRangeForBudgets(project);
            var projectBudgetsUpdated = projectUpdateBatch.ProjectBudgetUpdates.ToList();
            var calendarYearsUpdated = projectBudgetsUpdated.CalculateCalendarYearRangeForBudgets(projectUpdateBatch.ProjectUpdate);

            var originalHtml = GeneratePartialViewForOriginalBudgets(new List<IProjectBudgetAmount>(projectBudgetsOriginal),
                calendarYearsOriginal,
                new List<IProjectBudgetAmount>(projectBudgetsUpdated),
                calendarYearsUpdated);

            var updatedHtml = GeneratePartialViewForModifiedBudgets(new List<IProjectBudgetAmount>(projectBudgetsOriginal),
                calendarYearsOriginal,
                new List<IProjectBudgetAmount>(projectBudgetsUpdated),
                calendarYearsUpdated);
            var htmlDiffContainer = new HtmlDiffContainer(originalHtml, updatedHtml);
            return htmlDiffContainer;
        }

        private string GeneratePartialViewForBudgetsAsString(List<ProjectBudgetAmount2> projectBudgetAmounts, List<CalendarYearString> calendarYearStrings)
        {
            var viewData = new Views.Shared.ProjectUpdateDiffControls.ProjectBudgetSummaryViewData(projectBudgetAmounts, calendarYearStrings);
            var partialViewAsString = RenderPartialViewToString(TransporationBudgetsPartialViewPath, viewData);
            return partialViewAsString;
        }

        private string GeneratePartialViewForOriginalBudgets(List<IProjectBudgetAmount> projectBudgetAmountsOriginal,
            List<int> calendarYearsOriginal,
            List<IProjectBudgetAmount> projectBudgetAmountsUpdated,
            List<int> calendarYearsUpdated)
        {
            var fundingSourcesInOriginal = projectBudgetAmountsOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = projectBudgetAmountsUpdated.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInOriginal = fundingSourcesInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x)).ToList();

            var projectBudgetAmountsInOriginal = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsOriginal,
                calendarYearsOriginal);
            // we need to zero out calendar year values only in original
            foreach (var projectBudgetAmount2 in projectBudgetAmountsInOriginal)
            {
                ZeroOutBudget(projectBudgetAmount2, calendarYearsOriginal.Except(calendarYearsUpdated).ToList());
            }

            var projectBudgetAmountsInUpdated = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsUpdated, calendarYearsUpdated);

            // find the ones that are only in the modified set and add them and mark them as "added"
            projectBudgetAmountsInOriginal.AddRange(
                projectBudgetAmountsInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x.FundingSourceID))
                    .Select(x => ProjectBudgetAmount2.Clone(x, HtmlDiffContainer.DisplayCssClassAddedElement))
                    .ToList());
            // find the ones only in original and mark them as "deleted"
            projectBudgetAmountsInOriginal.Where(x => fundingSourcesOnlyInOriginal.Contains(x.FundingSourceID))
                .ForEach(x =>
                {
                    ZeroOutBudget(x, calendarYearsOriginal);
                    x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
                });

            var calendarYearStrings = GetCalendarYearStringsForDiffForOriginal(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForBudgetsAsString(projectBudgetAmountsInOriginal, calendarYearStrings);
        }

        private static void ZeroOutBudget(ProjectBudgetAmount2 projectBudgetAmount2, List<int> calendarYearsToZeroOut)
        {
            foreach (var projectCostTypeCalendarYearBudget in projectBudgetAmount2.ProjectCostTypeCalendarYearBudgets)
            {
                foreach (var calendarYear in calendarYearsToZeroOut)
                {
                    projectCostTypeCalendarYearBudget.CalendarYearBudget[calendarYear] = 0;
                }                
            }
        }

        private string GeneratePartialViewForModifiedBudgets(List<IProjectBudgetAmount> projectBudgetAmountsOriginal,
            List<int> calendarYearsOriginal,
            List<IProjectBudgetAmount> projectBudgetAmountsUpdated,
            List<int> calendarYearsUpdated)
        {
            var fundingSourcesInOriginal = projectBudgetAmountsOriginal.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesInUpdated = projectBudgetAmountsUpdated.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSourcesOnlyInUpdated = fundingSourcesInUpdated.Where(x => !fundingSourcesInOriginal.Contains(x)).ToList();

            var projectBudgetAmountsInOriginal = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsOriginal, calendarYearsOriginal);
            var projectBudgetAmountsInUpdated = ProjectBudgetAmount2.CreateFromProjectBudgets(projectBudgetAmountsUpdated, calendarYearsUpdated);

            // find the ones that are only in the original set and add them and mark them as "deleted"
            projectBudgetAmountsInUpdated.AddRange(
                projectBudgetAmountsInOriginal.Where(x => !fundingSourcesInUpdated.Contains(x.FundingSourceID))
                    .Select(x => ProjectBudgetAmount2.Clone(x, HtmlDiffContainer.DisplayCssClassDeletedElement))
                    .ToList());
            // find the ones only in modified and mark them as "added"
            projectBudgetAmountsInUpdated.Where(x => fundingSourcesOnlyInUpdated.Contains(x.FundingSourceID)).ForEach(x => x.DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement);

            var calendarYearStrings = GetCalendarYearStringsForDiffForUpdated(calendarYearsOriginal, calendarYearsUpdated);
            return GeneratePartialViewForBudgetsAsString(projectBudgetAmountsInUpdated, calendarYearStrings);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult DiffPhotos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var htmlDiffContainer = DiffPhotosImpl(projectUpdateBatch);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffPhotosImpl(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;

            var originalImages = new List<IFileResourcePhoto>(project.ProjectImages);
            var updatedImages = new List<IFileResourcePhoto>(projectUpdateBatch.ProjectImageUpdates);

            var dummyProject = Project.CreateNewBlank(TaxonomyTierOne.CreateNewBlank(TaxonomyTierTwo.CreateNewBlank(TaxonomyTierThree.CreateNewBlank())),
                ProjectStage.Completed,
                ProjectLocationSimpleType.None,
                FundingType.Capital);

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

        private bool IsLocationSimpleUpdated(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();

            if (project.ProjectLocationSimpleTypeID != projectUpdateBatch.ProjectUpdate.ProjectLocationSimpleTypeID)
                return true;

            if (project.ProjectLocationNotes != projectUpdateBatch.ProjectUpdate.ProjectLocationNotes)
                return true;

            switch (project.ProjectLocationSimpleType.ToEnum)
            {
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                    if (project.ProjectLocationPoint == null || projectUpdateBatch.ProjectUpdate.ProjectLocationPoint == null)
                    {
                        SitkaLogger.Instance.LogDetailedErrorMessage(string.Format("Project {0}appears to have inconsistent simple location configuration.", project.ProjectID));
                        return true;
                    }
                    return project.ProjectLocationPoint.ToSqlGeometry().STEquals(projectUpdateBatch.ProjectUpdate.ProjectLocationPoint.ToSqlGeometry()).IsFalse;

                case ProjectLocationSimpleTypeEnum.NamedAreas:
                    return project.ProjectLocationAreaID != projectUpdateBatch.ProjectUpdate.ProjectLocationAreaID;
            }

            return false;
        }

        private bool IsLocationDetailedUpdated(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();

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

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult DiffExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffExternalLinksImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffExternalLinksImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
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
        [ProjectUpdateManageFeature]
        public PartialViewResult DiffNotes(ProjectPrimaryKey projectPrimaryKey)
        {
            var htmlDiffContainer = DiffNotesImpl(projectPrimaryKey);
            var htmlDiff = new HtmlDiff.HtmlDiff(htmlDiffContainer.OriginalHtml, htmlDiffContainer.UpdatedHtml);
            return ViewHtmlDiff(htmlDiff.Build(), string.Empty);
        }

        private HtmlDiffContainer DiffNotesImpl(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var entityNotesOriginal = new List<IEntityNote>(project.ProjectNotes);
            var entityNotesUpdated = new List<IEntityNote>(projectUpdateBatch.ProjectNoteUpdates);

            var originalHtml = GeneratePartialViewForOriginalNotes(entityNotesOriginal, entityNotesUpdated);
            var updatedHtml = GeneratePartialViewForModifiedNotes(entityNotesOriginal, entityNotesUpdated);

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
            var viewData = new EntityNotesViewData(entityNotes, null, "Project", false);
            var partialViewToString = RenderPartialViewToString(EntityNotesPartialViewPath, viewData);
            return partialViewToString;
        }

        [HttpGet]
        [ProjectUpdateViewFeature]
        public PartialViewResult ProjectUpdateBatchDiff(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            var viewData = new ProjectUpdateBatchDiffLogViewData(CurrentPerson, projectUpdateBatch);
            var partialViewToString = RenderPartialViewToString(ProjectUpdateBatchDiffLogPartialViewPath, viewData);
            return ViewHtmlDiff(partialViewToString, string.Format("Project Update from {0}", projectUpdateBatch.LastUpdateDate.ToLongDateString()));
        }

        private UpdateStatus GetUpdateStatus(ProjectUpdateBatch projectUpdateBatch)
        {
            var isPerformanceMeasuresUpdated = DiffPerformanceMeasuresImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isExpendituresUpdated = DiffExpendituresImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isBudgetsUpdated = DiffBudgetsImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isLocationSimpleUpdated = IsLocationSimpleUpdated(projectUpdateBatch.ProjectID);
            var isLocationDetailUpdated = IsLocationDetailedUpdated(projectUpdateBatch.ProjectID);
            var isExternalLinksUpdated = DiffExternalLinksImpl(projectUpdateBatch.ProjectID).HasChanged;
            var isNotesUpdated = DiffNotesImpl(projectUpdateBatch.ProjectID).HasChanged;

            //Must be called last, since basics actually changes the Project object which can break the other Diff functions
            var isBasicsUpdated = DiffBasicsImpl(projectUpdateBatch.ProjectID).HasChanged;

            return new UpdateStatus(isBasicsUpdated,
                isPerformanceMeasuresUpdated,
                isExpendituresUpdated,
                isBudgetsUpdated,
                projectUpdateBatch.IsPhotosUpdated,
                isLocationSimpleUpdated,
                isLocationDetailUpdated,
                isExternalLinksUpdated,
                isNotesUpdated);
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
    }
}