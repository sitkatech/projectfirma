using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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

        public static bool InEditableState(this ProjectUpdateBatch projectUpdateBatch) => projectUpdateBatch.Project.IsActiveProject() && (projectUpdateBatch.IsCreated() || projectUpdateBatch.IsReturned());

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
            if (ProjectModelExtensions.GetLatestNotApprovedUpdateBatch(project) != null)
            {
                projectUpdateBatch = ProjectModelExtensions.GetLatestNotApprovedUpdateBatch(project);
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

        public static ProjectUpdateBatch CreateNewProjectUpdateBatchForProject(Project project, Person currentPerson)
        {
            var projectUpdateBatch = CreateProjectUpdateBatchAndLogTransition(project, currentPerson);

            // basics & map
            ProjectUpdateModelExtensions.CreateFromProject(projectUpdateBatch);

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

        private static void RefreshFromDatabase(IEnumerable updates)
        {
            ((IObjectContextAdapter)HttpRequestStorage.DatabaseEntities).ObjectContext.Refresh(RefreshMode.StoreWins, updates);
        }

        public static void DeleteProjectImageUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            DeleteProjectImageUpdates(projectUpdateBatch.ProjectImageUpdates);
            RefreshFromDatabase(projectUpdateBatch.ProjectImageUpdates);
        }

        public static void DeleteProjectImageUpdates(ICollection<ProjectImageUpdate> projectImageUpdates)
        {
            var projectImageFileResourceIDsToDelete = projectImageUpdates.Where(x => x.FileResourceID.HasValue).Select(x => x.FileResourceID.Value).ToList();
            projectImageUpdates.DeleteProjectImageUpdate();
            projectImageFileResourceIDsToDelete.DeleteFileResource();
        }

        public static void DeleteProjectExternalLinkUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectExternalLinkUpdates.DeleteProjectExternalLinkUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectExternalLinkUpdates);
        }

        public static void DeleteProjectNoteUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectNoteUpdates.DeleteProjectNoteUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectNoteUpdates);
        }

        public static void DeleteProjectDocumentUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectDocumentUpdates.DeleteProjectDocumentUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectDocumentUpdates);
        }

        public static void DeleteProjectUpdateHistories(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectUpdateHistories.DeleteProjectUpdateHistory();
            RefreshFromDatabase(projectUpdateBatch.ProjectUpdateHistories);
        }

        public static void DeletePerformanceMeasuresProjectExemptReportingYearUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            var performanceMeasuresExemptReportingYears = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears();
            performanceMeasuresExemptReportingYears.DeleteProjectExemptReportingYearUpdate();
            projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation = null;
            RefreshFromDatabase(performanceMeasuresExemptReportingYears);
        }

        public static void DeleteExpendituresProjectExemptReportingYearUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            var performanceMeasuresExemptReportingYears = projectUpdateBatch.GetExpendituresExemptReportingYears();
            performanceMeasuresExemptReportingYears.DeleteProjectExemptReportingYearUpdate();
            projectUpdateBatch.NoExpendituresToReportExplanation = null;
            RefreshFromDatabase(performanceMeasuresExemptReportingYears);
        }

        public static void DeleteProjectFundingSourceExpenditureUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.DeleteProjectFundingSourceExpenditureUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates);
        }

        public static void DeleteProjectFundingSourceRequestUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectFundingSourceRequestUpdates.DeleteProjectFundingSourceRequestUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectFundingSourceRequestUpdates);
        }

        public static void DeleteProjectBudgetUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //projectUpdateBatch.ProjectBudgetUpdates.DeleteProjectBudgetUpdate();
            //RefreshFromDatabase(projectUpdateBatch.ProjectBudgetUpdates);
        }

        public static void DeletePerformanceMeasureActualUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.PerformanceMeasureActualUpdates.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates.Select(y => y.PerformanceMeasureActualSubcategoryOptionUpdateID)).ToList().DeletePerformanceMeasureActualSubcategoryOptionUpdate();
            projectUpdateBatch.PerformanceMeasureActualUpdates.DeletePerformanceMeasureActualUpdate();
            RefreshFromDatabase(projectUpdateBatch.PerformanceMeasureActualUpdates);
        }

        public static void DeleteProjectLocationUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectLocationUpdates.DeleteProjectLocationUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectLocationUpdates);
        }

        public static void DeleteProjectLocationStagingUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectLocationStagingUpdates.DeleteProjectLocationStagingUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectLocationStagingUpdates);
        }

        public static void DeleteProjectGeospatialAreaUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectGeospatialAreaUpdates.DeleteProjectGeospatialAreaUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectGeospatialAreaUpdates);
        }

        public static void DeleteProjectOrganizationUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectOrganizationUpdates.DeleteProjectOrganizationUpdate();
            RefreshFromDatabase(projectUpdateBatch.ProjectOrganizationUpdates);
        }

        public static void DeleteAll(ProjectUpdateBatch projectUpdateBatch)
        {
            DeleteProjectLocationStagingUpdates(projectUpdateBatch);
            DeleteProjectLocationUpdates(projectUpdateBatch);
            DeletePerformanceMeasureActualUpdates(projectUpdateBatch);
            DeletePerformanceMeasuresProjectExemptReportingYearUpdates(projectUpdateBatch);
            DeleteProjectFundingSourceExpenditureUpdates(projectUpdateBatch);
            DeleteProjectFundingSourceRequestUpdates(projectUpdateBatch);
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//            DeleteProjectBudgetUpdates();
            DeleteProjectImageUpdates(projectUpdateBatch);
            DeleteProjectExternalLinkUpdates(projectUpdateBatch);
            DeleteProjectNoteUpdates(projectUpdateBatch);
            DeleteProjectUpdateHistories(projectUpdateBatch);
            DeleteProjectUpdate(projectUpdateBatch);
            DeleteProjectGeospatialAreaUpdates(projectUpdateBatch);
            DeleteProjectOrganizationUpdates(projectUpdateBatch);
            DeleteProjectDocumentUpdates(projectUpdateBatch);
            projectUpdateBatch.DeleteProjectUpdateBatch();
        }

        private static void DeleteProjectUpdate(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectUpdate.DeleteProjectUpdate();
        }

        public static BasicsValidationResult ValidateProjectBasics(ProjectUpdateBatch projectUpdateBatch)
        {
            return new BasicsValidationResult(projectUpdateBatch.ProjectUpdate);
        }

        public static bool AreProjectBasicsValid(this ProjectUpdateBatch projectUpdateBatch)
        {
            return ValidateProjectBasics(projectUpdateBatch).IsValid;
        }

        public static PerformanceMeasuresValidationResult ValidatePerformanceMeasures(ProjectUpdateBatch projectUpdateBatch)
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
            var performanceMeasureActualUpdatesWithIncompleteWarnings = ValidateNoIncompletePerformanceMeasureActualUpdateRow(projectUpdateBatch);

            //validation 3: duplicate PM row
            var performanceMeasureActualUpdatesWithDuplicateWarnings = ValidateNoDuplicatePerformanceMeasureActualUpdateRow(projectUpdateBatch);

            //validation4: data entered for exempt years
            var performanceMeasureActualUpdatesWithExemptYear = ValidateNoExemptYearsWithReportedPerformanceMeasureRow(projectUpdateBatch);

            var performanceMeasuresValidationResult = new PerformanceMeasuresValidationResult(missingYears, performanceMeasureActualUpdatesWithIncompleteWarnings, performanceMeasureActualUpdatesWithDuplicateWarnings, performanceMeasureActualUpdatesWithExemptYear);
            return performanceMeasuresValidationResult;
        }

        private static HashSet<int> ValidateNoIncompletePerformanceMeasureActualUpdateRow(ProjectUpdateBatch projectUpdateBatch)
        {
            var performanceMeasureActualUpdatesWithMissingSubcategoryOptions = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(
                x => !x.ActualValue.HasValue || x.PerformanceMeasure.PerformanceMeasureSubcategories.Count != x.PerformanceMeasureActualSubcategoryOptionUpdates.Count).ToList();
            return new HashSet<int>(performanceMeasureActualUpdatesWithMissingSubcategoryOptions.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        private static HashSet<int> ValidateNoDuplicatePerformanceMeasureActualUpdateRow(ProjectUpdateBatch projectUpdateBatch)
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

        private static HashSet<int> ValidateNoExemptYearsWithReportedPerformanceMeasureRow(ProjectUpdateBatch projectUpdateBatch)
        {
            if (projectUpdateBatch.PerformanceMeasureActualUpdates == null)
            {
                return new HashSet<int>();
            }
            var exemptYears = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();

            var performanceMeasureActualUpdatesWithExemptYear = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(x => exemptYears.Contains(x.CalendarYear)).ToList();            

            return new HashSet<int>(performanceMeasureActualUpdatesWithExemptYear.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        public static bool ArePerformanceMeasuresValid(ProjectUpdateBatch projectUpdateBatch)
        {
            return projectUpdateBatch.NewStageIsPlanningDesign() || ValidatePerformanceMeasures(projectUpdateBatch).IsValid;
        }

        public static List<string> ValidateExpendituresAndForceValidation(ProjectUpdateBatch projectUpdateBatch)
        {
            return ValidateExpenditures(projectUpdateBatch);
        }

        public static ExpectedFundingValidationResult ValidateExpectedFunding(ProjectUpdateBatch projectUpdateBatch, List<ProjectFundingSourceRequestSimple> newProjectFundingSourceRequests)
        {
            return new ExpectedFundingValidationResult();
        }

        public static List<string> ValidateExpenditures(ProjectUpdateBatch projectUpdateBatch)
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

        public static bool AreExpendituresValid(ProjectUpdateBatch projectUpdateBatch)
        {
            return ValidateExpenditures(projectUpdateBatch).Count == 0;
        }

        public static OrganizationsValidationResult ValidateOrganizations(ProjectUpdateBatch projectUpdateBatch)
        {
            return new OrganizationsValidationResult(projectUpdateBatch.ProjectOrganizationUpdates.Select(x => new ProjectOrganizationSimple(x))
                .ToList());
        }

        public static bool AreOrganizationsValid(ProjectUpdateBatch projectUpdateBatch)
        {
            return ValidateOrganizations(projectUpdateBatch).IsValid;
        }

        public static LocationSimpleValidationResult ValidateProjectLocationSimple(ProjectUpdateBatch projectUpdateBatch)
        {           
            var incomplete = projectUpdateBatch.ProjectUpdate.ProjectLocationPoint == null &&
                             String.IsNullOrWhiteSpace(projectUpdateBatch.ProjectUpdate.ProjectLocationNotes);

            var locationSimpleValidationResult = new LocationSimpleValidationResult(incomplete);

            return locationSimpleValidationResult;
        }

        public static bool IsProjectLocationSimpleValid(ProjectUpdateBatch projectUpdateBatch)
        {
            return ValidateProjectLocationSimple(projectUpdateBatch).IsValid;
        }

        public static GeospatialAreaValidationResult ValidateProjectGeospatialArea(ProjectUpdateBatch projectUpdateBatch, GeospatialAreaType geospatialAreaType)
        {
            var projectGeospatialAreaTypeNoteUpdate = projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);
            var incomplete = projectUpdateBatch.ProjectGeospatialAreaUpdates.All(x => x.GeospatialArea.GeospatialAreaTypeID != geospatialAreaType.GeospatialAreaTypeID) && projectGeospatialAreaTypeNoteUpdate == null;
            var geospatialAreaValidationResult = new GeospatialAreaValidationResult(incomplete, geospatialAreaType);
            return geospatialAreaValidationResult;
        }

        public static bool IsProjectGeospatialAreaValid(ProjectUpdateBatch projectUpdateBatch, GeospatialAreaType geospatialAreaType)
        {
            return ValidateProjectGeospatialArea(projectUpdateBatch, geospatialAreaType).IsValid;
        }

        public static void SubmitToReviewer(ProjectUpdateBatch projectUpdateBatch, Person currentPerson, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsReadyToSubmit(), $"You cannot submit a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that is not ready to be submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Submitted, currentPerson, transitionDate);
        }

        public static void Return(ProjectUpdateBatch projectUpdateBatch, Person currentPerson, DateTime transitionDate)
        {
            Check.Require(projectUpdateBatch.IsSubmitted(), $"You cannot return a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update that has not been submitted!");
            projectUpdateBatch.CreateNewTransitionRecord(ProjectUpdateState.Returned, currentPerson, transitionDate);
        }

        public static void Approve( // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //IList<ProjectBudget> projectBudgets, 
            ProjectUpdateBatch projectUpdateBatch, Person currentPerson, DateTime transitionDate,
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
            var areAllProjectGeospatialAreasValid = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList().All(geospatialAreaType => IsProjectGeospatialAreaValid(projectUpdateBatch, geospatialAreaType));
            return projectUpdateBatch.AreProjectBasicsValid() && AreExpendituresValid(projectUpdateBatch) && ArePerformanceMeasuresValid(projectUpdateBatch) && IsProjectLocationSimpleValid(projectUpdateBatch) &&
                   areAllProjectGeospatialAreasValid;
        }
    }
}