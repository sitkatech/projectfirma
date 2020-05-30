//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditureUpdate]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceExpenditureUpdate GetProjectFundingSourceExpenditureUpdate(this IQueryable<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, int projectFundingSourceExpenditureUpdateID)
        {
            var projectFundingSourceExpenditureUpdate = projectFundingSourceExpenditureUpdates.SingleOrDefault(x => x.ProjectFundingSourceExpenditureUpdateID == projectFundingSourceExpenditureUpdateID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceExpenditureUpdate, "ProjectFundingSourceExpenditureUpdate", projectFundingSourceExpenditureUpdateID);
            return projectFundingSourceExpenditureUpdate;
        }

    }
}