//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoFundingSourceIdentifiedUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectNoFundingSourceIdentifiedUpdate GetProjectNoFundingSourceIdentifiedUpdate(this IQueryable<ProjectNoFundingSourceIdentifiedUpdate> projectNoFundingSourceIdentifiedUpdates, int projectNoFundingSourceIdentifiedUpdateID)
        {
            var projectNoFundingSourceIdentifiedUpdate = projectNoFundingSourceIdentifiedUpdates.SingleOrDefault(x => x.ProjectNoFundingSourceIdentifiedUpdateID == projectNoFundingSourceIdentifiedUpdateID);
            Check.RequireNotNullThrowNotFound(projectNoFundingSourceIdentifiedUpdate, "ProjectNoFundingSourceIdentifiedUpdate", projectNoFundingSourceIdentifiedUpdateID);
            return projectNoFundingSourceIdentifiedUpdate;
        }

    }
}