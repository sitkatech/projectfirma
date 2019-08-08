//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAttachment]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectAttachment GetProjectAttachment(this IQueryable<ProjectAttachment> projectAttachments, int projectAttachmentID)
        {
            var projectAttachment = projectAttachments.SingleOrDefault(x => x.ProjectAttachmentID == projectAttachmentID);
            Check.RequireNotNullThrowNotFound(projectAttachment, "ProjectAttachment", projectAttachmentID);
            return projectAttachment;
        }

    }
}