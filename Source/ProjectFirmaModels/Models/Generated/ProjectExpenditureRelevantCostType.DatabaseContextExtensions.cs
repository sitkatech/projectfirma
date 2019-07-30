//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExpenditureRelevantCostType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExpenditureRelevantCostType GetProjectExpenditureRelevantCostType(this IQueryable<ProjectExpenditureRelevantCostType> projectExpenditureRelevantCostTypes, int projectExpenditureRelevantCostTypeID)
        {
            var projectExpenditureRelevantCostType = projectExpenditureRelevantCostTypes.SingleOrDefault(x => x.ProjectExpenditureRelevantCostTypeID == projectExpenditureRelevantCostTypeID);
            Check.RequireNotNullThrowNotFound(projectExpenditureRelevantCostType, "ProjectExpenditureRelevantCostType", projectExpenditureRelevantCostTypeID);
            return projectExpenditureRelevantCostType;
        }

    }
}