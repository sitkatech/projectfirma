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
            this.AuditLogs = new List<AuditLog>();
            this.FileResourcesWhereYouAreTheCreatePerson = new List<FileResource>();
            this.Notifications = new List<Notification>();
            this.OrganizationsWhereYouAreThePrimaryContactPerson = new List<Organization>();
            this.PerformanceMeasureNotesWhereYouAreTheCreatePerson = new List<PerformanceMeasureNote>();
            this.PerformanceMeasureNotesWhereYouAreTheUpdatePerson = new List<PerformanceMeasureNote>();
            this.ProjectsWhereYouAreThePrimaryContactPerson = new List<Project>();
            this.ProjectsWhereYouAreTheProposingPerson = new List<Project>();
            this.ProjectsWhereYouAreTheReviewedByPerson = new List<Project>();
            this.ProjectLocationStagings = new List<ProjectLocationStaging>();
            this.ProjectLocationStagingUpdates = new List<ProjectLocationStagingUpdate>();
            this.ProjectNotesWhereYouAreTheCreatePerson = new List<ProjectNote>();
            this.ProjectNotesWhereYouAreTheUpdatePerson = new List<ProjectNote>();
            this.ProjectNoteUpdatesWhereYouAreTheCreatePerson = new List<ProjectNoteUpdate>();
            this.ProjectNoteUpdatesWhereYouAreTheUpdatePerson = new List<ProjectNoteUpdate>();
            this.ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson = new List<ProjectUpdateBatch>();
            this.ProjectUpdateHistoriesWhereYouAreTheUpdatePerson = new List<ProjectUpdateHistory>();
            this.SupportRequestLogsWhereYouAreTheRequestPerson = new List<SupportRequestLog>();
            this.TenantAttributesWhereYouAreThePrimaryContactPerson = new List<TenantAttribute>();
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
            return AuditLogs.Any() || FileResourcesWhereYouAreTheCreatePerson.Any() || Notifications.Any() || OrganizationsWhereYouAreThePrimaryContactPerson.Any() || PerformanceMeasureNotesWhereYouAreTheCreatePerson.Any() || PerformanceMeasureNotesWhereYouAreTheUpdatePerson.Any() || ProjectsWhereYouAreThePrimaryContactPerson.Any() || ProjectsWhereYouAreTheProposingPerson.Any() || ProjectsWhereYouAreTheReviewedByPerson.Any() || ProjectLocationStagings.Any() || ProjectLocationStagingUpdates.Any() || ProjectNotesWhereYouAreTheCreatePerson.Any() || ProjectNotesWhereYouAreTheUpdatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheCreatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheUpdatePerson.Any() || ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson.Any() || ProjectUpdateHistoriesWhereYouAreTheUpdatePerson.Any() || SupportRequestLogsWhereYouAreTheRequestPerson.Any() || TenantAttributesWhereYouAreThePrimaryContactPerson.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Person).Name, typeof(AuditLog).Name, typeof(FileResource).Name, typeof(Notification).Name, typeof(Organization).Name, typeof(PerformanceMeasureNote).Name, typeof(Project).Name, typeof(ProjectLocationStaging).Name, typeof(ProjectLocationStagingUpdate).Name, typeof(ProjectNote).Name, typeof(ProjectNoteUpdate).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectUpdateHistory).Name, typeof(SupportRequestLog).Name, typeof(TenantAttribute).Name};

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
        [NotMapped]
        public int PrimaryKey { get { return PersonID; } set { PersonID = value; } }

        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<FileResource> FileResourcesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Organization> OrganizationsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreTheProposingPerson { get; set; }
        public virtual ICollection<Project> ProjectsWhereYouAreTheReviewedByPerson { get; set; }
        public virtual ICollection<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual ICollection<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson { get; set; }
        public virtual ICollection<ProjectUpdateHistory> ProjectUpdateHistoriesWhereYouAreTheUpdatePerson { get; set; }
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