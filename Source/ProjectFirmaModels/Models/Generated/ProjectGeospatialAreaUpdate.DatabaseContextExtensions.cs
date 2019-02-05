//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectGeospatialAreaUpdate GetProjectGeospatialAreaUpdate(this IQueryable<ProjectGeospatialAreaUpdate> projectGeospatialAreaUpdates, int projectGeospatialAreaUpdateID)
        {
            var projectGeospatialAreaUpdate = projectGeospatialAreaUpdates.SingleOrDefault(x => x.ProjectGeospatialAreaUpdateID == projectGeospatialAreaUpdateID);
            Check.RequireNotNullThrowNotFound(projectGeospatialAreaUpdate, "ProjectGeospatialAreaUpdate", projectGeospatialAreaUpdateID);
            return projectGeospatialAreaUpdate;
        }

    }
}