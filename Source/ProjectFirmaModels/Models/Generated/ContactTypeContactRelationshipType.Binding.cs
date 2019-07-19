//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactTypeContactRelationshipType]
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
    // Table [dbo].[ContactTypeContactRelationshipType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ContactTypeContactRelationshipType]")]
    public partial class ContactTypeContactRelationshipType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ContactTypeContactRelationshipType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContactTypeContactRelationshipType(int contactTypeContactRelationshipTypeID, int contactTypeID, int contactRelationshipTypeID) : this()
        {
            this.ContactTypeContactRelationshipTypeID = contactTypeContactRelationshipTypeID;
            this.ContactTypeID = contactTypeID;
            this.ContactRelationshipTypeID = contactRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContactTypeContactRelationshipType(int contactTypeID, int contactRelationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ContactTypeContactRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ContactTypeID = contactTypeID;
            this.ContactRelationshipTypeID = contactRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ContactTypeContactRelationshipType(ContactType contactType, ContactRelationshipType contactRelationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ContactTypeContactRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ContactTypeID = contactType.ContactTypeID;
            this.ContactType = contactType;
            contactType.ContactTypeContactRelationshipTypes.Add(this);
            this.ContactRelationshipTypeID = contactRelationshipType.ContactRelationshipTypeID;
            this.ContactRelationshipType = contactRelationshipType;
            contactRelationshipType.ContactTypeContactRelationshipTypes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ContactTypeContactRelationshipType CreateNewBlank(ContactType contactType, ContactRelationshipType contactRelationshipType)
        {
            return new ContactTypeContactRelationshipType(contactType, contactRelationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ContactTypeContactRelationshipType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllContactTypeContactRelationshipTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ContactTypeContactRelationshipTypeID { get; set; }
        public int TenantID { get; set; }
        public int ContactTypeID { get; set; }
        public int ContactRelationshipTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ContactTypeContactRelationshipTypeID; } set { ContactTypeContactRelationshipTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ContactType ContactType { get; set; }
        public virtual ContactRelationshipType ContactRelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}