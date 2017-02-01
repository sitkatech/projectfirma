//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateBatch]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ProjectUpdateBatch]")]
    public partial class ProjectUpdateBatch : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectUpdateBatch()
        {
            this.PerformanceMeasureActualUpdates = new HashSet<PerformanceMeasureActualUpdate>();
            this.ProjectBudgetUpdates = new HashSet<ProjectBudgetUpdate>();
            this.ProjectExemptReportingYearUpdates = new HashSet<ProjectExemptReportingYearUpdate>();
            this.ProjectExternalLinkUpdates = new HashSet<ProjectExternalLinkUpdate>();
            this.ProjectFundingSourceExpenditureUpdates = new HashSet<ProjectFundingSourceExpenditureUpdate>();
            this.ProjectImageUpdates = new HashSet<ProjectImageUpdate>();
            this.ProjectLocationStagingUpdates = new HashSet<ProjectLocationStagingUpdate>();
            this.ProjectLocationUpdates = new HashSet<ProjectLocationUpdate>();
            this.ProjectNoteUpdates = new HashSet<ProjectNoteUpdate>();
            this.ProjectUpdates = new HashSet<ProjectUpdate>();
            this.ProjectUpdateHistories = new HashSet<ProjectUpdateHistory>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateBatch(int projectUpdateBatchID, int projectID, DateTime lastUpdateDate, string performanceMeasureActualYearsExemptionExplanation, bool showBasicsValidationWarnings, bool showPerformanceMeasuresValidationWarnings, bool showExpendituresValidationWarnings, bool showBudgetsValidationWarnings, bool showLocationSimpleValidationWarnings, int lastUpdatePersonID, string basicsComment, string expendituresComment, string performanceMeasuresComment, string locationSimpleComment, string locationDetailedComment, string budgetsComment, int projectUpdateStateID, bool isPhotosUpdated, string basicsDiffLog, string performanceMeasureDiffLog, string expendituresDiffLog, string budgetsDiffLog, string externalLinksDiffLog, string notesDiffLog) : this()
        {
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectID = projectID;
            this.LastUpdateDate = lastUpdateDate;
            this.PerformanceMeasureActualYearsExemptionExplanation = performanceMeasureActualYearsExemptionExplanation;
            this.ShowBasicsValidationWarnings = showBasicsValidationWarnings;
            this.ShowPerformanceMeasuresValidationWarnings = showPerformanceMeasuresValidationWarnings;
            this.ShowExpendituresValidationWarnings = showExpendituresValidationWarnings;
            this.ShowBudgetsValidationWarnings = showBudgetsValidationWarnings;
            this.ShowLocationSimpleValidationWarnings = showLocationSimpleValidationWarnings;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.BasicsComment = basicsComment;
            this.ExpendituresComment = expendituresComment;
            this.PerformanceMeasuresComment = performanceMeasuresComment;
            this.LocationSimpleComment = locationSimpleComment;
            this.LocationDetailedComment = locationDetailedComment;
            this.BudgetsComment = budgetsComment;
            this.ProjectUpdateStateID = projectUpdateStateID;
            this.IsPhotosUpdated = isPhotosUpdated;
            this.BasicsDiffLog = basicsDiffLog;
            this.PerformanceMeasureDiffLog = performanceMeasureDiffLog;
            this.ExpendituresDiffLog = expendituresDiffLog;
            this.BudgetsDiffLog = budgetsDiffLog;
            this.ExternalLinksDiffLog = externalLinksDiffLog;
            this.NotesDiffLog = notesDiffLog;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateBatch(int projectID, DateTime lastUpdateDate, bool showBasicsValidationWarnings, bool showPerformanceMeasuresValidationWarnings, bool showExpendituresValidationWarnings, bool showBudgetsValidationWarnings, bool showLocationSimpleValidationWarnings, int lastUpdatePersonID, int projectUpdateStateID, bool isPhotosUpdated) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectUpdateBatchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.LastUpdateDate = lastUpdateDate;
            this.ShowBasicsValidationWarnings = showBasicsValidationWarnings;
            this.ShowPerformanceMeasuresValidationWarnings = showPerformanceMeasuresValidationWarnings;
            this.ShowExpendituresValidationWarnings = showExpendituresValidationWarnings;
            this.ShowBudgetsValidationWarnings = showBudgetsValidationWarnings;
            this.ShowLocationSimpleValidationWarnings = showLocationSimpleValidationWarnings;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.ProjectUpdateStateID = projectUpdateStateID;
            this.IsPhotosUpdated = isPhotosUpdated;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectUpdateBatch(Project project, DateTime lastUpdateDate, bool showBasicsValidationWarnings, bool showPerformanceMeasuresValidationWarnings, bool showExpendituresValidationWarnings, bool showBudgetsValidationWarnings, bool showLocationSimpleValidationWarnings, Person lastUpdatePerson, ProjectUpdateState projectUpdateState, bool isPhotosUpdated) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateBatchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectUpdateBatches.Add(this);
            this.LastUpdateDate = lastUpdateDate;
            this.ShowBasicsValidationWarnings = showBasicsValidationWarnings;
            this.ShowPerformanceMeasuresValidationWarnings = showPerformanceMeasuresValidationWarnings;
            this.ShowExpendituresValidationWarnings = showExpendituresValidationWarnings;
            this.ShowBudgetsValidationWarnings = showBudgetsValidationWarnings;
            this.ShowLocationSimpleValidationWarnings = showLocationSimpleValidationWarnings;
            this.LastUpdatePersonID = lastUpdatePerson.PersonID;
            this.LastUpdatePerson = lastUpdatePerson;
            lastUpdatePerson.ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson.Add(this);
            this.ProjectUpdateStateID = projectUpdateState.ProjectUpdateStateID;
            this.IsPhotosUpdated = isPhotosUpdated;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectUpdateBatch CreateNewBlank(Project project, Person lastUpdatePerson, ProjectUpdateState projectUpdateState)
        {
            return new ProjectUpdateBatch(project, default(DateTime), default(bool), default(bool), default(bool), default(bool), default(bool), lastUpdatePerson, projectUpdateState, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureActualUpdates.Any() || ProjectBudgetUpdates.Any() || ProjectExemptReportingYearUpdates.Any() || ProjectExternalLinkUpdates.Any() || ProjectFundingSourceExpenditureUpdates.Any() || ProjectImageUpdates.Any() || ProjectLocationStagingUpdates.Any() || ProjectLocationUpdates.Any() || ProjectNoteUpdates.Any() || (ProjectUpdate != null) || ProjectUpdateHistories.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectUpdateBatch).Name, typeof(PerformanceMeasureActualUpdate).Name, typeof(ProjectBudgetUpdate).Name, typeof(ProjectExemptReportingYearUpdate).Name, typeof(ProjectExternalLinkUpdate).Name, typeof(ProjectFundingSourceExpenditureUpdate).Name, typeof(ProjectImageUpdate).Name, typeof(ProjectLocationStagingUpdate).Name, typeof(ProjectLocationUpdate).Name, typeof(ProjectNoteUpdate).Name, typeof(ProjectUpdate).Name, typeof(ProjectUpdateHistory).Name};

        [Key]
        public int ProjectUpdateBatchID { get; set; }
        public int ProjectID { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string PerformanceMeasureActualYearsExemptionExplanation { get; set; }
        public bool ShowBasicsValidationWarnings { get; set; }
        public bool ShowPerformanceMeasuresValidationWarnings { get; set; }
        public bool ShowExpendituresValidationWarnings { get; set; }
        public bool ShowBudgetsValidationWarnings { get; set; }
        public bool ShowLocationSimpleValidationWarnings { get; set; }
        public int LastUpdatePersonID { get; set; }
        public string BasicsComment { get; set; }
        public string ExpendituresComment { get; set; }
        public string PerformanceMeasuresComment { get; set; }
        public string LocationSimpleComment { get; set; }
        public string LocationDetailedComment { get; set; }
        public string BudgetsComment { get; set; }
        public int ProjectUpdateStateID { get; set; }
        public bool IsPhotosUpdated { get; set; }
        [NotMapped]
        private string BasicsDiffLog { get; set; }
        public HtmlString BasicsDiffLogHtmlString
        { 
            get { return BasicsDiffLog == null ? null : new HtmlString(BasicsDiffLog); }
            set { BasicsDiffLog = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string PerformanceMeasureDiffLog { get; set; }
        public HtmlString PerformanceMeasureDiffLogHtmlString
        { 
            get { return PerformanceMeasureDiffLog == null ? null : new HtmlString(PerformanceMeasureDiffLog); }
            set { PerformanceMeasureDiffLog = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string ExpendituresDiffLog { get; set; }
        public HtmlString ExpendituresDiffLogHtmlString
        { 
            get { return ExpendituresDiffLog == null ? null : new HtmlString(ExpendituresDiffLog); }
            set { ExpendituresDiffLog = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string BudgetsDiffLog { get; set; }
        public HtmlString BudgetsDiffLogHtmlString
        { 
            get { return BudgetsDiffLog == null ? null : new HtmlString(BudgetsDiffLog); }
            set { BudgetsDiffLog = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string ExternalLinksDiffLog { get; set; }
        public HtmlString ExternalLinksDiffLogHtmlString
        { 
            get { return ExternalLinksDiffLog == null ? null : new HtmlString(ExternalLinksDiffLog); }
            set { ExternalLinksDiffLog = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string NotesDiffLog { get; set; }
        public HtmlString NotesDiffLogHtmlString
        { 
            get { return NotesDiffLog == null ? null : new HtmlString(NotesDiffLog); }
            set { NotesDiffLog = value == null ? null : value.ToString(); }
        }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectUpdateBatchID; } set { ProjectUpdateBatchID = value; } }

        public virtual ICollection<PerformanceMeasureActualUpdate> PerformanceMeasureActualUpdates { get; set; }
        public virtual ICollection<ProjectBudgetUpdate> ProjectBudgetUpdates { get; set; }
        public virtual ICollection<ProjectExemptReportingYearUpdate> ProjectExemptReportingYearUpdates { get; set; }
        public virtual ICollection<ProjectExternalLinkUpdate> ProjectExternalLinkUpdates { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual ICollection<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public virtual ICollection<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual ICollection<ProjectLocationUpdate> ProjectLocationUpdates { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdates { get; set; }
        protected virtual ICollection<ProjectUpdate> ProjectUpdates { get; set; }
        public ProjectUpdate ProjectUpdate { get { return ProjectUpdates.SingleOrDefault(); } set { ProjectUpdates = new List<ProjectUpdate>{value};} }
        public virtual ICollection<ProjectUpdateHistory> ProjectUpdateHistories { get; set; }
        public virtual Project Project { get; set; }
        public virtual Person LastUpdatePerson { get; set; }
        public ProjectUpdateState ProjectUpdateState { get { return ProjectUpdateState.AllLookupDictionary[ProjectUpdateStateID]; } }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureActualYearsExemptionExplanation = 4000;
            public const int BasicsComment = 1000;
            public const int ExpendituresComment = 1000;
            public const int PerformanceMeasuresComment = 1000;
            public const int LocationSimpleComment = 1000;
            public const int LocationDetailedComment = 1000;
            public const int BudgetsComment = 1000;
        }
    }
}