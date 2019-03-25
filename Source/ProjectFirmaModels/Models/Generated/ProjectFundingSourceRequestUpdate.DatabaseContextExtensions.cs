//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequestUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceRequestUpdate GetProjectFundingSourceRequestUpdate(this IQueryable<ProjectFundingSourceRequestUpdate> projectFundingSourceRequestUpdates, int projectFundingSourceRequestUpdateID)
        {
            var projectFundingSourceRequestUpdate = projectFundingSourceRequestUpdates.SingleOrDefault(x => x.ProjectFundingSourceRequestUpdateID == projectFundingSourceRequestUpdateID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceRequestUpdate, "ProjectFundingSourceRequestUpdate", projectFundingSourceRequestUpdateID);
            return projectFundingSourceRequestUpdate;
        }

    }
}