﻿using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectUpdateBatchModelExtensions
    {
        public static bool IsReadyToSubmit(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.InEditableState() && projectUpdateBatch.IsPassingAllValidationRules();

        public static bool IsReadyToApprove(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.IsPassingAllValidationRules();

        public static bool InEditableState(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.Project.IsActiveProject() && !projectUpdateBatch.IsNew() &&  (projectUpdateBatch.IsCreated() || projectUpdateBatch.IsReturned());

        public static List<ProjectExemptReportingYearUpdate> GetPerformanceMeasuresExemptReportingYears(this ProjectUpdateBatch project)
        {
            return project.ProjectExemptReportingYearUpdates
                .Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.PerformanceMeasures)
                .OrderBy(x => x.CalendarYear).ToList();
        }
        public static List<ProjectExemptReportingYearUpdate> GetExpendituresExemptReportingYears(this ProjectUpdateBatch project)
        {
            return project.ProjectExemptReportingYearUpdates
                .Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.Expenditures)
                .OrderBy(x => x.CalendarYear).ToList();
        }

        public static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchOrCreateNew(Project project, Person currentPerson)
        {
            
            ProjectUpdateBatch projectUpdateBatch;
            if (project.GetLatestNotApprovedUpdateBatch() != null)
            {
                projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch();
            }
            else
            {
                projectUpdateBatch = CreateNewProjectUpdateBatchForProject(project, currentPerson);
            }

            return projectUpdateBatch;
        }

        public static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchOrCreateNewAndSaveToDatabase(Project project, Person currentPerson)
        {
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, currentPerson);
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID))
            {
                HttpRequestStorage.DatabaseEntities.SaveChanges();
            }
            return projectUpdateBatch;
        }

        public static DateTime? GetLatestSubmittalDate(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.GetLatestProjectUpdateHistorySubmitted()?.TransitionDate;


        public static ProjectUpdateBatch CreateNewProjectUpdateBatchForProject(Project project, Person currentPerson)
        {
            var projectUpdateBatch = CreateProjectUpdateBatchAndLogTransition(project, currentPerson);

            // basics & map
            projectUpdateBatch.CreateFromProject();

            // expenditures
            ProjectFundingSourceExpenditureUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // project expenditures exempt reporting years
            ProjectExemptReportingYearUpdateModelExtensions.CreateExpendituresExemptReportingYearsFromProject(projectUpdateBatch);

            // expenditures exempt explanation
            projectUpdateBatch.SyncExpendituresYearsExemptionExplanation();

            // Expected Funding
            ProjectFundingSourceRequestUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // performance measures
            PerformanceMeasureActualUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // project performance measures exempt reporting years
            ProjectExemptReportingYearUpdateModelExtensions.CreatePerformanceMeasuresExemptReportingYearsFromProject(projectUpdateBatch);

            // project exempt reporting years reason
            projectUpdateBatch.SyncPerformanceMeasureActualYearsExemptionExplanation();

            // project locations - detailed
            ProjectLocationUpdate.CreateFromProject(projectUpdateBatch);

            // project geospatialArea
            ProjectGeospatialAreaUpdate.CreateFromProject(projectUpdateBatch);

            // photos
            ProjectImageUpdateModelExtensions.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.IsPhotosUpdated = false;

            // external links
            ProjectExternalLinkUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // notes
            ProjectNoteUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // organizations
            ProjectOrganizationUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // Documents
            ProjectDocumentUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            // Custom attributes
            ProjectCustomAttributeUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

            return projectUpdateBatch;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static ProjectUpdateBatch CreateProjectUpdateBatchAndLogTransition(Project project, Person currentPerson)
        {
            var projectUpdateBatch = new ProjectUpdateBatch(project, DateTime.Now, currentPerson, ProjectUpdateState.Created, false);

            // create a project update history record
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Created, currentPerson, DateTime.Now);
            return projectUpdateBatch;
        }

        public static void DeleteProjectImageUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var fileResources = projectUpdateBatch.ProjectImageUpdates.Select(x => x.FileResource).ToList();
            foreach (var fileResource in fileResources)
            {
                fileResource.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectExternalLinkUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectExternalLinkUpdates = projectUpdateBatch.ProjectExternalLinkUpdates.ToList();
            foreach (var projectNoteUpdate in projectExternalLinkUpdates)
            {
                projectNoteUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
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

        public static void DeleteProjectDocumentUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectDocumentUpdates = projectUpdateBatch.ProjectDocumentUpdates.ToList();
            foreach (var projectDocumentUpdate in projectDocumentUpdates)
            {
                projectDocumentUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeletePerformanceMeasuresProjectExemptReportingYearUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            foreach (var projectExemptReportingYearUpdate in projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears())
            {
                projectExemptReportingYearUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            projectUpdateBatch.NoExpendituresToReportExplanation = null;
        }

        public static void DeleteExpendituresProjectExemptReportingYearUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            foreach (var projectExemptReportingYearUpdate in projectUpdateBatch.GetExpendituresExemptReportingYears())
            {
                projectExemptReportingYearUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            projectUpdateBatch.NoExpendituresToReportExplanation = null;
        }

        public static void DeleteProjectFundingSourceExpenditureUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectFundingSourceExpenditureUpdates = projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList();
            foreach (var projectFundingSourceExpenditureUpdate in projectFundingSourceExpenditureUpdates)
            {
                projectFundingSourceExpenditureUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static void DeleteProjectFundingSourceRequestUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectFundingSourceRequestUpdates = projectUpdateBatch.ProjectFundingSourceRequestUpdates.ToList();
            foreach (var projectFundingSourceRequestUpdate in projectFundingSourceRequestUpdates)
            {
                projectFundingSourceRequestUpdate.DeleteFull(HttpRequestStorage.DatabaseEntities);
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

        public static void DeleteProjectLocationUpdates(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectLocationUpdates = projectUpdateBatch.ProjectLocationUpdates.ToList();
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

        public static BasicsValidationResult ValidateProjectBasics(this ProjectUpdateBatch projectUpdateBatch)
        {
            return new BasicsValidationResult(projectUpdateBatch.ProjectUpdate);
        }

        public static bool AreProjectBasicsValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ValidateProjectBasics().IsValid;
        }

        public static PerformanceMeasuresValidationResult ValidatePerformanceMeasures(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (!projectUpdateBatch.AreProjectBasicsValid())
            {
                return new PerformanceMeasuresValidationResult(FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection);
            }
            
            // validation 1: ensure that we have PM values from ProjectUpdate start year to min(endyear, currentyear); if the ProjectUpdate record has a stage of Planning/Design, we do not do this validation
            var missingYears = new HashSet<int>();
            if (projectUpdateBatch.ProjectUpdate.ProjectStage.RequiresPerformanceMeasureActuals() || projectUpdateBatch.ProjectUpdate.ProjectStage == ProjectStage.Completed)
            {
                var exemptYears = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();
                var yearsExpected = projectUpdateBatch.ProjectUpdate.GetProjectUpdateImplementationStartToCompletionYearRange().Where(x => !exemptYears.Contains(x)).ToList();
                var yearsEntered = projectUpdateBatch.PerformanceMeasureActualUpdates.Select(x => x.CalendarYear).Distinct();
                missingYears = yearsExpected.GetMissingYears(yearsEntered);
            }
            // validation 2: incomplete PM row (missing performanceMeasureSubcategory option id)
            var performanceMeasureActualUpdatesWithIncompleteWarnings = projectUpdateBatch.ValidateNoIncompletePerformanceMeasureActualUpdateRow();

            //validation 3: duplicate PM row
            var performanceMeasureActualUpdatesWithDuplicateWarnings = projectUpdateBatch.ValidateNoDuplicatePerformanceMeasureActualUpdateRow();

            //validation4: data entered for exempt years
            var performanceMeasureActualUpdatesWithExemptYear = projectUpdateBatch.ValidateNoExemptYearsWithReportedPerformanceMeasureRow();

            var performanceMeasuresValidationResult = new PerformanceMeasuresValidationResult(missingYears, performanceMeasureActualUpdatesWithIncompleteWarnings, performanceMeasureActualUpdatesWithDuplicateWarnings, performanceMeasureActualUpdatesWithExemptYear);
            return performanceMeasuresValidationResult;
        }

        private static HashSet<int> ValidateNoIncompletePerformanceMeasureActualUpdateRow(this ProjectUpdateBatch projectUpdateBatch)
        {
            var performanceMeasureActualUpdatesWithMissingSubcategoryOptions = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(
                x => !x.ActualValue.HasValue || x.PerformanceMeasure.PerformanceMeasureSubcategories.Count != x.PerformanceMeasureActualSubcategoryOptionUpdates.Count).ToList();
            return new HashSet<int>(performanceMeasureActualUpdatesWithMissingSubcategoryOptions.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        private static HashSet<int> ValidateNoDuplicatePerformanceMeasureActualUpdateRow(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (projectUpdateBatch.PerformanceMeasureActualUpdates == null)
            {
                return new HashSet<int>();
            }
            var duplicates = projectUpdateBatch.PerformanceMeasureActualUpdates
                .GroupBy(x => new { x.PerformanceMeasureID, x.CalendarYear })
                .Select(x => x.ToList())
                .ToList()
                .Select(x => x)
                .Where(x => x.Select(m => m.PerformanceMeasureActualSubcategoryOptionUpdates).ToList().Select(z => String.Join("_", z.Select(s => s.PerformanceMeasureSubcategoryOptionID).ToList())).ToList().HasDuplicates()).ToList();

            return new HashSet<int>(duplicates.SelectMany(x => x).ToList().Select(x => x.PerformanceMeasureActualUpdateID));
        }

        private static HashSet<int> ValidateNoExemptYearsWithReportedPerformanceMeasureRow(this ProjectUpdateBatch projectUpdateBatch)
        {
            if (projectUpdateBatch.PerformanceMeasureActualUpdates == null)
            {
                return new HashSet<int>();
            }
            var exemptYears = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();

            var performanceMeasureActualUpdatesWithExemptYear = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(x => exemptYears.Contains(x.CalendarYear)).ToList();            

            return new HashSet<int>(performanceMeasureActualUpdatesWithExemptYear.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        public static bool ArePerformanceMeasuresValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.NewStageIsPlanningDesign() || projectUpdateBatch.ValidatePerformanceMeasures().IsValid;
        }

        public static List<string> ValidateExpendituresAndForceValidation(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ValidateExpenditures();
        }

        public static ExpectedFundingValidationResult ValidateExpectedFunding(this ProjectUpdateBatch projectUpdateBatch, List<ProjectFundingSourceRequestSimple> newProjectFundingSourceRequests)
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
                var validateExpenditures = ExpendituresValidationResult.ValidateImpl(
                    projectUpdateBatch.GetExpendituresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList(), projectUpdateBatch.NoExpendituresToReportExplanation, yearsExpected, new List<IFundingSourceExpenditure>(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates));
                return validateExpenditures;
            }
            return new List<string>();
        }

        public static bool AreExpendituresValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.ValidateExpenditures().Count == 0;
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

        public static LocationSimpleValidationResult ValidateProjectLocationSimple(this ProjectUpdateBatch projectUpdateBatch)
        {           
            var incomplete = projectUpdateBatch.ProjectUpdate.ProjectLocationPoint == null &&
                             String.IsNullOrWhiteSpace(projectUpdateBatch.ProjectUpdate.ProjectLocationNotes);

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

        public static void SubmitToReviewer(this ProjectUpdateBatch projectUpdateBatch, Person currentPerson, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsReadyToSubmit(), $"You cannot submit a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that is not ready to be submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Submitted, currentPerson, transitionDate);
        }

        public static void Return(this ProjectUpdateBatch projectUpdateBatch, Person currentPerson, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsSubmitted(), $"You cannot return a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that has not been submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Returned, currentPerson, transitionDate);
        }

        public static void Approve( // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //IList<ProjectBudget> projectBudgets, 
            this ProjectUpdateBatch projectUpdateBatch, Person currentPerson, DateTime transitionDate,
            IList<ProjectExemptReportingYear> projectExemptReportingYears,
            IList<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            IList<PerformanceMeasureActual> performanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions,
            IList<ProjectExternalLink> projectExternalLinks, IList<ProjectNote> projectNotes,
            IList<ProjectImage> projectImages, IList<ProjectLocation> projectLocations,
            IList<ProjectGeospatialArea> projectGeospatialAreas, 
            IList<ProjectGeospatialAreaTypeNote> projectGeospatialAreaTypeNotes, 
            IList<ProjectFundingSourceRequest> projectFundingSourceRequests,
            IList<ProjectOrganization> allProjectOrganizations,
            IList<ProjectDocument> allProjectDocuments,
            IList<ProjectCustomAttribute> allProjectCustomAttributes,
            IList<ProjectCustomAttributeValue> allProjectCustomAttributeValues)
        {
            Check.Require(projectUpdateBatch.IsSubmitted(), $"You cannot approve a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that has not been submitted!");
            projectUpdateBatch.CommitChangesToProject(projectExemptReportingYears,
                projectFundingSourceExpenditures,
                // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//                projectBudgets,
                performanceMeasureActuals,
                performanceMeasureActualSubcategoryOptions,
                projectExternalLinks,
                projectNotes,
                projectImages,
                projectLocations,
                projectGeospatialAreas,
                projectGeospatialAreaTypeNotes,
                projectFundingSourceRequests,
                allProjectOrganizations,
                allProjectDocuments,
                allProjectCustomAttributes,
                allProjectCustomAttributeValues);
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Approved, currentPerson, transitionDate);
            projectUpdateBatch.PushTransitionRecordsToAuditLog();
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
                    projectUpdateHistory.ProjectUpdateState.ProjectUpdateStateDisplayName) {ProjectID = projectUpdateBatch.ProjectID};
            }
        }

        private static void CommitChangesToProject( 
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//            IList<ProjectBudget> projectBudgets,
            this ProjectUpdateBatch projectUpdateBatch, IList<ProjectExemptReportingYear> projectExemptReportingYears,
            IList<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            IList<PerformanceMeasureActual> performanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions,
            IList<ProjectExternalLink> projectExternalLinks, IList<ProjectNote> projectNotes,
            IList<ProjectImage> projectImages, IList<ProjectLocation> projectLocations,
            IList<ProjectGeospatialArea> projectGeospatialAreas,
            IList<ProjectGeospatialAreaTypeNote> projectGeospatialAreaTypeNotes,
            IList<ProjectFundingSourceRequest> projectFundingSourceRequests,
            IList<ProjectOrganization> allProjectOrganizations,
            IList<ProjectDocument> allProjectDocuments,
            IList<ProjectCustomAttribute> allProjectCustomAttributes,
            IList<ProjectCustomAttributeValue> allProjectCustomAttributeValues)
        {
            // basics
            projectUpdateBatch.ProjectUpdate.CommitChangesToProject(projectUpdateBatch.Project);

            // expenditures
            ProjectFundingSourceExpenditureUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, projectFundingSourceExpenditures);

            // expected funding
            ProjectFundingSourceRequestUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, projectFundingSourceRequests);

            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //  project budgets
            //ProjectBudgetUpdate.CommitChangesToProject(this, projectBudgets);

            // only relevant for stages past planning/design
            if (!projectUpdateBatch.NewStageIsPlanningDesign())
            {
                // performance measures
                PerformanceMeasureActualUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, performanceMeasureActuals,
                    performanceMeasureActualSubcategoryOptions);

                // project exempt reporting years
                ProjectExemptReportingYearUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, projectExemptReportingYears);

                // project exempt reporting years reason
                projectUpdateBatch.Project.PerformanceMeasureActualYearsExemptionExplanation = projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation;
            }

            // project location simple
            projectUpdateBatch.ProjectUpdate.CommitSimpleLocationToProject(projectUpdateBatch.Project);

            // project location detailed
            ProjectLocationUpdate.CommitChangesToProject(projectUpdateBatch, projectLocations);

            // project geospatialArea
            ProjectGeospatialAreaUpdate.CommitChangesToProject(projectUpdateBatch, projectGeospatialAreas);
            ProjectGeospatialAreaTypeNoteUpdate.CommitChangesToProject(projectUpdateBatch, projectGeospatialAreaTypeNotes);

            // photos
            ProjectImageUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, projectImages);
            projectUpdateBatch.IsPhotosUpdated = false;

            // external links
            ProjectExternalLinkUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, projectExternalLinks);

            // notes
            ProjectNoteUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, projectNotes);

            // Organizations
            ProjectOrganizationUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, allProjectOrganizations);

            // Documents
            ProjectDocumentUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, allProjectDocuments);

            // Project Custom Attributes
            ProjectCustomAttributeUpdateModelExtensions.CommitChangesToProject(projectUpdateBatch, allProjectCustomAttributes, allProjectCustomAttributeValues);
        }

        public static void RejectSubmission(this ProjectUpdateBatch projectUpdateBatch, Person currentPerson, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsSubmitted(), "You cannot reject a batch that has not been submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Returned, currentPerson, transitionDate);
        }

        /// <summary>
        /// Note, the saving is done by the controller
        /// </summary>
        private static void CreateNewTransitionRecord(this ProjectUpdateBatch projectUpdateBatch, ProjectUpdateState projectUpdateState, Person currentPerson, DateTime transitionDate)
        {
            var projectUpdateHistory = new ProjectUpdateHistory(projectUpdateBatch, projectUpdateState, currentPerson, transitionDate);
            HttpRequestStorage.DatabaseEntities.AllProjectUpdateHistories.Add(projectUpdateHistory);
            projectUpdateBatch.ProjectUpdateStateID = projectUpdateState.ProjectUpdateStateID;
            projectUpdateBatch.TickleLastUpdateDate(transitionDate, currentPerson);
        }

        public static bool AreAccomplishmentsRelevant(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectStage = projectUpdateBatch.ProjectUpdate == null ? projectUpdateBatch.Project.ProjectStage : projectUpdateBatch.ProjectUpdate.ProjectStage;
            return projectStage != ProjectStage.PlanningDesign;
        }

        public static List<ProjectSectionSimple> GetApplicableWizardSections(this ProjectUpdateBatch projectUpdateBatch, bool ignoreStatus)
        {
            return ProjectWorkflowSectionGrouping.All.SelectMany(x => x.GetProjectUpdateSections(projectUpdateBatch, null, ignoreStatus)).OrderBy(x => x.ProjectWorkflowSectionGrouping.SortOrder).ThenBy(x => x.SortOrder).ToList();
        }

        public static bool IsPassingAllValidationRules(this ProjectUpdateBatch projectUpdateBatch)
        {
            var areAllProjectGeospatialAreasValid = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList().All(geospatialAreaType => projectUpdateBatch.IsProjectGeospatialAreaValid(geospatialAreaType));
            return projectUpdateBatch.AreProjectBasicsValid() && projectUpdateBatch.AreExpendituresValid() && projectUpdateBatch.ArePerformanceMeasuresValid() && projectUpdateBatch.IsProjectLocationSimpleValid() &&
                   areAllProjectGeospatialAreasValid;
        }
    }
}