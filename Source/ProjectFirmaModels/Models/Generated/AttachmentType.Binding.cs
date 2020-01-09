//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipType]
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
    // Table [dbo].[AttachmentRelationshipType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[AttachmentRelationshipType]")]
    public partial class AttachmentRelationshipType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AttachmentRelationshipType()
        {
            this.AttachmentRelationshipTypeFileResourceMimeTypes = new HashSet<AttachmentRelationshipTypeFileResourceMimeType>();
            this.AttachmentRelationshipTypeTaxonomyTrunks = new HashSet<AttachmentRelationshipTypeTaxonomyTrunk>();
            this.ProjectAttachments = new HashSet<ProjectAttachment>();
            this.ProjectAttachmentUpdates = new HashSet<ProjectAttachmentUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentRelationshipType(int attachmentRelationshipTypeID, string attachmentRelationshipTypeName, string attachmentRelationshipTypeDescription, int maxFileSize, int? numberOfAllowedAttachments) : this()
        {
            this.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            this.AttachmentRelationshipTypeName = attachmentRelationshipTypeName;
            this.AttachmentRelationshipTypeDescription = attachmentRelationshipTypeDescription;
            this.MaxFileSize = maxFileSize;
            this.NumberOfAllowedAttachments = numberOfAllowedAttachments;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentRelationshipType(string attachmentRelationshipTypeName, int maxFileSize) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentRelationshipTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AttachmentRelationshipTypeName = attachmentRelationshipTypeName;
            this.MaxFileSize = maxFileSize;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AttachmentRelationshipType CreateNewBlank()
        {
            return new AttachmentRelationshipType(default(string), default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AttachmentRelationshipTypeFileResourceMimeTypes.Any() || AttachmentRelationshipTypeTaxonomyTrunks.Any() || ProjectAttachments.Any() || ProjectAttachmentUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AttachmentRelationshipType).Name, typeof(AttachmentRelationshipTypeFileResourceMimeType).Name, typeof(AttachmentRelationshipTypeTaxonomyTrunk).Name, typeof(ProjectAttachment).Name, typeof(ProjectAttachmentUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllAttachmentRelationshipTypes.Remove(this);
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

            foreach(var x in AttachmentRelationshipTypeFileResourceMimeTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in AttachmentRelationshipTypeTaxonomyTrunks.ToList())
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
        public int AttachmentRelationshipTypeID { get; set; }
        public int TenantID { get; set; }
        public string AttachmentRelationshipTypeName { get; set; }
        public string AttachmentRelationshipTypeDescription { get; set; }
        public int MaxFileSize { get; set; }
        public int? NumberOfAllowedAttachments { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AttachmentRelationshipTypeID; } set { AttachmentRelationshipTypeID = value; } }

        public virtual ICollection<AttachmentRelationshipTypeFileResourceMimeType> AttachmentRelationshipTypeFileResourceMimeTypes { get; set; }
        public virtual ICollection<AttachmentRelationshipTypeTaxonomyTrunk> AttachmentRelationshipTypeTaxonomyTrunks { get; set; }
        public virtual ICollection<ProjectAttachment> ProjectAttachments { get; set; }
        public virtual ICollection<ProjectAttachmentUpdate> ProjectAttachmentUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int AttachmentRelationshipTypeName = 200;
            public const int AttachmentRelationshipTypeDescription = 360;
        }
    }
}