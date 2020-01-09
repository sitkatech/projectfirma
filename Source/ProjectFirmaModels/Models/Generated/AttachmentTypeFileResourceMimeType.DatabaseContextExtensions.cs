//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipTypeFileResourceMimeType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AttachmentRelationshipTypeFileResourceMimeType GetAttachmentRelationshipTypeFileResourceMimeType(this IQueryable<AttachmentRelationshipTypeFileResourceMimeType> attachmentRelationshipTypeFileResourceMimeTypes, int attachmentRelationshipTypeFileResourceMimeTypeID)
        {
            var attachmentRelationshipTypeFileResourceMimeType = attachmentRelationshipTypeFileResourceMimeTypes.SingleOrDefault(x => x.AttachmentRelationshipTypeFileResourceMimeTypeID == attachmentRelationshipTypeFileResourceMimeTypeID);
            Check.RequireNotNullThrowNotFound(attachmentRelationshipTypeFileResourceMimeType, "AttachmentRelationshipTypeFileResourceMimeType", attachmentRelationshipTypeFileResourceMimeTypeID);
            return attachmentRelationshipTypeFileResourceMimeType;
        }

    }
}