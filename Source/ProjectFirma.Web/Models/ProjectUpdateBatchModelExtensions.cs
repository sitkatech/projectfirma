﻿using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectUpdateBatchModelExtensions
    {
        public static bool IsReadyToSubmit(this ProjectUpdateBatch projectUpdateBatch)
        {
            bool inEditableState = projectUpdateBatch.InEditableState();
            bool isPassingAllValidationRules = projectUpdateBatch.IsPassingAllValidationRules();
            bool projectUpdateBatchHasAlreadyBeenSaved = ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID);

            return inEditableState && isPassingAllValidationRules && projectUpdateBatchHasAlreadyBeenSaved;
        }

        public static bool IsReadyToApprove(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.IsPassingAllValidationRules();

        public static bool InEditableState(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.Project.IsActiveProject() && !projectUpdateBatch.IsNew() &&  (projectUpdateBatch.IsCreated() || projectUpdateBatch.IsReturned());

        public static List<ProjectExemptReportingYearUpdate> GetPerformanceMeasuresExemptReportingYears(this ProjectUpdateBatch project)
        {
            return project.ProjectExemptReportingYearUpdates
                .Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.PerformanceMeasures)
                .OrderBy(x => x.CalendarYear).ToList();
        }

        public static List<ProjectRelevantCostTypeUpdate> GetExpendituresRelevantCostTypes(this ProjectUpdateBatch project)
        {
            return project.ProjectRelevantCostTypeUpdates
                .Where(x => x.ProjectRelevantCostTypeGroup == ProjectRelevantCostTypeGroup.Expenditures)
                .OrderBy(x => x.CostType.CostTypeName).ToList();
        }

        public static List<ProjectRelevantCostTypeUpdate> GetBudgetsRelevantCostTypes(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ProjectRelevantCostTypeUpdates
                .Where(x => x.ProjectRelevantCostTypeGroup == ProjectRelevantCostTypeGroup.Budgets)
                .OrderBy(x => x.CostType.CostTypeName).ToList();
        }

        public static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchOrCreateNew(Project project, FirmaSession currentFirmaSession)
        {
            ProjectUpdateBatch projectUpdateBatch;
            if (project.GetLatestNotApprovedUpdateBatch() != null)
            {
                projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            }
            else
            {
                projectUpdateBatch = CreateNewProjectUpdateBatchForProject(project, currentFirmaSession);
            }

            return projectUpdateBatch;
        }

        public static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchOrCreateNewAndSaveToDatabase(Project project, FirmaSession currentFirmaSession, ILog logger)
        {
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, currentFirmaSession);
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID))
            {
                try
                {
                    HttpRequestStorage.DatabaseEntities.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    logger.Warn(e.Message);
                }
            }
            return projectUpdateBatch;
        }

        public static DateTime? GetLatestSubmittalDate(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.GetLatestProjectUpdateHistorySubmitted()?.TransitionDate;

        public static ProjectUpdateBatch CreateNewProjectUpdateBatchForProject(Project project, FirmaSession currentFirmaSession)
        {
            Check.Require(project.ProjectUpdateBatches.All(x => x.ProjectUpdateState == ProjectUpdateState.Approved), "Cannot create a new Project Update Batch, there is already an active update for this project.");

            var projectUpdateBatch = CreateProjectUpdateBatchAndLogTransition(project, currentFirmaSession);

            // basics & map
            projectUpdateBatch.CreateFromProject();

            // expenditures
            ProjectFundingSourceExpenditureUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // project expenditures relevant cost types
            ProjectRelevantCostTypeUpdateModelExtensions.CreateExpendituresRelevantCostTypesFromProject(projectUpdateBatch);
            ProjectRelevantCostTypeUpdateModelExtensions.CreateBudgetsRelevantCostTypesFromProject(projectUpdateBatch);

            // expenditures exempt explanation
            projectUpdateBatch.SyncExpendituresYearsExemptionExplanation();

            // Expected Funding
            ProjectFundingSourceBudgetUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            ProjectNoFundingSourceIdentifiedUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // expected performance measures
            PerformanceMeasureExpectedUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // reported performance measures
            PerformanceMeasureActualUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // project performance measures exempt reporting years
            ProjectExemptReportingYearUpdateModelExtensions.CreatePerformanceMeasuresExemptReportingYearsFromProject(projectUpdateBatch);

            // project exempt reporting years reason
            projectUpdateBatch.SyncPerformanceMeasureActualYearsExemptionExplanation();

            // project locations - detailed
            ProjectLocationUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // project geospatialArea
            ProjectGeospatialAreaUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // photos
            ProjectImageUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.IsPhotosUpdated = false;

            // external links
            ProjectExternalLinkUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // notes
            ProjectNoteUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // organizations
            ProjectOrganizationUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            //Contacts
            ProjectContactUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // Attachments
            ProjectAttachmentUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // Custom attributes
            ProjectCustomAttributeUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            //Classifications
            ProjectClassificationsUpdateModelExtensions.CreateFromProject(projectUpdateBatch, HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList());

            return projectUpdateBatch;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static ProjectUpdateBatch CreateProjectUpdateBatchAndLogTransition(Project project, FirmaSession currentFirmaSession)
        {
            var projectUpdateBatch = new ProjectUpdateBatch(project, DateTime.Now, currentFirmaSession.Person, ProjectUpdateState.Created, false);

            // create a project update history record
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Created, currentFirmaSession, DateTime.Now);
            return projectUpdateBatch;
        }

        public static void DeleteProjectExternalLinkUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectExternalLinkUpdates = projectUpdateBatch.ProjectExternalLinkUpdates.ToList();
            foreach (var projectNoteUpdate in projectExternalLinkUpdates)
            {
                projectNoteUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectImageUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var fileResources = projectUpdateBatch.ProjectImageUpdates.Select(x => x.FileResourceInfo).ToList();
            foreach (var fileResourceInfo in fileResources)
            {
                fileResourceInfo.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectNoteUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectNoteUpdates = projectUpdateBatch.ProjectNoteUpdates.ToList();
            foreach (var projectNoteUpdate in projectNoteUpdates)
            {
                projectNoteUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectAttachmentUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectAttachmentUpdates = projectUpdateBatch.ProjectAttachmentUpdates.ToList();
            foreach (var projectAttachmentUpdate in projectAttachmentUpdates)
            {
                projectAttachmentUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeletePerformanceMeasuresProjectExemptReportingYearUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            foreach (var projectExemptReportingYearUpdate in projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears())
            {
                projectExemptReportingYearUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            projectUpdateBatch.ExpendituresNote = null;
        }

        public static void DeleteExpendituresProjectRelevantCostTypeUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            foreach (var projectRelevantCostTypeUpdate in projectUpdateBatch.GetExpendituresRelevantCostTypes())
            {
                projectRelevantCostTypeUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectFundingSourceExpenditureUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectFundingSourceExpenditureUpdates = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            foreach (var projectFundingSourceExpenditureUpdate in projectFundingSourceExpenditureUpdates)
            {
                projectFundingSourceExpenditureUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectFundingSourceBudgetUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList();
            foreach (var projectFundingSourceBudgetUpdate in projectFundingSourceBudgetUpdates)
            {
                projectFundingSourceBudgetUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectNoFundingSourceIdentifiedUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectNoFundingSourceIdentifiedUpdates = projectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates.ToList();
            foreach (var projectNoFundingSourceIdentifiedUpdate in projectNoFundingSourceIdentifiedUpdates)
            {
                projectNoFundingSourceIdentifiedUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeletePerformanceMeasureActualUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var performanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates.ToList();
            foreach (var performanceMeasureActualUpdate in performanceMeasureActualUpdates)
            {
                performanceMeasureActualUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeletePerformanceMeasureExpectedUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var performanceMeasureExpectedUpdates = projectUpdateBatch.PerformanceMeasureExpectedUpdates.ToList();
            foreach (var performanceMeasureExpectedUpdate in performanceMeasureExpectedUpdates)
            {
                performanceMeasureExpectedUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectLocationUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectLocationUpdates = projectUpdateBatch.ProjectUpdate.GetProjectLocationDetailedAsProjectLocationUpdate(true).ToList();
            foreach (var projectLocationUpdate in projectLocationUpdates)
            {
                projectLocationUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectLocationStagingUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectLocationStagingUpdates = projectUpdateBatch.ProjectLocationStagingUpdates.ToList();
            foreach (var projectLocationStagingUpdate in projectLocationStagingUpdates.ToList())
            {
                projectLocationStagingUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectGeospatialAreaUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectGeospatialAreaUpdates = projectUpdateBatch.ProjectGeospatialAreaUpdates.ToList();
            foreach (var projectGeospatialAreaUpdate in projectGeospatialAreaUpdates)
            {
                projectGeospatialAreaUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectOrganizationUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectOrganizationUpdates = projectUpdateBatch.ProjectOrganizationUpdates.ToList();
            foreach (var projectOrganizationUpdate in projectOrganizationUpdates)
            {
                projectOrganizationUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectClassificationUpdates(this ProjectUpdateBatch projectUpdateBatch, ClassificationSystem classificationSystem)
        {
            var projectClassificationUpdates = projectUpdateBatch.ProjectClassificationUpdates.Where(x => x.Classification.ClassificationSystemID == classificationSystem.ClassificationSystemID).ToList();
            foreach (var projectClassificationUpdate in projectClassificationUpdates)
            {
                projectClassificationUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }
        public static void DeleteProjectContactUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectContactUpdates = projectUpdateBatch.ProjectContactUpdates.ToList();
            foreach (var projectContactUpdate in projectContactUpdates)
            {
                projectContactUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectCustomAttributeUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectCustomAttributeUpdates = projectUpdateBatch.ProjectCustomAttributeUpdates.ToList();
            foreach (var projectCustomAttributeUpdate in projectCustomAttributeUpdates)
            {
                projectCustomAttributeUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static BasicsValidationResult ValidateProjectBasics(this ProjectUpdateBatch projectUpdateBatch)
        {
            return new BasicsValidationResult(projectUpdateBatch.ProjectUpdate);
        }

        public static bool AreProjectBasicsValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ValidateProjectBasics().IsValid;
        }

        public static ProjectCustomAttributesValidationResult ValidateProjectCustomAttributes(this ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession)
        {
            return new ProjectCustomAttributesValidationResult(projectUpdateBatch.ProjectUpdate, currentFirmaSession);
        }

        public static bool AreProjectCustomAttributesValid(this ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession)
        {
            return projectUpdateBatch.ValidateProjectCustomAttributes(currentFirmaSession).IsValid;
        }


        public static List<PerformanceMeasuresValidationResult> ValidatePerformanceMeasures(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (!projectUpdateBatch.AreProjectBasicsValid())
            {
                return new List<PerformanceMeasuresValidationResult> { new PerformanceMeasuresValidationResult(FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection)};
            }

            List<PerformanceMeasuresValidationResult> results = new List<PerformanceMeasuresValidationResult>();

            var performanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates ?? new List<PerformanceMeasureActualUpdate>();

            // What years are expected for this Project?
            var exemptYears = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();
            var yearsExpected = projectUpdateBatch.ProjectUpdate.GetProjectUpdateImplementationStartToCompletionYearRange().Where(x => !exemptYears.Contains(x)).ToList();

            // validation 1: ensure that at least one PM has values for each year that isn't marked as 'No accomplishments to report' from ProjectUpdate Project Implementation start year to min(endyear, currentyear)
            // if the ProjectUpdate record has a stage of Planning/Design, we do not do this validation
            var missingYears = new HashSet<int>();
            if (projectUpdateBatch.ProjectUpdate.ProjectStage.RequiresPerformanceMeasureActuals() || projectUpdateBatch.ProjectUpdate.ProjectStage == ProjectStage.Completed || projectUpdateBatch.ProjectUpdate.ProjectStage == ProjectStage.PostImplementation)
            {
                var yearsEntered = projectUpdateBatch.PerformanceMeasureActualUpdates.Select(x => x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear).Distinct();
                missingYears = yearsExpected.GetMissingYears(yearsEntered);
            }
            if (missingYears.Any() && !performanceMeasureActualUpdates.Any())
            {
                // There are missing years, but no PMs entered
                results.Add(new PerformanceMeasuresValidationResult(FirmaValidationMessages.PerformanceMeasureOrExemptYearsRequired));
            }

            // What distinct PerformanceMeasures are being worked with? 
            var pmausGrouped = performanceMeasureActualUpdates.GroupBy(pmas => pmas.PerformanceMeasureID);

            // Examine each PerformanceMeasure group as a unit to check for problems within the group
            foreach (var performanceMeasureActualUpdateGroup in pmausGrouped)
            {
                var currentPerformanceMeasureActualUpdate = performanceMeasureActualUpdateGroup.First();
                var currentPerformanceMeasureID = currentPerformanceMeasureActualUpdate.PerformanceMeasureID;

                // validation 2: incomplete PM row (missing performanceMeasureSubcategory option id)
                var performanceMeasureActualsWithIncompleteWarnings = projectUpdateBatch.ValidateNoIncompletePerformanceMeasureActualUpdateRow(currentPerformanceMeasureID);

                // validation 3: duplicate PM row
                var performanceMeasureActualsWithDuplicateWarnings = projectUpdateBatch.ValidateNoDuplicatePerformanceMeasureActualUpdateRow(currentPerformanceMeasureID);

                // validation 4: data entered for exempt years
                var performanceMeasureActualsWithExemptYear = projectUpdateBatch.ValidateNoExemptYearsWithReportedPerformanceMeasureRow(currentPerformanceMeasureID);

                string currentPerformanceMeasureDisplayName = currentPerformanceMeasureActualUpdate.PerformanceMeasure.PerformanceMeasureDisplayName;

                var performanceMeasuresValidationResult = new PerformanceMeasuresValidationResult(
                    currentPerformanceMeasureID,
                    currentPerformanceMeasureDisplayName,
                    missingYears,
                    performanceMeasureActualsWithIncompleteWarnings,
                    performanceMeasureActualsWithDuplicateWarnings,
                    performanceMeasureActualsWithExemptYear);

                results.Add(performanceMeasuresValidationResult);
            }

            return results;
        }
        
        private static HashSet<int> ValidateNoIncompletePerformanceMeasureActualUpdateRow(this ProjectUpdateBatch projectUpdateBatch, int relevantPerformanceMeasureID)
        {
            var performanceMeasureActualUpdatesWithMissingSubcategoryOptions = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(
                x => (!x.ActualValue.HasValue || x.PerformanceMeasure.PerformanceMeasureSubcategories.Count != x.PerformanceMeasureActualSubcategoryOptionUpdates.Count) 
                     && x.PerformanceMeasureID == relevantPerformanceMeasureID
            ).ToList();
            return new HashSet<int>(performanceMeasureActualUpdatesWithMissingSubcategoryOptions.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        private static HashSet<int> ValidateNoDuplicatePerformanceMeasureActualUpdateRow(this ProjectUpdateBatch projectUpdateBatch, int relevantPerformanceMeasureID)
        {
            if (projectUpdateBatch.PerformanceMeasureActualUpdates == null)
            {
                return new HashSet<int>();
            }

            var duplicates = projectUpdateBatch.PerformanceMeasureActualUpdates
                .Where(x => x.PerformanceMeasureID == relevantPerformanceMeasureID)
                .GroupBy(x => new { x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear })
                .Select(x => x.ToList())
                .ToList()
                .Select(x => x)
                .Where(x => x.Select(m => m.PerformanceMeasureActualSubcategoryOptionUpdates).ToList().Select(z => String.Join("_", z.Select(s => s.PerformanceMeasureSubcategoryOptionID).ToList())).ToList().HasDuplicates()).ToList();

            return new HashSet<int>(duplicates.SelectMany(x => x).ToList().Select(x => x.PerformanceMeasureActualUpdateID));
        }

        private static HashSet<int> ValidateNoExemptYearsWithReportedPerformanceMeasureRow(this ProjectUpdateBatch projectUpdateBatch, int relevantPerformanceMeasureID)
        {
            var performanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(pma => pma.PerformanceMeasureID == relevantPerformanceMeasureID).ToList();
            var exemptYears = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();
            var performanceMeasureActualsWithExemptYear = performanceMeasureActualUpdates.Where(x => exemptYears.Contains(x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)).ToList();
            return new HashSet<int>(performanceMeasureActualsWithExemptYear.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        public static bool AreReportedPerformanceMeasuresValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return !MultiTenantHelpers.TrackAccomplishments() || projectUpdateBatch.NewStageIsPlanningDesign() || PerformanceMeasuresValidationResult.AreAllValid(projectUpdateBatch.ValidatePerformanceMeasures());
        }

        public static List<string> ValidateExpendituresAndForceValidation(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                if (MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType == BudgetType.AnnualBudgetByCostType)
                {
                    return projectUpdateBatch.ValidateExpendituresByCostType();
                }
                return projectUpdateBatch.ValidateExpenditures();
            }
            return new List<string>();
        }

        public static ExpectedFundingValidationResult ValidateExpectedFunding(this ProjectUpdateBatch projectUpdateBatch, List<ProjectFundingSourceBudgetSimple> newProjectFundingSourceBudgets)
        {
            return new ExpectedFundingValidationResult();
        }

        public static List<string> ValidateExpenditures(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (!projectUpdateBatch.AreProjectBasicsValid())
            {
                return new List<string> {FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection};
            }

            if (projectUpdateBatch.ProjectUpdate.ProjectStage.RequiresReportedExpenditures() || projectUpdateBatch.ProjectUpdate.ProjectStage == ProjectStage.Completed)
            {
                // validation 1: ensure that we have expenditure values from ProjectUpdate start year to min(endyear, currentyear)
                var yearsExpected = projectUpdateBatch.ProjectUpdate.GetProjectUpdatePlanningDesignStartToCompletionYearRange();
                var validateExpenditures = ExpendituresValidationResult.ValidateImpl(projectUpdateBatch.ExpendituresNote, yearsExpected, new List<IFundingSourceExpenditure>(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates));
                return validateExpenditures;
            }
            return new List<string>();
        }
        public static List<string> ValidateExpendituresByCostType(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (!projectUpdateBatch.AreProjectBasicsValid())
            {
                return new List<string> {FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection};
            }

            if (projectUpdateBatch.ProjectUpdate.ProjectStage.RequiresReportedExpenditures() || projectUpdateBatch.ProjectUpdate.ProjectStage == ProjectStage.Completed)
            {
                // validation 1: ensure that we have expenditure values from ProjectUpdate start year to min(endyear, currentyear)
                var yearsExpected = projectUpdateBatch.ProjectUpdate.GetProjectUpdatePlanningDesignStartToCompletionYearRange();
                List<IFundingSourceExpenditure> projectFundingSourceExpenditures = new List<IFundingSourceExpenditure>(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates);
                var errors = new List<string>();
                // Need to get FundingSources by IDs because we may have unsaved projectFundingSourceExpenditures that won't have a reference to the entity
                var fundingSourcesIDs = projectFundingSourceExpenditures.Select(x => x.FundingSourceID).Distinct().ToList();
                var fundingSources =
                    HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => fundingSourcesIDs.Contains(x.FundingSourceID));

                if (!projectFundingSourceExpenditures.Any())
                {
                    if (string.IsNullOrWhiteSpace(projectUpdateBatch.ExpendituresNote))
                    {
                        errors.Add(FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears);
                    }
                }
                else
                {
                    if (!fundingSources.Any())
                    {
                        var yearsForErrorDisplay = string.Join(", ", FirmaHelpers.CalculateYearRanges(yearsExpected));
                        errors.Add($"Missing Expenditures for {string.Join(", ", yearsForErrorDisplay)}");
                    }
                    else
                    {
                        var missingFundingSourceYears =
                            new Dictionary<ProjectFirmaModels.Models.FundingSource, IEnumerable<int>>();
                        foreach (var fundingSource in fundingSources)
                        {
                            var currentFundingSource = fundingSource;
                            var missingYears =
                                yearsExpected
                                    .GetMissingYears(projectFundingSourceExpenditures
                                        .Where(x => x.FundingSourceID == currentFundingSource.FundingSourceID)
                                        .Select(x => x.CalendarYear)).ToList();

                            if (missingYears.Any())
                            {
                                missingFundingSourceYears.Add(currentFundingSource, missingYears);
                            }
                        }

                        foreach (var fundingSource in missingFundingSourceYears)
                        {
                            var yearsForErrorDisplay =
                                string.Join(", ", FirmaHelpers.CalculateYearRanges(fundingSource.Value));
                            errors.Add(
                                $"Missing Expenditures for {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} '{fundingSource.Key.GetDisplayName()}' for the following years: {string.Join(", ", yearsForErrorDisplay)}");
                        }
                    }
                }

                return errors;
            }
            return new List<string>();
        }

        public static bool AreExpendituresValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                if (MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType == BudgetType.AnnualBudgetByCostType)
                {
                    return projectUpdateBatch.ValidateExpendituresByCostType().Count == 0;
                }
                return projectUpdateBatch.ValidateExpenditures().Count == 0;
            }

            return true;
        }

        public static OrganizationsValidationResult ValidateOrganizations(this ProjectUpdateBatch projectUpdateBatch)
        {
            return new OrganizationsValidationResult(projectUpdateBatch.ProjectOrganizationUpdates.Select(x => new ProjectOrganizationSimple(x))
                .ToList());
        }

        public static bool AreOrganizationsValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ValidateOrganizations().IsValid;
        }

        public static bool AreContactsValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ValidateContacts().IsValid;
        }

        public static ContactsValidationResult ValidateContacts(this ProjectUpdateBatch projectUpdateBatch)
        {
            return new ContactsValidationResult(projectUpdateBatch.Project, projectUpdateBatch.ProjectContactUpdates.Select(x => new ProjectContactSimple(x))
                .ToList());
        }

        public static ClassificationsValidationResult ValidateClassifications(this ProjectUpdateBatch projectUpdateBatch, int classificationSystemID)
        {
            var projectClassificationSimples = ProjectUpdateController.GetProjectClassificationSimples(projectUpdateBatch, classificationSystemID);
            var classificationLabel = FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel();
            var classificationSystemsLabel = FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel();
            return new ClassificationsValidationResult(projectClassificationSimples, classificationLabel, classificationSystemsLabel, classificationSystemID);
        }

        public static LocationSimpleValidationResult ValidateProjectLocationSimple(this ProjectUpdateBatch projectUpdateBatch)
        {           
            var incomplete = !projectUpdateBatch.ProjectUpdate.HasProjectLocationPoint(true) &&
                             string.IsNullOrWhiteSpace(projectUpdateBatch.ProjectUpdate.ProjectLocationNotes);

            var locationSimpleValidationResult = new LocationSimpleValidationResult(incomplete);

            return locationSimpleValidationResult;
        }

        public static bool IsProjectLocationSimpleValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ValidateProjectLocationSimple().IsValid;
        }

        public static GeospatialAreaValidationResult ValidateProjectGeospatialArea(this ProjectUpdateBatch projectUpdateBatch, GeospatialAreaType geospatialAreaType)
        {
            var projectGeospatialAreaTypeNoteUpdate = projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);
            var incomplete = projectUpdateBatch.ProjectGeospatialAreaUpdates.All(x => x.GeospatialArea.GeospatialAreaTypeID != geospatialAreaType.GeospatialAreaTypeID) && projectGeospatialAreaTypeNoteUpdate == null;
            var geospatialAreaValidationResult = new GeospatialAreaValidationResult(incomplete, geospatialAreaType);
            return geospatialAreaValidationResult;
        }

        public static bool IsProjectGeospatialAreaValid(this ProjectUpdateBatch projectUpdateBatch, GeospatialAreaType geospatialAreaType)
        {
            return projectUpdateBatch.ValidateProjectGeospatialArea(geospatialAreaType).IsValid;
        }

        public static void SubmitToReviewer(this ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsReadyToSubmit(), $"You cannot submit a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that is not ready to be submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Submitted, currentFirmaSession, transitionDate);
        }

        public static void Return(this ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsSubmitted(), $"You cannot return a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that has not been submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Returned, currentFirmaSession, transitionDate);
        }

        public static void Approve(this ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession, DateTime transitionDate, DatabaseEntities databaseEntities)
        {
            Check.Require(projectUpdateBatch.IsSubmitted(), $"You cannot approve a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that has not been submitted!");
            projectUpdateBatch.CommitChangesToProject(databaseEntities);
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Approved, currentFirmaSession, transitionDate);
            projectUpdateBatch.PushTransitionRecordsToAuditLog();
        }

        private static void CommitChangesToProject(this ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            // basics
            projectUpdateBatch.ProjectUpdate.CommitBasicsChangesToProject(projectUpdateBatch.Project);

            // expenditures
            ProjectFundingSourceExpenditureUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // expected funding
            ProjectFundingSourceBudgetUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            ProjectNoFundingSourceIdentifiedUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // project exempt reporting years
            ProjectExemptReportingYearUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);
            projectUpdateBatch.Project.ExpendituresNote = projectUpdateBatch.ExpendituresNote;

            // project relevant cost types
            ProjectRelevantCostTypeUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // only relevant for stages past planning/design
            if (!projectUpdateBatch.NewStageIsPlanningDesign())
            {
                // reported performance measures
                PerformanceMeasureActualUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

                // project exempt reporting years reason
                projectUpdateBatch.Project.PerformanceMeasureActualYearsExemptionExplanation = projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation;
            }

            // expected performance measures
            PerformanceMeasureExpectedUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);


            // project location simple
            projectUpdateBatch.ProjectUpdate.CommitSimpleLocationToProject(projectUpdateBatch.Project);

            // project location detailed
            ProjectLocationUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // project geospatialArea
            ProjectGeospatialAreaUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);
            ProjectGeospatialAreaTypeNoteUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // photos
            ProjectImageUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities); 

            // external links
            ProjectExternalLinkUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // notes
            ProjectNoteUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // Organizations
            ProjectOrganizationUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            //  Contacts
            ProjectContactUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // Attachments
            ProjectAttachmentUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            // Project Custom Attributes
            ProjectCustomAttributeUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

            //Project Classifications
            ProjectClassificationsUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, databaseEntities);

        }

        private static void PushTransitionRecordsToAuditLog(this ProjectUpdateBatch projectUpdateBatch)
        {
            foreach (var projectUpdateHistory in projectUpdateBatch.ProjectUpdateHistories.ToList())
            {
                var auditLog = new AuditLog(projectUpdateHistory.UpdatePerson,
                    projectUpdateHistory.TransitionDate,
                    AuditLogEventType.Added,
                    $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update",
                    projectUpdateHistory.ProjectUpdateHistoryID,
                    $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update record",
                    projectUpdateHistory.ProjectUpdateState.ProjectUpdateStateDisplayName
                    , true) {ProjectID = projectUpdateBatch.ProjectID};
                HttpRequestStorage.DatabaseEntities.AllAuditLogs.Add(auditLog);
            }
        }

        public static void RejectSubmission(this ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsSubmitted(), "You cannot reject a batch that has not been submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Returned, currentFirmaSession, transitionDate);
        }

        /// <summary>
        /// Note, the saving is done by the controller
        /// </summary>
        private static void CreateNewTransitionRecord(this ProjectUpdateBatch projectUpdateBatch, ProjectUpdateState projectUpdateState, FirmaSession currentFirmaSession, DateTime transitionDate)
        {
            var currentPerson = currentFirmaSession.Person;
            var projectUpdateHistory = new ProjectUpdateHistory(projectUpdateBatch, projectUpdateState, currentPerson, transitionDate);
            HttpRequestStorage.DatabaseEntities.AllProjectUpdateHistories.Add(projectUpdateHistory);
            projectUpdateBatch.ProjectUpdateStateID = projectUpdateState.ProjectUpdateStateID;
            projectUpdateBatch.TickleLastUpdateDate(transitionDate, currentFirmaSession);
        }

        public static bool AreAccomplishmentsRelevant(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectStage = projectUpdateBatch.ProjectUpdate == null ? projectUpdateBatch.Project.ProjectStage : projectUpdateBatch.ProjectUpdate.ProjectStage;
            return projectStage != ProjectStage.PlanningDesign;
        }

        public static List<ProjectSectionSimple> GetApplicableWizardSections(this ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession, bool ignoreStatus, bool hasEditableCustomAttributes)
        {
            var projectWorkflowSectionGroupings = ProjectWorkflowSectionGrouping.All;
            if (!MultiTenantHelpers.TrackAccomplishments())
            {
                projectWorkflowSectionGroupings = projectWorkflowSectionGroupings.Where(x => x != ProjectWorkflowSectionGrouping.Accomplishments).ToList();
            }
            if (!MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                projectWorkflowSectionGroupings = projectWorkflowSectionGroupings.Where(x => x != ProjectWorkflowSectionGrouping.Financials).ToList();
            }
            return projectWorkflowSectionGroupings.SelectMany(x => x.GetProjectUpdateSections(currentFirmaSession, projectUpdateBatch, null, ignoreStatus, hasEditableCustomAttributes)).OrderBy(x => x.ProjectWorkflowSectionGrouping.SortOrder).ThenBy(x => x.SortOrder).ToList();
        }

        public static bool IsPassingAllValidationRules(this ProjectUpdateBatch projectUpdateBatch)
        {
            bool areAllProjectGeospatialAreasValid = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList().All(geospatialAreaType => projectUpdateBatch.IsProjectGeospatialAreaValid(geospatialAreaType));

            return projectUpdateBatch.AreProjectBasicsValid() &&
                   projectUpdateBatch.AreContactsValid() &&
                   projectUpdateBatch.AreExpendituresValid() &&
                   projectUpdateBatch.AreReportedPerformanceMeasuresValid() &&
                   projectUpdateBatch.IsProjectLocationSimpleValid() &&
                   projectUpdateBatch.AreProjectCustomAttributesValid(HttpRequestStorage.FirmaSession) &&
                   areAllProjectGeospatialAreasValid;
        }

        public static IEnumerable<AttachmentType> GetValidAttachmentTypesForForms(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.GetAllAttachmentTypes().Where(x => !x.NumberOfAllowedAttachments.HasValue || (x.ProjectAttachmentUpdates.Where(pau => pau.ProjectUpdateBatchID == projectUpdateBatch.ProjectUpdateBatchID).ToList().Count < x.NumberOfAllowedAttachments));
        }

        public static IEnumerable<AttachmentType> GetAllAttachmentTypes(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.Project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.AttachmentTypeTaxonomyTrunks.Select(x => x.AttachmentType);
        }


        public static List<PerformanceMeasureReportedValue> GetPerformanceMeasureReportedValues(this ProjectUpdateBatch projectUpdateBatch)
        {
            var reportedPerformanceMeasures = projectUpdateBatch.GetNonVirtualPerformanceMeasureReportedValues();
            return reportedPerformanceMeasures.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }

        public static List<PerformanceMeasureReportedValue> GetNonVirtualPerformanceMeasureReportedValues(this ProjectUpdateBatch projectUpdateBatch)
        {
            var performanceMeasureReportedValues = projectUpdateBatch.PerformanceMeasureActualUpdates.Select(x => x.PerformanceMeasure)
                .Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
                .SelectMany(x => x.GetReportedPerformanceMeasureValues(projectUpdateBatch)).ToList();
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }
    }
}