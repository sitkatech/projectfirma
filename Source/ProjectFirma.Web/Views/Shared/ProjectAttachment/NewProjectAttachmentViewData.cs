using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class NewProjectAttachmentViewData
    {
        public List<AttachmentRelationshipTypeSimple> AllAttachmentRelationshipTypes { get; }

        public NewProjectAttachmentViewData(IEnumerable<ProjectFirmaModels.Models.AttachmentRelationshipType> attachmentRelationshipTypes)
        {
            AllAttachmentRelationshipTypes = attachmentRelationshipTypes.Select(x => new AttachmentRelationshipTypeSimple(x)).ToList();
        }
    }


    public class AttachmentRelationshipTypeSimple
    {
        public int AttachmentRelationshipTypeID { get; set; }
        public string AttachmentRelationshipTypeName { get; set; }
        public string AttachmentRelationshipTypeDescription { get; set; }
        public int MaxFileSize { get; set; }
        public int? NumberOfAllowedAttachments { get; set; }
        public List<string> AllowedFileResourceMimeTypes { get; set; }
        public List<string> AllowedFileResourceExtensions { get; set; }

        public AttachmentRelationshipTypeSimple(ProjectFirmaModels.Models.AttachmentRelationshipType attachmentRelationshipType)
        {
            AttachmentRelationshipTypeID = attachmentRelationshipType.AttachmentRelationshipTypeID;
            AttachmentRelationshipTypeName = attachmentRelationshipType.AttachmentRelationshipTypeName;
            AttachmentRelationshipTypeDescription = attachmentRelationshipType.AttachmentRelationshipTypeDescription;
            MaxFileSize = attachmentRelationshipType.MaxFileSize;
            NumberOfAllowedAttachments = attachmentRelationshipType.NumberOfAllowedAttachments;
            AllowedFileResourceMimeTypes =
                attachmentRelationshipType.AttachmentRelationshipTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeType.FileResourceMimeTypeContentTypeName).ToList();
            AllowedFileResourceExtensions = attachmentRelationshipType.AttachmentRelationshipTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeType.FileResourceMimeTypeDisplayName).ToList();
        }
    }




}
