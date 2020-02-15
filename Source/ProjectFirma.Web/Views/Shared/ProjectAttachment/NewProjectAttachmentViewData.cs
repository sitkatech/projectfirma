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
        public List<AttachmentTypeSimple> AllAttachmentTypes { get; }

        public NewProjectAttachmentViewData(IEnumerable<ProjectFirmaModels.Models.AttachmentType> attachmentTypes)
        {
            AllAttachmentTypes = attachmentTypes.Select(x => new AttachmentTypeSimple(x)).ToList();
        }
    }


    public class AttachmentTypeSimple
    {
        public int AttachmentTypeID { get; set; }
        public string AttachmentTypeName { get; set; }
        public string AttachmentTypeDescription { get; set; }
        public int MaxFileSize { get; set; }
        public int? NumberOfAllowedAttachments { get; set; }
        public List<string> AllowedFileResourceMimeTypes { get; set; }
        public List<string> AllowedFileResourceExtensions { get; set; }

        public AttachmentTypeSimple(ProjectFirmaModels.Models.AttachmentType attachmentType)
        {
            AttachmentTypeID = attachmentType.AttachmentTypeID;
            AttachmentTypeName = attachmentType.AttachmentTypeName;
            AttachmentTypeDescription = attachmentType.AttachmentTypeDescription;
            MaxFileSize = attachmentType.MaxFileSize;
            NumberOfAllowedAttachments = attachmentType.NumberOfAllowedAttachments;
            AllowedFileResourceMimeTypes =
                attachmentType.AttachmentTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeType.FileResourceMimeTypeContentTypeName).ToList();
            AllowedFileResourceExtensions = attachmentType.AttachmentTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeType.FileResourceMimeTypeDisplayName).ToList();
        }
    }




}
