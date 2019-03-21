//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationUpdate GetProjectLocationUpdate(this IQueryable<ProjectLocationUpdate> projectLocationUpdates, int projectLocationUpdateID)
        {
            var projectLocationUpdate = projectLocationUpdates.SingleOrDefault(x => x.ProjectLocationUpdateID == projectLocationUpdateID);
            Check.RequireNotNullThrowNotFound(projectLocationUpdate, "ProjectLocationUpdate", projectLocationUpdateID);
            return projectLocationUpdate;
        }

    }
}