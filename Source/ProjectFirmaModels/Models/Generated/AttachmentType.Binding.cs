//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentType]
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
    // Table [dbo].[AttachmentType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[AttachmentType]")]
    public partial class AttachmentType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AttachmentType()
        {
            this.AttachmentTypeFileResourceMimeTypes = new HashSet<AttachmentTypeFileResourceMimeType>();
            this.AttachmentTypeTaxonomyTrunks = new HashSet<AttachmentTypeTaxonomyTrunk>();
            this.ProjectAttachments = new HashSet<ProjectAttachment>();
            this.ProjectAttachmentUpdates = new HashSet<ProjectAttachmentUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentType(int attachmentTypeID, string attachmentTypeName, string attachmentTypeDescription, int maxFileSize, int? numberOfAllowedAttachments) : this()
        {
            this.AttachmentTypeID = attachmentTypeID;
            this.AttachmentTypeName = attachmentTypeName;
            this.AttachmentTypeDescription = attachmentTypeDescription;
            this.MaxFileSize = maxFileSize;
            this.NumberOfAllowedAttachments = numberOfAllowedAttachments;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentType(string attachmentTypeName, int maxFileSize) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AttachmentTypeName = attachmentTypeName;
            this.MaxFileSize = maxFileSize;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AttachmentType CreateNewBlank()
        {
            return new AttachmentType(default(string), default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AttachmentTypeFileResourceMimeTypes.Any() || AttachmentTypeTaxonomyTrunks.Any() || ProjectAttachments.Any() || ProjectAttachmentUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AttachmentType).Name, typeof(AttachmentTypeFileResourceMimeType).Name, typeof(AttachmentTypeTaxonomyTrunk).Name, typeof(ProjectAttachment).Name, typeof(ProjectAttachmentUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllAttachmentTypes.Remove(this);
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

            foreach(var x in AttachmentTypeFileResourceMimeTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in AttachmentTypeTaxonomyTrunks.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectAttachments.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectAttachmentUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int AttachmentTypeID { get; set; }
        public int TenantID { get; set; }
        public string AttachmentTypeName { get; set; }
        public string AttachmentTypeDescription { get; set; }
        public int MaxFileSize { get; set; }
        public int? NumberOfAllowedAttachments { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AttachmentTypeID; } set { AttachmentTypeID = value; } }

        public virtual ICollection<AttachmentTypeFileResourceMimeType> AttachmentTypeFileResourceMimeTypes { get; set; }
        public virtual ICollection<AttachmentTypeTaxonomyTrunk> AttachmentTypeTaxonomyTrunks { get; set; }
        public virtual ICollection<ProjectAttachment> ProjectAttachments { get; set; }
        public virtual ICollection<ProjectAttachmentUpdate> ProjectAttachmentUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int AttachmentTypeName = 200;
            public const int AttachmentTypeDescription = 360;
        }
    }
}