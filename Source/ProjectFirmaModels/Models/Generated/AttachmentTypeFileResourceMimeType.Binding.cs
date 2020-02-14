//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeFileResourceMimeType]
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
    // Table [dbo].[AttachmentTypeFileResourceMimeType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[AttachmentTypeFileResourceMimeType]")]
    public partial class AttachmentTypeFileResourceMimeType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AttachmentTypeFileResourceMimeType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentTypeFileResourceMimeType(int attachmentTypeFileResourceMimeTypeID, int attachmentTypeID, int fileResourceMimeTypeID) : this()
        {
            this.AttachmentTypeFileResourceMimeTypeID = attachmentTypeFileResourceMimeTypeID;
            this.AttachmentTypeID = attachmentTypeID;
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentTypeFileResourceMimeType(int attachmentTypeID, int fileResourceMimeTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentTypeFileResourceMimeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AttachmentTypeID = attachmentTypeID;
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AttachmentTypeFileResourceMimeType(AttachmentType attachmentType, FileResourceMimeType fileResourceMimeType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentTypeFileResourceMimeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.AttachmentTypeID = attachmentType.AttachmentTypeID;
            this.AttachmentType = attachmentType;
            attachmentType.AttachmentTypeFileResourceMimeTypes.Add(this);
            this.FileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AttachmentTypeFileResourceMimeType CreateNewBlank(AttachmentType attachmentType, FileResourceMimeType fileResourceMimeType)
        {
            return new AttachmentTypeFileResourceMimeType(attachmentType, fileResourceMimeType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AttachmentTypeFileResourceMimeType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllAttachmentTypeFileResourceMimeTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int AttachmentTypeFileResourceMimeTypeID { get; set; }
        public int TenantID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int FileResourceMimeTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AttachmentTypeFileResourceMimeTypeID; } set { AttachmentTypeFileResourceMimeTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual AttachmentType AttachmentType { get; set; }
        public FileResourceMimeType FileResourceMimeType { get { return FileResourceMimeType.AllLookupDictionary[FileResourceMimeTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}