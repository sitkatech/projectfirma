//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipTypeFileResourceMimeType]
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
    // Table [dbo].[AttachmentRelationshipTypeFileResourceMimeType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[AttachmentRelationshipTypeFileResourceMimeType]")]
    public partial class AttachmentRelationshipTypeFileResourceMimeType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AttachmentRelationshipTypeFileResourceMimeType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentRelationshipTypeFileResourceMimeType(int attachmentRelationshipTypeFileResourceMimeTypeID, int attachmentRelationshipTypeID, int fileResourceMimeTypeID) : this()
        {
            this.AttachmentRelationshipTypeFileResourceMimeTypeID = attachmentRelationshipTypeFileResourceMimeTypeID;
            this.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentRelationshipTypeFileResourceMimeType(int attachmentRelationshipTypeID, int fileResourceMimeTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentRelationshipTypeFileResourceMimeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AttachmentRelationshipTypeFileResourceMimeType(AttachmentRelationshipType attachmentRelationshipType, FileResourceMimeType fileResourceMimeType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentRelationshipTypeFileResourceMimeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.AttachmentRelationshipTypeID = attachmentRelationshipType.AttachmentRelationshipTypeID;
            this.AttachmentRelationshipType = attachmentRelationshipType;
            attachmentRelationshipType.AttachmentRelationshipTypeFileResourceMimeTypes.Add(this);
            this.FileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AttachmentRelationshipTypeFileResourceMimeType CreateNewBlank(AttachmentRelationshipType attachmentRelationshipType, FileResourceMimeType fileResourceMimeType)
        {
            return new AttachmentRelationshipTypeFileResourceMimeType(attachmentRelationshipType, fileResourceMimeType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AttachmentRelationshipTypeFileResourceMimeType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllAttachmentRelationshipTypeFileResourceMimeTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int AttachmentRelationshipTypeFileResourceMimeTypeID { get; set; }
        public int TenantID { get; set; }
        public int AttachmentRelationshipTypeID { get; set; }
        public int FileResourceMimeTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AttachmentRelationshipTypeFileResourceMimeTypeID; } set { AttachmentRelationshipTypeFileResourceMimeTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual AttachmentRelationshipType AttachmentRelationshipType { get; set; }
        public FileResourceMimeType FileResourceMimeType { get { return FileResourceMimeType.AllLookupDictionary[FileResourceMimeTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}