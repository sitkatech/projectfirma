//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeUpdate GetProjectCustomAttributeUpdate(this IQueryable<ProjectCustomAttributeUpdate> projectCustomAttributeUpdates, int projectCustomAttributeUpdateID)
        {
            var projectCustomAttributeUpdate = projectCustomAttributeUpdates.SingleOrDefault(x => x.ProjectCustomAttributeUpdateID == projectCustomAttributeUpdateID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeUpdate, "ProjectCustomAttributeUpdate", projectCustomAttributeUpdateID);
            return projectCustomAttributeUpdate;
        }

    }
}