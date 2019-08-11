//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]
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
    // Table [dbo].[AttachmentRelationshipTypeTaxonomyTrunk] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[AttachmentRelationshipTypeTaxonomyTrunk]")]
    public partial class AttachmentRelationshipTypeTaxonomyTrunk : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AttachmentRelationshipTypeTaxonomyTrunk()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentRelationshipTypeTaxonomyTrunk(int attachmentRelationshipTypeTaxonomyTrunkID, int attachmentRelationshipTypeID, int taxonomyTrunkID) : this()
        {
            this.AttachmentRelationshipTypeTaxonomyTrunkID = attachmentRelationshipTypeTaxonomyTrunkID;
            this.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            this.TaxonomyTrunkID = taxonomyTrunkID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentRelationshipTypeTaxonomyTrunk(int attachmentRelationshipTypeID, int taxonomyTrunkID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentRelationshipTypeTaxonomyTrunkID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            this.TaxonomyTrunkID = taxonomyTrunkID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AttachmentRelationshipTypeTaxonomyTrunk(AttachmentRelationshipType attachmentRelationshipType, TaxonomyTrunk taxonomyTrunk) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentRelationshipTypeTaxonomyTrunkID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.AttachmentRelationshipTypeID = attachmentRelationshipType.AttachmentRelationshipTypeID;
            this.AttachmentRelationshipType = attachmentRelationshipType;
            attachmentRelationshipType.AttachmentRelationshipTypeTaxonomyTrunks.Add(this);
            this.TaxonomyTrunkID = taxonomyTrunk.TaxonomyTrunkID;
            this.TaxonomyTrunk = taxonomyTrunk;
            taxonomyTrunk.AttachmentRelationshipTypeTaxonomyTrunks.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AttachmentRelationshipTypeTaxonomyTrunk CreateNewBlank(AttachmentRelationshipType attachmentRelationshipType, TaxonomyTrunk taxonomyTrunk)
        {
            return new AttachmentRelationshipTypeTaxonomyTrunk(attachmentRelationshipType, taxonomyTrunk);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AttachmentRelationshipTypeTaxonomyTrunk).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllAttachmentRelationshipTypeTaxonomyTrunks.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int AttachmentRelationshipTypeTaxonomyTrunkID { get; set; }
        public int TenantID { get; set; }
        public int AttachmentRelationshipTypeID { get; set; }
        public int TaxonomyTrunkID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AttachmentRelationshipTypeTaxonomyTrunkID; } set { AttachmentRelationshipTypeTaxonomyTrunkID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual AttachmentRelationshipType AttachmentRelationshipType { get; set; }
        public virtual TaxonomyTrunk TaxonomyTrunk { get; set; }

        public static class FieldLengths
        {

        }
    }
}