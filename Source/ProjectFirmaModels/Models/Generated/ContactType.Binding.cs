//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactType]
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
    // Table [dbo].[ContactType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ContactType]")]
    public partial class ContactType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ContactType()
        {
            this.ContactTypeContactRelationshipTypes = new HashSet<ContactTypeContactRelationshipType>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContactType(int contactTypeID, string contactTypeName, string contactTypeAbbreviation, bool isDefaultContactType) : this()
        {
            this.ContactTypeID = contactTypeID;
            this.ContactTypeName = contactTypeName;
            this.ContactTypeAbbreviation = contactTypeAbbreviation;
            this.IsDefaultContactType = isDefaultContactType;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContactType(string contactTypeName, string contactTypeAbbreviation, bool isDefaultContactType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ContactTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ContactTypeName = contactTypeName;
            this.ContactTypeAbbreviation = contactTypeAbbreviation;
            this.IsDefaultContactType = isDefaultContactType;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ContactType CreateNewBlank()
        {
            return new ContactType(default(string), default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ContactTypeContactRelationshipTypes.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ContactType).Name, typeof(ContactTypeContactRelationshipType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllContactTypes.Remove(this);
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

            foreach(var x in ContactTypeContactRelationshipTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ContactTypeID { get; set; }
        public int TenantID { get; set; }
        public string ContactTypeName { get; set; }
        public string ContactTypeAbbreviation { get; set; }
        public bool IsDefaultContactType { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ContactTypeID; } set { ContactTypeID = value; } }

        public virtual ICollection<ContactTypeContactRelationshipType> ContactTypeContactRelationshipTypes { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ContactTypeName = 200;
            public const int ContactTypeAbbreviation = 100;
        }
    }
}