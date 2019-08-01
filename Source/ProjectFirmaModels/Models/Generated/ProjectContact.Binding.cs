//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectContact]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ProjectContact] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectContact]")]
    public partial class ProjectContact : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectContact()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectContact(int projectContactID, int projectID, int contactID, int contactRelationshipTypeID) : this()
        {
            this.ProjectContactID = projectContactID;
            this.ProjectID = projectID;
            this.ContactID = contactID;
            this.ContactRelationshipTypeID = contactRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectContact(int projectID, int contactID, int contactRelationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectContactID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.ContactID = contactID;
            this.ContactRelationshipTypeID = contactRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectContact(Project project, Person contact, ContactRelationshipType contactRelationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectContactID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectContacts.Add(this);
            this.ContactID = contact.PersonID;
            this.Contact = contact;
            contact.ProjectContactsWhereYouAreTheContact.Add(this);
            this.ContactRelationshipTypeID = contactRelationshipType.ContactRelationshipTypeID;
            this.ContactRelationshipType = contactRelationshipType;
            contactRelationshipType.ProjectContacts.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectContact CreateNewBlank(Project project, Person contact, ContactRelationshipType contactRelationshipType)
        {
            return new ProjectContact(project, contact, contactRelationshipType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectContact).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectContacts.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectContactID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int ContactID { get; set; }
        public int ContactRelationshipTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectContactID; } set { ProjectContactID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Person Contact { get; set; }
        public virtual ContactRelationshipType ContactRelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}