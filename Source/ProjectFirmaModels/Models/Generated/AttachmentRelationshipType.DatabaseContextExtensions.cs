//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AttachmentRelationshipType GetAttachmentRelationshipType(this IQueryable<AttachmentRelationshipType> attachmentRelationshipTypes, int attachmentRelationshipTypeID)
        {
            var attachmentRelationshipType = attachmentRelationshipTypes.SingleOrDefault(x => x.AttachmentRelationshipTypeID == attachmentRelationshipTypeID);
            Check.RequireNotNullThrowNotFound(attachmentRelationshipType, "AttachmentRelationshipType", attachmentRelationshipTypeID);
            return attachmentRelationshipType;
        }

    }
}