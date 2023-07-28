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
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ProjectUpdateBatch] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectUpdateBatch]")]
    public partial class ProjectUpdateBatch : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectUpdateBatch()
        {
            this.PerformanceMeasureActualUpdates = new HashSet<PerformanceMeasureActualUpdate>();
            this.PerformanceMeasureExpectedUpdates = new HashSet<PerformanceMeasureExpectedUpdate>();
            this.ProjectAttachmentUpdates = new HashSet<ProjectAttachmentUpdate>();
            this.ProjectClassificationUpdates = new HashSet<ProjectClassificationUpdate>();
            this.ProjectContactUpdates = new HashSet<ProjectContactUpdate>();
            this.ProjectCustomAttributeUpdates = new HashSet<ProjectCustomAttributeUpdate>();
            this.ProjectExemptReportingYearUpdates = new HashSet<ProjectExemptReportingYearUpdate>();
            this.ProjectExternalLinkUpdates = new HashSet<ProjectExternalLinkUpdate>();
            this.ProjectFundingSourceBudgetUpdates = new HashSet<ProjectFundingSourceBudgetUpdate>();
            this.ProjectFundingSourceExpenditureUpdates = new HashSet<ProjectFundingSourceExpenditureUpdate>();
            this.ProjectGeospatialAreaTypeNoteUpdates = new HashSet<ProjectGeospatialAreaTypeNoteUpdate>();
            this.ProjectGeospatialAreaUpdates = new HashSet<ProjectGeospatialAreaUpdate>();
            this.ProjectImageUpdates = new HashSet<ProjectImageUpdate>();
            this.ProjectLocationStagingUpdates = new HashSet<ProjectLocationStagingUpdate>();
            this.ProjectLocationUpdates = new HashSet<ProjectLocationUpdate>();
            this.ProjectNoFundingSourceIdentifiedUpdates = new HashSet<ProjectNoFundingSourceIdentifiedUpdate>();
            this.ProjectNoteUpdates = new HashSet<ProjectNoteUpdate>();
            this.ProjectOrganizationUpdates = new HashSet<ProjectOrganizationUpdate>();
            this.ProjectRelevantCostTypeUpdates = new HashSet<ProjectRelevantCostTypeUpdate>();
            this.ProjectUpdates = new HashSet<ProjectUpdate>();
            this.ProjectUpdateBatchClassificationSystems = new HashSet<ProjectUpdateBatchClassificationSystem>();
            this.ProjectUpdateHistories = new HashSet<ProjectUpdateHistory>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateBatch(int projectUpdateBatchID, int projectID, DateTime lastUpdateDate, string performanceMeasureActualYearsExemptionExplanation, int lastUpdatePersonID, string basicsComment, string expendituresComment, string reportedPerformanceMeasuresComment, string locationSimpleComment, string locationDetailedComment, string budgetsComment, int projectUpdateStateID, bool isPhotosUpdated, string basicsDiffLog, string reportedPerformanceMeasureDiffLog, string expendituresDiffLog, string budgetsDiffLog, string externalLinksDiffLog, string notesDiffLog, string expectedFundingComment, string expectedFundingDiffLog, string organizationsComment, string organizationsDiffLog, string expendituresNote, string expectedPerformanceMeasuresComment, string technicalAssistanceRequestsComment, string contactsComment, string expectedFundingUpdateNote, string contactsDiffLog, string customAttributesComment, string customAttributesDiffLog, string expectedPerformanceMeasureDiffLog, bool? isSimpleLocationUpdated, bool? isDetailedLocationUpdated, bool? isSpatialInformationUpdated, string photosComment, string attachmentsAndNotesComment, string externalLinksComment) : this()
        {
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectID = projectID;
            this.LastUpdateDate = lastUpdateDate;
            this.PerformanceMeasureActualYearsExemptionExplanation = performanceMeasureActualYearsExemptionExplanation;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.BasicsComment = basicsComment;
            this.ExpendituresComment = expendituresComment;
            this.ReportedPerformanceMeasuresComment = reportedPerformanceMeasuresComment;
            this.LocationSimpleComment = locationSimpleComment;
            this.LocationDetailedComment = locationDetailedComment;
            this.BudgetsComment = budgetsComment;
            this.ProjectUpdateStateID = projectUpdateStateID;
            this.IsPhotosUpdated = isPhotosUpdated;
            this.BasicsDiffLog = basicsDiffLog;
            this.ReportedPerformanceMeasureDiffLog = reportedPerformanceMeasureDiffLog;
            this.ExpendituresDiffLog = expendituresDiffLog;
            this.BudgetsDiffLog = budgetsDiffLog;
            this.ExternalLinksDiffLog = externalLinksDiffLog;
            this.NotesDiffLog = notesDiffLog;
            this.ExpectedFundingComment = expectedFundingComment;
            this.ExpectedFundingDiffLog = expectedFundingDiffLog;
            this.OrganizationsComment = organizationsComment;
            this.OrganizationsDiffLog = organizationsDiffLog;
            this.ExpendituresNote = expendituresNote;
            this.ExpectedPerformanceMeasuresComment = expectedPerformanceMeasuresComment;
            this.TechnicalAssistanceRequestsComment = technicalAssistanceRequestsComment;
            this.ContactsComment = contactsComment;
            this.ExpectedFundingUpdateNote = expectedFundingUpdateNote;
            this.ContactsDiffLog = contactsDiffLog;
            this.CustomAttributesComment = customAttributesComment;
            this.CustomAttributesDiffLog = customAttributesDiffLog;
            this.ExpectedPerformanceMeasureDiffLog = expectedPerformanceMeasureDiffLog;
            this.IsSimpleLocationUpdated = isSimpleLocationUpdated;
            this.IsDetailedLocationUpdated = isDetailedLocationUpdated;
            this.IsSpatialInformationUpdated = isSpatialInformationUpdated;
            this.PhotosComment = photosComment;
            this.AttachmentsAndNotesComment = attachmentsAndNotesComment;
            this.ExternalLinksComment = externalLinksComment;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateBatch(int projectID, DateTime lastUpdateDate, int lastUpdatePersonID, int projectUpdateStateID, bool isPhotosUpdated) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateBatchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
            this.ProjectUpdateStateID = projectUpdateStateID;
            this.IsPhotosUpdated = isPhotosUpdated;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectUpdateBatch(Project project, DateTime lastUpdateDate, Person lastUpdatePerson, ProjectUpdateState projectUpdateState, bool isPhotosUpdated) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateBatchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectUpdateBatches.Add(this);
            this.LastUpdateDate = lastUpdateDate;
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
            return new ProjectUpdateBatch(project, default(DateTime), lastUpdatePerson, projectUpdateState, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureActualUpdates.Any() || PerformanceMeasureExpectedUpdates.Any() || ProjectAttachmentUpdates.Any() || ProjectClassificationUpdates.Any() || ProjectContactUpdates.Any() || ProjectCustomAttributeUpdates.Any() || ProjectExemptReportingYearUpdates.Any() || ProjectExternalLinkUpdates.Any() || ProjectFundingSourceBudgetUpdates.Any() || ProjectFundingSourceExpenditureUpdates.Any() || ProjectGeospatialAreaTypeNoteUpdates.Any() || ProjectGeospatialAreaUpdates.Any() || ProjectImageUpdates.Any() || ProjectLocationStagingUpdates.Any() || ProjectLocationUpdates.Any() || ProjectNoFundingSourceIdentifiedUpdates.Any() || ProjectNoteUpdates.Any() || ProjectOrganizationUpdates.Any() || ProjectRelevantCostTypeUpdates.Any() || (ProjectUpdate != null) || ProjectUpdateBatchClassificationSystems.Any() || ProjectUpdateHistories.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(PerformanceMeasureActualUpdates.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureActualUpdate).Name);
            }

            if(PerformanceMeasureExpectedUpdates.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureExpectedUpdate).Name);
            }

            if(ProjectAttachmentUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectAttachmentUpdate).Name);
            }

            if(ProjectClassificationUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectClassificationUpdate).Name);
            }

            if(ProjectContactUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectContactUpdate).Name);
            }

            if(ProjectCustomAttributeUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectCustomAttributeUpdate).Name);
            }

            if(ProjectExemptReportingYearUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectExemptReportingYearUpdate).Name);
            }

            if(ProjectExternalLinkUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectExternalLinkUpdate).Name);
            }

            if(ProjectFundingSourceBudgetUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectFundingSourceBudgetUpdate).Name);
            }

            if(ProjectFundingSourceExpenditureUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectFundingSourceExpenditureUpdate).Name);
            }

            if(ProjectGeospatialAreaTypeNoteUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectGeospatialAreaTypeNoteUpdate).Name);
            }

            if(ProjectGeospatialAreaUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectGeospatialAreaUpdate).Name);
            }

            if(ProjectImageUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectImageUpdate).Name);
            }

            if(ProjectLocationStagingUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectLocationStagingUpdate).Name);
            }

            if(ProjectLocationUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectLocationUpdate).Name);
            }

            if(ProjectNoFundingSourceIdentifiedUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectNoFundingSourceIdentifiedUpdate).Name);
            }

            if(ProjectNoteUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectNoteUpdate).Name);
            }

            if(ProjectOrganizationUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectOrganizationUpdate).Name);
            }

            if(ProjectRelevantCostTypeUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectRelevantCostTypeUpdate).Name);
            }

            if((ProjectUpdate != null))
            {
                dependentObjects.Add(typeof(ProjectUpdate).Name);
            }

            if(ProjectUpdateBatchClassificationSystems.Any())
            {
                dependentObjects.Add(typeof(ProjectUpdateBatchClassificationSystem).Name);
            }

            if(ProjectUpdateHistories.Any())
            {
                dependentObjects.Add(typeof(ProjectUpdateHistory).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectUpdateBatch).Name, typeof(PerformanceMeasureActualUpdate).Name, typeof(PerformanceMeasureExpectedUpdate).Name, typeof(ProjectAttachmentUpdate).Name, typeof(ProjectClassificationUpdate).Name, typeof(ProjectContactUpdate).Name, typeof(ProjectCustomAttributeUpdate).Name, typeof(ProjectExemptReportingYearUpdate).Name, typeof(ProjectExternalLinkUpdate).Name, typeof(ProjectFundingSourceBudgetUpdate).Name, typeof(ProjectFundingSourceExpenditureUpdate).Name, typeof(ProjectGeospatialAreaTypeNoteUpdate).Name, typeof(ProjectGeospatialAreaUpdate).Name, typeof(ProjectImageUpdate).Name, typeof(ProjectLocationStagingUpdate).Name, typeof(ProjectLocationUpdate).Name, typeof(ProjectNoFundingSourceIdentifiedUpdate).Name, typeof(ProjectNoteUpdate).Name, typeof(ProjectOrganizationUpdate).Name, typeof(ProjectRelevantCostTypeUpdate).Name, typeof(ProjectUpdate).Name, typeof(ProjectUpdateBatchClassificationSystem).Name, typeof(ProjectUpdateHistory).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectUpdateBatches.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in PerformanceMeasureActualUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpectedUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectAttachmentUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectClassificationUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectContactUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectCustomAttributeUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectExemptReportingYearUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectExternalLinkUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceBudgetUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceExpenditureUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreaTypeNoteUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreaUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectImageUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectLocationStagingUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectLocationUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNoFundingSourceIdentifiedUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNoteUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectOrganizationUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectRelevantCostTypeUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdateBatchClassificationSystems.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdateHistories.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectUpdateBatchID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string PerformanceMeasureActualYearsExemptionExplanation { get; set; }
        public int LastUpdatePersonID { get; set; }
        public string BasicsComment { get; set; }
        public string ExpendituresComment { get; set; }
        public string ReportedPerformanceMeasuresComment { get; set; }
        public string LocationSimpleComment { get; set; }
        public string LocationDetailedComment { get; set; }
        public string BudgetsComment { get; set; }
        public int ProjectUpdateStateID { get; set; }
        public bool IsPhotosUpdated { get; set; }
        public string BasicsDiffLog { get; set; }
        [NotMapped]
        public HtmlString BasicsDiffLogHtmlString
        { 
            get { return BasicsDiffLog == null ? null : new HtmlString(BasicsDiffLog); }
            set { BasicsDiffLog = value?.ToString(); }
        }
        public string ReportedPerformanceMeasureDiffLog { get; set; }
        [NotMapped]
        public HtmlString ReportedPerformanceMeasureDiffLogHtmlString
        { 
            get { return ReportedPerformanceMeasureDiffLog == null ? null : new HtmlString(ReportedPerformanceMeasureDiffLog); }
            set { ReportedPerformanceMeasureDiffLog = value?.ToString(); }
        }
        public string ExpendituresDiffLog { get; set; }
        [NotMapped]
        public HtmlString ExpendituresDiffLogHtmlString
        { 
            get { return ExpendituresDiffLog == null ? null : new HtmlString(ExpendituresDiffLog); }
            set { ExpendituresDiffLog = value?.ToString(); }
        }
        public string BudgetsDiffLog { get; set; }
        [NotMapped]
        public HtmlString BudgetsDiffLogHtmlString
        { 
            get { return BudgetsDiffLog == null ? null : new HtmlString(BudgetsDiffLog); }
            set { BudgetsDiffLog = value?.ToString(); }
        }
        public string ExternalLinksDiffLog { get; set; }
        [NotMapped]
        public HtmlString ExternalLinksDiffLogHtmlString
        { 
            get { return ExternalLinksDiffLog == null ? null : new HtmlString(ExternalLinksDiffLog); }
            set { ExternalLinksDiffLog = value?.ToString(); }
        }
        public string NotesDiffLog { get; set; }
        [NotMapped]
        public HtmlString NotesDiffLogHtmlString
        { 
            get { return NotesDiffLog == null ? null : new HtmlString(NotesDiffLog); }
            set { NotesDiffLog = value?.ToString(); }
        }
        public string ExpectedFundingComment { get; set; }
        public string ExpectedFundingDiffLog { get; set; }
        public string OrganizationsComment { get; set; }
        public string OrganizationsDiffLog { get; set; }
        [NotMapped]
        public HtmlString OrganizationsDiffLogHtmlString
        { 
            get { return OrganizationsDiffLog == null ? null : new HtmlString(OrganizationsDiffLog); }
            set { OrganizationsDiffLog = value?.ToString(); }
        }
        public string ExpendituresNote { get; set; }
        public string ExpectedPerformanceMeasuresComment { get; set; }
        public string TechnicalAssistanceRequestsComment { get; set; }
        public string ContactsComment { get; set; }
        public string ExpectedFundingUpdateNote { get; set; }
        public string ContactsDiffLog { get; set; }
        [NotMapped]
        public HtmlString ContactsDiffLogHtmlString
        { 
            get { return ContactsDiffLog == null ? null : new HtmlString(ContactsDiffLog); }
            set { ContactsDiffLog = value?.ToString(); }
        }
        public string CustomAttributesComment { get; set; }
        public string CustomAttributesDiffLog { get; set; }
        [NotMapped]
        public HtmlString CustomAttributesDiffLogHtmlString
        { 
            get { return CustomAttributesDiffLog == null ? null : new HtmlString(CustomAttributesDiffLog); }
            set { CustomAttributesDiffLog = value?.ToString(); }
        }
        public string ExpectedPerformanceMeasureDiffLog { get; set; }
        [NotMapped]
        public HtmlString ExpectedPerformanceMeasureDiffLogHtmlString
        { 
            get { return ExpectedPerformanceMeasureDiffLog == null ? null : new HtmlString(ExpectedPerformanceMeasureDiffLog); }
            set { ExpectedPerformanceMeasureDiffLog = value?.ToString(); }
        }
        public bool? IsSimpleLocationUpdated { get; set; }
        public bool? IsDetailedLocationUpdated { get; set; }
        public bool? IsSpatialInformationUpdated { get; set; }
        public string PhotosComment { get; set; }
        public string AttachmentsAndNotesComment { get; set; }
        public string ExternalLinksComment { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateBatchID; } set { ProjectUpdateBatchID = value; } }

        public virtual ICollection<PerformanceMeasureActualUpdate> PerformanceMeasureActualUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedUpdate> PerformanceMeasureExpectedUpdates { get; set; }
        public virtual ICollection<ProjectAttachmentUpdate> ProjectAttachmentUpdates { get; set; }
        public virtual ICollection<ProjectClassificationUpdate> ProjectClassificationUpdates { get; set; }
        public virtual ICollection<ProjectContactUpdate> ProjectContactUpdates { get; set; }
        public virtual ICollection<ProjectCustomAttributeUpdate> ProjectCustomAttributeUpdates { get; set; }
        public virtual ICollection<ProjectExemptReportingYearUpdate> ProjectExemptReportingYearUpdates { get; set; }
        public virtual ICollection<ProjectExternalLinkUpdate> ProjectExternalLinkUpdates { get; set; }
        public virtual ICollection<ProjectFundingSourceBudgetUpdate> ProjectFundingSourceBudgetUpdates { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual ICollection<ProjectGeospatialAreaTypeNoteUpdate> ProjectGeospatialAreaTypeNoteUpdates { get; set; }
        public virtual ICollection<ProjectGeospatialAreaUpdate> ProjectGeospatialAreaUpdates { get; set; }
        public virtual ICollection<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public virtual ICollection<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual ICollection<ProjectLocationUpdate> ProjectLocationUpdates { get; set; }
        public virtual ICollection<ProjectNoFundingSourceIdentifiedUpdate> ProjectNoFundingSourceIdentifiedUpdates { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdates { get; set; }
        public virtual ICollection<ProjectOrganizationUpdate> ProjectOrganizationUpdates { get; set; }
        public virtual ICollection<ProjectRelevantCostTypeUpdate> ProjectRelevantCostTypeUpdates { get; set; }
        public virtual ICollection<ProjectUpdate> ProjectUpdates { get; set; }
        [NotMapped]
        public ProjectUpdate ProjectUpdate { get { return ProjectUpdates.SingleOrDefault(); } set { ProjectUpdates = new List<ProjectUpdate>{value};} }
        public virtual ICollection<ProjectUpdateBatchClassificationSystem> ProjectUpdateBatchClassificationSystems { get; set; }
        public virtual ICollection<ProjectUpdateHistory> ProjectUpdateHistories { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Person LastUpdatePerson { get; set; }
        public ProjectUpdateState ProjectUpdateState { get { return ProjectUpdateState.AllLookupDictionary[ProjectUpdateStateID]; } }

        public static class FieldLengths
        {
            public const int PerformanceMeasureActualYearsExemptionExplanation = 4000;
            public const int BasicsComment = 1000;
            public const int ExpendituresComment = 1000;
            public const int ReportedPerformanceMeasuresComment = 1000;
            public const int LocationSimpleComment = 1000;
            public const int LocationDetailedComment = 1000;
            public const int BudgetsComment = 1000;
            public const int ExpectedFundingComment = 1000;
            public const int OrganizationsComment = 1000;
            public const int ExpectedPerformanceMeasuresComment = 1000;
            public const int TechnicalAssistanceRequestsComment = 1000;
            public const int ContactsComment = 1000;
            public const int ExpectedFundingUpdateNote = 500;
            public const int CustomAttributesComment = 1000;
            public const int PhotosComment = 1000;
            public const int AttachmentsAndNotesComment = 1000;
            public const int ExternalLinksComment = 1000;
        }
    }
}