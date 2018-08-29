/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateBatch.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Models
{
    public partial class ProjectUpdateBatch
    {
        public bool IsApproved => ProjectUpdateState == ProjectUpdateState.Approved;

        public bool IsReturned => ProjectUpdateState == ProjectUpdateState.Returned;

        public bool IsSubmitted => ProjectUpdateState == ProjectUpdateState.Submitted;

        public bool IsCreated => ProjectUpdateState == ProjectUpdateState.Created;

        public bool IsNew => ProjectUpdateState == ProjectUpdateState.Created &&
                             !ModelObjectHelpers.IsRealPrimaryKeyValue(ProjectUpdateBatchID);

        public ProjectUpdateHistory LatestProjectUpdateHistorySubmitted => ProjectUpdateHistories.GetLatestProjectUpdateHistory(ProjectUpdateState.Submitted);

        public DateTime? LatestSubmittalDate => LatestProjectUpdateHistorySubmitted?.TransitionDate;

        public ProjectUpdateHistory LatestProjectUpdateHistoryReturned => ProjectUpdateHistories.GetLatestProjectUpdateHistory(ProjectUpdateState.Returned);

        public bool IsReadyToSubmit => InEditableState && IsPassingAllValidationRules;

        public bool IsReadyToApprove => IsPassingAllValidationRules;

        private bool IsPassingAllValidationRules => AreProjectBasicsValid && AreExpendituresValid() && ArePerformanceMeasuresValid() &&
                                                    IsProjectLocationSimpleValid() && IsProjectWatershedValid();

        public bool InEditableState => Project.IsActiveProject() && (IsCreated || IsReturned);

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

        public static ProjectUpdateBatch CreateNewProjectUpdateBatchForProject(Project project, Person currentPerson)
        {
            var projectUpdateBatch = CreateProjectUpdateBatchAndLogTransition(project, currentPerson);

            // basics & map
            ProjectUpdate.CreateFromProject(projectUpdateBatch);

            // expenditures
            ProjectFundingSourceExpenditureUpdate.CreateFromProject(projectUpdateBatch);

            // project expenditures exempt reporting years
            ProjectExemptReportingYearUpdate.CreateExpendituresExemptReportingYearsFromProject(projectUpdateBatch);

            // expenditures exempt explanation
            projectUpdateBatch.SyncExpendituresYearsExemptionExplanation();

            // Expected Funding
            ProjectFundingSourceRequestUpdate.CreateFromProject(projectUpdateBatch);

            // performance measures
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // project performance measures exempt reporting years
            ProjectExemptReportingYearUpdate.CreatePerformanceMeasuresExemptReportingYearsFromProject(projectUpdateBatch);

            // project exempt reporting years reason
            projectUpdateBatch.SyncPerformanceMeasureActualYearsExemptionExplanation();

            // project locations - detailed
            ProjectLocationUpdate.CreateFromProject(projectUpdateBatch);

            // project watershed
            ProjectWatershedUpdate.CreateFromProject(projectUpdateBatch);

            // photos
            ProjectImageUpdate.CreateFromProject(projectUpdateBatch);
            projectUpdateBatch.IsPhotosUpdated = false;

            // external links
            ProjectExternalLinkUpdate.CreateFromProject(projectUpdateBatch);

            // notes
            ProjectNoteUpdate.CreateFromProject(projectUpdateBatch);

            // organizations
            ProjectOrganizationUpdate.CreateFromProject(projectUpdateBatch);

            // Documents
            ProjectDocumentUpdate.CreateFromProject(projectUpdateBatch);

            // Custom attributes
            ProjectCustomAttributeUpdate.CreateFromProject(projectUpdateBatch);

            return projectUpdateBatch;
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static ProjectUpdateBatch CreateProjectUpdateBatchAndLogTransition(Project project, Person currentPerson)
        {
            var projectUpdateBatch = new ProjectUpdateBatch(project, DateTime.Now, currentPerson, ProjectUpdateState.Created, false);

            // create a project update history record
            CreateNewTransitionRecord(projectUpdateBatch, ProjectUpdateState.Created, currentPerson, DateTime.Now);
            return projectUpdateBatch;
        }

        public void SyncPerformanceMeasureActualYearsExemptionExplanation()
        {
            PerformanceMeasureActualYearsExemptionExplanation = Project.PerformanceMeasureActualYearsExemptionExplanation;
        }

        public void SyncExpendituresYearsExemptionExplanation()
        {
            NoExpendituresToReportExplanation = Project.NoExpendituresToReportExplanation;
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

        private static void RefreshFromDatabase(IEnumerable updates)
        {
            ((IObjectContextAdapter)HttpRequestStorage.DatabaseEntities).ObjectContext.Refresh(RefreshMode.StoreWins, updates);
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
        
        public void DeleteProjectDocumentUpdates()
        {
            ProjectDocumentUpdates.DeleteProjectDocumentUpdate();
            RefreshFromDatabase(ProjectDocumentUpdates);
        }

        public void DeleteProjectUpdateHistories()
        {
            ProjectUpdateHistories.DeleteProjectUpdateHistory();
            RefreshFromDatabase(ProjectUpdateHistories);
        }

        public void DeletePerformanceMeasuresProjectExemptReportingYearUpdates()
        {
            var performanceMeasuresExemptReportingYears = this.GetPerformanceMeasuresExemptReportingYears();
            performanceMeasuresExemptReportingYears.DeleteProjectExemptReportingYearUpdate();
            PerformanceMeasureActualYearsExemptionExplanation = null;
            RefreshFromDatabase(performanceMeasuresExemptReportingYears);
        }
        public void DeleteExpendituresProjectExemptReportingYearUpdates()
        {
            var performanceMeasuresExemptReportingYears = this.GetExpendituresExemptReportingYears();
            performanceMeasuresExemptReportingYears.DeleteProjectExemptReportingYearUpdate();
            NoExpendituresToReportExplanation = null;
            RefreshFromDatabase(performanceMeasuresExemptReportingYears);
        }

        public void DeleteProjectFundingSourceExpenditureUpdates()
        {
            ProjectFundingSourceExpenditureUpdates.DeleteProjectFundingSourceExpenditureUpdate();
            RefreshFromDatabase(ProjectFundingSourceExpenditureUpdates);
        }

        public void DeleteProjectFundingSourceRequestUpdates()
        {
            ProjectFundingSourceRequestUpdates.DeleteProjectFundingSourceRequestUpdate();
            RefreshFromDatabase(ProjectFundingSourceRequestUpdates);
        }

        public void DeleteProjectBudgetUpdates()
        {
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //ProjectBudgetUpdates.DeleteProjectBudgetUpdate();
            //RefreshFromDatabase(ProjectBudgetUpdates);
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

        public void DeleteProjectWatershedUpdates()
        {
            ProjectWatershedUpdates.DeleteProjectWatershedUpdate();
            RefreshFromDatabase(ProjectWatershedUpdates);
        }

        public void DeleteProjectOrganizationUpdates()
        {
            ProjectOrganizationUpdates.DeleteProjectOrganizationUpdate();
            RefreshFromDatabase(ProjectOrganizationUpdates);
        }

        public void DeleteAll()
        {
            DeleteProjectLocationStagingUpdates();
            DeleteProjectLocationUpdates();
            DeletePerformanceMeasureActualUpdates();
            DeletePerformanceMeasuresProjectExemptReportingYearUpdates();
            DeleteProjectFundingSourceExpenditureUpdates();
            DeleteProjectFundingSourceRequestUpdates();
            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//            DeleteProjectBudgetUpdates();
            DeleteProjectImageUpdates();
            DeleteProjectExternalLinkUpdates();
            DeleteProjectNoteUpdates();
            DeleteProjectUpdateHistories();
            DeleteProjectUpdate();
            DeleteProjectWatershedUpdates();
            DeleteProjectOrganizationUpdates();
            DeleteProjectDocumentUpdates();
            this.DeleteProjectUpdateBatch();
        }

        private void DeleteProjectUpdate()
        {
            ProjectUpdate.DeleteProjectUpdate();
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
            private set => _areProjectBasicsValid = value;
        }

        public bool NewStageIsPlanningDesign => ProjectUpdate.ProjectStage == ProjectStage.PlanningDesign;

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
                var exemptYears = this.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();
                var yearsExpected = ProjectUpdate.GetProjectUpdateImplementationStartToCompletionYearRange().Where(x => !exemptYears.Contains(x)).ToList();
                var yearsEntered = PerformanceMeasureActualUpdates.Select(x => x.CalendarYear).Distinct();
                missingYears = yearsExpected.GetMissingYears(yearsEntered);
            }
            // validation 2: incomplete PM row (missing performanceMeasureSubcategory option id)
            var performanceMeasureActualUpdatesWithIncompleteWarnings = ValidateNoIncompletePerformanceMeasureActualUpdateRow();

            //validation 3: duplicate PM row
            var performanceMeasureActualUpdatesWithDuplicateWarnings = ValidateNoDuplicatePerformanceMeasureActualUpdateRow();

            //validation4: data entered for exempt years
            var performanceMeasureActualUpdatesWithExemptYear = ValidateNoExemptYearsWithReportedPerformanceMeasureRow();

            var performanceMeasuresValidationResult = new PerformanceMeasuresValidationResult(missingYears, performanceMeasureActualUpdatesWithIncompleteWarnings, performanceMeasureActualUpdatesWithDuplicateWarnings, performanceMeasureActualUpdatesWithExemptYear);
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
            if (PerformanceMeasureActualUpdates == null)
            {
                return new HashSet<int>();
            }
            var duplicates =  PerformanceMeasureActualUpdates
                .GroupBy(x => new { x.PerformanceMeasureID, x.CalendarYear })
                .Select(x => x.ToList())
                .ToList()
                .Select(x => x)
                .Where(x => x.Select(m => m.PerformanceMeasureActualSubcategoryOptionUpdates).ToList().Select(z => String.Join("_", z.Select(s => s.PerformanceMeasureSubcategoryOptionID).ToList())).ToList().HasDuplicates()).ToList();

            return new HashSet<int>(duplicates.SelectMany(x => x).ToList().Select(x => x.PerformanceMeasureActualUpdateID));
        }

        private HashSet<int> ValidateNoExemptYearsWithReportedPerformanceMeasureRow()
        {
            if (PerformanceMeasureActualUpdates == null)
            {
                return new HashSet<int>();
            }
            var exemptYears = this.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList();

            var performanceMeasureActualUpdatesWithExemptYear =
                PerformanceMeasureActualUpdates.Where(x => exemptYears.Contains(x.CalendarYear)).ToList();            

            return new HashSet<int>(performanceMeasureActualUpdatesWithExemptYear.Select(x => x.PerformanceMeasureActualUpdateID));
        }

        public bool ArePerformanceMeasuresValid()
        {
            return NewStageIsPlanningDesign || ValidatePerformanceMeasures().IsValid;
        }

        public List<string> ValidateExpendituresAndForceValidation()
        {
            AreProjectBasicsValid = ValidateProjectBasics().IsValid;
            return ValidateExpenditures();
        }

        public ExpectedFundingValidationResult ValidateExpectedFunding(List<ProjectFundingSourceRequestSimple> newProjectFundingSourceRequests)
        {
            return new ExpectedFundingValidationResult();
        }

        public List<string> ValidateExpenditures()
        {
            if (!AreProjectBasicsValid)
            {
                return new List<string> {FirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection};
            }

            if (ProjectUpdate.ProjectStage.RequiresReportedExpenditures() || ProjectUpdate.ProjectStage == ProjectStage.Completed)
            {
                // validation 1: ensure that we have expenditure values from ProjectUpdate start year to min(endyear, currentyear)
                var yearsExpected = ProjectUpdate.GetProjectUpdatePlanningDesignStartToCompletionYearRange();
                var validateExpenditures = ExpendituresValidationResult.ValidateImpl(
                    this.GetExpendituresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList(),
                    NoExpendituresToReportExplanation, yearsExpected, new List<IFundingSourceExpenditure>(ProjectFundingSourceExpenditureUpdates));
                return validateExpenditures;
            }
            return new List<string>();
        }

        public bool AreExpendituresValid()
        {
            return ValidateExpenditures().Count == 0;
        }

        public OrganizationsValidationResult ValidateOrganizations()
        {
            return new OrganizationsValidationResult(ProjectOrganizationUpdates.Select(x => new ProjectOrganizationSimple(x))
                .ToList());
        }

        public bool AreOrganizationsValid()
        {
            return ValidateOrganizations().IsValid;
        }

        public LocationSimpleValidationResult ValidateProjectLocationSimple()
        {           
            var incomplete = ProjectUpdate.ProjectLocationPoint == null &&
                             string.IsNullOrWhiteSpace(ProjectUpdate.ProjectLocationNotes);

            var locationSimpleValidationResult = new LocationSimpleValidationResult(incomplete);

            return locationSimpleValidationResult;
        }
        
        public bool IsProjectLocationSimpleValid()
        {
            return ValidateProjectLocationSimple().IsValid;
        }

        public WatershedValidationResult ValidateProjectWatershed()
        {
            var incomplete = ProjectWatershedUpdates.Count.Equals(0) &&
                string.IsNullOrWhiteSpace(ProjectUpdate.ProjectWatershedNotes);            

            var watershedValidationResult = new WatershedValidationResult(incomplete);

            return watershedValidationResult;
        }

        public bool IsProjectWatershedValid()
        {
            return ValidateProjectWatershed().IsValid;
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

        public void Approve( // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //IList<ProjectBudget> projectBudgets, 
            Person currentPerson, DateTime transitionDate,
            IList<ProjectExemptReportingYear> projectExemptReportingYears,
            IList<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            IList<PerformanceMeasureActual> performanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions,
            IList<ProjectExternalLink> projectExternalLinks, IList<ProjectNote> projectNotes,
            IList<ProjectImage> projectImages, IList<ProjectLocation> projectLocations,
            IList<ProjectWatershed> projectWatersheds, IList<ProjectFundingSourceRequest> projectFundingSourceRequests,
            IList<ProjectOrganization> allProjectOrganizations,
            IList<ProjectDocument> allProjectDocuments,
            IList<ProjectCustomAttribute> allProjectCustomAttributes,
            IList<ProjectCustomAttributeValue> allProjectCustomAttributeValues)
        {
            Check.Require(IsSubmitted, "You cannot approve a project update that has not been submitted!");
            CommitChangesToProject(projectExemptReportingYears,
                projectFundingSourceExpenditures,
                // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//                projectBudgets,
                performanceMeasureActuals,
                performanceMeasureActualSubcategoryOptions,
                projectExternalLinks,
                projectNotes,
                projectImages,
                projectLocations,
                projectWatersheds,
                projectFundingSourceRequests,
                allProjectOrganizations,
                allProjectDocuments,
                allProjectCustomAttributes,
                allProjectCustomAttributeValues);
            CreateNewTransitionRecord(this, ProjectUpdateState.Approved, currentPerson, transitionDate);
            PushTransitionRecordsToAuditLog();
        }

        private void PushTransitionRecordsToAuditLog()
        {
            foreach (var projectUpdateHistory in ProjectUpdateHistories.ToList())
            {
                var auditLog = new AuditLog(projectUpdateHistory.UpdatePerson,
                    projectUpdateHistory.TransitionDate,
                    AuditLogEventType.Added,
                    "Project Update",
                    projectUpdateHistory.ProjectUpdateHistoryID,
                    "Project Update record",
                    projectUpdateHistory.ProjectUpdateState.ProjectUpdateStateDisplayName) {ProjectID = ProjectID};
            }
        }

        private void CommitChangesToProject( 
                // TODO: Neutered per #1136; most likely will bring back when BOR project starts
//            IList<ProjectBudget> projectBudgets,
                IList<ProjectExemptReportingYear> projectExemptReportingYears,
                IList<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
                IList<PerformanceMeasureActual> performanceMeasureActuals,
                IList<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions,
                IList<ProjectExternalLink> projectExternalLinks, IList<ProjectNote> projectNotes,
                IList<ProjectImage> projectImages, IList<ProjectLocation> projectLocations,
                IList<ProjectWatershed> projectWatersheds,
                IList<ProjectFundingSourceRequest> projectFundingSourceRequests,
                IList<ProjectOrganization> allProjectOrganizations,
                IList<ProjectDocument> allProjectDocuments,
                IList<ProjectCustomAttribute> allProjectCustomAttributes,
                IList<ProjectCustomAttributeValue> allProjectCustomAttributeValues)
        {
            // basics
            ProjectUpdate.CommitChangesToProject(Project);

            // expenditures
            ProjectFundingSourceExpenditureUpdate.CommitChangesToProject(this, projectFundingSourceExpenditures);

            // expected funding
            ProjectFundingSourceRequestUpdate.CommitChangesToProject(this, projectFundingSourceRequests);

            // TODO: Neutered per #1136; most likely will bring back when BOR project starts
            //  project budgets
            //ProjectBudgetUpdate.CommitChangesToProject(this, projectBudgets);

            // only relevant for stages past planning/design
            if (!NewStageIsPlanningDesign)
            {
                // performance measures
                PerformanceMeasureActualUpdate.CommitChangesToProject(this, performanceMeasureActuals,
                    performanceMeasureActualSubcategoryOptions);

                // project exempt reporting years
                ProjectExemptReportingYearUpdate.CommitChangesToProject(this, projectExemptReportingYears);

                // project exempt reporting years reason
                Project.PerformanceMeasureActualYearsExemptionExplanation =
                    PerformanceMeasureActualYearsExemptionExplanation;
            }

            // project location simple
            ProjectUpdate.CommitSimpleLocationToProject(Project);

            // project location detailed
            ProjectLocationUpdate.CommitChangesToProject(this, projectLocations);

            // project watershed
            ProjectWatershedUpdate.CommitChangesToProject(this, projectWatersheds);
            ProjectUpdate.CommitWatershedNotesToProject(Project);

            // photos
            ProjectImageUpdate.CommitChangesToProject(this, projectImages);
            IsPhotosUpdated = false;

            // external links
            ProjectExternalLinkUpdate.CommitChangesToProject(this, projectExternalLinks);

            // notes
            ProjectNoteUpdate.CommitChangesToProject(this, projectNotes);

            // Organizations
            ProjectOrganizationUpdate.CommitChangesToProject(this, allProjectOrganizations);

            // Documents
            ProjectDocumentUpdate.CommitChangesToProject(this, allProjectDocuments);

            // Project Custom Attributes
            ProjectCustomAttributeUpdate.CommitChangesToProject(this, allProjectCustomAttributes, allProjectCustomAttributeValues);
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

        public bool AreAccomplishmentsRelevant()
        {
            var projectStage = ProjectUpdate == null ? Project.ProjectStage : ProjectUpdate.ProjectStage;
            return projectStage != ProjectStage.PlanningDesign;
        }

        public List<ProjectUpdateSection> GetApplicableWizardSections()
        {
            var projectUpdateSections = ProjectUpdateSection.All.Except(new List<ProjectUpdateSection> { ProjectUpdateSection.ExpectedFunding, ProjectUpdateSection.PerformanceMeasures }).ToList();
            
            if (Project.IsExpectedFundingRelevant())
            {
                projectUpdateSections.Add(ProjectUpdateSection.ExpectedFunding);
            }

            if (AreAccomplishmentsRelevant())
            {
                projectUpdateSections.Add(ProjectUpdateSection.PerformanceMeasures);
            }

            return projectUpdateSections.OrderBy(x => x.SortOrder).ToList();
        }
    }
}
