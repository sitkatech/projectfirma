//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationTypeOrganizationRelationshipType]
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
    // Table [dbo].[OrganizationTypeOrganizationRelationshipType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[OrganizationTypeOrganizationRelationshipType]")]
    public partial class OrganizationTypeOrganizationRelationshipType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected OrganizationTypeOrganizationRelationshipType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationTypeOrganizationRelationshipType(int organizationTypeOrganizationRelationshipTypeID, int organizationTypeID, int organizationRelationshipTypeID) : this()
        {
            this.OrganizationTypeOrganizationRelationshipTypeID = organizationTypeOrganizationRelationshipTypeID;
            this.OrganizationTypeID = organizationTypeID;
            this.OrganizationRelationshipTypeID = organizationRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationTypeOrganizationRelationshipType(int organizationTypeID, int organizationRelationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationTypeOrganizationRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationTypeID = organizationTypeID;
            this.OrganizationRelationshipTypeID = organizationRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public OrganizationTypeOrganizationRelationshipType(OrganizationType organizationType, OrganizationRelationshipType organizationRelationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationTypeOrganizationRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationTypeID = organizationType.OrganizationTypeID;
            this.OrganizationType = organizationType;
            organizationType.OrganizationTypeOrganizationRelationshipTypes.Add(this);
            this.OrganizationRelationshipTypeID = organizationRelationshipType.OrganizationRelationshipTypeID;
            this.OrganizationRelationshipType = organizationRelationshipType;
            organizationRelationshipType.OrganizationTypeOrganizationRelationshipTypes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static OrganizationTypeOrganizationRelationshipType CreateNewBlank(OrganizationType organizationType, OrganizationRelationshipType organizationRelationshipType)
        {
            return new OrganizationTypeOrganizationRelationshipType(organizationType, organizationRelationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(OrganizationTypeOrganizationRelationshipType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllOrganizationTypeOrganizationRelationshipTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int OrganizationTypeOrganizationRelationshipTypeID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationTypeID { get; set; }
        public int OrganizationRelationshipTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationTypeOrganizationRelationshipTypeID; } set { OrganizationTypeOrganizationRelationshipTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual OrganizationType OrganizationType { get; set; }
        public virtual OrganizationRelationshipType OrganizationRelationshipType { get; set; }

        public static class FieldLengths
        {

        }
    }
}