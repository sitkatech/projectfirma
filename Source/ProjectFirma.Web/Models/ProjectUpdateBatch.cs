/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateBatch.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
            //Budget section used to be required for Transportation projects. Now that we have no notion of transportation project, make budget never required until we decide on rules.
            get { return AreProjectBasicsValid && AreExpendituresValid() && ArePerformanceMeasuresValid() && IsProjectLocationSimpleValid(); }
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
                HttpRequestStorage.DatabaseEntities.SaveChanges();
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

            //  project budgets
            ProjectBudgetUpdate.CreateFromProject(projectUpdateBatch);

            // performance measures
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // project exempt reporting years
            ProjectExemptReportingYearUpdate.CreateFromProject(projectUpdateBatch);

            // project exempt reporting years reason
            projectUpdateBatch.SyncPerformanceMeasureActualYearsExemptionExplanation();

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

        public void SyncPerformanceMeasureActualYearsExemptionExplanation()
        {
            PerformanceMeasureActualYearsExemptionExplanation = Project.PerformanceMeasureActualYearsExemptionExplanation;
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
            projectImageUpdates.DeleteProjectImageUpdate();
            projectImageFileResourceIDsToDelete.DeleteFileResource();
        }

        public void DeleteProjectExternalLinkUpdates()
        {
            ProjectExternalLinkUpdates.DeleteProjectExternalLinkUpdate();
            RefreshFromDatabase(ProjectExternalLinkUpdates);
        }

        public void DeleteProjectNoteUpdates()
        {
            ProjectNoteUpdates.DeleteProjectNoteUpdate();
            RefreshFromDatabase(ProjectNoteUpdates);
        }

        public void DeleteProjectUpdateHistories()
        {
            ProjectUpdateHistories.DeleteProjectUpdateHistory();
            RefreshFromDatabase(ProjectUpdateHistories);
        }

        public void DeleteProjectExemptReportingYearUpdates()
        {
            ProjectExemptReportingYearUpdates.DeleteProjectExemptReportingYearUpdate();
            RefreshFromDatabase(ProjectExemptReportingYearUpdates);
        }

        public void DeleteProjectFundingSourceExpenditureUpdates()
        {
            ProjectFundingSourceExpenditureUpdates.DeleteProjectFundingSourceExpenditureUpdate();
            RefreshFromDatabase(ProjectFundingSourceExpenditureUpdates);
        }

        public void DeleteProjectBudgetUpdates()
        {
            ProjectBudgetUpdates.DeleteProjectBudgetUpdate();
            RefreshFromDatabase(ProjectBudgetUpdates);
        }

        public void DeletePerformanceMeasureActualUpdates()
        {
            PerformanceMeasureActualUpdates.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates.Select(y => y.PerformanceMeasureActualSubcategoryOptionUpdateID)).ToList().DeletePerformanceMeasureActualSubcategoryOptionUpdate();
            PerformanceMeasureActualUpdates.DeletePerformanceMeasureActualUpdate();
            RefreshFromDatabase(PerformanceMeasureActualUpdates);
        }

        public void DeleteProjectLocationUpdates()
        {
            ProjectLocationUpdates.DeleteProjectLocationUpdate();
            RefreshFromDatabase(ProjectLocationUpdates);
        }

        public void DeleteProjectLocationStagingUpdates()
        {
            ProjectLocationStagingUpdates.DeleteProjectLocationStagingUpdate();
            RefreshFromDatabase(ProjectLocationStagingUpdates);
        }

        public void DeleteAll()
        {
            DeleteProjectLocationStagingUpdates();
            DeleteProjectLocationUpdates();
            DeletePerformanceMeasureActualUpdates();
            DeleteProjectExemptReportingYearUpdates();
            DeleteProjectFundingSourceExpenditureUpdates();
            DeleteProjectBudgetUpdates();
            DeleteProjectImageUpdates();
            DeleteProjectExternalLinkUpdates();
            DeleteProjectNoteUpdates();
            DeleteProjectUpdateHistories();
            DeleteProjectUpdate();
            this.DeleteProjectUpdateBatch();
        }

        private void DeleteProjectUpdate()
        {
            ProjectUpdate.DeleteProjectUpdate();
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
                if (startYear.HasValue && startYear.Value < FirmaDateUtilities.MinimumYear &&
                    (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value < FirmaDateUtilities.MinimumYear))
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
                FirmaDateUtilities.MinimumYear,
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

        public PerformanceMeasuresValidationResult ValidatePerformanceMeasuresAndForceValidation()
        {
            AreProjectBasicsValid = ValidateProjectBasics().IsValid;
            return ValidatePerformanceMeasures();
        }

        public PerformanceMeasuresValidationResult ValidatePerformanceMeasures()
        {
            if (!AreProjectBasicsValid)
            {
                return new PerformanceMeasuresValidationResult(FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection);
            }
            
            // validation 1: ensure that we have PM values from ProjectUpdate start year to min(endyear, currentyear); if the ProjectUpdate record has a stage of Planning/Design, we do not do this validation
            var missingYears = new HashSet<int>();
            if (ProjectUpdate.ProjectStage.RequiresPerformanceMeasureActuals() || ProjectUpdate.ProjectStage == ProjectStage.Completed)
            {
                var exemptYears = ProjectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList();
                var yearsExpected = GetProjectUpdateImplementationStartToCompletionYearRange(ProjectUpdate).Where(x => !exemptYears.Contains(x)).ToList();
                var yearsEntered = PerformanceMeasureActualUpdates.Select(x => x.CalendarYear).Distinct();
                missingYears = yearsExpected.GetMissingYears(yearsEntered);
            }
            // validation 2: incomplete PM row (missing performanceMeasureSubcategory option id)
            var performanceMeasureActualUpdatesWithIncompleteWarnings = ValidateNoIncompletePerformanceMeasureActualUpdateRow();

            //validation 3: duplicate PM row
            var performanceMeasureActualUpdatesWithDuplicateWarnings = ValidateNoDuplicatePerformanceMeasureActualUpdateRow();

            var performanceMeasuresValidationResult = new PerformanceMeasuresValidationResult(missingYears, performanceMeasureActualUpdatesWithIncompleteWarnings, performanceMeasureActualUpdatesWithDuplicateWarnings);
            return performanceMeasuresValidationResult;
        }

        private HashSet<int> ValidateNoIncompletePerformanceMeasureActualUpdateRow()
        {
            var performanceMeasureActualUpdatesWithMissingSubcategoryOptions =
                PerformanceMeasureActualUpdates.Where(
                    x => !x.ActualValue.HasValue || x.PerformanceMeasure.PerformanceMeasureSubcategories.Count != x.PerformanceMeasureActualSubcategoryOptionUpdates.Count).ToList();
            return new HashSet<int>(performanceMeasureActualUpdatesWithMissingSubcategoryOptions.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        private HashSet<int> ValidateNoDuplicatePerformanceMeasureActualUpdateRow()
        {
            var hasDuplicates = PerformanceMeasureActualUpdates
                .GroupBy(x => new { x.PerformanceMeasureID, x.CalendarYear })
                .Select(x => x.ToList())
                .ToList()
                .Select(x => x)
                .Where(x => x.Select(m => m.PerformanceMeasureActualSubcategoryOptionUpdates).ToList().Select(z => String.Join("_", z.Select(s => s.PerformanceMeasureSubcategoryOptionID).ToList())).ToList().HasDuplicates()).ToList();
            var test = hasDuplicates.SelectMany(x => x).ToList();

            return new HashSet<int>(test.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        public bool ArePerformanceMeasuresValid()
        {
            return ValidatePerformanceMeasures().IsValid;
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

        public BudgetsValidationResult ValidateBudgetsAndForceValidation()
        {
            AreProjectBasicsValid = ValidateProjectBasics().IsValid;
            return ValidateBudgets();
        }

        public BudgetsValidationResult ValidateBudgets()
        {
            if (!AreProjectBasicsValid)
            {
                return new BudgetsValidationResult(FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection);
            }

            // get distinct Funding Sources
            var fundingSources = ProjectBudgetUpdates.Select(x => x.FundingSource).Distinct().ToList();

            if (!fundingSources.Any())
            {
                return new BudgetsValidationResult();
            }

            // validation 1: ensure that we have budget values from ProjectUpdate start year to min(endyear, currentyear)
            var yearsExpected = FirmaDateUtilities.CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(new List<int>(), ProjectUpdate, FirmaDateUtilities.CalculateCurrentYearToUseForReporting());

            var missingFundingSourceYears = new Dictionary<FundingSource, HashSet<int>>();
            foreach (var fundingSource in fundingSources)
            {
                var currentFundingSource = fundingSource;
                var missingYears =
                    yearsExpected.GetMissingYears(ProjectBudgetUpdates.Where(x => x.FundingSourceID == currentFundingSource.FundingSourceID).Select(x => x.CalendarYear));
                if (missingYears.Any())
                {
                    missingFundingSourceYears.Add(currentFundingSource, missingYears);
                }
            }
            var budgetsValidationResult = new BudgetsValidationResult(missingFundingSourceYears);
            return budgetsValidationResult;

        }

        public bool AreBudgetsValid()
        {
            return ValidateBudgets().IsValid;
        }

        public LocationSimpleValidationResult ValidateProjectLocationSimple()
        {
            return new LocationSimpleValidationResult(ProjectUpdate);
        }
        
        public bool IsProjectLocationSimpleValid()
        {
            return ValidateProjectLocationSimple().IsValid;
        }

        public void SubmitToReviewer(Person currentPerson, DateTime transitionDate)
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
            IList<ProjectBudget> projectBudgets,
            IList<PerformanceMeasureActual> performanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions,
            IList<ProjectExternalLink> projectExternalLinks,
            IList<ProjectNote> projectNotes,
            IList<ProjectImage> projectImages,
            IList<ProjectLocation> projectLocations)
        {
            Check.Require(IsSubmitted, "You cannot approve a project update that has not been submitted!");
            CommitChangesToProject(projectExemptReportingYears,
                projectFundingSourceExpenditures,
                projectBudgets,
                performanceMeasureActuals,
                performanceMeasureActualSubcategoryOptions,
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
            IList<ProjectBudget> projectBudgets,
            IList<PerformanceMeasureActual> performanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions,
            IList<ProjectExternalLink> projectExternalLinks,
            IList<ProjectNote> projectNotes,
            IList<ProjectImage> projectImages,
            IList<ProjectLocation> projectLocations)
        {
            // basics
            ProjectUpdate.CommitChangesToProject(Project);

            // expenditures
            ProjectFundingSourceExpenditureUpdate.CommitChangesToProject(this, projectFundingSourceExpenditures);

            //  project budgets
            ProjectBudgetUpdate.CommitChangesToProject(this, projectBudgets);

            // performance measures
            PerformanceMeasureActualUpdate.CommitChangesToProject(this, performanceMeasureActuals, performanceMeasureActualSubcategoryOptions);

            // project exempt reporting years
            ProjectExemptReportingYearUpdate.CommitChangesToProject(this, projectExemptReportingYears);

            // project exempt reporting years reason
            Project.PerformanceMeasureActualYearsExemptionExplanation = PerformanceMeasureActualYearsExemptionExplanation;

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
            HttpRequestStorage.DatabaseEntities.AllProjectUpdateHistories.Add(projectUpdateHistory);
            projectUpdateBatch.ProjectUpdateStateID = projectUpdateState.ProjectUpdateStateID;
            projectUpdateBatch.TickleLastUpdateDate(transitionDate, currentPerson);
        }
    }
}
