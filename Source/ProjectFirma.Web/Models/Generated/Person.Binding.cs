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
    public partial class Person : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Person()
        {
            this.AuditLogs = new HashSet<AuditLog>();
            this.FileResourcesWhereYouAreTheCreatePerson = new HashSet<FileResource>();
            this.IndicatorNotesWhereYouAreTheCreatePerson = new HashSet<IndicatorNote>();
            this.IndicatorNotesWhereYouAreTheUpdatePerson = new HashSet<IndicatorNote>();
            this.Notifications = new HashSet<Notification>();
            this.OrganizationsWhereYouAreThePrimaryContactPerson = new HashSet<Organization>();
            this.PersonAreas = new HashSet<PersonArea>();
            this.ProjectNotesWhereYouAreTheCreatePerson = new HashSet<ProjectNote>();
            this.ProjectNotesWhereYouAreTheUpdatePerson = new HashSet<ProjectNote>();
            this.ProjectNoteUpdatesWhereYouAreTheCreatePerson = new HashSet<ProjectNoteUpdate>();
            this.ProjectNoteUpdatesWhereYouAreTheUpdatePerson = new HashSet<ProjectNoteUpdate>();
            this.ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson = new HashSet<ProjectUpdateBatch>();
            this.ProjectUpdateHistoriesWhereYouAreTheUpdatePerson = new HashSet<ProjectUpdateHistory>();
            this.ProposedProjectsWhereYouAreTheProposingPerson = new HashSet<ProposedProject>();
            this.ProposedProjectsWhereYouAreTheReviewedByPerson = new HashSet<ProposedProject>();
            this.ProposedProjectNotesWhereYouAreTheCreatePerson = new HashSet<ProposedProjectNote>();
            this.ProposedProjectNotesWhereYouAreTheUpdatePerson = new HashSet<ProposedProjectNote>();
            this.SupportRequestLogsWhereYouAreTheRequestPerson = new HashSet<SupportRequestLog>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Person(int personID, Guid personGuid, string firstName, string lastName, string email, string phone, string passwordPdfK2SaltHash, int eIPRoleID, DateTime createDate, DateTime? updateDate, DateTime? lastActivityDate, bool isActive, int organizationID, Guid? webServiceAccessToken) : this()
        {
            this.PersonID = personID;
            this.PersonGuid = personGuid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.PasswordPdfK2SaltHash = passwordPdfK2SaltHash;
            this.EIPRoleID = eIPRoleID;
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
            this.LastActivityDate = lastActivityDate;
            this.IsActive = isActive;
            this.OrganizationID = organizationID;
            this.WebServiceAccessToken = webServiceAccessToken;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Person(Guid personGuid, string firstName, string lastName, string email, int eIPRoleID, DateTime createDate, bool isActive, int organizationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PersonID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonGuid = personGuid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.EIPRoleID = eIPRoleID;
            this.CreateDate = createDate;
            this.IsActive = isActive;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Person(Guid personGuid, string firstName, string lastName, string email, EIPRole eIPRole, DateTime createDate, bool isActive, Organization organization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonGuid = personGuid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.EIPRoleID = eIPRole.EIPRoleID;
            this.CreateDate = createDate;
            this.IsActive = isActive;
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.People.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Person CreateNewBlank(EIPRole eIPRole, Organization organization)
        {
            return new Person(default(Guid), default(string), default(string), default(string), eIPRole, default(DateTime), default(bool), organization);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AuditLogs.Any() || FileResourcesWhereYouAreTheCreatePerson.Any() || IndicatorNotesWhereYouAreTheCreatePerson.Any() || IndicatorNotesWhereYouAreTheUpdatePerson.Any() || Notifications.Any() || OrganizationsWhereYouAreThePrimaryContactPerson.Any() || PersonAreas.Any() || ProjectNotesWhereYouAreTheCreatePerson.Any() || ProjectNotesWhereYouAreTheUpdatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheCreatePerson.Any() || ProjectNoteUpdatesWhereYouAreTheUpdatePerson.Any() || ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson.Any() || ProjectUpdateHistoriesWhereYouAreTheUpdatePerson.Any() || ProposedProjectsWhereYouAreTheProposingPerson.Any() || ProposedProjectsWhereYouAreTheReviewedByPerson.Any() || ProposedProjectNotesWhereYouAreTheCreatePerson.Any() || ProposedProjectNotesWhereYouAreTheUpdatePerson.Any() || SupportRequestLogsWhereYouAreTheRequestPerson.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Person).Name, typeof(AuditLog).Name, typeof(FileResource).Name, typeof(IndicatorNote).Name, typeof(Notification).Name, typeof(Organization).Name, typeof(PersonArea).Name, typeof(ProjectNote).Name, typeof(ProjectNoteUpdate).Name, typeof(ProjectUpdateBatch).Name, typeof(ProjectUpdateHistory).Name, typeof(ProposedProject).Name, typeof(ProposedProjectNote).Name, typeof(SupportRequestLog).Name};

        [Key]
        public int PersonID { get; set; }
        public Guid PersonGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordPdfK2SaltHash { get; set; }
        public int EIPRoleID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationID { get; set; }
        public Guid? WebServiceAccessToken { get; set; }
        public int PrimaryKey { get { return PersonID; } set { PersonID = value; } }

        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<FileResource> FileResourcesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<IndicatorNote> IndicatorNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<IndicatorNote> IndicatorNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Organization> OrganizationsWhereYouAreThePrimaryContactPerson { get; set; }
        public virtual ICollection<PersonArea> PersonAreas { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNote> ProjectNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProjectNoteUpdate> ProjectNoteUpdatesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProjectUpdateBatch> ProjectUpdateBatchesWhereYouAreTheLastUpdatePerson { get; set; }
        public virtual ICollection<ProjectUpdateHistory> ProjectUpdateHistoriesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjectsWhereYouAreTheProposingPerson { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjectsWhereYouAreTheReviewedByPerson { get; set; }
        public virtual ICollection<ProposedProjectNote> ProposedProjectNotesWhereYouAreTheCreatePerson { get; set; }
        public virtual ICollection<ProposedProjectNote> ProposedProjectNotesWhereYouAreTheUpdatePerson { get; set; }
        public virtual ICollection<SupportRequestLog> SupportRequestLogsWhereYouAreTheRequestPerson { get; set; }
        public EIPRole EIPRole { get { return EIPRole.AllLookupDictionary[EIPRoleID]; } }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int FirstName = 100;
            public const int LastName = 100;
            public const int Email = 255;
            public const int Phone = 30;
            public const int PasswordPdfK2SaltHash = 1000;
        }
    }
}