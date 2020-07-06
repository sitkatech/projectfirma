//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Person]
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
    // Table [dbo].[Person] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Person]")]
    public partial class Person : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Person()
        {
            this.AuditLogs = new HashSet<AuditLog>();
            this.DocumentLibraryDocumentsWhereYouAreTheLastUpdatePerson = new HashSet<DocumentLibraryDocument>();
            this.EvaluationsWhereYouAreTheCreatePerson = new HashSet<Evaluation>();
            this.FileResourceInfosWhereYouAreTheCreatePerson = new HashSet<FileResourceInfo>();
            this.FirmaSessions = new HashSet<FirmaSession>();
            this.FirmaSessionsWhereYouAreTheOriginalPerson = new HashSet<FirmaSession>();
            this.ImportExternalProjectStagingsWhereYouAreTheCreatePerson = new HashSet<ImportExternalProjectStaging>();
            this.Notifications = new HashSet<Notification>();
            this.OrganizationsWhereYouAreThePrimaryContactPerson = new HashSet<Organization>();
            this.PerformanceMeasureNotesWhereYouAreTheCreatePerson = new HashSet<PerformanceMeasureNote>();
            this.PerformanceMeasureNotesWhereYouAreTheUpdatePerson = new HashSet<PerformanceMeasureNote>();
            this.PersonStewardGeospatialAreas = new HashSet<PersonStewardGeospatialArea>();
            this.PersonStewardOrganizations = new HashSet<PersonStewardOrganization>();
            this.PersonStewardTaxonomyBranches = new HashSet<PersonStewardTaxonomyBranch>();
            this.ProjectsWhereYouAreThePrimaryContactPerson = new HashSet<Project>();
            this.ProjectsWhereYouAreTheProposingPerson = new HashSet<Project>();
            this.ProjectsWhereYouAreTheReviewedByPerson = new HashSet<Project>();
            this.ProjectsWhereYouAreTheSubmittedByPerson = new HashSet<Project>();
            this.ProjectContactsWhereYouAreTheContact = new HashSet<ProjectContact>();
            this.ProjectContactUpdatesWhereYouAreTheContact = new HashSet<ProjectContactUpdate>();
            this.ProjectInternalNotesWhereYouAreTheCreatePerson = new HashSet<ProjectInternalNote>();
            this.ProjectInternalNotesWhereYouAreTheUpdatePerson = new HashSet<ProjectInternalNote>();
            this.ProjectLocationStagings = new HashSet<ProjectLocationStaging>();
            this.ProjectLocationStagingUpdates = new HashSet<ProjectLocationStagingUpdate>();
            this.ProjectNotesWhereYouAreTheCreatePerson = new HashSet<ProjectNote>();
            this.ProjectNotesWhereYouAreTheUpdatePerson = new HashSet<ProjectNote>();
            this.ProjectNoteUpdatesWhereYouAreTheCreatePerson = new HashSet<ProjectNoteUpdate>();
            this.ProjectNoteUpdatesWhereYouAreTheUpdatePerson = new HashSet<ProjectNoteUpdate>();
            this.ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson = new HashSet<ProjectProjectStatus>();
            this.ProjectProjectStatusesWhereYouAreTheProjectProjectStatusLastEditedPerson = new HashSet<ProjectProjectStatus>();
            this.ProjectUpdatesWhereYouAreThePrimaryContactPerson = new HashSet<ProjectUpdate>();
            this.ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson = new HashSet<ProjectUpdateBatch>();
            this.ProjectUpdateHistoriesWhereYouAreTheUpdatePerson = new HashSet<ProjectUpdateHistory>();
            this.ReleaseNotesWhereYouAreTheCreatePerson = new HashSet<ReleaseNote>();
            this.ReleaseNotesWhereYouAreTheUpdatePerson = new HashSet<ReleaseNote>();
            this.SupportRequestLogsWhereYouAreTheRequestPerson = new HashSet<SupportRequestLog>();
            this.TechnicalAssistanceRequests = new HashSet<TechnicalAssistanceRequest>();
            this.TechnicalAssistanceRequestUpdates = new HashSet<TechnicalAssistanceRequestUpdate>();
            this.TenantAttributesWhereYouAreThePrimaryContactPerson = new HashSet<TenantAttribute>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Person(int personID, Guid personGuid, string firstName, string lastName, string email, string phone, string passwordPdfK2SaltHash, int roleID, DateTime createDate, DateTime? updateDate, DateTime? lastActivityDate, bool isActive, int organizationID, bool receiveSupportEmails, Guid? webServiceAccessToken, string loginName) : this()
        {
            this.PersonID = personID;
            this.PersonGuid = personGuid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.PasswordPdfK2SaltHash = passwordPdfK2SaltHash;
            this.RoleID = roleID;
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
            this.LastActivityDate = lastActivityDate;
            this.IsActive = isActive;
            this.OrganizationID = organizationID;
            this.ReceiveSupportEmails = receiveSupportEmails;
            this.WebServiceAccessToken = webServiceAccessToken;
            this.LoginName = loginName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Person(Guid personGuid, string firstName, string lastName, string email, int roleID, DateTime createDate, bool isActive, int organizationID, bool receiveSupportEmails, string loginName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonGuid = personGuid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.RoleID = roleID;
            this.CreateDate = createDate;
            this.IsActive = isActive;
            this.OrganizationID = organizationID;
            this.ReceiveSupportEmails = receiveSupportEmails;
            this.LoginName = loginName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Person(Guid personGuid, string firstName, string lastName, string email, Role role, DateTime createDate, bool isActive, Organization organization, bool receiveSupportEmails, string loginName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonGuid = personGuid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.RoleID = role.RoleID;
            this.CreateDate = createDate;
            this.IsActive = isActive;
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.People.Add(this);
            this.ReceiveSupportEmails = receiveSupportEmails;
            this.LoginName = loginName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Person CreateNewBlank(Role role, Organization organization)
        {
            return new Person(default(Guid), default(string), default(string), default(string), role, default(DateTime), default(bool), organization, default(bool), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AuditLogs.Any() || DocumentLibraryDocumentsWhereYouAreTheLastUpdatePerson.Any() || EvaluationsWhereYouAreTheCreatePerson.Any() || FileResourceInfosWhereYouAreTheCreatePerson.Any() || FirmaSessions.Any() || FirmaSessionsWhereYouAreTheOriginalPerson.Any() || ImportExternalProjectStagingsWhereYouAreTheCreatePerson.Any() || Notifications.Any() || OrganizationsWhereYouAreThePrimaryContactPerson.Any() || PerformanceMeasureNotesWhereYouAreTheCreatePerson.Any() || PerformanceMeasureNotesWhereYouAreTheUpdatePerson.Any() || PersonStewardGeospatialAreas.Any() || PersonStewardOrganizations.Any() || PersonStewardTaxonomyBranches.Any() || ProjectsWhereYouAreThePrimaryContactPerson.Any() || ProjectsWhereYouAreTheProposingPerson.Any() || ProjectsWhereYouAreTheReviewedByPerson.Any() || ProjectsWhereYouAreTheSubmittedByPerson.Any() || ProjectContactsWhereYouAreTheContact.Any() || ProjectContactUpdatesWhereYouAreTheContact.Any() || ProjectInternalNotesWhereYouAreTheCreatePerson.Any() || ProjectInternalNotesWhereYouAreTheUpdatePerson.Any() || ProjectLocationStagings.Any() || ProjectLocationStagingUpdates.Any() || ProjectNotesWhereYouAreTheCreatePerson.Any() || ProjectNotesWhereYouAreTheUpdatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheCreatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheUpdatePerson.Any() || ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson.Any() || ProjectProjectStatusesWhereYouAreTheProjectProjectStatusLastEditedPerson.Any() || ProjectUpdatesWhereYouAreThePrimaryContactPerson.Any() || ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson.Any() || ProjectUpdateHistoriesWhereYouAreTheUpdatePerson.Any() || ReleaseNotesWhereYouAreTheCreatePerson.Any() || ReleaseNotesWhereYouAreTheUpdatePerson.Any() || SupportRequestLogsWhereYouAreTheRequestPerson.Any() || TechnicalAssistanceRequests.Any() || TechnicalAssistanceRequestUpdates.Any() || TenantAttributesWhereYouAreThePrimaryContactPerson.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(AuditLogs.Any())
            {
                dependentObjects.Add(typeof(AuditLog).Name);
            }

            if(DocumentLibraryDocumentsWhereYouAreTheLastUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(DocumentLibraryDocument).Name);
            }

            if(EvaluationsWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(Evaluation).Name);
            }

            if(FileResourceInfosWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(FileResourceInfo).Name);
            }

            if(FirmaSessions.Any())
            {
                dependentObjects.Add(typeof(FirmaSession).Name);
            }

            if(FirmaSessionsWhereYouAreTheOriginalPerson.Any())
            {
                dependentObjects.Add(typeof(FirmaSession).Name);
            }

            if(ImportExternalProjectStagingsWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(ImportExternalProjectStaging).Name);
            }

            if(Notifications.Any())
            {
                dependentObjects.Add(typeof(Notification).Name);
            }

            if(OrganizationsWhereYouAreThePrimaryContactPerson.Any())
            {
                dependentObjects.Add(typeof(Organization).Name);
            }

            if(PerformanceMeasureNotesWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureNote).Name);
            }

            if(PerformanceMeasureNotesWhereYouAreTheUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureNote).Name);
            }

            if(PersonStewardGeospatialAreas.Any())
            {
                dependentObjects.Add(typeof(PersonStewardGeospatialArea).Name);
            }

            if(PersonStewardOrganizations.Any())
            {
                dependentObjects.Add(typeof(PersonStewardOrganization).Name);
            }

            if(PersonStewardTaxonomyBranches.Any())
            {
                dependentObjects.Add(typeof(PersonStewardTaxonomyBranch).Name);
            }

            if(ProjectsWhereYouAreThePrimaryContactPerson.Any())
            {
                dependentObjects.Add(typeof(Project).Name);
            }

            if(ProjectsWhereYouAreTheProposingPerson.Any())
            {
                dependentObjects.Add(typeof(Project).Name);
            }

            if(ProjectsWhereYouAreTheReviewedByPerson.Any())
            {
                dependentObjects.Add(typeof(Project).Name);
            }

            if(ProjectsWhereYouAreTheSubmittedByPerson.Any())
            {
                dependentObjects.Add(typeof(Project).Name);
            }

            if(ProjectContactsWhereYouAreTheContact.Any())
            {
                dependentObjects.Add(typeof(ProjectContact).Name);
            }

            if(ProjectContactUpdatesWhereYouAreTheContact.Any())
            {
                dependentObjects.Add(typeof(ProjectContactUpdate).Name);
            }

            if(ProjectInternalNotesWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectInternalNote).Name);
            }

            if(ProjectInternalNotesWhereYouAreTheUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectInternalNote).Name);
            }

            if(ProjectLocationStagings.Any())
            {
                dependentObjects.Add(typeof(ProjectLocationStaging).Name);
            }

            if(ProjectLocationStagingUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectLocationStagingUpdate).Name);
            }

            if(ProjectNotesWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectNote).Name);
            }

            if(ProjectNotesWhereYouAreTheUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectNote).Name);
            }

            if(ProjectNoteUpdatesWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectNoteUpdate).Name);
            }

            if(ProjectNoteUpdatesWhereYouAreTheUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectNoteUpdate).Name);
            }

            if(ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectProjectStatus).Name);
            }

            if(ProjectProjectStatusesWhereYouAreTheProjectProjectStatusLastEditedPerson.Any())
            {
                dependentObjects.Add(typeof(ProjectProjectStatus).Name);
            }

            if(ProjectUpdatesWhereYouAreThePrimaryContactPerson.Any())
            {
                dependentObjects.Add(typeof(ProjectUpdate).Name);
            }

            if(ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectUpdateBatch).Name);
            }

            if(ProjectUpdateHistoriesWhereYouAreTheUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(ProjectUpdateHistory).Name);
            }

            if(ReleaseNotesWhereYouAreTheCreatePerson.Any())
            {
                dependentObjects.Add(typeof(ReleaseNote).Name);
            }

            if(ReleaseNotesWhereYouAreTheUpdatePerson.Any())
            {
                dependentObjects.Add(typeof(ReleaseNote).Name);
            }

            if(SupportRequestLogsWhereYouAreTheRequestPerson.Any())
            {
                dependentObjects.Add(typeof(SupportRequestLog).Name);
            }

            if(TechnicalAssistanceRequests.Any())
            {
                dependentObjects.Add(typeof(TechnicalAssistanceRequest).Name);
            }

            if(TechnicalAssistanceRequestUpdates.Any())
            {
                dependentObjects.Add(typeof(TechnicalAssistanceRequestUpdate).Name);
            }

            if(TenantAttributesWhereYouAreThePrimaryContactPerson.Any())
            {
                dependentObjects.Add(typeof(TenantAttribute).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Person).Name, typeof(AuditLog).Name, typeof(DocumentLibraryDocument).Name, typeof(Evaluation).Name, typeof(FileResourceInfo).Name, typeof(FirmaSession).Name, typeof(ImportExternalProjectStaging).Name, typeof(Notification).Name, typeof(Organization).Name, typeof(PerformanceMeasureNote).Name, typeof(PersonStewardGeospatialArea).Name, typeof(PersonStewardOrganization).Name, typeof(PersonStewardTaxonomyBranch).Name, typeof(Project).Name, typeof(ProjectContact).Name, typeof(ProjectContactUpdate).Name, typeof(ProjectInternalNote).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectLocationStagingUpdate).Name, typeof(ProjectNote).Name, typeof(ProjectNoteUpdate).Name, typeof(ProjectProjectStatus).Name, typeof(ProjectUpdate).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectUpdateHistory).Name, typeof(ReleaseNote).Name, typeof(SupportRequestLog).Name, typeof(TechnicalAssistanceRequest).Name, typeof(TechnicalAssistanceRequestUpdate).Name, typeof(TenantAttribute).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPeople.Remove(this);
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

            foreach(var x in AuditLogs.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in DocumentLibraryDocumentsWhereYouAreTheLastUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in EvaluationsWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FileResourceInfosWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FirmaSessions.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FirmaSessionsWhereYouAreTheOriginalPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ImportExternalProjectStagingsWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in Notifications.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in OrganizationsWhereYouAreThePrimaryContactPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureNotesWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureNotesWhereYouAreTheUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PersonStewardGeospatialAreas.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PersonStewardOrganizations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PersonStewardTaxonomyBranches.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectsWhereYouAreThePrimaryContactPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectsWhereYouAreTheProposingPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectsWhereYouAreTheReviewedByPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectsWhereYouAreTheSubmittedByPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectContactsWhereYouAreTheContact.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectContactUpdatesWhereYouAreTheContact.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectInternalNotesWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectInternalNotesWhereYouAreTheUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectLocationStagings.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectLocationStagingUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNotesWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNotesWhereYouAreTheUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNoteUpdatesWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNoteUpdatesWhereYouAreTheUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectProjectStatusesWhereYouAreTheProjectProjectStatusLastEditedPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdatesWhereYouAreThePrimaryContactPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectUpdateHistoriesWhereYouAreTheUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReleaseNotesWhereYouAreTheCreatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReleaseNotesWhereYouAreTheUpdatePerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in SupportRequestLogsWhereYouAreTheRequestPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TechnicalAssistanceRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TechnicalAssistanceRequestUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TenantAttributesWhereYouAreThePrimaryContactPerson.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PersonID { get; set; }
        public int TenantID { get; set; }
        public Guid PersonGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordPdfK2SaltHash { get; set; }
        public int RoleID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationID { get; set; }
        public bool ReceiveSupportEmails { get; set; }
        public Guid? WebServiceAccessToken { get; set; }
        public string LoginName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonID; } set { PersonID = value; } }

        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<DocumentLibraryDocument> DocumentLibraryDocumentsWhereYouAreTheLastUpdatePerson { get; set; }
        public virtual ICollection<Evaluation> EvaluationsWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<FileResourceInfo> FileResourceInfosWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<FirmaSession> FirmaSessions { get; set; }
        public virtual ICollection<FirmaSession> FirmaSessionsWhereYouAreTheOriginalPerson { get; set; }
        public virtual ICollection<ImportExternalProjectStaging> ImportExternalProjectStagingsWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Organization> OrganizationsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<PersonStewardGeospatialArea> PersonStewardGeospatialAreas { get; set; }
        public virtual ICollection<PersonStewardOrganization> PersonStewardOrganizations { get; set; }
        public virtual ICollection<PersonStewardTaxonomyBranch> PersonStewardTaxonomyBranches { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreTheProposingPerson { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreTheReviewedByPerson { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreTheSubmittedByPerson { get; set; }
        public virtual ICollection<ProjectContact> ProjectContactsWhereYouAreTheContact { get; set; }
        public virtual ICollection<ProjectContactUpdate> ProjectContactUpdatesWhereYouAreTheContact { get; set; }
        public virtual ICollection<ProjectInternalNote> ProjectInternalNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectInternalNote> ProjectInternalNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectProjectStatus> ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson { get; set; }
        public virtual ICollection<ProjectProjectStatus> ProjectProjectStatusesWhereYouAreTheProjectProjectStatusLastEditedPerson { get; set; }
        public virtual ICollection<ProjectUpdate> ProjectUpdatesWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson { get; set; }
        public virtual ICollection<ProjectUpdateHistory> ProjectUpdateHistoriesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ReleaseNote> ReleaseNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ReleaseNote> ReleaseNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<SupportRequestLog> SupportRequestLogsWhereYouAreTheRequestPerson { get; set; }
        public virtual ICollection<TechnicalAssistanceRequest> TechnicalAssistanceRequests { get; set; }
        public virtual ICollection<TechnicalAssistanceRequestUpdate> TechnicalAssistanceRequestUpdates { get; set; }
        public virtual ICollection<TenantAttribute> TenantAttributesWhereYouAreThePrimaryContactPerson { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public Role Role { get { return Role.AllLookupDictionary[RoleID]; } }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int FirstName = 100;
            public const int LastName = 100;
            public const int Email = 255;
            public const int Phone = 30;
            public const int PasswordPdfK2SaltHash = 1000;
            public const int LoginName = 128;
        }
    }
}