//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeFileResourceMimeType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AttachmentTypeFileResourceMimeType GetAttachmentTypeFileResourceMimeType(this IQueryable<AttachmentTypeFileResourceMimeType> attachmentTypeFileResourceMimeTypes, int attachmentTypeFileResourceMimeTypeID)
        {
            var attachmentTypeFileResourceMimeType = attachmentTypeFileResourceMimeTypes.SingleOrDefault(x => x.AttachmentTypeFileResourceMimeTypeID == attachmentTypeFileResourceMimeTypeID);
            Check.RequireNotNullThrowNotFound(attachmentTypeFileResourceMimeType, "AttachmentTypeFileResourceMimeType", attachmentTypeFileResourceMimeTypeID);
            return attachmentTypeFileResourceMimeType;
        }

    }
}