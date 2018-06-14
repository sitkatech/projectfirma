/*-----------------------------------------------------------------------
<copyright file="ProjectController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Tag;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.ProjectFunding;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using Detail = ProjectFirma.Web.Views.Project.Detail;
using DetailViewData = ProjectFirma.Web.Views.Project.DetailViewData;
using Index = ProjectFirma.Web.Views.Project.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Project.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Project.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult Edit(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var latestNotApprovedUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            var viewModel = new EditProjectViewModel(project, latestNotApprovedUpdateBatch != null);
            return ViewEdit(viewModel, project, EditProjectType.ExistingProject, project.TaxonomyLeaf.DisplayName, project.TotalExpenditures);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectPrimaryKey projectPrimaryKey, EditProjectViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, project, EditProjectType.ExistingProject, project.TaxonomyLeaf.DisplayName, project.TotalExpenditures);
            }
            viewModel.UpdateModel(project);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditProjectViewModel viewModel, Project project, EditProjectType editProjectType, string taxonomyLeafDisplayName, decimal? totalExpenditures)
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().OrderBy(ap => ap.DisplayName).ToList();
            var primaryContactPeople = HttpRequestStorage.DatabaseEntities.People.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            var defaultPrimaryContact = project?.GetPrimaryContact() ?? CurrentPerson.Organization.PrimaryContactPerson;
            var viewData = new EditProjectViewData(editProjectType,
                taxonomyLeafDisplayName,
                ProjectStage.All.Except(new[] {ProjectStage.Proposal}), FundingType.All, organizations,
                primaryContactPeople,
                defaultPrimaryContact,
                totalExpenditures,
                taxonomyLeafs
            );
            return RazorPartialView<EditProject, EditProjectViewData, EditProjectViewModel>(viewData, viewModel);
        }

        [CrossAreaRoute]
        [ProjectViewFeature]
        public PartialViewResult ProjectMapPopup(ProjectPrimaryKey primaryKeyProject)
        {
            var project = primaryKeyProject.EntityObject;
            return RazorPartialView<ProjectMapPopup, ProjectMapPopupViewData>(new ProjectMapPopupViewData(project, true));
        }

        [CrossAreaRoute]
        [ProjectViewFeature]
        public PartialViewResult ProjectSimpleMapPopup(ProjectPrimaryKey primaryKeyProject)
        {
            var project = primaryKeyProject.EntityObject;
            return RazorPartialView<ProjectMapPopup, ProjectMapPopupViewData>(new ProjectMapPopupViewData(project, false));
        }

        [ProjectViewFeature]
        public ViewResult Detail(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var activeProjectStages = GetActiveProjectStages(project);

            var userHasProjectAdminPermissions = new FirmaAdminFeature().HasPermissionByPerson(CurrentPerson);
            var userHasEditProjectPermissions = new ProjectEditAsAdminFeature().HasPermission(CurrentPerson, project).HasPermission;
            var userHasProjectUpdatePermissions = new ProjectUpdateCreateEditSubmitFeature().HasPermission(CurrentPerson, project).HasPermission;
            var userCanEditProposal = new ProjectCreateFeature().HasPermission(CurrentPerson, project).HasPermission;
            var userHasPerformanceMeasureActualManagePermissions = new PerformanceMeasureActualFromProjectManageFeature().HasPermission(CurrentPerson, project).HasPermission;

            var editSimpleProjectLocationUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationSimple(project));
            var editDetailedProjectLocationUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationDetailed(project));
            var editOrganizationsUrl = SitkaRoute<ProjectOrganizationController>.BuildUrlFromExpression(c => c.EditOrganizations(project));
            var editPerformanceMeasureExpectedsUrl = SitkaRoute<PerformanceMeasureExpectedController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureExpectedsForProject(project));
            var editPerformanceMeasureActualsUrl = SitkaRoute<PerformanceMeasureActualController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureActualsForProject(project));
            var editWatershedsUrl = SitkaRoute<ProjectWatershedController>.BuildUrlFromExpression(c => c.EditProjectWatersheds(project));
            var editReportedExpendituresUrl = SitkaRoute<ProjectFundingSourceExpenditureController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceExpendituresForProject(project));
            var editExternalLinksUrl = SitkaRoute<ProjectExternalLinkController>.BuildUrlFromExpression(c => c.EditProjectExternalLinks(project));

            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(project, $"project_{project.ProjectID}_Map", false);
            var mapFormID = GenerateEditProjectLocationFormID(project);

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var projectBasicsViewData = new ProjectBasicsViewData(project, false, taxonomyLevel);
            var projectBasicsTagsViewData = new ProjectBasicsTagsViewData(project, new TagHelper(project.ProjectTags.Select(x => new BootstrapTag(x.Tag)).ToList()));
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(project, projectLocationSummaryMapInitJson);
            var performanceMeasureExpectedsSummaryViewData = new PerformanceMeasureExpectedSummaryViewData(new List<IPerformanceMeasureValue>(project.PerformanceMeasureExpecteds.OrderBy(x=>x.PerformanceMeasure.PerformanceMeasureSortOrder)));
            var performanceMeasureReportedValuesGroupedViewData = BuildPerformanceMeasureReportedValuesGroupedViewData(project);
            var projectExpendituresSummaryViewData = BuildProjectExpendituresDetailViewData(project);
            var projectFundingDetailViewData = new ProjectFundingDetailViewData(CurrentPerson, new List<IFundingSourceRequestAmount>(project.ProjectFundingSourceRequests));
            var imageGalleryViewData = BuildImageGalleryViewData(project, CurrentPerson);
            var entityNotesViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(new List<IEntityNote>(project.ProjectNotes)),
                SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(x => x.New(project)),
                project.DisplayName,
                userHasEditProjectPermissions);
            var entityExternalLinksViewData = new EntityExternalLinksViewData(ExternalLink.CreateFromEntityExternalLink(new List<IEntityExternalLink>(project.ProjectExternalLinks)));

            var auditLogsGridSpec = new AuditLogsGridSpec {ObjectNameSingular = "Change", ObjectNamePlural = "Changes", SaveFiltersInCookie = true};
            var auditLogsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.AuditLogsGridJsonData(project));

            var projectNotificationGridSpec = new ProjectNotificationGridSpec();
            const string projectNotificationGridName = "projectNotifications";
            var projectNotificationGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ProjectNotificationsGridJsonData(project));

            var projectOrganizationsDetailViewData = new ProjectOrganizationsDetailViewData(project.GetAssociatedOrganizations(), project.GetPrimaryContact());

            var classificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList();

            var viewData = new DetailViewData(CurrentPerson,
                project,
                activeProjectStages,
                projectBasicsViewData,
                projectLocationSummaryViewData, projectFundingDetailViewData,
                performanceMeasureExpectedsSummaryViewData, performanceMeasureReportedValuesGroupedViewData,
                projectExpendituresSummaryViewData, imageGalleryViewData, entityNotesViewData,
                entityExternalLinksViewData, projectBasicsTagsViewData, userHasProjectAdminPermissions,
                userHasEditProjectPermissions, userHasProjectUpdatePermissions,
                userHasPerformanceMeasureActualManagePermissions, mapFormID,
                editSimpleProjectLocationUrl, editDetailedProjectLocationUrl, editOrganizationsUrl,
                editPerformanceMeasureExpectedsUrl, editPerformanceMeasureActualsUrl, editReportedExpendituresUrl, editWatershedsUrl, auditLogsGridSpec, auditLogsGridDataUrl,
                editExternalLinksUrl, projectNotificationGridSpec, projectNotificationGridName,
                projectNotificationGridDataUrl, userCanEditProposal, projectOrganizationsDetailViewData, classificationSystems, ProjectLocationController.EditProjectBoundingBoxFormID);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        private static ProjectExpendituresDetailViewData BuildProjectExpendituresDetailViewData(Project project)
        {
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearsForFundingSourceExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var fromFundingSourcesAndCalendarYears = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures),
                calendarYearsForFundingSourceExpenditures);
            var projectExpendituresDetailViewData = new ProjectExpendituresDetailViewData(fromFundingSourcesAndCalendarYears, calendarYearsForFundingSourceExpenditures);
            return projectExpendituresDetailViewData;
        }

        private static PerformanceMeasureReportedValuesGroupedViewData BuildPerformanceMeasureReportedValuesGroupedViewData(Project project)
        {
            var performanceMeasureReportedValues = project.GetReportedPerformanceMeasures();
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(performanceMeasureReportedValues.OrderBy(x=>x.PerformanceMeasure.SortOrder).ThenBy(x=>x.PerformanceMeasure.DisplayName)));
            var performanceMeasureReportedValuesGroupedViewData = new PerformanceMeasureReportedValuesGroupedViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                project.ProjectExemptReportingYears.Select(x => x.CalendarYear).ToList(),
                project.PerformanceMeasureActualYearsExemptionExplanation,
                performanceMeasureReportedValues.Select(x => x.CalendarYear).Distinct().ToList(),
                false);
            return performanceMeasureReportedValuesGroupedViewData;
        }

        private static ImageGalleryViewData BuildImageGalleryViewData(Project project, Person currentPerson)
        {
            var userCanAddPhotosToThisProject = new ProjectEditAsAdminFeature().HasPermission(currentPerson, project).HasPermission;
            var newPhotoForProjectUrl = SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.New(project));
            var selectKeyImageUrl = userCanAddPhotosToThisProject
                ? SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.SetKeyPhoto(UrlTemplate.Parameter1Int))
                : string.Empty;
            var galleryName = $"ProjectImage{project.ProjectID}";
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
        public ViewResult FactSheet(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            Check.Assert(project.ProjectStage != ProjectStage.Terminated, "There is no Fact Sheet available for this Project because it has been terminated.");
            return project.IsBackwardLookingFactSheetRelevant() ? ViewBackwardLookingFactSheet(project) : ViewForwardLookingFactSheet(project);
        }
        private ViewResult ViewBackwardLookingFactSheet(Project project)
        {
            new ProjectViewFeature().DemandPermission(CurrentPerson, project);
            var mapDivID = $"project_{project.ProjectID}_Map";
            var projectLocationDetailMapInitJson = new ProjectLocationSummaryMapInitJson(project, mapDivID, false);
            var chartName = $"ProjectFactSheet{project.ProjectID}PieChart";
            var expenditureGooglePieChartSlices = project.GetExpenditureGooglePieChartSlices();
            var googleChartDataTable = GetProjectFactSheetGoogleChartDataTable(expenditureGooglePieChartSlices);
            var googleChartTitle = $"Investment by Funding Sector for: {project.ProjectName}";
            var googleChartType = GoogleChartType.PieChart;
            var googleChartConfiguration = new GooglePieChartConfiguration(googleChartTitle,
                MeasurementUnitTypeEnum.Dollars, expenditureGooglePieChartSlices, googleChartType,
                googleChartDataTable);
            var googleChartJson = new GoogleChartJson(string.Empty, chartName, googleChartConfiguration,
                googleChartType, googleChartDataTable, null);
            var viewData = new BackwardLookingFactSheetViewData(CurrentPerson, project, projectLocationDetailMapInitJson,
                googleChartJson, expenditureGooglePieChartSlices, FirmaHelpers.DefaultColorRange);
            return RazorView<BackwardLookingFactSheet, BackwardLookingFactSheetViewData>(viewData);
        }

        private ViewResult ViewForwardLookingFactSheet(Project project)
        {
            new ProjectViewFeature().DemandPermission(CurrentPerson, project);
            var mapDivID = $"project_{project.ProjectID}_Map";
            var projectLocationDetailMapInitJson = new ProjectLocationSummaryMapInitJson(project, mapDivID, false);

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

            var viewData = new ForwardLookingFactSheetViewData(CurrentPerson, project, projectLocationDetailMapInitJson,
                googleChartJson, fundingSourceRequestAmountGooglePieChartSlices);
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FullProjectList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ProjectsViewFullListFeature]
        public GridJsonNetJObjectResult<Project> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentPerson);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [ProjectsInProposalStageViewListFeature]
        public ViewResult Proposed()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.Proposals);
            var viewData = new ProposedViewData(CurrentPerson, firmaPage);
            return RazorView<Proposed, ProposedViewData>(viewData);
        }

        [ProjectsInProposalStageViewListFeature]
        public GridJsonNetJObjectResult<Project> ProposedGridJsonData()
        {
            var gridSpec = new ProposalsGridSpec(CurrentPerson);
            var proposals = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetProposalsVisibleToUser(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(proposals, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [PendingProjectsViewListFeature]
        public ViewResult Pending()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.PendingProjects);
            var viewData = new PendingViewData(CurrentPerson, firmaPage);
            return RazorView<Pending, PendingViewData>(viewData);
        }

        [PendingProjectsViewListFeature]
        public GridJsonNetJObjectResult<Project> PendingGridJsonData()
        {
            var gridSpec = new PendingGridSpec(CurrentPerson);
            var pendingProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetPendingProjects(CurrentPerson.CanViewPendingProjects);
            List<Project> filteredProposals;
            if (CurrentPerson.Role == Role.Normal)
            {
                filteredProposals = pendingProjects.Where(x =>
                        x.GetAssociatedOrganizations().Select(y => y.Organization).Contains(CurrentPerson.Organization))
                    .ToList();
            }
            else
            {
                filteredProposals = pendingProjects;
            }
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(filteredProposals, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectsViewFullListFeature]
        public ExcelResult IndexExcelDownload()
        {
            return FullDatabaseExcelDownloadImpl(
                HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects(),
                FieldDefinition.Project.GetFieldDefinitionLabelPluralized());
        }

        [ProjectsViewFullListFeature]
        public ExcelResult ProposalsExcelDownload()
        {
            return FullDatabaseExcelDownloadImpl(
                HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .GetProposalsVisibleToUser(CurrentPerson),
                FieldDefinition.Proposal.GetFieldDefinitionLabelPluralized());
        }

        [ProjectsViewFullListFeature]
        public ExcelResult PendingExcelDownload()
        {
            return FullDatabaseExcelDownloadImpl(
                HttpRequestStorage.DatabaseEntities.Projects.ToList()
                .GetPendingProjects(CurrentPerson.CanViewPendingProjects),
                "Pending Projects");
        }

        private ExcelResult FullDatabaseExcelDownloadImpl(List<Project> projects, string workbookTitle)
        {
            var projectsSpec = new ProjectExcelSpec();
            var wsProjects = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", projectsSpec, projects);

            var workSheets = new List<IExcelWorkbookSheetDescriptor>
            {
                wsProjects
            };


            var projectsDescriptionSpec = new ProjectDescriptionExcelSpec();
            var wsProjectDescriptions = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.ProjectDescription.GetFieldDefinitionLabelPluralized()}", projectsDescriptionSpec, projects);
            workSheets.Add(wsProjectDescriptions);

            var organizationsSpec = new ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec();
            var projectOrganizations = projects.SelectMany(p => p.GetAssociatedOrganizations()).ToList();
            var wsOrganizations = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()}", organizationsSpec, projectOrganizations);
            workSheets.Add(wsOrganizations);

            var projectNoteSpec = new ProjectNoteExcelSpec();
            var projectNotes = (projects.SelectMany(p => p.ProjectNotes)).ToList();
            var wsProjectNotes = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.ProjectNote.GetFieldDefinitionLabelPluralized()}", projectNoteSpec, projectNotes);
            workSheets.Add(wsProjectNotes);

            var performanceMeasureExpectedExcelSpec = new PerformanceMeasureExpectedExcelSpec();
            var performanceMeasureExpecteds = (projects.SelectMany(p => p.PerformanceMeasureExpecteds)).ToList();
            var wsPerformanceMeasureExpecteds = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet(
                $"Expected {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}s",
                performanceMeasureExpectedExcelSpec,
                performanceMeasureExpecteds);
            workSheets.Add(wsPerformanceMeasureExpecteds);

            var performanceMeasureActualExcelSpec = new PerformanceMeasureActualExcelSpec();
            var performanceMeasureActuals = (projects.SelectMany(p => p.GetReportedPerformanceMeasures())).ToList();
            var wsPerformanceMeasureActuals = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet(
                $"Reported {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}", performanceMeasureActualExcelSpec, performanceMeasureActuals);
            workSheets.Add(wsPerformanceMeasureActuals);

            var projectFundingSourceExpenditureSpec = new ProjectFundingSourceExpenditureExcelSpec();
            var projectFundingSourceExpenditures = (projects.SelectMany(p => p.ProjectFundingSourceExpenditures)).ToList();
            var wsProjectFundingSourceExpenditures = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.ReportedExpenditure.GetFieldDefinitionLabelPluralized()}", projectFundingSourceExpenditureSpec, projectFundingSourceExpenditures);
            workSheets.Add(wsProjectFundingSourceExpenditures);

            var projectWatershedSpec = new ProjectWatershedExcelSpec();
            var projectWatersheds = (projects.SelectMany(p => p.ProjectWatersheds)).ToList();
            var wsProjectWatersheds = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.Project.GetFieldDefinitionLabel()} {FieldDefinition.Watershed.GetFieldDefinitionLabelPluralized()}", projectWatershedSpec, projectWatersheds);
            workSheets.Add(wsProjectWatersheds);

            MultiTenantHelpers.GetClassificationSystems().ForEach(c =>
            {
                var projectClassificationSpec = new ProjectClassificationExcelSpec();
                var projectClassifications = projects.SelectMany(p => p.ProjectClassifications).Where(x => x.Classification.ClassificationSystem == c).ToList();
                var wsProjectClassifications = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet(
                    c.ClassificationSystemNamePluralized, projectClassificationSpec, projectClassifications);
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
            var confirmMessage = $"Are you sure you want to delete this Project '{project.DisplayName}'?";
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

            var message = $"Project \"{project.DisplayName}\" succesfully deleted.";
            project.DeleteFull();
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<AuditLog> AuditLogsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var gridSpec = new AuditLogsGridSpec();
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
                    .ToList().GetActiveProjectsAndProposals(CurrentPerson.CanViewProposals);
            return projectsFound;
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult SearchImpl(string searchCriteria, List<Project> projectsFound)
        {
            if (projectsFound.Count == 1)
            {
                return RedirectToAction(new SitkaRoute<ProjectController>(x => x.Detail(projectsFound.Single())));
            }

            var viewData = new SearchResultsViewData(CurrentPerson, projectsFound, searchCriteria);
            return RazorView<SearchResults, SearchResultsViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public JsonResult Find(string term)
        {
            var projectFindResults = GetViewableProjectsFromSearchCriteria(term.Trim());
            var results = projectFindResults.Take(ProjectsCountLimit).Select(p => new ListItem(p.DisplayName.ToEllipsifiedString(100), p.GetDetailUrl())).ToList();
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FeaturedProjectList);
            var viewData = new FeaturedListViewData(CurrentPerson, firmaPage);
            return RazorView<FeaturedList, FeaturedListViewData>(viewData);
        }

        [ProjectManageFeaturedFeature]
        public GridJsonNetJObjectResult<Project> FeaturedListGridJsonData()
        {
            var gridSpec = new FeaturesListProjectGridSpec(CurrentPerson);
            var taxonomyBranches = HttpRequestStorage.DatabaseEntities.Projects.Where(p => p.IsFeatured).ToList().GetActiveProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(taxonomyBranches, gridSpec);
            return gridJsonNetJObjectResult;
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
                var newlyFearturedProjects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
                newlyFearturedProjects.ForEach(x => x.IsFeatured = true);
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FullProjectListSimple);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects();
            var viewData = new FullProjectListSimpleViewData(CurrentPerson, firmaPage, projects);
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
An update for this {FieldDefinition.Project.GetFieldDefinitionLabel()} was already submitted for this {
                    FieldDefinition.ReportingYear.GetFieldDefinitionLabel()
                } {dateDisplayText}. If {FieldDefinition.Project.GetFieldDefinitionLabel()} information has changed, 
any new information you'd like to provide will be added to the {
                    FieldDefinition.Project.GetFieldDefinitionLabel()
                }. Thanks for being proactive!
</div>
<div>
<hr />
Continue with a new {FieldDefinition.Project.GetFieldDefinitionLabel()} update?
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
            var gridSpec = new ProjectNotificationGridSpec();
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
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn($"{FieldDefinition.FundingSource.GetFieldDefinitionLabel()}", GoogleChartColumnDataType.String, GoogleChartType.PieChart), new GoogleChartColumn("Expenditures", GoogleChartColumnDataType.Number, GoogleChartType.PieChart) };
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.MyOrganizationsProjects);
            var viewData = new MyOrganizationsProjectsViewData(CurrentPerson, firmaPage);
            return RazorView<MyOrganizationsProjects, MyOrganizationsProjectsViewData>(viewData);
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<Project> MyOrganizationsProjectsGridJsonData()
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            var organization = CurrentPerson.Organization;
            var taxonomyBranches = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(p => organization.IsLeadImplementingOrganizationForProject(p) ||
                                                                                                                        organization.IsProjectStewardOrganizationForProject(p)).OrderBy(x => x.DisplayName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(taxonomyBranches, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectsInProposalStageViewListFeature]
        public GridJsonNetJObjectResult<Project> MyOrganizationsProposalsGridJsonData()
        {
            var gridSpec = new ProposalsGridSpec(CurrentPerson);

            var proposals = HttpRequestStorage.DatabaseEntities.Projects.ToList()
                .GetProposalsVisibleToUser(CurrentPerson)
                .Where(x => x.ProposingPerson.OrganizationID == CurrentPerson.OrganizationID)
                .ToList();

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(proposals, gridSpec);
            return gridJsonNetJObjectResult;
        }
        
        [ProjectsViewFullListFeature]
        public PartialViewResult DenyCreateProject()
        {
            var projectStewardLabel = FieldDefinition.ProjectSteward.GetFieldDefinitionLabel();
            var projectLabel = FieldDefinition.Project.GetFieldDefinitionLabel();
            var organizationLabel = FieldDefinition.Organization.GetFieldDefinitionLabel();
            var projectRelationshipTypeLabel = FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel();

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
            var projectStewardLabel = FieldDefinition.ProjectSteward.GetFieldDefinitionLabel();
            var projectLabel = FieldDefinition.Project.GetFieldDefinitionLabel();
            var organizationLabel = FieldDefinition.Organization.GetFieldDefinitionLabel();

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
            var projectStewardLabel = FieldDefinition.ProjectSteward.GetFieldDefinitionLabel();
            var proposalLabel = FieldDefinition.Proposal.GetFieldDefinitionLabel();

            var confirmMessage = CurrentPerson.RoleID == Role.ProjectSteward.RoleID
                ? $"Although you are a {projectStewardLabel}, you do not have permission to edit this {proposalLabel} through this page because it is pending approval. You can <a href='{projectCreateUrl}'>review, edit, or approve</a> the proposal."
                : $"You don't have permission to edit this {proposalLabel}.";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, false);
            var viewModel = new ConfirmDialogFormViewModel();
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [ProjectsViewFullListFeature]
        public FileContentResult FactSheetPdf(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            using (var outputFile = new DisposableTempFile())
            {
                var pdfConversionSettings = new PDFUtility.PdfConversionSettings(new HttpCookieCollection()) { Zoom = 0.9 };
                PDFUtility.ConvertURLToPDF(
                    new Uri(new SitkaRoute<ProjectController>(c => c.FactSheet(project)).BuildAbsoluteUrlFromExpression()),
                    outputFile.FileInfo,
                    pdfConversionSettings);

                var fileContents = FileUtility.FileToString(outputFile.FileInfo);
                Check.Assert(fileContents.StartsWith("%PDF-"), "Should be a PDF file and have the starting bytes for PDF");
                Check.Assert(fileContents.Contains("wkhtmltopdf") || fileContents.Contains("\0w\0k\0h\0t\0m\0l\0t\0o\0p\0d\0f"), "Should be a PDF file produced by wkhtmltopdf.");

                var fileName = $"{project.ProjectName.ToLower().Replace(" ", "-")}-fact-sheet.pdf";
                var content = System.IO.File.ReadAllBytes(outputFile.FileInfo.FullName);
                return File(content, "application/pdf", fileName);
            }
        }
    }
}
