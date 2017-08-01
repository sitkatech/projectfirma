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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[Person]")]
    public partial class Person : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Person()
        {
            this.AuditLogs = new HashSet<AuditLog>();
            this.FileResourcesWhereYouAreTheCreatePerson = new HashSet<FileResource>();
            this.Notifications = new HashSet<Notification>();
            this.OrganizationsWhereYouAreThePrimaryContactPerson = new HashSet<Organization>();
            this.PerformanceMeasureNotesWhereYouAreTheCreatePerson = new HashSet<PerformanceMeasureNote>();
            this.PerformanceMeasureNotesWhereYouAreTheUpdatePerson = new HashSet<PerformanceMeasureNote>();
            this.ProjectsWhereYouAreThePrimaryContactPerson = new HashSet<Project>();
            this.ProjectLocationStagings = new HashSet<ProjectLocationStaging>();
            this.ProjectLocationStagingUpdates = new HashSet<ProjectLocationStagingUpdate>();
            this.ProjectNotesWhereYouAreTheCreatePerson = new HashSet<ProjectNote>();
            this.ProjectNotesWhereYouAreTheUpdatePerson = new HashSet<ProjectNote>();
            this.ProjectNoteUpdatesWhereYouAreTheCreatePerson = new HashSet<ProjectNoteUpdate>();
            this.ProjectNoteUpdatesWhereYouAreTheUpdatePerson = new HashSet<ProjectNoteUpdate>();
            this.ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson = new HashSet<ProjectUpdateBatch>();
            this.ProjectUpdateHistoriesWhereYouAreTheUpdatePerson = new HashSet<ProjectUpdateHistory>();
            this.ProposedProjectsWhereYouAreThePrimaryContactPerson = new HashSet<ProposedProject>();
            this.ProposedProjectsWhereYouAreTheProposingPerson = new HashSet<ProposedProject>();
            this.ProposedProjectsWhereYouAreTheReviewedByPerson = new HashSet<ProposedProject>();
            this.ProposedProjectLocationStagings = new HashSet<ProposedProjectLocationStaging>();
            this.ProposedProjectNotesWhereYouAreTheCreatePerson = new HashSet<ProposedProjectNote>();
            this.ProposedProjectNotesWhereYouAreTheUpdatePerson = new HashSet<ProposedProjectNote>();
            this.SupportRequestLogsWhereYouAreTheRequestPerson = new HashSet<SupportRequestLog>();
            this.TenantAttributesWhereYouAreThePrimaryContactPerson = new HashSet<TenantAttribute>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
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
            return AuditLogs.Any() || FileResourcesWhereYouAreTheCreatePerson.Any() || Notifications.Any() || OrganizationsWhereYouAreThePrimaryContactPerson.Any() || PerformanceMeasureNotesWhereYouAreTheCreatePerson.Any() || PerformanceMeasureNotesWhereYouAreTheUpdatePerson.Any() || ProjectsWhereYouAreThePrimaryContactPerson.Any() || ProjectLocationStagings.Any() || ProjectLocationStagingUpdates.Any() || ProjectNotesWhereYouAreTheCreatePerson.Any() || ProjectNotesWhereYouAreTheUpdatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheCreatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheUpdatePerson.Any() || ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson.Any() || ProjectUpdateHistoriesWhereYouAreTheUpdatePerson.Any() || ProposedProjectsWhereYouAreThePrimaryContactPerson.Any() || ProposedProjectsWhereYouAreTheProposingPerson.Any() || ProposedProjectsWhereYouAreTheReviewedByPerson.Any() || ProposedProjectLocationStagings.Any() || ProposedProjectNotesWhereYouAreTheCreatePerson.Any() || ProposedProjectNotesWhereYouAreTheUpdatePerson.Any() || SupportRequestLogsWhereYouAreTheRequestPerson.Any() || TenantAttributesWhereYouAreThePrimaryContactPerson.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Person).Name, typeof(AuditLog).Name, typeof(FileResource).Name, typeof(Notification).Name, typeof(Organization).Name, typeof(PerformanceMeasureNote).Name, typeof(Project).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectLocationStagingUpdate).Name, typeof(ProjectNote).Name, typeof(ProjectNoteUpdate).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectUpdateHistory).Name, typeof(ProposedProject).Name, typeof(ProposedProjectLocationStaging).Name, typeof(ProposedProjectNote).Name, typeof(SupportRequestLog).Name, typeof(TenantAttribute).Name};

        [Key]
        public int PersonID { get; set; }
        public int TenantID { get; private set; }
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
        public int PrimaryKey { get { return PersonID; } set { PersonID = value; } }

        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<FileResource> FileResourcesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Organization> OrganizationsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson { get; set; }
        public virtual ICollection<ProjectUpdateHistory> ProjectUpdateHistoriesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjectsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjectsWhereYouAreTheProposingPerson { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjectsWhereYouAreTheReviewedByPerson { get; set; }
        public virtual ICollection<ProposedProjectLocationStaging> ProposedProjectLocationStagings { get; set; }
        public virtual ICollection<ProposedProjectNote> ProposedProjectNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProposedProjectNote> ProposedProjectNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<SupportRequestLog> SupportRequestLogsWhereYouAreTheRequestPerson { get; set; }
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