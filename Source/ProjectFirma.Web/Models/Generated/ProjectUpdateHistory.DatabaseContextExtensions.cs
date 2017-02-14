//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateHistory]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateHistory GetProjectUpdateHistory(this IQueryable<ProjectUpdateHistory> projectUpdateHistories, int projectUpdateHistoryID)
        {
            var projectUpdateHistory = projectUpdateHistories.SingleOrDefault(x => x.ProjectUpdateHistoryID == projectUpdateHistoryID);
            Check.RequireNotNullThrowNotFound(projectUpdateHistory, "ProjectUpdateHistory", projectUpdateHistoryID);
            return projectUpdateHistory;
        }

        public static void DeleteProjectUpdateHistory(this List<int> projectUpdateHistoryIDList)
        {
            if(projectUpdateHistoryIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateHistories.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectUpdateHistories.Where(x => projectUpdateHistoryIDList.Contains(x.ProjectUpdateHistoryID)));
            }
        }

        public static void DeleteProjectUpdateHistory(this ICollection<ProjectUpdateHistory> projectUpdateHistoriesToDelete)
        {
            if(projectUpdateHistoriesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateHistories.RemoveRange(projectUpdateHistoriesToDelete);
            }
        }

        public static void DeleteProjectUpdateHistory(this int projectUpdateHistoryID)
        {
            DeleteProjectUpdateHistory(new List<int> { projectUpdateHistoryID });
        }

        public static void DeleteProjectUpdateHistory(this ProjectUpdateHistory projectUpdateHistoryToDelete)
        {
            DeleteProjectUpdateHistory(new List<ProjectUpdateHistory> { projectUpdateHistoryToDelete });
        }
    }
}