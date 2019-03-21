//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateHistory]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateHistory GetProjectUpdateHistory(this IQueryable<ProjectUpdateHistory> projectUpdateHistories, int projectUpdateHistoryID)
        {
            var projectUpdateHistory = projectUpdateHistories.SingleOrDefault(x => x.ProjectUpdateHistoryID == projectUpdateHistoryID);
            Check.RequireNotNullThrowNotFound(projectUpdateHistory, "ProjectUpdateHistory", projectUpdateHistoryID);
            return projectUpdateHistory;
        }

    }
}