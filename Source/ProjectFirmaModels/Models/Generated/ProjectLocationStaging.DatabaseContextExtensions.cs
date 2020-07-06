//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStaging]
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
        public static ProjectLocationStaging GetProjectLocationStaging(this IQueryable<ProjectLocationStaging> projectLocationStagings, int projectLocationStagingID)
        {
            var projectLocationStaging = projectLocationStagings.SingleOrDefault(x => x.ProjectLocationStagingID == projectLocationStagingID);
            Check.RequireNotNullThrowNotFound(projectLocationStaging, "ProjectLocationStaging", projectLocationStagingID);
            return projectLocationStaging;
        }

    }
}