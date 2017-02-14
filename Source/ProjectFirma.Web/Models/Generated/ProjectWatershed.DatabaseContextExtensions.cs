//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectWatershed]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectWatershed GetProjectWatershed(this IQueryable<ProjectWatershed> projectWatersheds, int projectWatershedID)
        {
            var projectWatershed = projectWatersheds.SingleOrDefault(x => x.ProjectWatershedID == projectWatershedID);
            Check.RequireNotNullThrowNotFound(projectWatershed, "ProjectWatershed", projectWatershedID);
            return projectWatershed;
        }

        public static void DeleteProjectWatershed(this List<int> projectWatershedIDList)
        {
            if(projectWatershedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectWatersheds.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectWatersheds.Where(x => projectWatershedIDList.Contains(x.ProjectWatershedID)));
            }
        }

        public static void DeleteProjectWatershed(this ICollection<ProjectWatershed> projectWatershedsToDelete)
        {
            if(projectWatershedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectWatersheds.RemoveRange(projectWatershedsToDelete);
            }
        }

        public static void DeleteProjectWatershed(this int projectWatershedID)
        {
            DeleteProjectWatershed(new List<int> { projectWatershedID });
        }

        public static void DeleteProjectWatershed(this ProjectWatershed projectWatershedToDelete)
        {
            DeleteProjectWatershed(new List<ProjectWatershed> { projectWatershedToDelete });
        }
    }
}