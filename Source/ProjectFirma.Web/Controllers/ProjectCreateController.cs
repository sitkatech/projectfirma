/*-----------------------------------------------------------------------
<copyright file="ProjectCreateController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectAttachment;
using ProjectFirma.Web.Views.Shared.ProjectContact;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Basics = ProjectFirma.Web.Views.ProjectCreate.Basics;
using BasicsViewData = ProjectFirma.Web.Views.ProjectCreate.BasicsViewData;
using BasicsViewModel = ProjectFirma.Web.Views.ProjectCreate.BasicsViewModel;
using Contacts = ProjectFirma.Web.Views.ProjectCreate.Contacts;
using ContactsViewData = ProjectFirma.Web.Views.ProjectCreate.ContactsViewData;
using ContactsViewModel = ProjectFirma.Web.Views.ProjectCreate.ContactsViewModel;
using ExpectedFunding = ProjectFirma.Web.Views.ProjectCreate.ExpectedFunding;
using ExpectedFundingViewData = ProjectFirma.Web.Views.ProjectCreate.ExpectedFundingViewData;
using ExpectedFundingViewModel = ProjectFirma.Web.Views.ProjectCreate.ExpectedFundingViewModel;
using Expenditures = ProjectFirma.Web.Views.ProjectCreate.Expenditures;
using ExpendituresViewData = ProjectFirma.Web.Views.ProjectCreate.ExpendituresViewData;
using ExpendituresViewModel = ProjectFirma.Web.Views.ProjectCreate.ExpendituresViewModel;
using GeospatialAreaViewData = ProjectFirma.Web.Views.ProjectCreate.GeospatialAreaViewData;
using GeospatialAreaViewModel = ProjectFirma.Web.Views.ProjectCreate.GeospatialAreaViewModel;
using LocationDetailed = ProjectFirma.Web.Views.ProjectCreate.LocationDetailed;
using LocationDetailedViewData = ProjectFirma.Web.Views.ProjectCreate.LocationDetailedViewData;
using LocationDetailedViewModel = ProjectFirma.Web.Views.ProjectCreate.LocationDetailedViewModel;
using LocationSimple = ProjectFirma.Web.Views.ProjectCreate.LocationSimple;
using LocationSimpleViewData = ProjectFirma.Web.Views.ProjectCreate.LocationSimpleViewData;
using LocationSimpleViewModel = ProjectFirma.Web.Views.ProjectCreate.LocationSimpleViewModel;
using Organizations = ProjectFirma.Web.Views.ProjectCreate.Organizations;
using OrganizationsViewData = ProjectFirma.Web.Views.ProjectCreate.OrganizationsViewData;
using OrganizationsViewModel = ProjectFirma.Web.Views.ProjectCreate.OrganizationsViewModel;
using PerformanceMeasures = ProjectFirma.Web.Views.ProjectCreate.PerformanceMeasures;
using PerformanceMeasuresViewData = ProjectFirma.Web.Views.ProjectCreate.PerformanceMeasuresViewData;
using PerformanceMeasuresViewModel = ProjectFirma.Web.Views.ProjectCreate.PerformanceMeasuresViewModel;
using Photos = ProjectFirma.Web.Views.ProjectCreate.Photos;
using ProjectCustomAttributes = ProjectFirma.Web.Views.ProjectCreate.ProjectCustomAttributes;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCreateController : FirmaBaseController
    {
        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public PartialViewResult ProjectTypeSelection()
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
            var viewData = new ProjectTypeSelectionViewData(tenantAttribute);
            var viewModel = new ProjectTypeSelectionViewModel();
            return RazorPartialView<ProjectTypeSelection, ProjectTypeSelectionViewData, ProjectTypeSelectionViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ProjectTypeSelection(ProjectTypeSelectionViewModel viewModel)
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
            var viewData = new ProjectTypeSelectionViewData(tenantAttribute);

            if (!ModelState.IsValid)
            {
                return RazorPartialView<ProjectTypeSelection, ProjectTypeSelectionViewData, ProjectTypeSelectionViewModel>(viewData, viewModel);
            }

            switch (viewModel.CreateType)
            {
                case ProjectTypeSelectionViewModel.ProjectCreateType.Proposal:
                    return new ModalDialogFormJsonResult(
                        SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null)));
                case ProjectTypeSelectionViewModel.ProjectCreateType.Existing:
                    return new ModalDialogFormJsonResult(
                        SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsEnterHistoric(null)));
                case ProjectTypeSelectionViewModel.ProjectCreateType.ImportExternal:
                    return new ModalDialogFormJsonResult(
                        SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.ImportExternal()));
                default:
                    throw new ArgumentException();
            }
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult InstructionsProposal(int? projectID)
        {
            var firmaPage = FirmaPageTypeEnum.ProposeProjectInstructions.GetFirmaPage();

            if (projectID.HasValue)
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID.Value);
                var proposalSectionsStatus = GetProposalSectionsStatus(project);

                var viewData = new InstructionsProposalViewData(CurrentFirmaSession, project, proposalSectionsStatus, firmaPage, false);

                return RazorView<InstructionsProposal, InstructionsProposalViewData>(viewData);
            }
            else
            {

                var viewData = new InstructionsProposalViewData(CurrentFirmaSession, firmaPage, true);
                return RazorView<InstructionsProposal, InstructionsProposalViewData>(viewData);
            }
        }

        private static ProposalSectionsStatus GetProposalSectionsStatus(Project project)
        {
            return new ProposalSectionsStatus(project, HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList());
        }

        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult InstructionsEnterHistoric(int? projectID)
        {
            var firmaPage = FirmaPageTypeEnum.EnterHistoricProjectInstructions.GetFirmaPage();

            if (projectID.HasValue)
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID.Value);
                var proposalSectionsStatus = GetProposalSectionsStatus(project);
                var viewData = new InstructionsEnterHistoricViewData(CurrentFirmaSession, project, proposalSectionsStatus, firmaPage, false);

                return RazorView<InstructionsEnterHistoric, InstructionsEnterHistoricViewData>(viewData);
            }
            else
            {
                var viewData = new InstructionsEnterHistoricViewData(CurrentFirmaSession, firmaPage, true);
                return RazorView<InstructionsEnterHistoric, InstructionsEnterHistoricViewData>(viewData);
            }
        }

        [HttpGet]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ActionResult CreateAndEditBasics(bool newProjectIsProposal)
        {
            var basicsViewModel = new BasicsViewModel();
            basicsViewModel.ProjectTypeEnum = ProjectTypeEnum.Normal;
            if (newProjectIsProposal)
            {
                basicsViewModel.ProjectStageID = ProjectStage.Proposal.ProjectStageID;
            }

            return ViewCreateAndEditBasics(basicsViewModel, !newProjectIsProposal);
        }

        [HttpPost]
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult CreateAndEditBasics(bool newProjectIsProposal, BasicsViewModel viewModel)
        {
            return CreateAndEditBasicsPostImpl(viewModel);
        }

        [HttpGet]
        [ProjectCreateNewFeature]
        public ViewResult CreateBasicsFromExternalImport(ImportExternalProjectStagingPrimaryKey importExternalProjectStagingPrimaryKey)
        {
            var importExternalProjectStaging = importExternalProjectStagingPrimaryKey.EntityObject;
            var viewModel = new BasicsViewModel
            {
                ImportExternalProjectStagingID = importExternalProjectStaging.ImportExternalProjectStagingID,
                ProjectName = importExternalProjectStaging.ProjectName,
                ProjectDescription = importExternalProjectStaging.Description,
                PlanningDesignStartYear = importExternalProjectStaging.PlanningDesignStartYear,
                ImplementationStartYear = importExternalProjectStaging.ImplementationStartYear,
                CompletionYear = importExternalProjectStaging.EndYear,
                ProjectTypeEnum = ProjectTypeEnum.Normal
            };
            return ViewCreateAndEditBasics(viewModel, true);
        }

        [HttpPost]
        [ProjectCreateNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult CreateBasicsFromExternalImport(ImportExternalProjectStagingPrimaryKey importExternalProjectStagingPrimaryKey,
            BasicsViewModel viewModel)
        {
            return CreateAndEditBasicsPostImpl(viewModel);
        }

        private ActionResult CreateAndEditBasicsPostImpl(BasicsViewModel viewModel)
        {
            // To keep a 100% consistent time, we snapshot it so it doesn't change between calls
            var now = DateTime.Now;

            var project = new Project(viewModel.TaxonomyLeafID ?? ModelObjectHelpers.NotYetAssignedID,
                viewModel.ProjectStageID ?? ModelObjectHelpers.NotYetAssignedID,
                viewModel.ProjectName,
                viewModel.ProjectDescription,
                false,
                ProjectLocationSimpleType.None.ProjectLocationSimpleTypeID,
                ProjectApprovalStatus.Draft.ProjectApprovalStatusID,
                now, 
                ProjectType.Normal.ProjectTypeID)
            {

                ProposingPerson = CurrentFirmaSession.Person,
                ProposingDate = now
            };

            return SaveProjectAndCreateAuditEntry(project, viewModel);
        }

        private ViewResult ViewCreateAndEditBasics(BasicsViewModel viewModel, bool newProjectIsHistoric)
        {
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs;
            var instructionsPageUrl = newProjectIsHistoric
                ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsEnterHistoric(null))
                : SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));

            var fundingTypes = FundingType.All.ToList();
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();

            var viewData = new BasicsViewData(CurrentFirmaSession, fundingTypes, taxonomyLeafs, newProjectIsHistoric,
                instructionsPageUrl, tenantAttribute);

            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditBasics(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new BasicsViewModel(project);
            return ViewEditBasics(project, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBasics(ProjectPrimaryKey projectPrimaryKey, BasicsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            return SaveProjectAndCreateAuditEntry(project, viewModel);
        }

        private ViewResult ViewEditBasics(Project project, BasicsViewModel viewModel)
        {
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsBasicsSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsBasicsSectionComplete;
            
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs;
            var fundingTypes =FundingType.All.ToList();
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();

            var viewData = new BasicsViewData(CurrentFirmaSession, project, proposalSectionsStatus, taxonomyLeafs,
                fundingTypes, tenantAttribute);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Basics successfully saved.");
            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        private ActionResult SaveProjectAndCreateAuditEntry(Project project, BasicsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var showProjectStageDropDown = viewModel.ProjectStageID != ProjectStage.Proposal.ProjectStageID;
                return ModelObjectHelpers.IsRealPrimaryKeyValue(project.PrimaryKey) ? ViewEditBasics(project, viewModel) : ViewCreateAndEditBasics(viewModel, showProjectStageDropDown);
            }

            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(project.PrimaryKey))
            {
                HttpRequestStorage.DatabaseEntities.AllProjects.Add(project);
            }


            viewModel.UpdateModel(project, CurrentFirmaSession);

            if (project.ProjectStage == ProjectStage.Proposal)
            {
                DeletePerformanceMeasureActuals(project);
                foreach (var projectExemptReportingYear in project.ProjectExemptReportingYears)
                {
                    projectExemptReportingYear.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }

                foreach (var projectFundingSourceExpenditure in project.ProjectFundingSourceExpenditures)
                {
                    projectFundingSourceExpenditure.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }

            if (project.ProjectStage == ProjectStage.PlanningDesign)
            {
                DeletePerformanceMeasureActuals(project);
                foreach (var projectExemptReportingYear in project.GetPerformanceMeasuresExemptReportingYears())
                {
                    projectExemptReportingYear.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }

            HttpRequestStorage.DatabaseEntities.SaveChanges();


            var auditLog = new AuditLog(CurrentFirmaSession.Person,
                DateTime.Now,
                AuditLogEventType.Added,
                "Project",
                project.ProjectID,
                "ProjectID",
                project.ProjectID.ToString())
            {
                ProjectID = project.ProjectID,
                AuditDescription = $"Project: created {project.GetDisplayName()}"
            };
            HttpRequestStorage.DatabaseEntities.AllAuditLogs.Add(auditLog);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} successfully saved.");

            return GoToNextSection(viewModel, project, ProjectCreateSection.Basics.ProjectCreateSectionDisplayName);
        }

        [HttpGet]
        [PerformanceMeasureExpectedProposedFeature]
        public ViewResult ExpectedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ExpectedPerformanceMeasureValuesViewModel(project);
            return ViewExpectedPerformanceMeasures(project, viewModel);
        }

        private ViewResult ViewExpectedPerformanceMeasures(Project project, ExpectedPerformanceMeasureValuesViewModel viewModel)
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsPerformanceMeasureSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsPerformanceMeasureSectionComplete;

            var configurePerformanceMeasuresUrl = string.Empty;

            if (new PerformanceMeasureManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession))
            {
                configurePerformanceMeasuresUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Manage());
            }

            var editPerformanceMeasureExpectedsViewData = new EditPerformanceMeasureExpectedViewData(
                new List<ProjectSimple> {new ProjectSimple(project)}, performanceMeasures, project.ProjectID, false, configurePerformanceMeasuresUrl);

            var viewData = new ExpectedPerformanceMeasureValuesViewData(CurrentFirmaSession, project, proposalSectionsStatus, editPerformanceMeasureExpectedsViewData);
            return RazorView<ExpectedPerformanceMeasureValues, ExpectedPerformanceMeasureValuesViewData, ExpectedPerformanceMeasureValuesViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureExpectedProposedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpectedPerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, ExpectedPerformanceMeasureValuesViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewExpectedPerformanceMeasures(project, viewModel);
            }
            var performanceMeasureExpecteds = project.PerformanceMeasureExpecteds.ToList();

            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Load();
            var allPerformanceMeasureExpecteds = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpecteds.Local;

            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptions.Load();
            var allPerformanceMeasureExpectedSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptions.Local;

            viewModel.UpdateModel(performanceMeasureExpecteds, allPerformanceMeasureExpecteds, allPerformanceMeasureExpectedSubcategoryOptions, project);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Expected {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} successfully saved.");
            return GoToNextSection(viewModel, project,ProjectCreateSection.ExpectedAccomplishments.ProjectCreateSectionDisplayName);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ActionResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;


            var performanceMeasureActualSimples =
                project.PerformanceMeasureActuals.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(x=>x.PerformanceMeasure.GetDisplayName())
                    .ThenByDescending(x => x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                    .Select(x => new PerformanceMeasureActualSimple(x))
                    .ToList();
            var projectExemptReportingYears = project.GetPerformanceMeasuresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            var possibleYearsToExempt = project.GetProjectUpdateImplementationStartToCompletionYearRange();
            projectExemptReportingYears.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x))
                    .Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), project.ProjectID, x)));

            var viewModel = new PerformanceMeasuresViewModel(performanceMeasureActualSimples,
                project.PerformanceMeasureActualYearsExemptionExplanation,
                projectExemptReportingYears.OrderBy(x => x.CalendarYear).ToList())
            {ProjectID = projectPrimaryKey.PrimaryKeyValue};
            return ViewPerformanceMeasures(project, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult PerformanceMeasures(ProjectPrimaryKey projectPrimaryKey, PerformanceMeasuresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;


            if (!ModelState.IsValid)
            {
                return ViewPerformanceMeasures(project, viewModel);
            }
            var performanceMeasureActuals = project.PerformanceMeasureActuals.ToList();
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            var allPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Load();
            var performanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptions.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.Load();
            var allPerformanceMeasureReportingPeriods = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Local;
            viewModel.UpdateModel(performanceMeasureActuals, allPerformanceMeasureActuals, performanceMeasureActualSubcategoryOptions, project, allPerformanceMeasureReportingPeriods);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.ReportedAccomplishments.ProjectCreateSectionDisplayName);
        }

        private ViewResult ViewPerformanceMeasures(Project project, PerformanceMeasuresViewModel viewModel)
        {
            var performanceMeasures =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var showExemptYears = project.GetPerformanceMeasuresExemptReportingYears().Any() ||
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

            var viewDataForAngularEditor = new PerformanceMeasuresViewData.ViewDataForAngularEditor(project.ProjectID,
                performanceMeasureSimples,
                performanceMeasureSubcategorySimples,
                performanceMeasureSubcategoryOptionSimples,
                calendarYearStrings,
                showExemptYears);
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            var viewData =

                new PerformanceMeasuresViewData(CurrentFirmaSession, project, viewDataForAngularEditor, proposalSectionsStatus);
            return RazorView<PerformanceMeasures, PerformanceMeasuresViewData, PerformanceMeasuresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult ExpectedFunding(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ExpectedFundingViewModel(project);
            return ViewExpectedFunding(project, viewModel);
        }

        private ViewResult ViewExpectedFunding(Project project, ExpectedFundingViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var fundingTypes = FundingType.All.ToList().ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            var viewDataForAngularEditor = new ExpectedFundingViewData.ViewDataForAngularClass(project, allFundingSources, fundingTypes);
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsExpectedFundingSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsPerformanceMeasureSectionComplete;


            var viewData = new ExpectedFundingViewData(CurrentFirmaSession, project, proposalSectionsStatus, viewDataForAngularEditor);
            return RazorView<ExpectedFunding, ExpectedFundingViewData, ExpectedFundingViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpectedFunding(ProjectPrimaryKey projectPrimaryKey, ExpectedFundingViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewExpectedFunding(project, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceBudgets.Load();
            var projectFundingSourceBudgets = project.ProjectFundingSourceBudgets.ToList();
            var allProjectFundingSourceBudgets = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceBudgets.Local;
            viewModel.UpdateModel(project, projectFundingSourceBudgets, allProjectFundingSourceBudgets);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Budget successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Budget.ProjectCreateSectionDisplayName);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ActionResult ExpectedFundingByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;

            var calendarYearRange = project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
            var costTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList();
            var projectRelevantCostTypes = project.GetBudgetsRelevantCostTypes().Select(x => new ProjectRelevantCostTypeSimple(x)).ToList();
            var currentRelevantCostTypeIDs = projectRelevantCostTypes.Select(x => x.CostTypeID).ToList();
            projectRelevantCostTypes.AddRange(
                costTypes.Where(x => !currentRelevantCostTypeIDs.Contains(x.CostTypeID))
                    .Select((x, index) => new ProjectRelevantCostTypeSimple(-(index + 1), project.ProjectID, x.CostTypeID, x.CostTypeName)));
            var viewModel = new ExpectedFundingByCostTypeViewModel(project, calendarYearRange, projectRelevantCostTypes);
            return ViewExpectedFundingByCostType(project, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpectedFundingByCostType(ProjectPrimaryKey projectPrimaryKey, ExpectedFundingByCostTypeViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;

            var calendarYearRange = project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
            if (!ModelState.IsValid)
            {
                return ViewExpectedFundingByCostType(project, calendarYearRange, viewModel);
            }
            viewModel.UpdateModel(project, HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Budget successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Budget.ProjectCreateSectionDisplayName);
        }

        private ViewResult ViewExpectedFundingByCostType(Project project, List<int> calendarYearRange, ExpectedFundingByCostTypeViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var allCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList().Select(x => new CostTypeSimple(x)).OrderBy(p => p.CostTypeName).ToList();
            var fundingTypes = FundingType.All.ToList().ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            var viewDataForAngularEditor = new ExpectedFundingByCostTypeViewData.ViewDataForAngularClass(project, allFundingSources, allCostTypes, calendarYearRange, fundingTypes);


            var viewData = new ExpectedFundingByCostTypeViewData(CurrentFirmaSession, project, GetProposalSectionsStatus(project), viewDataForAngularEditor);
            return RazorView<ExpectedFundingByCostType, ExpectedFundingByCostTypeViewData, ExpectedFundingByCostTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ActionResult Expenditures(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();

            var calendarYearRangeForExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var projectFundingSourceExpenditureBulks = ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditures, calendarYearRangeForExpenditures);

            var viewModel = new ExpendituresViewModel(projectFundingSourceExpenditureBulks, project) {ProjectID = project.ProjectID};
            return ViewExpenditures(project, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Expenditures(ProjectPrimaryKey projectPrimaryKey, ExpendituresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectFundingSourceExpenditureUpdates = project.ProjectFundingSourceExpenditures.ToList();

            if (!ModelState.IsValid)
            {

                return ViewExpenditures(project, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureUpdates.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            viewModel.UpdateModel(project, projectFundingSourceExpenditureUpdates, allProjectFundingSourceExpenditures);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Expenditures successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.ReportedExpenditures.ProjectCreateSectionDisplayName);
        }

        private ViewResult ViewExpenditures(Project project, ExpendituresViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var requiredCalendarYearRange = project.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
            var viewDataForAngularClass = new ExpendituresViewData.ViewDataForAngularClass(project,
                allFundingSources,
                requiredCalendarYearRange);
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            var viewData = new ExpendituresViewData(CurrentFirmaSession, project, viewDataForAngularClass, proposalSectionsStatus);
            return RazorView<Expenditures, ExpendituresViewData, ExpendituresViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ActionResult ExpendituresByCostType(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;

            var calendarYearRange = project.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
            var costTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList();
            var projectRelevantCostTypes = project.GetExpendituresRelevantCostTypes().Select(x => new ProjectRelevantCostTypeSimple(x)).ToList();
            var currentRelevantCostTypeIDs = projectRelevantCostTypes.Select(x => x.CostTypeID).ToList();
            projectRelevantCostTypes.AddRange(
                costTypes.Where(x => !currentRelevantCostTypeIDs.Contains(x.CostTypeID))
                    .Select((x, index) => new ProjectRelevantCostTypeSimple(-(index + 1), project.ProjectID, x.CostTypeID, x.CostTypeName)));

            var viewModel = new ExpendituresByCostTypeViewModel(project, calendarYearRange, projectRelevantCostTypes);
            return ViewExpendituresByCostType(project, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ExpendituresByCostType(ProjectPrimaryKey projectPrimaryKey, ExpendituresByCostTypeViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;

            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRange = project.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
            if (!ModelState.IsValid)
            {
                return ViewExpendituresByCostType(project, calendarYearRange, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            viewModel.UpdateModel(project, projectFundingSourceExpenditures, allProjectFundingSourceExpenditures);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Expenditures successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.ReportedExpenditures.ProjectCreateSectionDisplayName);
        }

        private ViewResult ViewExpendituresByCostType(Project project, List<int> calendarYearRange, ExpendituresByCostTypeViewModel viewModel)
        {

            var showNoExpendituresExplanation = !string.IsNullOrWhiteSpace(project.ExpendituresNote);
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var allCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList().Select(x => new CostTypeSimple(x)).OrderBy(p => p.CostTypeName).ToList();
            var viewDataForAngularEditor = new ExpendituresByCostTypeViewData.ViewDataForAngularClass(project, allFundingSources, allCostTypes, calendarYearRange, showNoExpendituresExplanation);

            var viewData = new ExpendituresByCostTypeViewData(CurrentFirmaSession, project, viewDataForAngularEditor, GetProposalSectionsStatus(project));
            return RazorView<ExpendituresByCostType, ExpendituresByCostTypeViewData, ExpendituresByCostTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditClassifications(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectClassificationSimples = GetProjectClassificationSimples(project);
            var viewModel = new EditProposalClassificationsViewModel(projectClassificationSimples);
            return ViewEditClassifications(project, viewModel);
        }

        public static List<ProjectClassificationSimple> GetProjectClassificationSimples(Project project)
        {
            var selectedProjectClassifications = project.ProjectClassifications;

            var projectClassificationSimples =
                HttpRequestStorage.DatabaseEntities.ClassificationSystems.OrderBy(x => x.ClassificationSystemName).SelectMany(x => x.Classifications).OrderBy(x => x.DisplayName).Select(x => new ProjectClassificationSimple
                {
                    ClassificationID = x.ClassificationID,
                    ClassificationSystemID = x.ClassificationSystemID,
                    ProjectID = project.ProjectID
                }).ToList();
 
            foreach (var selectedClassification in selectedProjectClassifications)
            {
                var selectedSimple = projectClassificationSimples.Single(x => x.ClassificationID == selectedClassification.ClassificationID);
                selectedSimple.Selected = true;
                selectedSimple.ProjectClassificationNotes = selectedClassification.ProjectClassificationNotes;
            }

            return projectClassificationSimples;
        }

        private ViewResult ViewEditClassifications(Project project, EditProposalClassificationsViewModel viewModel)
        {
            var allClassificationSystems = HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList().Where(x => x.HasClassifications).OrderBy(p => p.ClassificationSystemName).ToList();
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsClassificationsComplete = ModelState.IsValid && proposalSectionsStatus.IsClassificationsComplete;


            var viewData = new EditProposalClassificationsViewData(CurrentFirmaSession, project, allClassificationSystems, ProjectCreateSection.Classifications.ProjectCreateSectionDisplayName, proposalSectionsStatus);
            return RazorView<EditProposalClassifications, EditProposalClassificationsViewData, EditProposalClassificationsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditClassifications(ProjectPrimaryKey projectPrimaryKey, EditProposalClassificationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditClassifications(project, viewModel);
            }
            var currentProjectClassifications = viewModel.ProjectClassificationSimples;
            HttpRequestStorage.DatabaseEntities.ProjectClassifications.Load();
            viewModel.UpdateModel(project, currentProjectClassifications);

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabelPluralized()} successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Classifications.ProjectCreateSectionDisplayName);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditAssessment(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;            
            var projectAssessmentQuestionSimples = GetProjectAssessmentQuestionSimples(project);
            var viewModel = new EditAssessmentViewModel(projectAssessmentQuestionSimples);
            return ViewEditAssessment(project, viewModel);
        }

        public static List<ProjectAssessmentQuestionSimple> GetProjectAssessmentQuestionSimples(Project project)
        {           
            var allQuestionsAsSimples =
                HttpRequestStorage.DatabaseEntities.AssessmentQuestions.Where(x => !x.ArchiveDate.HasValue).ToList().Select(x => new ProjectAssessmentQuestionSimple(x, project)).ToList();

            var answeredQuestions = project.ProjectAssessmentQuestions.ToList();

            foreach (var question in allQuestionsAsSimples)
            {
                var matchedQuestionOrNull = answeredQuestions.SingleOrDefault(answeredQuestion => answeredQuestion.AssessmentQuestionID == question.AssessmentQuestionID);                
                question.Answer = matchedQuestionOrNull?.Answer;
            }
            return allQuestionsAsSimples;
        }


        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProjectCreateFeature]
        public ActionResult EditAssessment(ProjectPrimaryKey projectPrimaryKey, EditAssessmentViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditAssessment(project, viewModel);
            }
            viewModel.UpdateModel(project);
            SetMessageForDisplay("Assessment successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Assessment.ProjectCreateSectionDisplayName);
        }

        private ViewResult ViewEditAssessment(Project project, EditAssessmentViewModel viewModel)
        {
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsAssessmentComplete = ModelState.IsValid && proposalSectionsStatus.IsAssessmentComplete;
            var assessmentGoals = HttpRequestStorage.DatabaseEntities.AssessmentGoals.ToList();

            var viewData = new EditAssessmentViewData(CurrentFirmaSession, project, assessmentGoals, ProjectCreateSection.Assessment.ProjectCreateSectionDisplayName, proposalSectionsStatus);
            return RazorView<EditAssessment, EditAssessmentViewData, EditAssessmentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditLocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new LocationSimpleViewModel(project);
            return ViewEditLocationSimple(project, viewModel);
        }

        private ViewResult ViewEditLocationSimple(Project project, LocationSimpleViewModel viewModel)
        {
            var layerGeoJsons = MapInitJson.GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Hide);
            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_EditMap", 10, layerGeoJsons, MapInitJson.GetExternalMapLayers(), BoundingBox.MakeNewDefaultBoundingBox(), false) {AllowFullScreen = false, DisablePopups = true };
            var mapPostUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.EditLocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationSimpleFormID(project);
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName)
                .ToList();
            var editProjectLocationViewData = new ProjectLocationSimpleViewData(CurrentFirmaSession, mapInitJson, geospatialAreaTypes, null, mapPostUrl, mapFormID);
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsProjectLocationSimpleSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsProjectLocationSimpleSectionComplete;

            var viewData = new LocationSimpleViewData(CurrentFirmaSession, project, proposalSectionsStatus, editProjectLocationViewData);
            return RazorView<LocationSimple, LocationSimpleViewData, LocationSimpleViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditLocationSimple(ProjectPrimaryKey projectPrimaryKey, LocationSimpleViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditLocationSimple(project, viewModel);
            }

            viewModel.UpdateModel(project);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Simple Location successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.LocationSimple.ProjectCreateSectionDisplayName);
        }


        private static string GenerateEditProjectLocationSimpleFormID(Project project)
        {
            return $"editMapForProject{project.ProjectID}";
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditLocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new LocationDetailedViewModel();
            return ViewEditLocationDetailed(project, viewModel);
        }

        private ViewResult ViewEditLocationDetailed(Project project, LocationDetailedViewModel viewModel)
        {
            var mapDivID = $"project_{project.GetEntityID()}_EditDetailedMap";
            var detailedLocationGeoJsonFeatureCollection = ProjectModelExtensions.DetailedLocationToGeoJsonFeatureCollection(project);
            var editableLayerGeoJson = new LayerGeoJson($"Proposed {FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}- Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var layers = MapInitJson.GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleMapLayer(project));
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, MapInitJson.GetExternalMapLayers(), boundingBox) { AllowFullScreen = false, DisablePopups = true};
            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var uploadGisFileUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.GetEntityID()));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationDetailed(project, null));
            var hasSimpleLocationPoint = project.ProjectLocationPoint != null;
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            var projectLocationDetailViewData = new ProjectLocationDetailViewData(project.ProjectID, mapInitJson, editableLayerGeoJson, uploadGisFileUrl, mapFormID, saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation, hasSimpleLocationPoint);

            var viewData = new LocationDetailedViewData(CurrentFirmaSession, project, proposalSectionsStatus, projectLocationDetailViewData);
            return RazorView<LocationDetailed, LocationDetailedViewData, LocationDetailedViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditLocationDetailed(ProjectPrimaryKey projectPrimaryKey, LocationDetailedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditLocationDetailed(project, viewModel);
            }
            SaveDetailedLocations(viewModel, project);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Detailed Location successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.LocationDetailed.ProjectCreateSectionDisplayName);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ImportGdbFileViewModel();
            return ViewImportGdbFile(viewModel, project.ProjectID);
        }

        private PartialViewResult ViewImportGdbFile(ImportGdbFileViewModel viewModel, int projectID)
        {
            var mapFormID = GenerateEditProjectLocationFormID(projectID);
            var newGisUploadUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ImportGdbFile(projectID, null));
            var approveGisUploadUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ApproveGisUpload(projectID, null));
            var viewData = new ImportGdbFileViewData(mapFormID, newGisUploadUrl, approveGisUploadUrl);
            return RazorPartialView<ImportGdbFile, ImportGdbFileViewData, ImportGdbFileViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey, ImportGdbFileViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewImportGdbFile(viewModel, project.ProjectID);
            }

            var httpPostedFileBase = viewModel.FileResourceData;
            var isKml = httpPostedFileBase.FileName.EndsWith(".kml");
            var fileEnding = isKml ? ".kml" : ".gdb.zip";
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var gdbOrKmlFile = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(gdbOrKmlFile.FullName);
                foreach (var projectLocationStaging in project.ProjectLocationStagings.ToList())
                {
                    projectLocationStaging.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }

                if (isKml)
                {
                    ProjectLocationStagingModelExtensions.CreateProjectLocationStagingListFromKml(gdbOrKmlFile, httpPostedFileBase.FileName, project, CurrentFirmaSession);
                }
                else
                {
                    ProjectLocationStagingModelExtensions.CreateProjectLocationStagingListFromGdb(gdbOrKmlFile, httpPostedFileBase.FileName, project, CurrentFirmaSession);
                }
                
            }
            return ApproveGisUpload(project);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ProjectLocationDetailViewModel();
            return ViewApproveGisUpload(project, viewModel);
        }

        private PartialViewResult ViewApproveGisUpload(Project project, ProjectLocationDetailViewModel viewModel)
        {
            var projectLocationStagings = project.ProjectLocationStagings.ToList();
            var layerGeoJsons =
                projectLocationStagings.Select(
                    (projectLocationStaging, i) =>
                        new LayerGeoJson(projectLocationStaging.FeatureClassName,
                            projectLocationStaging.ToGeoJsonFeatureCollection(),
                            FirmaHelpers.DefaultColorRange[i],
                            1,
                            LayerInitialVisibility.Show)).ToList();
            var showFeatureClassColumn = projectLocationStagings.Any(x => x.FeatureClassName.Length > 0);

            var boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layerGeoJsons);

            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_PreviewMap", 10, layerGeoJsons, MapInitJson.GetExternalMapLayers(), boundingBox, false) {AllowFullScreen = false, DisablePopups = true};
            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var approveGisUploadUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ApproveGisUpload(project, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagings), mapInitJson, mapFormID, approveGisUploadUrl, showFeatureClassColumn);
            return RazorPartialView<ApproveGisUpload, ApproveGisUploadViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewApproveGisUpload(project, viewModel);
            }
            SaveDetailedLocations(viewModel, project);
            var iHaveSqlGeometries = new List<IHaveSqlGeometry>(project.ProjectLocations.ToList());
            if (!iHaveSqlGeometries.Any())
            {
                SetWarningForDisplay("No valid geometries found in upload");
            }
            else
            {
                DbSpatialHelper.Reduce(iHaveSqlGeometries);
            }
            return new ModalDialogFormJsonResult();
        }

        private static void SaveDetailedLocations(ProjectLocationDetailViewModel viewModel, Project project)
        {
            var projectLocations = project.ProjectLocations.ToList();
            foreach (var projectLocation in projectLocations)
            {
                projectLocation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            if (viewModel.WktAndAnnotations != null)
            {
                foreach (var wktAndAnnotation in viewModel.WktAndAnnotations)
                {
                    project.ProjectLocations.Add(new ProjectLocation(project, DbGeometry.FromText(wktAndAnnotation.Wkt), wktAndAnnotation.Annotation));
                }
            }
        }

        public static string GenerateEditProjectLocationFormID(int projectID)
        {
            return $"editMapForProject{projectID}";
        }

        #region "GeospatialAreas"
        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult EditGeospatialArea(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            var geospatialAreaIDs = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).Select(x => x.GeospatialAreaID).ToList();
            var geospatialAreaNotes = project.ProjectGeospatialAreaTypeNotes.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID)?.Notes;
            var viewModel = new GeospatialAreaViewModel(geospatialAreaIDs, geospatialAreaNotes);
            return ViewEditGeospatialArea(project, viewModel, geospatialAreaType);
        }

        private ViewResult ViewEditGeospatialArea(Project project, GeospatialAreaViewModel viewModel, GeospatialAreaType geospatialAreaType)
        {
            var boundingBox = BoundingBox.MakeNewDefaultBoundingBox();
            var layers = MapInitJson.GetGeospatialAreaMapLayersForGeospatialAreaType(geospatialAreaType, LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(project));
            var mapInitJson = new MapInitJson("projectGeospatialAreaMap", 0, layers, MapInitJson.GetExternalMapLayers(), boundingBox) { AllowFullScreen = false, DisablePopups = true};
            var geospatialAreaIDs = viewModel.GeospatialAreaIDs ?? new List<int>();
            var geospatialAreasInViewModel = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => geospatialAreaIDs.Contains(x.GeospatialAreaID)).ToList();
            var editProjectGeospatialAreasPostUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.EditGeospatialArea(project, geospatialAreaType, null));
            var editProjectGeospatialAreasFormId = GenerateEditProjectGeospatialAreaFormID(project);
            var editSimpleLocationUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationSimple(project));

            var geospatialAreasContainingProjectSimpleLocation =
                HttpRequestStorage.DatabaseEntities.GeospatialAreas
                    .Where(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList()
                    .GetGeospatialAreasContainingProjectLocation(project).ToList();


            var editProjectLocationViewData = new EditProjectGeospatialAreasViewData(CurrentFirmaSession, mapInitJson,
                geospatialAreasInViewModel, editProjectGeospatialAreasPostUrl, editProjectGeospatialAreasFormId,
                project.HasProjectLocationPoint, project.HasProjectLocationDetail, geospatialAreaType, geospatialAreasContainingProjectSimpleLocation, editSimpleLocationUrl);

            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsGeospatialAreaSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsGeospatialAreaSectionComplete;

            var viewData = new GeospatialAreaViewData(CurrentFirmaSession, project, geospatialAreaType, proposalSectionsStatus, editProjectLocationViewData);

            return RazorView<Views.ProjectCreate.GeospatialArea, GeospatialAreaViewData, GeospatialAreaViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditGeospatialArea(ProjectPrimaryKey projectPrimaryKey, GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey, GeospatialAreaViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditGeospatialArea(project, viewModel, geospatialAreaType);
            }
            var currentProjectGeospatialAreas = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList();
            var allProjectGeospatialAreas = HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.Local;
            viewModel.UpdateModel(project, currentProjectGeospatialAreas, allProjectGeospatialAreas);
            var projectGeospatialAreaTypeNote = project.ProjectGeospatialAreaTypeNotes.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);
            if (!string.IsNullOrWhiteSpace(viewModel.ProjectGeospatialAreaNotes))
            {
                if (projectGeospatialAreaTypeNote == null)
                {
                    projectGeospatialAreaTypeNote = new ProjectGeospatialAreaTypeNote(project, geospatialAreaType, viewModel.ProjectGeospatialAreaNotes);
                }
                projectGeospatialAreaTypeNote.Notes = viewModel.ProjectGeospatialAreaNotes;
            }
            else
            {
                projectGeospatialAreaTypeNote?.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {geospatialAreaType.GeospatialAreaTypeNamePluralized} successfully saved.");
            return GoToNextSection(viewModel, project, geospatialAreaType.GeospatialAreaTypeNamePluralized);
        }

        private static string GenerateEditProjectGeospatialAreaFormID(Project project)
        {
            return $"editMapForProject{project.ProjectID}";
        }


        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult BulkSetSpatialInformation(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new BulkSetSpatialInformationViewModel(project.ProjectGeospatialAreas.Select(x => x.GeospatialAreaID).ToList());
            return ViewBulkSetSpatialInformation(project, viewModel);
        }
        
        private ViewResult ViewBulkSetSpatialInformation(Project project, BulkSetSpatialInformationViewModel viewModel)
        {
            var boundingBox = BoundingBox.MakeNewDefaultBoundingBox();
            var layers = MapInitJson.GetProjectLocationSimpleAndDetailedMapLayers(project);

            var mapInitJson = new MapInitJson("projectGeospatialAreaMap", 0, layers, MapInitJson.GetExternalMapLayers(), boundingBox) { AllowFullScreen = false, DisablePopups = true };
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList();
            var bulkSetSpatialAreaUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.BulkSetSpatialInformation(project, null));
            var editProjectGeospatialAreasFormId = GenerateEditProjectGeospatialAreaFormID(project);
            var editSimpleLocationUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationSimple(project));

            var geospatialAreasContainingProjectSimpleLocation =
                HttpRequestStorage.DatabaseEntities.GeospatialAreas.ToList().GetGeospatialAreasContainingProjectLocation(project).ToList();


            var quickSetProjectSpatialInformationViewData = new BulkSetProjectSpatialInformationViewData(CurrentFirmaSession, project, project.ProjectGeospatialAreas.Select(x => x.GeospatialArea).ToList(),
                geospatialAreaTypes, mapInitJson, bulkSetSpatialAreaUrl, editProjectGeospatialAreasFormId,
                geospatialAreasContainingProjectSimpleLocation, project.HasProjectLocationPoint,
                project.HasProjectLocationDetail, editSimpleLocationUrl);

            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsGeospatialAreaSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsGeospatialAreaSectionComplete;

            var viewData = new BulkSetSpatialInformationViewData(CurrentFirmaSession, project, proposalSectionsStatus, quickSetProjectSpatialInformationViewData);
            return RazorView<BulkSetSpatialInformation, BulkSetSpatialInformationViewData, BulkSetSpatialInformationViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult BulkSetSpatialInformation(ProjectPrimaryKey projectPrimaryKey, BulkSetSpatialInformationViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewBulkSetSpatialInformation(project, viewModel);
            }

            var currentProjectGeospatialAreas = project.ProjectGeospatialAreas.ToList();
            var allProjectGeospatialAreas = HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.Local;
            viewModel.UpdateModel(project, currentProjectGeospatialAreas, allProjectGeospatialAreas);

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Spatial Information successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.BulkSetSpatialInformation.ProjectCreateSectionDisplayName);
        }


        #endregion "GeospatialAreas"

        #region "Attachments and Notes"

        [ProjectCreateFeature]
        public ViewResult AttachmentsAndNotes(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var addNoteUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.NewNote(project));

            var canEditAttachmentsAndNotes = new ProjectCreateFeature().HasPermission(CurrentFirmaSession, project).HasPermission;
            var entityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(project.ProjectNotes), addNoteUrl, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", canEditAttachmentsAndNotes);

            var proposalSectionsStatus = GetProposalSectionsStatus(project);

            var attachmentTypes = project.GetAllAttachmentTypes().ToList();
            var projectAttachmentsDetailViewData = new ProjectAttachmentsDetailViewData(
                                                                                        EntityAttachment.CreateFromProjectAttachment(project.ProjectAttachments),
                                                                                        SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.NewAttachment(project)), project.ProjectName,
                                                                                        canEditAttachmentsAndNotes,
                                                                                        attachmentTypes,

                                                                                        CurrentFirmaSession);
            var viewData = new AttachmentsAndNotesViewData(CurrentFirmaSession, project, proposalSectionsStatus, entityNotesViewData, projectAttachmentsDetailViewData);
            return RazorView<AttachmentsAndNotes, AttachmentsAndNotesViewData>(viewData);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult NewNote(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEditNote(viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewNote(ProjectPrimaryKey projectPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            var projectNote = ProjectNote.CreateNewBlank(project);

            viewModel.UpdateModel(projectNote, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllProjectNotes.Add(projectNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectNoteManageFeature]
        public PartialViewResult EditNote(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(projectNote.Note);
            return ViewEditNote(viewModel);
        }

        [HttpPost]
        [ProjectNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditNote(ProjectNotePrimaryKey projectNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel);
            }
            var projectNote = projectNotePrimaryKey.EntityObject;

            viewModel.UpdateModel(projectNote, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditNote(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectNoteManageFeature]
        public PartialViewResult DeleteNote(ProjectNotePrimaryKey projectNotePrimaryKey)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectNote.ProjectNoteID);
            return ViewDeleteNote(projectNote, viewModel);
        }

        private PartialViewResult ViewDeleteNote(ProjectNote projectNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectNote.Project.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Proposed {FieldDefinitionEnum.ProjectNote.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteNote(ProjectNotePrimaryKey projectNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectNote = projectNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteNote(projectNote, viewModel);
            }
            projectNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }



        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult NewAttachment(ProjectPrimaryKey projectPrimaryKey)
        {

            var viewModel = new NewProjectAttachmentViewModel(projectPrimaryKey.EntityObject);
            return ViewNewAttachment(viewModel, projectPrimaryKey.EntityObject);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewAttachment(ProjectPrimaryKey projectPrimaryKey, NewProjectAttachmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewAttachment(viewModel, projectPrimaryKey.EntityObject);
            }
            var project = projectPrimaryKey.EntityObject;

            viewModel.UpdateModel(project, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectAttachmentEditAsAdminFeature]
        public PartialViewResult EditAttachment(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey)
        {
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            var viewModel = new EditProjectAttachmentsViewModel(projectAttachment);
            return ViewEditAttachment(viewModel);
        }

        [HttpPost]
        [ProjectAttachmentEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditAttachment(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey, EditProjectAttachmentsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditAttachment(viewModel);
            }
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            viewModel.UpdateModel(projectAttachment);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditAttachment(EditProjectAttachmentsViewModel viewModel)
        {
            var viewData = new EditProjectAttachmentsViewData();
            return RazorPartialView<EditProjectAttachments, EditProjectAttachmentsViewData, EditProjectAttachmentsViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewNewAttachment(NewProjectAttachmentViewModel viewModel, Project project)
        {
            IEnumerable<AttachmentType> attachmentTypes = project.GetValidAttachmentTypesForForms();

            Check.Assert(attachmentTypes != null, "Cannot find any valid attachment relationship types for this project.");
            var viewData = new NewProjectAttachmentViewData(attachmentTypes);
            return RazorPartialView<NewProjectAttachment, NewProjectAttachmentViewData, NewProjectAttachmentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectAttachmentEditAsAdminFeature]
        public PartialViewResult DeleteAttachment(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey)
        {
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectAttachment.ProjectAttachmentID);
            return ViewDeleteAttachment(projectAttachment, viewModel);
        }

        private PartialViewResult ViewDeleteAttachment(ProjectAttachment projectAttachment, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !projectAttachment.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete \"{projectAttachment.DisplayName}\" from this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Proposed {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Attachment");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectAttachmentEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteAttachment(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteAttachment(projectAttachment, viewModel);
            }
            projectAttachment.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        #endregion "Attachments and Notes"

        [ProjectCreateFeature]
        public ViewResult Photos(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;

            var viewData = BuildImageGalleryViewData(project, CurrentFirmaSession);
            return RazorView<Photos, PhotoViewData>(viewData);
        }


        private static PhotoViewData BuildImageGalleryViewData(Project project, FirmaSession currentFirmaSession)
        {
            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            var newPhotoForProjectUrl = SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.NewFromProposal(project));
            var galleryName = $"ProjectImage{project.ProjectID}";
            var projectImages = project.ProjectImages.ToList();

            var imageGalleryViewData = new PhotoViewData(currentFirmaSession, galleryName, projectImages.Select(x => new FileResourcePhoto(x)), newPhotoForProjectUrl, x => x.CaptionOnFullView, project, proposalSectionsStatus);
            return imageGalleryViewData;
        }

        [HttpGet]
        [ProjectDeleteProposalFeature]
        public PartialViewResult DeleteProjectProposal(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(projectPrimaryKey.PrimaryKeyValue);
            return ViewDeleteProject(projectPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteProject(Project project, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.GetDisplayName()}\"?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectDeleteProposalFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectProposal(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProject(project, viewModel);
            }
            var message = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.GetDisplayName()}\" successfully deleted.";
            project.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult Submit(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            //TODO: Change "reviewer" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to submit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.GetDisplayName()}\" to the reviewer?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Submit(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.PendingApproval.ProjectApprovalStatusID;
            project.SubmissionDate = DateTime.Now;
            NotificationProjectModelExtensions.SendSubmittedMessage(project);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} successfully submitted for review.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [HttpGet]
        [ProjectApproveFeature]
        public PartialViewResult Approve(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            return ViewApprove(viewModel);
        }


        [HttpPost]
        [ProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Approve(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewApprove(viewModel);
            }
            var project = projectPrimaryKey.EntityObject;
            Check.Assert(project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval,
                $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is not in Submitted state. Actual state is: " + project.ProjectApprovalStatus.ProjectApprovalStatusDisplayName);

            Check.Assert(ProposalSectionsStatus.AreAllSectionsValidForProject(project), "Proposal is not ready for submittal.");
            
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Approved.ProjectApprovalStatusID;
            project.ApprovalDate = DateTime.Now;
            project.ReviewedByPerson = CurrentPerson;

            // Business logic: An approved Proposal becomes an active project in the Planning and Design stage
            if (project.ProjectStageID == ProjectStage.Proposal.ProjectStageID)
            {
                project.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            }

            GenerateApprovalAuditLogEntries(project);
            NotificationProjectModelExtensions.SendApprovalMessage(project);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{UrlTemplate.MakeHrefString(project.GetDetailUrl(), project.GetDisplayName())}\" successfully approved.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        private void GenerateApprovalAuditLogEntries(Project project)
        {
            var auditLog = new AuditLog(CurrentPerson, DateTime.Now, AuditLogEventType.Added, "Project", project.ProjectID, "ProjectID", project.ProjectID.ToString())
            {
                ProjectID = project.ProjectID,
                AuditDescription = $"Proposal {project.GetDisplayName()} approved."
            };
            HttpRequestStorage.DatabaseEntities.AllAuditLogs.Add(auditLog);
        }

        private PartialViewResult ViewApprove(ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to approve this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult Withdraw(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            //TODO: Change "reviewer" to specific reviewer as determined by tentant review 
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to withdraw {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.GetDisplayName()}\" from review?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Withdraw(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Draft.ProjectApprovalStatusID;
            //TODO: Change "reviewer" to specific reviewer as determined by tentant review 
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} withdrawn from review.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [HttpGet]
        [ProjectApproveFeature]
        public PartialViewResult Return(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to return {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.GetDisplayName()}\" to Submitter?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Return(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Returned.ProjectApprovalStatusID;
            project.ReviewedByPerson = CurrentPerson;
            NotificationProjectModelExtensions.SendReturnedMessage(project);
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} returned to Submitter for additional clarifications/corrections.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [HttpGet]
        [ProjectApproveFeature]
        public PartialViewResult Reject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(project.ProjectID);
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to reject {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.GetDisplayName()}\"?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Reject(ProjectPrimaryKey projectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            project.ProjectApprovalStatusID = ProjectApprovalStatus.Rejected.ProjectApprovalStatusID;
            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} was rejected.");
            return new ModalDialogFormJsonResult(project.GetDetailUrl());
        }

        [ProjectViewFeature]
        public GridJsonNetJObjectResult<AuditLog> AuditLogsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var gridSpec = new AuditLogsGridSpec();
            var auditLogs = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProject(projectPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AuditLog>(auditLogs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private ActionResult GoToNextSection(FormViewModel viewModel, Project project, string currentSectionName)
        {
            var applicableWizardSections = project.GetApplicableProposalWizardSections(true);
            var currentSection = applicableWizardSections.Single(x => x.SectionDisplayName.Equals(currentSectionName, StringComparison.InvariantCultureIgnoreCase));
            var nextProjectUpdateSection = applicableWizardSections.Where(x => x.SortOrder > currentSection.SortOrder).OrderBy(x => x.SortOrder).FirstOrDefault();
            var nextSection = viewModel.AutoAdvance && nextProjectUpdateSection != null ? nextProjectUpdateSection.SectionUrl : currentSection.SectionUrl;
            return Redirect(nextSection);
        }

        private static void DeletePerformanceMeasureActuals(Project project)
        {
            foreach (var performanceMeasureActual in project.PerformanceMeasureActuals.ToList())
            {
                performanceMeasureActual.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            project.PerformanceMeasureActualYearsExemptionExplanation = null;
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult Organizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;

            var viewModel = new OrganizationsViewModel(project, CurrentFirmaSession);
            return ViewOrganizations(project, viewModel);
        }

        private ViewResult ViewOrganizations(Project project, OrganizationsViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.GetFullNameFirstLastAndOrg()).ToList();

            if (CurrentPerson != null && !allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.ToList();
            var defaultPrimaryContact = project?.GetPrimaryContact() ?? CurrentPerson.Organization.PrimaryContactPerson;
            
            var editOrganizationsViewData = new EditOrganizationsViewData(project, allOrganizations, allPeople, allRelationshipTypes, defaultPrimaryContact);

            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsProjectOrganizationsSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsProjectOrganizationsSectionComplete;

            var viewData = new OrganizationsViewData(CurrentFirmaSession, project, proposalSectionsStatus, editOrganizationsViewData);

            return RazorView<Organizations, OrganizationsViewData, OrganizationsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Organizations(ProjectPrimaryKey projectPrimaryKey, OrganizationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewOrganizations(project, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ProjectOrganizations.Load();
            var allProjectOrganizations = HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.Local;

            viewModel.UpdateModel(project, allProjectOrganizations);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()} successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Organizations.ProjectCreateSectionDisplayName);
        }

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult Contacts(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;

            var viewModel = new ContactsViewModel(project, CurrentFirmaSession);
            return ViewContacts(project, viewModel);
        }

        private ViewResult ViewContacts(Project project, ContactsViewModel viewModel)
        {
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.GetFullNameFirstLastAndOrg()).ToList();

            if (CurrentPerson != null && !allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allRelationshipTypes = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.ToList();
            //var defaultPrimaryContact = project?.GetPrimaryContact() ?? CurrentPerson.Contact.PrimaryContactPerson;

            var editContactsViewData = new EditContactsViewData(allPeople, allRelationshipTypes);

            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsProjectContactsSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsProjectContactsSectionComplete;

            var viewData = new ContactsViewData(CurrentFirmaSession, project, proposalSectionsStatus, editContactsViewData);

            return RazorView<Contacts, ContactsViewData, ContactsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Contacts(ProjectPrimaryKey projectPrimaryKey, ContactsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewContacts(project, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ProjectContacts.Load();
            var allProjectContacts = HttpRequestStorage.DatabaseEntities.AllProjectContacts.Local;

            viewModel.UpdateModel(project, allProjectContacts);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Contacts successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.Contacts.ProjectCreateSectionDisplayName);
        }



        [HttpGet]
        [ProjectCreateNewFeature]
        public ActionResult ImportExternal()
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
            if (!tenantAttribute.ProjectExternalDataSourceEnabled)
            {
                return new HttpNotFoundResult();
            }

            var viewModel = new ImportExternalViewModel();
            return ViewImportExternal(viewModel);
        }

        [HttpPost]
        [ProjectCreateNewFeature]
        public ActionResult ImportExternal(ImportExternalViewModel viewModel)
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
            if (!tenantAttribute.ProjectExternalDataSourceEnabled)
            {
                return new HttpNotFoundResult();
            }

            if (!ModelState.IsValid)
            {
                return ViewImportExternal(viewModel);
            }

            var projectExternalImportDataSimple = JsonConvert.DeserializeObject<ProjectExternalImportDataSimple>(viewModel.ProjectExternalImportRawData);
            var importExternalProjectStaging = projectExternalImportDataSimple.PopulateNewImportExternalProjectStaging();
            HttpRequestStorage.DatabaseEntities.AllImportExternalProjectStagings.Add(importExternalProjectStaging);

            // Save to materialize project and get an ID
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            return Redirect(SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(c => c.CreateBasicsFromExternalImport(importExternalProjectStaging)));
        }

        private ViewResult ViewImportExternal(ImportExternalViewModel viewModel)
        {

            var viewData = new ImportExternalViewData(CurrentFirmaSession, FirmaPageTypeEnum.ProjectCreateImportExternal.GetFirmaPage());
            return RazorView<ImportExternal, ImportExternalViewData, ImportExternalViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectCreateNewFeature]
        public ContentResult ValidateImportExternalProjectData()
        {
            return Content("Use POST.");
        }

        [HttpPost]
        [ProjectCreateNewFeature]
        public ActionResult ValidateImportExternalProjectData(ValidateImportExternalProjectDataViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }

            ProjectExternalImportDataSimple simple;
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(viewModel.RequestUri);
                webRequest.Method = "GET";

                var webResponse = (HttpWebResponse) webRequest.GetResponse();
                Check.Assert(webResponse.StatusCode == HttpStatusCode.OK,
                    $"Request to {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} External Import Data Uri {viewModel.RequestUri} should resolve 200.");

                var responseStream = webResponse.GetResponseStream();

                Check.RequireNotNull(responseStream, "Some exception");
                // ReSharper disable once AssignNullToNotNullAttribute
                var responseReader = new StreamReader(responseStream);
                var data = responseReader.ReadToEnd();

                // We need to massage because the data they gave us is lame-o
                data = Regex.Unescape(data);                // TODO remove: This should probably be resolved upstream so it's not stupid to decode this
                data = data.Trim();                         // TODO remove:
                data = data.Substring(1, data.Length - 2);  // TODO remove: Also need to strip off leading and trailing quotes

                simple = JsonConvert.DeserializeObject<ProjectExternalImportDataSimple>(data);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(400);
            }
            
            return Content(JsonConvert.SerializeObject(simple, Formatting.Indented));
        }

        #region "ProjectCustomAttributes"

        [HttpGet]
        [ProjectCreateFeature]
        public ViewResult ProjectCustomAttributes(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ProjectCustomAttributesViewModel(project);
            return ViewProjectCustomAttributes(project, viewModel);
        }

        private ViewResult ViewProjectCustomAttributes(Project project, ProjectCustomAttributesViewModel viewModel)
        {
            var customAttributesValidationResult = project.ValidateCustomAttributes();


            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Where(x => x.ProjectCustomAttributeGroup.ProjectCustomAttributeGroupProjectTypes.Any(pcagpt => pcagpt.ProjectTypeID == project.ProjectTypeID)).ToList().Where(x => x.HasEditPermission(CurrentFirmaSession));

            var editCustomAttributesViewData = new EditProjectCustomAttributesViewData(projectCustomAttributeTypes.ToList(), new List<IProjectCustomAttribute>(project.ProjectCustomAttributes.ToList())); 

            var proposalSectionsStatus = GetProposalSectionsStatus(project);
            proposalSectionsStatus.IsProjectCustomAttributesSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsProjectCustomAttributesSectionComplete;

            var viewData = new ProjectCustomAttributesViewData(CurrentFirmaSession, project, proposalSectionsStatus, editCustomAttributesViewData, customAttributesValidationResult);

            return RazorView<ProjectCustomAttributes, ProjectCustomAttributesViewData, ProjectCustomAttributesViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ProjectCustomAttributes(ProjectPrimaryKey projectPrimaryKey, ProjectCustomAttributesViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewProjectCustomAttributes(project, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ProjectCustomAttributes.Load();


            viewModel.UpdateModel(project, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Custom Attributes successfully saved.");
            return GoToNextSection(viewModel, project, ProjectCreateSection.CustomAttributes.ProjectCreateSectionDisplayName);
        }

        #endregion "ProjectCustomAttributes"

    }
}
