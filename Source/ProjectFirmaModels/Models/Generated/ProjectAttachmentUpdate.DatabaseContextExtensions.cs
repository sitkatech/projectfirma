//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAttachmentUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectAttachmentUpdate GetProjectAttachmentUpdate(this IQueryable<ProjectAttachmentUpdate> projectAttachmentUpdates, int projectAttachmentUpdateID)
        {
            var projectAttachmentUpdate = projectAttachmentUpdates.SingleOrDefault(x => x.ProjectAttachmentUpdateID == projectAttachmentUpdateID);
            Check.RequireNotNullThrowNotFound(projectAttachmentUpdate, "ProjectAttachmentUpdate", projectAttachmentUpdateID);
            return projectAttachmentUpdate;
        }

    }
}