//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

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

        public static void DeleteProjectUpdate(this List<int> projectUpdateIDList)
        {
            if(projectUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectUpdates.Where(x => projectUpdateIDList.Contains(x.ProjectUpdateID)));
            }
        }

        public static void DeleteProjectUpdate(this ICollection<ProjectUpdate> projectUpdatesToDelete)
        {
            if(projectUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdates.RemoveRange(projectUpdatesToDelete);
            }
        }

        public static void DeleteProjectUpdate(this int projectUpdateID)
        {
            DeleteProjectUpdate(new List<int> { projectUpdateID });
        }

        public static void DeleteProjectUpdate(this ProjectUpdate projectUpdateToDelete)
        {
            DeleteProjectUpdate(new List<ProjectUpdate> { projectUpdateToDelete });
        }
    }
}