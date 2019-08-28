//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAttachmentUpdate]
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
    // Table [dbo].[ProjectAttachmentUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectAttachmentUpdate]")]
    public partial class ProjectAttachmentUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectAttachmentUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectAttachmentUpdate(int projectAttachmentUpdateID, int projectUpdateBatchID, int attachmentID, int attachmentRelationshipTypeID, string displayName, string description) : this()
        {
            this.ProjectAttachmentUpdateID = projectAttachmentUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.AttachmentID = attachmentID;
            this.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            this.DisplayName = displayName;
            this.Description = description;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectAttachmentUpdate(int projectUpdateBatchID, int attachmentID, int attachmentRelationshipTypeID, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectAttachmentUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.AttachmentID = attachmentID;
            this.AttachmentRelationshipTypeID = attachmentRelationshipTypeID;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectAttachmentUpdate(ProjectUpdateBatch projectUpdateBatch, FileResource attachment, AttachmentRelationshipType attachmentRelationshipType, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectAttachmentUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectAttachmentUpdates.Add(this);
            this.AttachmentID = attachment.FileResourceID;
            this.Attachment = attachment;
            attachment.ProjectAttachmentUpdatesWhereYouAreTheAttachment.Add(this);
            this.AttachmentRelationshipTypeID = attachmentRelationshipType.AttachmentRelationshipTypeID;
            this.AttachmentRelationshipType = attachmentRelationshipType;
            attachmentRelationshipType.ProjectAttachmentUpdates.Add(this);
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectAttachmentUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, FileResource attachment, AttachmentRelationshipType attachmentRelationshipType)
        {
            return new ProjectAttachmentUpdate(projectUpdateBatch, attachment, attachmentRelationshipType, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectAttachmentUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectAttachmentUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectAttachmentUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int AttachmentID { get; set; }
        public int AttachmentRelationshipTypeID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectAttachmentUpdateID; } set { ProjectAttachmentUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual FileResource Attachment { get; set; }
        public virtual AttachmentRelationshipType AttachmentRelationshipType { get; set; }

        public static class FieldLengths
        {
            public const int DisplayName = 200;
            public const int Description = 1000;
        }
    }
}