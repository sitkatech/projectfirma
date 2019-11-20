//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectProjectStatus]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectProjectStatus GetProjectProjectStatus(this IQueryable<ProjectProjectStatus> projectProjectStatuses, int projectProjectStatusID)
        {
            var projectProjectStatus = projectProjectStatuses.SingleOrDefault(x => x.ProjectProjectStatusID == projectProjectStatusID);
            Check.RequireNotNullThrowNotFound(projectProjectStatus, "ProjectProjectStatus", projectProjectStatusID);
            return projectProjectStatus;
        }

    }
}