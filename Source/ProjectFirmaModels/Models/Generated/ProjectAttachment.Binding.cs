//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAttachment]
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
    // Table [dbo].[ProjectAttachment] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectAttachment]")]
    public partial class ProjectAttachment : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectAttachment()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectAttachment(int projectAttachmentID, int projectID, int attachmentID, int attachmentTypeID, string displayName, string description) : this()
        {
            this.ProjectAttachmentID = projectAttachmentID;
            this.ProjectID = projectID;
            this.AttachmentID = attachmentID;
            this.AttachmentTypeID = attachmentTypeID;
            this.DisplayName = displayName;
            this.Description = description;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectAttachment(int projectID, int attachmentID, int attachmentTypeID, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectAttachmentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.AttachmentID = attachmentID;
            this.AttachmentTypeID = attachmentTypeID;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectAttachment(Project project, FileResource attachment, AttachmentType attachmentType, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectAttachmentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectAttachments.Add(this);
            this.AttachmentID = attachment.FileResourceID;
            this.Attachment = attachment;
            attachment.ProjectAttachmentsWhereYouAreTheAttachment.Add(this);
            this.AttachmentTypeID = attachmentType.AttachmentTypeID;
            this.AttachmentType = attachmentType;
            attachmentType.ProjectAttachments.Add(this);
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectAttachment CreateNewBlank(Project project, FileResource attachment, AttachmentType attachmentType)
        {
            return new ProjectAttachment(project, attachment, attachmentType, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectAttachment).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectAttachments.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectAttachmentID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int AttachmentID { get; set; }
        public int AttachmentTypeID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectAttachmentID; } set { ProjectAttachmentID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual FileResource Attachment { get; set; }
        public virtual AttachmentType AttachmentType { get; set; }

        public static class FieldLengths
        {
            public const int DisplayName = 200;
            public const int Description = 1000;
        }
    }
}