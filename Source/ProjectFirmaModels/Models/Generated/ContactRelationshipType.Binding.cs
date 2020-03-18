//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactRelationshipType]
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
    // Table [dbo].[ContactRelationshipType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ContactRelationshipType]")]
    public partial class ContactRelationshipType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ContactRelationshipType()
        {
            this.ProjectContacts = new HashSet<ProjectContact>();
            this.ProjectContactUpdates = new HashSet<ProjectContactUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContactRelationshipType(int contactRelationshipTypeID, string contactRelationshipTypeName, bool isContactRelationshipTypeRequired, string contactRelationshipTypeDescription) : this()
        {
            this.ContactRelationshipTypeID = contactRelationshipTypeID;
            this.ContactRelationshipTypeName = contactRelationshipTypeName;
            this.IsContactRelationshipTypeRequired = isContactRelationshipTypeRequired;
            this.ContactRelationshipTypeDescription = contactRelationshipTypeDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContactRelationshipType(string contactRelationshipTypeName, bool isContactRelationshipTypeRequired) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ContactRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ContactRelationshipTypeName = contactRelationshipTypeName;
            this.IsContactRelationshipTypeRequired = isContactRelationshipTypeRequired;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ContactRelationshipType CreateNewBlank()
        {
            return new ContactRelationshipType(default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectContacts.Any() || ProjectContactUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ContactRelationshipType).Name, typeof(ProjectContact).Name, typeof(ProjectContactUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllContactRelationshipTypes.Remove(this);
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

            foreach(var x in ProjectContacts.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectContactUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ContactRelationshipTypeID { get; set; }
        public int TenantID { get; set; }
        public string ContactRelationshipTypeName { get; set; }
        public bool IsContactRelationshipTypeRequired { get; set; }
        public string ContactRelationshipTypeDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ContactRelationshipTypeID; } set { ContactRelationshipTypeID = value; } }

        public virtual ICollection<ProjectContact> ProjectContacts { get; set; }
        public virtual ICollection<ProjectContactUpdate> ProjectContactUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ContactRelationshipTypeName = 200;
            public const int ContactRelationshipTypeDescription = 360;
        }
    }
}