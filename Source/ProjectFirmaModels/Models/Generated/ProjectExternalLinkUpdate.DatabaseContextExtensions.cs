//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLinkUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExternalLinkUpdate GetProjectExternalLinkUpdate(this IQueryable<ProjectExternalLinkUpdate> projectExternalLinkUpdates, int projectExternalLinkUpdateID)
        {
            var projectExternalLinkUpdate = projectExternalLinkUpdates.SingleOrDefault(x => x.ProjectExternalLinkUpdateID == projectExternalLinkUpdateID);
            Check.RequireNotNullThrowNotFound(projectExternalLinkUpdate, "ProjectExternalLinkUpdate", projectExternalLinkUpdateID);
            return projectExternalLinkUpdate;
        }

    }
}