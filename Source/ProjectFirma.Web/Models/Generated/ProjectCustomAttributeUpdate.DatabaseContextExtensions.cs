//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeUpdate GetProjectCustomAttributeUpdate(this IQueryable<ProjectCustomAttributeUpdate> projectCustomAttributeUpdates, int projectCustomAttributeUpdateID)
        {
            var projectCustomAttributeUpdate = projectCustomAttributeUpdates.SingleOrDefault(x => x.ProjectCustomAttributeUpdateID == projectCustomAttributeUpdateID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeUpdate, "ProjectCustomAttributeUpdate", projectCustomAttributeUpdateID);
            return projectCustomAttributeUpdate;
        }

        public static void DeleteProjectCustomAttributeUpdate(this List<int> projectCustomAttributeUpdateIDList)
        {
            if(projectCustomAttributeUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeUpdates.Where(x => projectCustomAttributeUpdateIDList.Contains(x.ProjectCustomAttributeUpdateID)));
            }
        }

        public static void DeleteProjectCustomAttributeUpdate(this ICollection<ProjectCustomAttributeUpdate> projectCustomAttributeUpdatesToDelete)
        {
            if(projectCustomAttributeUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeUpdates.RemoveRange(projectCustomAttributeUpdatesToDelete);
            }
        }

        public static void DeleteProjectCustomAttributeUpdate(this int projectCustomAttributeUpdateID)
        {
            DeleteProjectCustomAttributeUpdate(new List<int> { projectCustomAttributeUpdateID });
        }

        public static void DeleteProjectCustomAttributeUpdate(this ProjectCustomAttributeUpdate projectCustomAttributeUpdateToDelete)
        {
            DeleteProjectCustomAttributeUpdate(new List<ProjectCustomAttributeUpdate> { projectCustomAttributeUpdateToDelete });
        }
    }
}