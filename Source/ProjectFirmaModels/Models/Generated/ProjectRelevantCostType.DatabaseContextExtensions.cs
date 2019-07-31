//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectRelevantCostType GetProjectRelevantCostType(this IQueryable<ProjectRelevantCostType> projectRelevantCostTypes, int projectRelevantCostTypeID)
        {
            var projectRelevantCostType = projectRelevantCostTypes.SingleOrDefault(x => x.ProjectRelevantCostTypeID == projectRelevantCostTypeID);
            Check.RequireNotNullThrowNotFound(projectRelevantCostType, "ProjectRelevantCostType", projectRelevantCostTypeID);
            return projectRelevantCostType;
        }

    }
}