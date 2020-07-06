//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vProjectAttachment]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class vProjectAttachment
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vProjectAttachment()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vProjectAttachment(int projectAttachmentID, int primaryKey, int tenantID, int projectID, int attachmentID, int attachmentTypeID, string projectAttachmentDisplayName, string projectAttachmentDescription, int fileResourceInfoID, int fileResourceMimeTypeID, string fileResourceOriginalBaseFilename, string fileResourceOriginalFileExtension, Guid fileResourceGUID, int fileResourceCreatePersonID, DateTime fileResourceCreateDate, string projectName, string attachmentTypeDescription, string attachmentTypeName) : this()
        {
            this.ProjectAttachmentID = projectAttachmentID;
            this.PrimaryKey = primaryKey;
            this.TenantID = tenantID;
            this.ProjectID = projectID;
            this.AttachmentID = attachmentID;
            this.AttachmentTypeID = attachmentTypeID;
            this.ProjectAttachmentDisplayName = projectAttachmentDisplayName;
            this.ProjectAttachmentDescription = projectAttachmentDescription;
            this.FileResourceInfoID = fileResourceInfoID;
            this.FileResourceMimeTypeID = fileResourceMimeTypeID;
            this.FileResourceOriginalBaseFilename = fileResourceOriginalBaseFilename;
            this.FileResourceOriginalFileExtension = fileResourceOriginalFileExtension;
            this.FileResourceGUID = fileResourceGUID;
            this.FileResourceCreatePersonID = fileResourceCreatePersonID;
            this.FileResourceCreateDate = fileResourceCreateDate;
            this.ProjectName = projectName;
            this.AttachmentTypeDescription = attachmentTypeDescription;
            this.AttachmentTypeName = attachmentTypeName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vProjectAttachment(vProjectAttachment vProjectAttachment) : this()
        {
            this.ProjectAttachmentID = vProjectAttachment.ProjectAttachmentID;
            this.PrimaryKey = vProjectAttachment.PrimaryKey;
            this.TenantID = vProjectAttachment.TenantID;
            this.ProjectID = vProjectAttachment.ProjectID;
            this.AttachmentID = vProjectAttachment.AttachmentID;
            this.AttachmentTypeID = vProjectAttachment.AttachmentTypeID;
            this.ProjectAttachmentDisplayName = vProjectAttachment.ProjectAttachmentDisplayName;
            this.ProjectAttachmentDescription = vProjectAttachment.ProjectAttachmentDescription;
            this.FileResourceInfoID = vProjectAttachment.FileResourceInfoID;
            this.FileResourceMimeTypeID = vProjectAttachment.FileResourceMimeTypeID;
            this.FileResourceOriginalBaseFilename = vProjectAttachment.FileResourceOriginalBaseFilename;
            this.FileResourceOriginalFileExtension = vProjectAttachment.FileResourceOriginalFileExtension;
            this.FileResourceGUID = vProjectAttachment.FileResourceGUID;
            this.FileResourceCreatePersonID = vProjectAttachment.FileResourceCreatePersonID;
            this.FileResourceCreateDate = vProjectAttachment.FileResourceCreateDate;
            this.ProjectName = vProjectAttachment.ProjectName;
            this.AttachmentTypeDescription = vProjectAttachment.AttachmentTypeDescription;
            this.AttachmentTypeName = vProjectAttachment.AttachmentTypeName;
            CallAfterConstructor(vProjectAttachment);
        }

        partial void CallAfterConstructor(vProjectAttachment vProjectAttachment);

        public int ProjectAttachmentID { get; set; }
        public int PrimaryKey { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int AttachmentID { get; set; }
        public int AttachmentTypeID { get; set; }
        public string ProjectAttachmentDisplayName { get; set; }
        public string ProjectAttachmentDescription { get; set; }
        public int FileResourceInfoID { get; set; }
        public int FileResourceMimeTypeID { get; set; }
        public string FileResourceOriginalBaseFilename { get; set; }
        public string FileResourceOriginalFileExtension { get; set; }
        public Guid FileResourceGUID { get; set; }
        public int FileResourceCreatePersonID { get; set; }
        public DateTime FileResourceCreateDate { get; set; }
        public string ProjectName { get; set; }
        public string AttachmentTypeDescription { get; set; }
        public string AttachmentTypeName { get; set; }
    }
}