//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImageUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectImageUpdate GetProjectImageUpdate(this IQueryable<ProjectImageUpdate> projectImageUpdates, int projectImageUpdateID)
        {
            var projectImageUpdate = projectImageUpdates.SingleOrDefault(x => x.ProjectImageUpdateID == projectImageUpdateID);
            Check.RequireNotNullThrowNotFound(projectImageUpdate, "ProjectImageUpdate", projectImageUpdateID);
            return projectImageUpdate;
        }

    }
}