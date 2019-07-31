//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudgetRelevantCostType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectBudgetRelevantCostType GetProjectBudgetRelevantCostType(this IQueryable<ProjectBudgetRelevantCostType> projectBudgetRelevantCostTypes, int projectBudgetRelevantCostTypeID)
        {
            var projectBudgetRelevantCostType = projectBudgetRelevantCostTypes.SingleOrDefault(x => x.ProjectBudgetRelevantCostTypeID == projectBudgetRelevantCostTypeID);
            Check.RequireNotNullThrowNotFound(projectBudgetRelevantCostType, "ProjectBudgetRelevantCostType", projectBudgetRelevantCostTypeID);
            return projectBudgetRelevantCostType;
        }

    }
}