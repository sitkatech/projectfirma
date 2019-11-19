//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStatus]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        // Delete using an IDList (Firma style)
        public static void DeleteProjectStatus(this IQueryable<ProjectStatus> projectStatuses, List<int> projectStatusIDList)
        {
            if(projectStatusIDList.Any())
            {
                projectStatuses.Where(x => projectStatusIDList.Contains(x.ProjectStatusID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteProjectStatus(this IQueryable<ProjectStatus> projectStatuses, ICollection<ProjectStatus> projectStatusesToDelete)
        {
            if(projectStatusesToDelete.Any())
            {
                var projectStatusIDList = projectStatusesToDelete.Select(x => x.ProjectStatusID).ToList();
                projectStatuses.Where(x => projectStatusIDList.Contains(x.ProjectStatusID)).Delete();
            }
        }

        public static void DeleteProjectStatus(this IQueryable<ProjectStatus> projectStatuses, int projectStatusID)
        {
            DeleteProjectStatus(projectStatuses, new List<int> { projectStatusID });
        }

        public static void DeleteProjectStatus(this IQueryable<ProjectStatus> projectStatuses, ProjectStatus projectStatusToDelete)
        {
            DeleteProjectStatus(projectStatuses, new List<ProjectStatus> { projectStatusToDelete });
        }
    }
}