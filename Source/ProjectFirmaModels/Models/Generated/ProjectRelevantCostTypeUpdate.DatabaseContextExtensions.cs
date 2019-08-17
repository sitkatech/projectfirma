//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostTypeUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectRelevantCostTypeUpdate GetProjectRelevantCostTypeUpdate(this IQueryable<ProjectRelevantCostTypeUpdate> projectRelevantCostTypeUpdates, int projectRelevantCostTypeUpdateID)
        {
            var projectRelevantCostTypeUpdate = projectRelevantCostTypeUpdates.SingleOrDefault(x => x.ProjectRelevantCostTypeUpdateID == projectRelevantCostTypeUpdateID);
            Check.RequireNotNullThrowNotFound(projectRelevantCostTypeUpdate, "ProjectRelevantCostTypeUpdate", projectRelevantCostTypeUpdateID);
            return projectRelevantCostTypeUpdate;
        }

    }
}