//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectContactUpdate]
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
    // Table [dbo].[ProjectContactUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectContactUpdate]")]
    public partial class ProjectContactUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectContactUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectContactUpdate(int projectContactUpdateID, int projectUpdateBatchID, int contactID, int contactRelationshipTypeID) : this()
        {
            this.ProjectContactUpdateID = projectContactUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ContactID = contactID;
            this.ContactRelationshipTypeID = contactRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectContactUpdate(int projectUpdateBatchID, int contactID, int contactRelationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectContactUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ContactID = contactID;
            this.ContactRelationshipTypeID = contactRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectContactUpdate(ProjectUpdateBatch projectUpdateBatch, Person contact, ContactRelationshipType contactRelationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectContactUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectContactUpdates.Add(this);
            this.ContactID = contact.PersonID;
            this.Contact = contact;
            contact.ProjectContactUpdatesWhereYouAreTheContact.Add(this);
            this.ContactRelationshipTypeID = contactRelationshipType.ContactRelationshipTypeID;
            this.ContactRelationshipType = contactRelationshipType;
            contactRelationshipType.ProjectContactUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectContactUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, Person contact, ContactRelationshipType contactRelationshipType)
        {
            return new ProjectContactUpdate(projectUpdateBatch, contact, contactRelationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectContactUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectContactUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectContactUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int ContactID { get; set; }
        public int ContactRelationshipTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectContactUpdateID; } set { ProjectContactUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual Person Contact { get; set; }
        public virtual ContactRelationshipType ContactRelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}