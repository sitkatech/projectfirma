//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdate]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdate GetProjectUpdate(this IQueryable<ProjectUpdate> projectUpdates, int projectUpdateID)
        {
            var projectUpdate = projectUpdates.SingleOrDefault(x => x.ProjectUpdateID == projectUpdateID);
            Check.RequireNotNullThrowNotFound(projectUpdate, "ProjectUpdate", projectUpdateID);
            return projectUpdate;
        }

        public static void DeleteProjectUpdate(this IQueryable<ProjectUpdate> projectUpdates, List<int> projectUpdateIDList)
        {
            if(projectUpdateIDList.Any())
            {
                projectUpdates.Where(x => projectUpdateIDList.Contains(x.ProjectUpdateID)).Delete();
            }
        }

        public static void DeleteProjectUpdate(this IQueryable<ProjectUpdate> projectUpdates, ICollection<ProjectUpdate> projectUpdatesToDelete)
        {
            if(projectUpdatesToDelete.Any())
            {
                var projectUpdateIDList = projectUpdatesToDelete.Select(x => x.ProjectUpdateID).ToList();
                projectUpdates.Where(x => projectUpdateIDList.Contains(x.ProjectUpdateID)).Delete();
            }
        }

        public static void DeleteProjectUpdate(this IQueryable<ProjectUpdate> projectUpdates, int projectUpdateID)
        {
            DeleteProjectUpdate(projectUpdates, new List<int> { projectUpdateID });
        }

        public static void DeleteProjectUpdate(this IQueryable<ProjectUpdate> projectUpdates, ProjectUpdate projectUpdateToDelete)
        {
            DeleteProjectUpdate(projectUpdates, new List<ProjectUpdate> { projectUpdateToDelete });
        }
    }
}