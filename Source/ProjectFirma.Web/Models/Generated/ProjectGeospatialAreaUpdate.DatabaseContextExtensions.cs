//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectGeospatialAreaUpdate GetProjectGeospatialAreaUpdate(this IQueryable<ProjectGeospatialAreaUpdate> projectGeospatialAreaUpdates, int projectGeospatialAreaUpdateID)
        {
            var projectGeospatialAreaUpdate = projectGeospatialAreaUpdates.SingleOrDefault(x => x.ProjectGeospatialAreaUpdateID == projectGeospatialAreaUpdateID);
            Check.RequireNotNullThrowNotFound(projectGeospatialAreaUpdate, "ProjectGeospatialAreaUpdate", projectGeospatialAreaUpdateID);
            return projectGeospatialAreaUpdate;
        }

        public static void DeleteProjectGeospatialAreaUpdate(this List<int> projectGeospatialAreaUpdateIDList)
        {
            if(projectGeospatialAreaUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreaUpdates.Where(x => projectGeospatialAreaUpdateIDList.Contains(x.ProjectGeospatialAreaUpdateID)));
            }
        }

        public static void DeleteProjectGeospatialAreaUpdate(this ICollection<ProjectGeospatialAreaUpdate> projectGeospatialAreaUpdatesToDelete)
        {
            if(projectGeospatialAreaUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaUpdates.RemoveRange(projectGeospatialAreaUpdatesToDelete);
            }
        }

        public static void DeleteProjectGeospatialAreaUpdate(this int projectGeospatialAreaUpdateID)
        {
            DeleteProjectGeospatialAreaUpdate(new List<int> { projectGeospatialAreaUpdateID });
        }

        public static void DeleteProjectGeospatialAreaUpdate(this ProjectGeospatialAreaUpdate projectGeospatialAreaUpdateToDelete)
        {
            DeleteProjectGeospatialAreaUpdate(new List<ProjectGeospatialAreaUpdate> { projectGeospatialAreaUpdateToDelete });
        }
    }
}