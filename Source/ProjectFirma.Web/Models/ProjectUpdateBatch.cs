using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.ProjectUpdate;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using WebGrease.Css.Extensions;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectUpdateBatch
    {
        public bool IsApproved
        {
            get { return ProjectUpdateState == ProjectUpdateState.Approved; }
        }

        public bool IsReturned
        {
            get { return ProjectUpdateState == ProjectUpdateState.Returned; }
        }

        public bool IsSubmitted
        {
            get { return ProjectUpdateState == ProjectUpdateState.Submitted; }
        }

        public bool IsCreated
        {
            get { return ProjectUpdateState == ProjectUpdateState.Created; }
        }

        public ProjectUpdateHistory LatestProjectUpdateHistorySubmitted
        {
            get { return ProjectUpdateHistories.GetLatestProjectUpdateHistory(ProjectUpdateState.Submitted); }
        }

        public DateTime? LatestSubmittalDate
        {
            get { return LatestProjectUpdateHistorySubmitted == null ? null : (DateTime?) LatestProjectUpdateHistorySubmitted.TransitionDate; }
        }

        public ProjectUpdateHistory LatestProjectUpdateHistoryReturned
        {
            get { return ProjectUpdateHistories.GetLatestProjectUpdateHistory(ProjectUpdateState.Returned); }
        }

        public bool IsReadyToSubmit
        {
            get { return InEditableState && IsPassingAllValidationRules; }
        }

        public bool IsReadyToApprove
        {
            get { return IsPassingAllValidationRules; }
        }

        private bool IsPassingAllValidationRules
        {
            get { return AreProjectBasicsValid && AreExpendituresValid() && AreEIPPerformanceMeasuresValid() && AreTransportationBudgetsValid() && IsProjectLocationSimpleValid(); }
        }

        public bool InEditableState
        {
            get { return IsCreated || IsReturned; }
        }

        public static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchOrCreateNew(Project project, Person currentPerson)
        {
            var projectUpdateBatch = project.GetLatestNotApprovedUpdateBatch() ?? CreateNewProjectUpdateBatchForProject(project, currentPerson);
            return projectUpdateBatch;
        }

        public static ProjectUpdateBatch GetLatestNotApprovedProjectUpdateBatchOrCreateNewAndSaveToDatabase(Project project, Person currentPerson)
        {
            var projectUpdateBatch = GetLatestNotApprovedProjectUpdateBatchOrCreateNew(project, currentPerson);
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectUpdateBatch.ProjectUpdateBatchID))
            {
                HttpRequestStorage.DetectChangesAndSave();
            }
            return projectUpdateBatch;
        }

        public static ProjectUpdateBatch CreateNewProjectUpdateBatchForProject(Project project, Person currentPerson)
        {
            var projectUpdateBatch = CreateProjectUpdateBatchAndLogTransition(project, currentPerson);

            // basics & map
            ProjectUpdate.CreateFromProject(projectUpdateBatch);

            // expenditures
            ProjectFundingSourceExpenditureUpdate.CreateFromProject(projectUpdateBatch);

            // transportation project budgets
            TransportationProjectBudgetUpdate.CreateFromProject(projectUpdateBatch);

            // performance measures
            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // project exempt reporting years
            ProjectExemptReportingYearUpdate.CreateFromProject(projectUpdateBatch);

            // project exempt reporting years reason
            projectUpdateBatch.SyncEIPPerformanceMeasureActualYearsExemptionExplanation();

            // project locations - detailed
            ProjectLocationUpdate.CreateFromProject(projectUpdateBatch);

            // photos
            ProjectImageUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.IsPhotosUpdated = false;

            // notes
            ProjectExternalLinkUpdate.CreateFromProject(projectUpdateBatch);

            // notes
            ProjectNoteUpdate.CreateFromProject(projectUpdateBatch);

            return projectUpdateBatch;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static ProjectUpdateBatch CreateProjectUpdateBatchAndLogTransition(Project project, Person currentPerson)
        {
            var projectUpdateBatch = new ProjectUpdateBatch(project, DateTime.Now, false, false, false, false, false, currentPerson, ProjectUpdateState.Created, false);

            // create a project update history record
            CreateNewTransitionRecord(projectUpdateBatch, ProjectUpdateState.Created, currentPerson, DateTime.Now);
            return projectUpdateBatch;
        }

        public void SyncEIPPerformanceMeasureActualYearsExemptionExplanation()
        {
            EIPPerformanceMeasureActualYearsExemptionExplanation = Project.EIPPerformanceMeasureActualYearsExemptionExplanation;
        }

        public void TickleLastUpdateDate(Person currentPerson)
        {
            TickleLastUpdateDate(DateTime.Now, currentPerson);
        }

        private void TickleLastUpdateDate(DateTime transitionDate, Person currentPerson)
        {
            LastUpdateDate = transitionDate;
            LastUpdatePerson = currentPerson;
        }

        private static void RefreshFromDatabase(IEnumerable projectExternalLinkUpdates)
        {
            ((IObjectContextAdapter)HttpRequestStorage.DatabaseEntities).ObjectContext.Refresh(RefreshMode.StoreWins, projectExternalLinkUpdates);
        }

        public void DeleteProjectImageUpdates()
        {
            DeleteProjectImageUpdates(ProjectImageUpdates);
            RefreshFromDatabase(ProjectImageUpdates);
        }

        public static void DeleteProjectImageUpdates(ICollection<ProjectImageUpdate> projectImageUpdates)
        {
            var projectImageFileResourceIDsToDelete = projectImageUpdates.Where(x => x.FileResourceID.HasValue).Select(x => x.FileResourceID.Value).ToList();
            var projectImageUpdateIDsToDelete = projectImageUpdates.Select(x => x.ProjectImageUpdateID).ToList();
            HttpRequestStorage.DatabaseEntities.ProjectImageUpdates.DeleteProjectImageUpdate(projectImageUpdateIDsToDelete);
            HttpRequestStorage.DatabaseEntities.FileResources.DeleteFileResource(projectImageFileResourceIDsToDelete);
        }

        public void DeleteProjectExternalLinkUpdates()
        {
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinkUpdates.DeleteProjectExternalLinkUpdate(ProjectExternalLinkUpdates);
            RefreshFromDatabase(ProjectExternalLinkUpdates);
        }

        public void DeleteProjectNoteUpdates()
        {
            HttpRequestStorage.DatabaseEntities.ProjectNoteUpdates.DeleteProjectNoteUpdate(ProjectNoteUpdates);
            RefreshFromDatabase(ProjectNoteUpdates);
        }

        public void DeleteProjectUpdateHistories()
        {
            HttpRequestStorage.DatabaseEntities.ProjectUpdateHistories.DeleteProjectUpdateHistory(ProjectUpdateHistories);
            RefreshFromDatabase(ProjectUpdateHistories);
        }

        public void DeleteProjectExemptReportingYearUpdates()
        {
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYearUpdates.DeleteProjectExemptReportingYearUpdate(ProjectExemptReportingYearUpdates);
            RefreshFromDatabase(ProjectExemptReportingYearUpdates);
        }

        public void DeleteProjectFundingSourceExpenditureUpdates()
        {
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureUpdates.DeleteProjectFundingSourceExpenditureUpdate(ProjectFundingSourceExpenditureUpdates);
            RefreshFromDatabase(ProjectFundingSourceExpenditureUpdates);
        }

        public void DeleteTransportationProjectBudgetUpdates()
        {
            HttpRequestStorage.DatabaseEntities.TransportationProjectBudgetUpdates.DeleteTransportationProjectBudgetUpdate(TransportationProjectBudgetUpdates);
            RefreshFromDatabase(TransportationProjectBudgetUpdates);
        }

        public void DeleteEIPPerformanceMeasureActualUpdates()
        {
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActualSubcategoryOptionUpdates.DeleteEIPPerformanceMeasureActualSubcategoryOptionUpdate(EIPPerformanceMeasureActualUpdates.SelectMany(x => x.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Select(y => y.EIPPerformanceMeasureActualSubcategoryOptionUpdateID)).ToList());
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActualUpdates.DeleteEIPPerformanceMeasureActualUpdate(EIPPerformanceMeasureActualUpdates);
            RefreshFromDatabase(EIPPerformanceMeasureActualUpdates);
        }

        public void DeleteProjectLocationUpdates()
        {
            HttpRequestStorage.DatabaseEntities.ProjectLocationUpdates.DeleteProjectLocationUpdate(ProjectLocationUpdates);
            RefreshFromDatabase(ProjectLocationUpdates);
        }

        public void DeleteProjectLocationStagingUpdates()
        {
            HttpRequestStorage.DatabaseEntities.ProjectLocationStagingUpdates.DeleteProjectLocationStagingUpdate(ProjectLocationStagingUpdates);
            RefreshFromDatabase(ProjectLocationStagingUpdates);
        }

        public void DeleteAll()
        {
            DeleteProjectLocationStagingUpdates();
            DeleteProjectLocationUpdates();
            DeleteEIPPerformanceMeasureActualUpdates();
            DeleteProjectExemptReportingYearUpdates();
            DeleteProjectFundingSourceExpenditureUpdates();
            DeleteTransportationProjectBudgetUpdates();
            DeleteProjectImageUpdates();
            DeleteProjectExternalLinkUpdates();
            DeleteProjectNoteUpdates();
            DeleteProjectUpdateHistories();
            DeleteProjectUpdate();
            HttpRequestStorage.DatabaseEntities.ProjectUpdateBatches.DeleteProjectUpdateBatch(ProjectUpdateBatchID);
        }

        private void DeleteProjectUpdate()
        {
            HttpRequestStorage.DatabaseEntities.ProjectUpdates.DeleteProjectUpdate(ProjectUpdate);
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static List<int> GetProjectUpdateImplementationStartToCompletionYearRange(ProjectUpdate projectUpdate)
        {
            var startYear = projectUpdate == null ? null : projectUpdate.ImplementationStartYear;
            return GetYearRangesImpl(projectUpdate, startYear);
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static List<int> GetProjectUpdatePlanningDesignStartToCompletionYearRange(ProjectUpdate projectUpdate)
        {
            var startYear = projectUpdate == null ? null : projectUpdate.PlanningDesignStartYear;
            return GetYearRangesImpl(projectUpdate, startYear);
        }

        private static List<int> GetYearRangesImpl(ProjectUpdate projectUpdate, int? startYear)
        {
            var currentYearToUse = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            if (projectUpdate != null)
            {
                if (startYear.HasValue && startYear.Value < FirmaDateUtilities.MinimumYearForReporting &&
                    (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value < FirmaDateUtilities.MinimumYearForReporting))
                {
                    // both start and completion year are before the minimum year, so no year range required
                    return new List<int>();
                }

                if (startYear.HasValue && startYear.Value > currentYearToUse && (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value > currentYearToUse))
                {
                    return new List<int>();
                }

                if (startYear.HasValue && projectUpdate.CompletionYear.HasValue && startYear.Value > projectUpdate.CompletionYear.Value)
                {
                    return new List<int>();
                }
            }
            return FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(),
                startYear,
                projectUpdate == null ? null : projectUpdate.CompletionYear,
                currentYearToUse,
                FirmaDateUtilities.MinimumYearForReporting,
                currentYearToUse);
        }

        public BasicsValidationResult ValidateProjectBasics()
        {
            return new BasicsValidationResult(ProjectUpdate);
        }

        private bool? _areProjectBasicsValid;
        public bool AreProjectBasicsValid
        {
            get
            {
                if (!_areProjectBasicsValid.HasValue)
                {
                    _areProjectBasicsValid = ValidateProjectBasics().IsValid;
                }
                return _areProjectBasicsValid.Value;
            }
            private set
            {
                _areProjectBasicsValid = value;
            }
        }

        public EIPPerformanceMeasuresValidationResult ValidateEIPPerformanceMeasuresAndForceValidation()
        {
            AreProjectBasicsValid = ValidateProjectBasics().IsValid;
            return ValidateEIPPerformanceMeasures();
        }

        public EIPPerformanceMeasuresValidationResult ValidateEIPPerformanceMeasures()
        {
            if (!AreProjectBasicsValid)
            {
                return new EIPPerformanceMeasuresValidationResult(FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection);
            }
            
            // validation 1: ensure that we have PM values from ProjectUpdate start year to min(endyear, currentyear); if the ProjectUpdate record has a stage of Planning/Design, we do not do this validation
            var missingYears = new HashSet<int>();
            if (ProjectUpdate.ProjectStage.RequiresEIPPerformanceMeasureActuals() || ProjectUpdate.ProjectStage == ProjectStage.Completed)
            {
                var exemptYears = ProjectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList();
                var yearsExpected = GetProjectUpdateImplementationStartToCompletionYearRange(ProjectUpdate).Where(x => !exemptYears.Contains(x)).ToList();
                var yearsEntered = EIPPerformanceMeasureActualUpdates.Select(x => x.CalendarYear).Distinct();
                missingYears = yearsExpected.GetMissingYears(yearsEntered);
            }
            // validation 2: incomplete PM row (missing indicatorSubcategory option id)
            var eipPerformanceMeasureActualUpdatesWithWarnings = ValidateNoIncompleteEIPPerformanceMeasureActualUpdateRow();

            var eipPerformanceMeasuresValidationResult = new EIPPerformanceMeasuresValidationResult(missingYears, eipPerformanceMeasureActualUpdatesWithWarnings);
            return eipPerformanceMeasuresValidationResult;
        }

        private HashSet<int> ValidateNoIncompleteEIPPerformanceMeasureActualUpdateRow()
        {
            var eipPerformanceMeasureActualUpdatesWithMissingSubcategoryOptions =
                EIPPerformanceMeasureActualUpdates.Where(
                    x => !x.ActualValue.HasValue || x.EIPPerformanceMeasure.IndicatorSubcategories.Count != x.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Count).ToList();
            return new HashSet<int>(eipPerformanceMeasureActualUpdatesWithMissingSubcategoryOptions.Select(x => x.EIPPerformanceMeasureActualUpdateID));
        }

        public bool AreEIPPerformanceMeasuresValid()
        {
            return ValidateEIPPerformanceMeasures().IsValid;
        }

        public ExpendituresValidationResult ValidateExpendituresAndForceValidation()
        {
            AreProjectBasicsValid = ValidateProjectBasics().IsValid;
            return ValidateExpenditures();
        }

        public ExpendituresValidationResult ValidateExpenditures()
        {
            if (!AreProjectBasicsValid)
            {
                return new ExpendituresValidationResult(FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection);
            }

            if (ProjectUpdate.ProjectStage.RequiresReportedExpenditures() || ProjectUpdate.ProjectStage == ProjectStage.Completed)
            {
                // get distinct Funding Sources
                var fundingSources = ProjectFundingSourceExpenditureUpdates.Select(x => x.FundingSource).Distinct().ToList();
                // validation 1: ensure that we have expenditure values from ProjectUpdate start year to min(endyear, currentyear)
                var yearsExpected = GetProjectUpdatePlanningDesignStartToCompletionYearRange(ProjectUpdate);
                if (!fundingSources.Any())
                {
                    // we need to at least check for the missing years
                    var expendituresValidationResult = new ExpendituresValidationResult(yearsExpected);
                    return expendituresValidationResult;
                }
                else
                {
                    var missingFundingSourceYears = new Dictionary<FundingSource, HashSet<int>>();
                    foreach (var fundingSource in fundingSources)
                    {
                        var currentFundingSource = fundingSource;
                        var missingYears =
                            yearsExpected.GetMissingYears(ProjectFundingSourceExpenditureUpdates.Where(x => x.FundingSourceID == currentFundingSource.FundingSourceID).Select(x => x.CalendarYear));
                        if (missingYears.Any())
                        {
                            missingFundingSourceYears.Add(currentFundingSource, missingYears);
                        }
                    }
                    var expendituresValidationResult = new ExpendituresValidationResult(missingFundingSourceYears);
                    return expendituresValidationResult;
                }
            }
            return new ExpendituresValidationResult(new List<int>());
        }

        public bool AreExpendituresValid()
        {
            return ValidateExpenditures().IsValid;
        }

        public TransportationBudgetsValidationResult ValidateTransportationBudgetsAndForceValidation()
        {
            AreProjectBasicsValid = ValidateProjectBasics().IsValid;
            return ValidateTransportationBudgets();
        }

        public TransportationBudgetsValidationResult ValidateTransportationBudgets()
        {
            if (!ProjectUpdate.ProjectUpdateBatch.Project.OnFederalTransportationImprovementProgramList)
            {
                return new TransportationBudgetsValidationResult(new List<int>());
            }

            if (!AreProjectBasicsValid)
            {
                return new TransportationBudgetsValidationResult(FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection);
            }

            // get distinct Funding Sources
            var fundingSources = TransportationProjectBudgetUpdates.Select(x => x.FundingSource).Distinct().ToList();
            // validation 1: ensure that we have budget values from ProjectUpdate start year to min(endyear, currentyear)
            var yearsExpected = FirmaDateUtilities.CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(new List<int>(), ProjectUpdate, FirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            if (!fundingSources.Any())
            {
                // we need to at least check for the missing years
                var budgetsValidationResult = new TransportationBudgetsValidationResult(yearsExpected);
                return budgetsValidationResult;
            }
            else
            {
                var missingFundingSourceYears = new Dictionary<FundingSource, HashSet<int>>();
                foreach (var fundingSource in fundingSources)
                {
                    var currentFundingSource = fundingSource;
                    var missingYears =
                        yearsExpected.GetMissingYears(TransportationProjectBudgetUpdates.Where(x => x.FundingSourceID == currentFundingSource.FundingSourceID).Select(x => x.CalendarYear));
                    if (missingYears.Any())
                    {
                        missingFundingSourceYears.Add(currentFundingSource, missingYears);
                    }
                }
                var budgetsValidationResult = new TransportationBudgetsValidationResult(missingFundingSourceYears);
                return budgetsValidationResult;
            }
        }

        public bool AreTransportationBudgetsValid()
        {
            return ValidateTransportationBudgets().IsValid;
        }

        public LocationSimpleValidationResult ValidateProjectLocationSimple()
        {
            return new LocationSimpleValidationResult(ProjectUpdate);
        }
        
        public bool IsProjectLocationSimpleValid()
        {
            return ValidateProjectLocationSimple().IsValid;
        }

        public void SubmitToTrpa(Person currentPerson, DateTime transitionDate)
        {
            Check.Require(IsReadyToSubmit, "You cannot submit a project update that is not ready to be submitted!");
            CreateNewTransitionRecord(this, ProjectUpdateState.Submitted, currentPerson, transitionDate);
        }

        public void Return(Person currentPerson, DateTime transitionDate)
        {
            Check.Require(IsSubmitted, "You cannot return a project update that has not been submitted!");
            CreateNewTransitionRecord(this, ProjectUpdateState.Returned, currentPerson, transitionDate);
        }

        public void Approve(Person currentPerson,
            DateTime transitionDate,
            IList<ProjectExemptReportingYear> projectExemptReportingYears,
            IList<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            IList<TransportationProjectBudget> transportationProjectBudgets,
            IList<EIPPerformanceMeasureActual> eipPerformanceMeasureActuals,
            IList<EIPPerformanceMeasureActualSubcategoryOption> eipPerformanceMeasureActualSubcategoryOptions,
            IList<ProjectExternalLink> projectExternalLinks,
            IList<ProjectNote> projectNotes,
            IList<ProjectImage> projectImages,
            IList<ProjectLocation> projectLocations)
        {
            Check.Require(IsSubmitted, "You cannot approve a project update that has not been submitted!");
            CommitChangesToProject(projectExemptReportingYears,
                projectFundingSourceExpenditures,
                transportationProjectBudgets,
                eipPerformanceMeasureActuals,
                eipPerformanceMeasureActualSubcategoryOptions,
                projectExternalLinks,
                projectNotes,
                projectImages,
                projectLocations);
            CreateNewTransitionRecord(this, ProjectUpdateState.Approved, currentPerson, transitionDate);
            PushTransitionRecordsToAuditLog();
        }

        private void PushTransitionRecordsToAuditLog()
        {
            ProjectUpdateHistories.ForEach(
                projectUpdateHistory =>
                    new AuditLog(projectUpdateHistory.UpdatePerson,
                        projectUpdateHistory.TransitionDate,
                        AuditLogEventType.Added,
                        "Project Update",
                        projectUpdateHistory.ProjectUpdateHistoryID,
                        "Project Update record",
                        projectUpdateHistory.ProjectUpdateState.ProjectUpdateStateDisplayName) {ProjectID = ProjectID});
        }

        private void CommitChangesToProject(IList<ProjectExemptReportingYear> projectExemptReportingYears,
            IList<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            IList<TransportationProjectBudget> transportationProjectBudgets,
            IList<EIPPerformanceMeasureActual> eipPerformanceMeasureActuals,
            IList<EIPPerformanceMeasureActualSubcategoryOption> eipPerformanceMeasureActualSubcategoryOptions,
            IList<ProjectExternalLink> projectExternalLinks,
            IList<ProjectNote> projectNotes,
            IList<ProjectImage> projectImages,
            IList<ProjectLocation> projectLocations)
        {
            // basics
            ProjectUpdate.CommitChangesToProject(Project);

            // expenditures
            ProjectFundingSourceExpenditureUpdate.CommitChangesToProject(this, projectFundingSourceExpenditures);

            // transportation project budgets; we only commit if they are still on FTIP list at time of approval
            if (Project.OnFederalTransportationImprovementProgramList)
            {
                TransportationProjectBudgetUpdate.CommitChangesToProject(this, transportationProjectBudgets);
            }

            // performance measures
            EIPPerformanceMeasureActualUpdate.CommitChangesToProject(this, eipPerformanceMeasureActuals, eipPerformanceMeasureActualSubcategoryOptions);

            // project exempt reporting years
            ProjectExemptReportingYearUpdate.CommitChangesToProject(this, projectExemptReportingYears);

            // project exempt reporting years reason
            Project.EIPPerformanceMeasureActualYearsExemptionExplanation = EIPPerformanceMeasureActualYearsExemptionExplanation;

            // project location simple
            ProjectUpdate.CommitSimpleLocationToProject(Project);

            // project location detailed
            ProjectLocationUpdate.CommitChangesToProject(this, projectLocations);

            // photos
            ProjectImageUpdate.CommitChangesToProject(this, projectImages);
            IsPhotosUpdated = false;

            // external links
            ProjectExternalLinkUpdate.CommitChangesToProject(this, projectExternalLinks);

            // notes
            ProjectNoteUpdate.CommitChangesToProject(this, projectNotes);
        }

        public void RejectSubmission(Person currentPerson, DateTime transitionDate)
        {
            Check.Require(IsSubmitted, "You cannot reject a batch that has not been submitted!");
            CreateNewTransitionRecord(this, ProjectUpdateState.Returned, currentPerson, transitionDate);
        }

        /// <summary>
        /// Note, the saving is done by the controller
        /// </summary>
        private static void CreateNewTransitionRecord(ProjectUpdateBatch projectUpdateBatch, ProjectUpdateState projectUpdateState, Person currentPerson, DateTime transitionDate)
        {
            var projectUpdateHistory = new ProjectUpdateHistory(projectUpdateBatch, projectUpdateState, currentPerson, transitionDate);
            HttpRequestStorage.DatabaseEntities.ProjectUpdateHistories.Add(projectUpdateHistory);
            projectUpdateBatch.ProjectUpdateStateID = projectUpdateState.ProjectUpdateStateID;
            projectUpdateBatch.TickleLastUpdateDate(transitionDate, currentPerson);
        }
    }
}