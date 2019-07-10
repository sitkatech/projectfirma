//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceBudget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceBudget GetProjectFundingSourceBudget(this IQueryable<ProjectFundingSourceBudget> projectFundingSourceBudgets, int projectFundingSourceBudgetID)
        {
            var projectFundingSourceBudget = projectFundingSourceBudgets.SingleOrDefault(x => x.ProjectFundingSourceBudgetID == projectFundingSourceBudgetID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceBudget, "ProjectFundingSourceBudget", projectFundingSourceBudgetID);
            return projectFundingSourceBudget;
        }

    }
}