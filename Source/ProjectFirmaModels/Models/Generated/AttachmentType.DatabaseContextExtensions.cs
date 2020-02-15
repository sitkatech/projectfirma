//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AttachmentType GetAttachmentType(this IQueryable<AttachmentType> attachmentTypes, int attachmentTypeID)
        {
            var attachmentType = attachmentTypes.SingleOrDefault(x => x.AttachmentTypeID == attachmentTypeID);
            Check.RequireNotNullThrowNotFound(attachmentType, "AttachmentType", attachmentTypeID);
            return attachmentType;
        }

    }
}