//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStatus]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectStatus GetProjectStatus(this IQueryable<ProjectStatus> projectStatuses, int projectStatusID)
        {
            var projectStatus = projectStatuses.SingleOrDefault(x => x.ProjectStatusID == projectStatusID);
            Check.RequireNotNullThrowNotFound(projectStatus, "ProjectStatus", projectStatusID);
            return projectStatus;
        }

    }
}