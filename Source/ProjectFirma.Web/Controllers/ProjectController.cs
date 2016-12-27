using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Views.ProposedProject;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Tag;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using Index = ProjectFirma.Web.Views.Project.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Project.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Project.IndexViewData;
using Summary = ProjectFirma.Web.Views.Project.Summary;
using SummaryViewData = ProjectFirma.Web.Views.Project.SummaryViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectController : FirmaBaseController
    {
        [HttpGet]
        [ProjectCreateNewFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditProjectViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ProjectCreateNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditProjectViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var taxonomyTierOne = HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.GetTaxonomyTierOne(viewModel.TaxonomyTierOneID);
            var project = new Project(viewModel.TaxonomyTierOneID,
                viewModel.ProjectStageID,
                viewModel.ProjectName,
                viewModel.ProjectDescription,
                false,
                false,
                ProjectLocationSimpleType.None.ProjectLocationSimpleTypeID,
                FundingType.Capital.FundingTypeID);
            HttpRequestStorage.DatabaseEntities.Projects.Add(project);
            viewModel.UpdateModel(project);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay(string.Format("Project {0} succesfully created.", UrlTemplate.MakeHrefString(project.GetSummaryUrl(), project.DisplayName)));
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectEditFeature]
        public PartialViewResult Edit(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var latestNotApprovedUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new EditProjectViewModel(project, latestNotApprovedUpdateBatch != null);
            return ViewEdit(viewModel, EditProjectType.ExistingProject, project.ProjectNumberString, project.TaxonomyTierOne.DisplayName, project.TotalExpenditures, latestNotApprovedUpdateBatch);
        }

        [HttpPost]
        [ProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectPrimaryKey projectPrimaryKey, EditProjectViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, EditProjectType.ExistingProject, project.ProjectNumberString, project.TaxonomyTierOne.DisplayName, project.TotalExpenditures, project.GetLatestNotApprovedUpdateBatch());
            }
            viewModel.UpdateModel(project);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditProjectViewModel viewModel)
        {
            return ViewEdit(viewModel, EditProjectType.NewProject, string.Empty, string.Empty, null, null);
        }

        private PartialViewResult ViewEdit(EditProjectViewModel viewModel, EditProjectType editProjectType, string projectNumberString, string taxonomyTierOneDisplayName, decimal? totalExpenditures, ProjectUpdateBatch projectUpdateBatch)
        {
            var taxonomyTierOnes = HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.ToList().OrderBy(ap => ap.DisplayName).ToList();
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var hasExistingProjectUpdate = projectUpdateBatch != null;
            var hasExistingProjectBudgetUpdates = hasExistingProjectUpdate && projectUpdateBatch.ProjectBudgetUpdates.Any();
            var viewData = new EditProjectViewData(taxonomyTierOnes,
                editProjectType,
                taxonomyTierOneDisplayName,
                projectNumberString,
                ProjectStage.All, FundingType.All, organizations, totalExpenditures, hasExistingProjectBudgetUpdates);
            return RazorPartialView<EditProject, EditProjectViewData, EditProjectViewModel>(viewData, viewModel);
        }

        [CrossAreaRoute]
        [ProjectViewFeature]
        public PartialViewResult ProjectMapPopup(ProjectPrimaryKey primaryKeyProject)
        {
            var project = primaryKeyProject.EntityObject;
            return RazorPartialView<ProjectMapPopup, ProjectMapPopupViewData>(new ProjectMapPopupViewData(project));
        }

        [ProjectsViewFullListFeature] //Handling permission check in code since this route is "overloaded" (can handle ProjectID or ProjectNumber)
        public ViewResult Summary(string projectNumber)
        {
            var project = ParseProjectNumberOrProjectID(projectNumber);
            new ProjectViewFeature().DemandPermission(CurrentPerson, project);

            var confirmNonMandatoryUpdateUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.ConfirmNonMandatoryUpdate(project.PrimaryKey));
            var activeProjectStages = GetActiveProjectStages(project);
            var projectTaxonomyViewData = new ProjectTaxonomyViewData(project);

            var projectBudgetAmounts =
                ProjectBudgetAmount.CreateFromProjectBudgets(new List<IProjectBudgetAmount>(project.ProjectBudgets.ToList()));
            var calendarYearsForProjectBudgets = project.ProjectBudgets.ToList().CalculateCalendarYearRangeForBudgets(project);
            var projectBudgetSummaryViewData = new ProjectBudgetSummaryViewData(projectBudgetAmounts, calendarYearsForProjectBudgets);

            var mapDivID = string.Format("project_{0}_Map", project.ProjectID);
            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(project, mapDivID);
            var mapFormID = GenerateEditProjectLocationFormID(project);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(project, projectLocationSummaryMapInitJson);
            var editSimpleProjectLocationUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationSimple(project));
            var editDetailedProjectLocationUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationDetailed(project));

            var editOrganizationsUrl = SitkaRoute<ProjectOrganizationController>.BuildUrlFromExpression(c => c.EditOrganizations(project));

            var performanceMeasureExpectedsSummaryViewData = new PerformanceMeasureExpectedSummaryViewData(new List<IPerformanceMeasureValue>(project.PerformanceMeasureExpecteds));
            var editPerformanceMeasureExpectedsUrl = SitkaRoute<PerformanceMeasureExpectedController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureExpectedsForProject(project));

            var performanceMeasureReportedValuesGroupedViewData = BuildPerformanceMeasureReportedValuesGroupedViewData(project);
            var editPerformanceMeasureActualsUrl = SitkaRoute<PerformanceMeasureActualController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureActualsForProject(project));

            var projectExpendituresSummaryViewData = BuildProjectExpendituresSummaryViewData(project);
            var editReportedExpendituresUrl = SitkaRoute<ProjectFundingSourceExpenditureController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceExpendituresForProject(project));

            var editThresholdCategoriesUrl = SitkaRoute<ProjectThresholdCategoryController>.BuildUrlFromExpression(c => c.EditProjectThresholdCategoriesForProject(project));

            var editAssessmentUrl = SitkaRoute<ProjectAssessmentQuestionController>.BuildUrlFromExpression(c => c.EditAssessment(project));

            var entityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(new List<IEntityNote>(project.ProjectNotes)),
                SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(x => x.New(project)),
                project.DisplayName,
                new ProjectNoteManageFeature().HasPermissionByPerson(CurrentPerson));

            var imageGalleryViewData = BuildImageGalleryViewData(project, CurrentPerson);

            var editWatershedsUrl = SitkaRoute<ProjectWatershedController>.BuildUrlFromExpression(c => c.EditProjectWatershedsForProject(project));

            var tagHelper = new TagHelper(project.ProjectTags.Select(x => new BootstrapTag(x.Tag)).ToList());

            var auditLogsGridSpec = new AuditLogsGridSpec() {ObjectNameSingular = "Change", ObjectNamePlural = "Changes", SaveFiltersInCookie = true};
            var auditLogsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.AuditLogsGridJsonData(project));

            var projectNotificationGridSpec = new ProjectNotificationGridSpec();
            const string projectNotificationGridName = "projectNotifications";
            var projectNotificationGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ProjectNotificationsGridJsonData(project));

            var inflationRate = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest().InflationRate;
            var editInflationUrl = SitkaRoute<CostParameterSetController>.BuildUrlFromExpression(controller => controller.Summary());
            var editProjectBudgetUrl = SitkaRoute<ProjectBudgetController>.BuildUrlFromExpression(c => c.EditBudgetsForProject(project));

            var editExternalLinksUrl = SitkaRoute<ProjectExternalLinkController>.BuildUrlFromExpression(c => c.EditProjectExternalLinks(project));
            var entityExternalLinksViewData = new EntityExternalLinksViewData(ExternalLink.CreateFromEntityExternalLink(new List<IEntityExternalLink>(project.ProjectExternalLinks)));

            var userHasProjectBudgetManagePermissions = new ProjectBudgetManageFeature().HasPermissionByPerson(CurrentPerson);

            var projectBasicsCalculatedCostsViewData = new ProjectBasicsCalculatedCostsViewData(project,
                CostParameterSet.CalculateCapitalCostInYearOfExpenditure(project),
                userHasProjectBudgetManagePermissions,
                editInflationUrl,
                inflationRate,
                CostParameterSet.CalculateTotalRemainingOperatingCost(project),
                CostParameterSet.StartYearForTotalCostCalculations(project));

            var projectBasicsTagsViewData = new ProjectBasicsTagsViewData(project, tagHelper);

            var projectBasicsViewData = new ProjectBasicsViewData(project,
                userHasProjectBudgetManagePermissions,
                new TagManageFeature().HasPermissionByPerson(CurrentPerson),
                true,
                projectBasicsCalculatedCostsViewData,
                projectBasicsTagsViewData);

            var goals = HttpRequestStorage.DatabaseEntities.AssessmentGoals.ToList();
            var goalsAsFancyTreeNodes = goals.Select(x => x.ToFancyTreeNode(new List<IQuestionAnswer>(project.ProjectAssessmentQuestions.ToList()))).ToList();
            var assessmentTreeViewData = new AssessmentTreeViewData(goalsAsFancyTreeNodes);

            var viewData = new SummaryViewData(CurrentPerson,
                project,
                confirmNonMandatoryUpdateUrl,
                activeProjectStages,
                projectTaxonomyViewData,
                projectBudgetSummaryViewData,
                projectLocationSummaryViewData,
                mapFormID,
                editSimpleProjectLocationUrl,
                editDetailedProjectLocationUrl,
                editOrganizationsUrl,
                performanceMeasureExpectedsSummaryViewData,
                editPerformanceMeasureExpectedsUrl,
                performanceMeasureReportedValuesGroupedViewData,
                editPerformanceMeasureActualsUrl,
                projectExpendituresSummaryViewData,
                editReportedExpendituresUrl,
                editThresholdCategoriesUrl,
                editAssessmentUrl,
                editWatershedsUrl,
                imageGalleryViewData,
                entityNotesViewData,
                auditLogsGridSpec,
                auditLogsGridDataUrl,
                editProjectBudgetUrl,
                editExternalLinksUrl,
                entityExternalLinksViewData,
                projectNotificationGridSpec,
                projectNotificationGridName,
                projectNotificationGridDataUrl,
                projectBasicsViewData,
                assessmentTreeViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        private Project ParseProjectNumberOrProjectID(string projectNumberOrProjectID)
        {
            if (projectNumberOrProjectID.Contains("."))
            {
                return HttpRequestStorage.DatabaseEntities.Projects.GetProjectByProjectNumber(projectNumberOrProjectID);
            }
            else
            {
                int projectID;
                if (int.TryParse(projectNumberOrProjectID, out projectID))
                {
                    return HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID);
                }
            }

            throw new SitkaRecordNotFoundException("Unrecognized ProjectID / ProjectNumber", projectNumberOrProjectID);
        }
      
        private static ProjectExpendituresSummaryViewData BuildProjectExpendituresSummaryViewData(Project project)
        {
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearsForFundingSourceExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var fromFundingSourcesAndCalendarYears = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures),
                calendarYearsForFundingSourceExpenditures);
            var projectExpendituresSummaryViewData = new ProjectExpendituresSummaryViewData(fromFundingSourcesAndCalendarYears, calendarYearsForFundingSourceExpenditures);
            return projectExpendituresSummaryViewData;
        }

        private static PerformanceMeasureReportedValuesGroupedViewData BuildPerformanceMeasureReportedValuesGroupedViewData(Project project)
        {
            var performanceMeasureReportedValues = project.GetReportedPerformanceMeasures();
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(performanceMeasureReportedValues));
            var performanceMeasureReportedValuesGroupedViewData = new PerformanceMeasureReportedValuesGroupedViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                project.ProjectExemptReportingYears.Select(x => x.CalendarYear).ToList(),
                project.PerformanceMeasureActualYearsExemptionExplanation,
                performanceMeasureReportedValues.Select(x => x.CalendarYear).Distinct().ToList());
            return performanceMeasureReportedValuesGroupedViewData;
        }

        private static ImageGalleryViewData BuildImageGalleryViewData(Project project, Person currentPerson)
        {
            var userCanAddPhotosToThisProject = new ProjectImageNewFeature().HasPermissionByPerson(currentPerson);
            var newPhotoForProjectUrl = SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.New(project));
            var selectKeyImageUrl = (new ProjectImageSetKeyPhotoFeature().HasPermissionByPerson(currentPerson))
                ? SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.SetKeyPhoto(UrlTemplate.Parameter1Int))
                : string.Empty;
            var galleryName = string.Format("ProjectImage{0}", project.ProjectID);
            var imageGalleryViewData = new ImageGalleryViewData(currentPerson,
                galleryName,
                project.ProjectImages,
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
            var activeProjectStages = new List<ProjectStage> {ProjectStage.PlanningDesign, ProjectStage.Implementation, ProjectStage.Completed, ProjectStage.PostImplementation};

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

        [ProjectsViewFullListFeature] //Handling permission check in code since this route is "overloaded" (can handle ProjectID or ProjectNumber)
        public ViewResult FactSheet(string projectNumber)
        {
            var project = ParseProjectNumberOrProjectID(projectNumber);
            new ProjectViewFeature().DemandPermission(CurrentPerson, project);

            var mapDivID = string.Format("project_{0}_Map", project.ProjectID);
            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(project, mapDivID);
            var viewData = new FactSheetViewData(CurrentPerson, project, projectLocationSummaryMapInitJson, FirmaHelpers.DefaultColorRange);
            return RazorView<FactSheet, FactSheetViewData>(viewData);
        }

        [ProjectsViewFullListFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FullProjectList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ProjectsViewFullListFeature]
        public GridJsonNetJObjectResult<Project> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var projects = GetIndexGridSpec(CurrentPerson, out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Project> GetIndexGridSpec(Person currentPerson, out IndexGridSpec gridSpec)
        {            
            gridSpec = new IndexGridSpec(currentPerson);
            return GetProjectsForGrid(null);
        }

        public static List<Project> GetProjectsForGrid(Func<Project, bool> filterFunction)
        {
            var watershedsWithGeospatialFeatures = HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures();
            var jurisdictionsWithGeospatialFeatures = HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures();
            return
                HttpRequestStorage.DatabaseEntities.Projects.GetProjectsWithGeoSpatialProperties(watershedsWithGeospatialFeatures,
                    jurisdictionsWithGeospatialFeatures,
                    filterFunction, HttpRequestStorage.DatabaseEntities.StateProvinces.ToList()).ToList();
        }

        [ProjectsViewFullListFeature]
        public ExcelResult IndexExcelDownload()
        {
            var projects = GetProjectsForGrid(null);

            var projectsSpec = new ProjectExcelSpec();
            var wsProjects = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Projects", projectsSpec, projects);

            var projectsDescriptionSpec = new ProjectDescriptionExcelSpec();
            var wsProjectDescriptions = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Project Descriptions", projectsDescriptionSpec, projects);

            var organizationsSpec = new ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec();
            var projectImplementingOrganizationOrProjectFundingOrganizations = (projects.SelectMany(p => p.GetAllProjectOrganizations())).ToList();
            var wsOrganizations = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Project Organizations", organizationsSpec, projectImplementingOrganizationOrProjectFundingOrganizations);

            var projectNoteSpec = new ProjectNoteExcelSpec();
            var projectNotes = (projects.SelectMany(p => p.ProjectNotes)).ToList();
            var wsProjectNotes = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Project Notes", projectNoteSpec, projectNotes);

            var performanceMeasureExpectedExcelSpec = new PerformanceMeasureExpectedExcelSpec();
            var performanceMeasureExpecteds = (projects.SelectMany(p => p.PerformanceMeasureExpecteds)).ToList();
            var wsPerformanceMeasureExpecteds = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Expected Performance Measures",
                performanceMeasureExpectedExcelSpec,
                performanceMeasureExpecteds);

            var performanceMeasureActualExcelSpec = new PerformanceMeasureActualExcelSpec();
            var performanceMeasureActuals = (projects.SelectMany(p => p.GetReportedPerformanceMeasures())).ToList();
            var wsPerformanceMeasureActuals = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Reported Performance Measures", performanceMeasureActualExcelSpec, performanceMeasureActuals);

            var projectFundingSourceExpenditureSpec = new ProjectFundingSourceExpenditureExcelSpec();
            var projectFundingSourceExpenditures = (projects.SelectMany(p => p.ProjectFundingSourceExpenditures)).ToList();
            var wsProjectFundingSourceExpenditures = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Reported Expenditures", projectFundingSourceExpenditureSpec, projectFundingSourceExpenditures);

            var projectWatershedSpec = new ProjectWatershedExcelSpec();
            var projectWatersheds = (projects.SelectMany(p => p.ProjectWatersheds)).ToList();
            var wsProjectWatersheds = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Project Watersheds", projectWatershedSpec, projectWatersheds);

            var projectThresholdCategorySpec = new ProjectThresholdCategoryExcelSpec();
            var projectThresholdCategories = (projects.SelectMany(p => p.ProjectThresholdCategories)).ToList();
            var wsProjectThresholdCategories = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Project Threshold Categories", projectThresholdCategorySpec, projectThresholdCategories);

            
            var workSheets = new List<IExcelWorkbookSheetDescriptor>
            {
                wsProjects,
                wsProjectDescriptions,
                wsOrganizations,
                wsProjectNotes,
                wsPerformanceMeasureExpecteds,
                wsPerformanceMeasureActuals,
                wsProjectFundingSourceExpenditures,
                wsProjectWatersheds,
                wsProjectThresholdCategories
            };

            var wbm = new ExcelWorkbookMaker(workSheets);
            var excelWorkbook = wbm.ToXLWorkbook();
            return new ExcelResult(excelWorkbook, string.Format("Projects as of {0}", DateTime.Now.ToStringDateTime()));
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
            var canDelete = project.CanDelete().HasPermission;
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Project '{0}'?", project.DisplayName)
                : string.Format("Only projects in the following stages may be deleted: {0}<br />{1}",
                    string.Join(", ", ProjectStage.All.Where(x => x.IsDeletable()).Select(x => x.ProjectStageDisplayName)),
                    ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Project", SitkaRoute<ProjectController>.BuildLinkFromExpression(x => x.Summary(project.ProjectNumberString), "here")));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProject(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var permissionCheckResult = project.CanDelete();
            if (!permissionCheckResult.HasPermission)
            {
                throw new SitkaRecordNotAuthorizedException(permissionCheckResult.PermissionDeniedMessage);
            }
            if (!ModelState.IsValid)
            {
                return ViewDeleteProject(project, viewModel);
            }
            // since we do not check for these in the CanDelete call, we need to remove them manually; this is because we are requiring a lead organization for each project, so the editor no longer supports deletion of all organizations per Mingle story #209.
            HttpRequestStorage.DatabaseEntities.ProjectImplementingOrganizations.RemoveRange(project.ProjectImplementingOrganizations);
            HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.RemoveRange(project.ProjectFundingOrganizations);
            HttpRequestStorage.DatabaseEntities.ProjectThresholdCategories.RemoveRange(project.ProjectThresholdCategories);
            HttpRequestStorage.DatabaseEntities.SnapshotProjects.RemoveRange(project.SnapshotProjects);
            HttpRequestStorage.DatabaseEntities.ProjectTags.RemoveRange(project.ProjectTags);
            HttpRequestStorage.DatabaseEntities.NotificationProjects.RemoveRange(project.NotificationProjects);
            if (project.ProposedProject != null)
            {
                project.ProposedProject.ProposedProjectStateID = ProposedProjectState.Rejected.ProposedProjectStateID;
                project.ProposedProject.Project = null;
            }

            HttpRequestStorage.DatabaseEntities.Projects.Remove(project);
            return new ModalDialogFormJsonResult();
        }

        [ProjectsViewFiveYearListFeature] 
        public ViewResult FiveYearList()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FiveYearProjectList);
            var viewData = new FiveYearListViewData(CurrentPerson, firmaPage);
            return RazorView<FiveYearList, FiveYearListViewData>(viewData);
        }

        [ProjectsViewFiveYearListFeature]
        public GridJsonNetJObjectResult<Project> FiveYearListGridJsonData()
        {
            BasicProjectInfoGridSpec gridSpec;
            var projects = GetFiveYearListGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetFiveYearListGridSpec(out BasicProjectInfoGridSpec gridSpec)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return GetProjectsForGrid(p => p.IsOnFiveYearList);
        }

        [ProjectsViewFullListFeature]
        public ViewResult CompletedList()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.CompletedProjectList);

            var viewData = new CompletedListViewData(CurrentPerson, firmaPage);
            return RazorView<CompletedList, CompletedListViewData>(viewData);
        }

        [ProjectsViewFullListFeature]
        public GridJsonNetJObjectResult<Project> CompletedListGridJsonData()
        {
            BasicProjectInfoGridSpec gridSpec;
            var taxonomyTierTwos = GetCompletedListGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(taxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetCompletedListGridSpec(out BasicProjectInfoGridSpec gridSpec)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return GetProjectsForGrid(p => p.ProjectStage.IsOnCompletedList());
        }

        [ProjectsViewTerminatedListFeature]
        public ViewResult TerminatedList()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.TerminatedProjectList);

            var viewData = new TerminatedListViewData(CurrentPerson, firmaPage);
            return RazorView<TerminatedList, TerminatedListViewData>(viewData);
        }

        [ProjectsViewTerminatedListFeature]
        public GridJsonNetJObjectResult<Project> TerminatedListGridJsonData()
        {
            BasicProjectInfoGridSpec gridSpec;
            var taxonomyTierTwos = GetTerminatedListGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(taxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectsViewTerminatedListFeature]
        private List<Project> GetTerminatedListGridSpec(out BasicProjectInfoGridSpec gridSpec)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return GetProjectsForGrid(p => p.ProjectStage == ProjectStage.Terminated);
        }

        [AdminFeature]
        public GridJsonNetJObjectResult<AuditLog> AuditLogsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            AuditLogsGridSpec gridSpec;
            var auditLogs = GetAuditLogsAndGridSpec(out gridSpec, projectPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AuditLog>(auditLogs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<AuditLog> GetAuditLogsAndGridSpec(out AuditLogsGridSpec gridSpec, Project project)
        {
            gridSpec = new AuditLogsGridSpec();
            var auditLogs = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProject(project).OrderByDescending(x => x.AuditLogDate).ToList();
            return auditLogs;
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
                    .ToList()
                    .Where(x => x.IsVisibleToThisPerson(CurrentPerson))
                    .OrderBy(x => x.ProjectNumberString)
                    .ToList();
            return projectsFound;
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult SearchImpl(string searchCriteria, List<Project> projectsFound)
        {
            if (projectsFound.Count == 1)
            {
                return RedirectToAction(new SitkaRoute<ProjectController>(x => x.Summary(projectsFound.Single().ProjectNumberString)));
            }

            var viewData = new SearchResultsViewData(CurrentPerson, projectsFound, searchCriteria);
            return RazorView<SearchResults, SearchResultsViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public JsonResult Find(string term)
        {
            var projectFindResults = GetViewableProjectsFromSearchCriteria(term.Trim());
            var results = projectFindResults.Take(ProjectsCountLimit).Select(pfr => new ListItem(pfr.DisplayName.ToEllipsifiedString(100), pfr.GetSummaryUrl())).ToList();
            if (projectFindResults.Count > ProjectsCountLimit)
            {
                results.Add(
                    new ListItem(
                        string.Format("<span style='font-weight:bold'>Displaying {0} of {1}</span><span style='color:blue; margin-left:8px'>See All Results</span>",
                            ProjectsCountLimit,
                            projectFindResults.Count),
                        SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Search(term))));
            }
            return Json(results.Select(pfr => new {label = pfr.Text, value = pfr.Value}), JsonRequestBehavior.AllowGet);
        }

        private const int ProjectsCountLimit = 20;

        [ProjectManageFeaturedFeature]
        public ViewResult FeaturedList()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FeaturedProjectList);
            var viewData = new FeaturedListViewData(CurrentPerson, firmaPage);
            return RazorView<FeaturedList, FeaturedListViewData>(viewData);
        }

        [ProjectManageFeaturedFeature]
        public GridJsonNetJObjectResult<Project> FeaturedListGridJsonData()
        {
            FeaturesListProjectGridSpec gridSpec;
            var taxonomyTierTwos = GetFeaturedListGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(taxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetFeaturedListGridSpec(out FeaturesListProjectGridSpec gridSpec)
        {
            gridSpec = new FeaturesListProjectGridSpec(CurrentPerson);
            return HttpRequestStorage.DatabaseEntities.Projects.Where(p => p.IsFeatured).ToList().OrderBy(x => x.ProjectNumberString).ToList();
        }

        [HttpGet]
        [ProjectManageFeaturedFeature]
        public PartialViewResult EditFeaturedProjects()
        {
            var featuredProjectIDs = HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.IsFeatured).Select(x => x.ProjectID).ToList();
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
            var newlyFearturedProjects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
            newlyFearturedProjects.ForEach(x => x.IsFeatured = true);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditFeaturedProjects(EditFeaturedProjectsViewModel viewModel)
        {
            var allProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().Select(x => new ProjectSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var viewData = new EditFeaturedProjectsViewData(allProjects);
            return RazorPartialView<EditFeaturedProjects, EditFeaturedProjectsViewData, EditFeaturedProjectsViewModel>(viewData, viewModel);
        }

        [ProjectsViewFullListFeature]
        public ViewResult FullProjectListSimple()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FullProjectListSimple);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().OrderBy(x => x.ProjectNumberString).ToList();
            var viewData = new FullProjectListSimpleViewData(CurrentPerson, firmaPage, projects);
            return RazorView<FullProjectListSimple, FullProjectListSimpleViewData>(viewData);
        }

        private static string GenerateEditProjectLocationFormID(Project project)
        {
            return string.Format("editMapForProject{0}", project.ProjectID);
        }

        [HttpGet]
        [ProjectUpdateManageFeature]
        public PartialViewResult ConfirmNonMandatoryUpdate(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel();
            
            var dateDisplayText = string.Empty;
            var latestUpdateSubmittalDate = project.GetLatestUpdateSubmittalDate();
            if (latestUpdateSubmittalDate.HasValue)
            {
                dateDisplayText = string.Format(" on <span style='font-weight: bold'>{0}</span>", latestUpdateSubmittalDate.Value.ToShortDateString());
            }

            var viewData = new ConfirmDialogFormViewData(string.Format(@"
<div>
An update for this project was already submitted for this reporting year{0}. If project information has changed, 
any new information you'd like to provide will be added to the project. Thanks for being pro-active!
</div>
<div>
<hr />
Continue with a new project update?
</div>", dateDisplayText));
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectUpdateManageFeature]
        public ActionResult ConfirmNonMandatoryUpdate(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            return new ModalDialogFormJsonResult(project.GetProjectUpdateUrl());
        }

        [ProjectUpdateViewFeature]
        public GridJsonNetJObjectResult<Notification> ProjectNotificationsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var gridSpec = new ProjectNotificationGridSpec();
            var notifications = project.NotificationProjects.Select(x => x.Notification).OrderByDescending(x => x.NotificationDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Notification>(notifications, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectUpdateViewFeature]
        public GridJsonNetJObjectResult<ProjectUpdateBatch> ProjectUpdateBatchGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var gridSpec = new ProjectUpdateBatchGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectUpdateBatch>(project.ProjectUpdateBatches.OrderBy(x => x.LastUpdateDate).ToList(), gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectUpdateViewFeature]
        public PartialViewResult ProjectUpdateDiffLog(ProjectUpdateBatchPrimaryKey projectUpdateBatchPrimaryKey)
        {
            var projectUpdateBatch = projectUpdateBatchPrimaryKey.EntityObject;
            var viewData = new ProjectUpdateBatchDiffLogViewData(CurrentPerson, projectUpdateBatch);
            return RazorPartialView<ProjectUpdateBatchDiffLog, ProjectUpdateBatchDiffLogViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult ProjectFactSheetGoogleChartPopup(ProjectPrimaryKey projectPrimaryKey)
        {
            var googleChart = GetProjectFactSheetGoogleChart(projectPrimaryKey);
            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
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

        public static GoogleChartJson GetProjectFactSheetGoogleChart(ProjectPrimaryKey projectPrimaryKey)
        {
            const int chartSize = 430;
            var chartName = string.Format("ProjectFactSheet{0}PieChart", projectPrimaryKey.PrimaryKeyValue);

            var project = projectPrimaryKey.EntityObject;
            var fundingSourceExpenditures = project.ProjectFundingSourceExpenditures.GroupBy(x => x.FundingSource.DisplayName).ToDictionary(x => x.Key, x => x.Sum(y => y.ExpenditureAmount));
            var googleChartDataTable = GetProjectFactSheetGoogleChartDataTable(fundingSourceExpenditures);
            var googleChartTitle = string.Format("Investment by Funding Sector for: {0}", project.ProjectName);
            var googleChartConfiguration = new GooglePieChartConfiguration(googleChartTitle, MeasurementUnitType.Dollars, chartSize, chartSize)
            {
                Slices = GetSlicesForGoogleChart(fundingSourceExpenditures)
            };

            var chartPopupUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.ProjectFactSheetGoogleChartPopup(projectPrimaryKey));
            var googleChart = new GoogleChartJson(string.Empty, chartName, googleChartConfiguration, GoogleChartType.PieChart, googleChartDataTable, chartPopupUrl, string.Empty, null);
            return googleChart;
        }

        public static GoogleChartDataTable GetProjectFactSheetGoogleChartDataTable(Dictionary<string, decimal> fundingSourceExpenditures)
        {
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Funding Sector", GoogleChartColumnDataType.String, GoogleChartType.PieChart), new GoogleChartColumn("Expenditures", GoogleChartColumnDataType.Number, GoogleChartType.PieChart) };
            var chartRowCs = fundingSourceExpenditures.Select(x =>
            {
                var sectorRowV = new GoogleChartRowV(x.Key);
                var formattedValue = GoogleChartJson.GetFormattedValue((double)x.Value, MeasurementUnitType.Dollars);
                var expenditureRowV = new GoogleChartRowV(x.Value, formattedValue);
                return new GoogleChartRowC(new List<GoogleChartRowV> { sectorRowV, expenditureRowV });
            });
            var googleChartRowCs = new List<GoogleChartRowC>(chartRowCs);

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        [ProjectsViewMyOrganizationsProjectListFeature]
        public ViewResult MyOrganizationsProjects()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.MyOrganizationsProjects);

            var viewData = new MyOrganizationsProjectsViewData(CurrentPerson, firmaPage);
            return RazorView<MyOrganizationsProjects, MyOrganizationsProjectsViewData>(viewData);
        }

        [ProjectsViewMyOrganizationsProjectListFeature]
        public GridJsonNetJObjectResult<Project> MyOrganizationsProjectsGridJsonData()
        {
            BasicProjectInfoGridSpec gridSpec;
            var taxonomyTierTwos = GetMyOrganizationsProjectsGridSpec(CurrentPerson, out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(taxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Project> GetMyOrganizationsProjectsGridSpec(Person currentPerson, out BasicProjectInfoGridSpec gridSpec)
        {
            gridSpec = new BasicProjectInfoGridSpec(currentPerson, true);
            return HttpRequestStorage.DatabaseEntities.Projects.ToList().Where(p => p.DoesPersonBelongToProjectLeadImplementingOranization(currentPerson)).OrderBy(x => x.DisplayName).ToList();
        }

        [ProposedProjectsViewListFeature]
        public GridJsonNetJObjectResult<ProposedProject> MyOrganizationsProposedProjectsGridJsonData()
        {
            ProposedProjectGridSpec gridSpec;
            var taxonomyTierTwos = GetMyOrganizationsProposedProjectsGridSpec(CurrentPerson, out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProposedProject>(taxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProposedProject> GetMyOrganizationsProposedProjectsGridSpec(Person currentPerson, out ProposedProjectGridSpec gridSpec)
        {
            gridSpec = new ProposedProjectGridSpec(currentPerson);
            return GetMyOrganizationsProposedProjectsForGrid(x => x.IsEditableToThisPerson(currentPerson) && x.DoesPersonBelongToProposedProjectLeadImplementingOranization(currentPerson));
        }

        public static List<ProposedProject> GetMyOrganizationsProposedProjectsForGrid(Func<ProposedProject, bool> filterFunction)
        {
            return
                HttpRequestStorage.DatabaseEntities.ProposedProjects.GetProposedProjectsWithGeoSpatialProperties(HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures(),
                    HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures(),
                    HttpRequestStorage.DatabaseEntities.StateProvinces.ToList(),
                    filterFunction).Where(x => x.ProposedProjectState != ProposedProjectState.Approved && x.ProposedProjectState != ProposedProjectState.Rejected).ToList();
        }
    }
}