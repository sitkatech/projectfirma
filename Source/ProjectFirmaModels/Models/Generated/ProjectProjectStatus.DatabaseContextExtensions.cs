//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectProjectStatus]
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
        public static ProjectProjectStatus GetProjectProjectStatus(this IQueryable<ProjectProjectStatus> projectProjectStatuses, int projectProjectStatusID)
        {
            var projectProjectStatus = projectProjectStatuses.SingleOrDefault(x => x.ProjectProjectStatusID == projectProjectStatusID);
            Check.RequireNotNullThrowNotFound(projectProjectStatus, "ProjectProjectStatus", projectProjectStatusID);
            return projectProjectStatus;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteProjectProjectStatus(this IQueryable<ProjectProjectStatus> projectProjectStatuses, List<int> projectProjectStatusIDList)
        {
            if(projectProjectStatusIDList.Any())
            {
                projectProjectStatuses.Where(x => projectProjectStatusIDList.Contains(x.ProjectProjectStatusID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteProjectProjectStatus(this IQueryable<ProjectProjectStatus> projectProjectStatuses, ICollection<ProjectProjectStatus> projectProjectStatusesToDelete)
        {
            if(projectProjectStatusesToDelete.Any())
            {
                var projectProjectStatusIDList = projectProjectStatusesToDelete.Select(x => x.ProjectProjectStatusID).ToList();
                projectProjectStatuses.Where(x => projectProjectStatusIDList.Contains(x.ProjectProjectStatusID)).Delete();
            }
        }

        public static void DeleteProjectProjectStatus(this IQueryable<ProjectProjectStatus> projectProjectStatuses, int projectProjectStatusID)
        {
            DeleteProjectProjectStatus(projectProjectStatuses, new List<int> { projectProjectStatusID });
        }

        public static void DeleteProjectProjectStatus(this IQueryable<ProjectProjectStatus> projectProjectStatuses, ProjectProjectStatus projectProjectStatusToDelete)
        {
            DeleteProjectProjectStatus(projectProjectStatuses, new List<ProjectProjectStatus> { projectProjectStatusToDelete });
        }
    }
}