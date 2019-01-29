//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationTypeRelationshipType]
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
    // Table [dbo].[OrganizationTypeRelationshipType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[OrganizationTypeRelationshipType]")]
    public partial class OrganizationTypeRelationshipType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected OrganizationTypeRelationshipType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationTypeRelationshipType(int organizationTypeRelationshipTypeID, int organizationTypeID, int relationshipTypeID) : this()
        {
            this.OrganizationTypeRelationshipTypeID = organizationTypeRelationshipTypeID;
            this.OrganizationTypeID = organizationTypeID;
            this.RelationshipTypeID = relationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationTypeRelationshipType(int organizationTypeID, int relationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationTypeRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationTypeID = organizationTypeID;
            this.RelationshipTypeID = relationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public OrganizationTypeRelationshipType(OrganizationType organizationType, RelationshipType relationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationTypeRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationTypeID = organizationType.OrganizationTypeID;
            this.OrganizationType = organizationType;
            organizationType.OrganizationTypeRelationshipTypes.Add(this);
            this.RelationshipTypeID = relationshipType.RelationshipTypeID;
            this.RelationshipType = relationshipType;
            relationshipType.OrganizationTypeRelationshipTypes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static OrganizationTypeRelationshipType CreateNewBlank(OrganizationType organizationType, RelationshipType relationshipType)
        {
            return new OrganizationTypeRelationshipType(organizationType, relationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(OrganizationTypeRelationshipType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllOrganizationTypeRelationshipTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int OrganizationTypeRelationshipTypeID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationTypeID { get; set; }
        public int RelationshipTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationTypeRelationshipTypeID; } set { OrganizationTypeRelationshipTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual OrganizationType OrganizationType { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}