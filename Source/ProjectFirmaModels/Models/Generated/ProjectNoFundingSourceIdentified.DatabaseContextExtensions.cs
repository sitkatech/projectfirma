//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoFundingSourceIdentified]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectNoFundingSourceIdentified GetProjectNoFundingSourceIdentified(this IQueryable<ProjectNoFundingSourceIdentified> projectNoFundingSourceIdentifieds, int projectNoFundingSourceIdentifiedID)
        {
            var projectNoFundingSourceIdentified = projectNoFundingSourceIdentifieds.SingleOrDefault(x => x.ProjectNoFundingSourceIdentifiedID == projectNoFundingSourceIdentifiedID);
            Check.RequireNotNullThrowNotFound(projectNoFundingSourceIdentified, "ProjectNoFundingSourceIdentified", projectNoFundingSourceIdentifiedID);
            return projectNoFundingSourceIdentified;
        }

    }
}