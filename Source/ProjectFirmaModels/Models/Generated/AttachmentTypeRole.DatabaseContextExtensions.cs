//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeRole]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AttachmentTypeRole GetAttachmentTypeRole(this IQueryable<AttachmentTypeRole> attachmentTypeRoles, int attachmentTypeRoleID)
        {
            var attachmentTypeRole = attachmentTypeRoles.SingleOrDefault(x => x.AttachmentTypeRoleID == attachmentTypeRoleID);
            Check.RequireNotNullThrowNotFound(attachmentTypeRole, "AttachmentTypeRole", attachmentTypeRoleID);
            return attachmentTypeRole;
        }

    }
}