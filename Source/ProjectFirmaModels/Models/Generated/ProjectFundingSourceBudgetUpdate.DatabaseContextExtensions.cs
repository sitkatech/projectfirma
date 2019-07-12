//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceBudgetUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceBudgetUpdate GetProjectFundingSourceBudgetUpdate(this IQueryable<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates, int projectFundingSourceBudgetUpdateID)
        {
            var projectFundingSourceBudgetUpdate = projectFundingSourceBudgetUpdates.SingleOrDefault(x => x.ProjectFundingSourceBudgetUpdateID == projectFundingSourceBudgetUpdateID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceBudgetUpdate, "ProjectFundingSourceBudgetUpdate", projectFundingSourceBudgetUpdateID);
            return projectFundingSourceBudgetUpdate;
        }

    }
}