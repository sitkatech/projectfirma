//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStagingUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationStagingUpdate GetProjectLocationStagingUpdate(this IQueryable<ProjectLocationStagingUpdate> projectLocationStagingUpdates, int projectLocationStagingUpdateID)
        {
            var projectLocationStagingUpdate = projectLocationStagingUpdates.SingleOrDefault(x => x.ProjectLocationStagingUpdateID == projectLocationStagingUpdateID);
            Check.RequireNotNullThrowNotFound(projectLocationStagingUpdate, "ProjectLocationStagingUpdate", projectLocationStagingUpdateID);
            return projectLocationStagingUpdate;
        }

    }
}