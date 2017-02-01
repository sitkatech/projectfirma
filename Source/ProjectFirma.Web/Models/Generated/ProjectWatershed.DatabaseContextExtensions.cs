//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectWatershed]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteProjectWatershed(this IQueryable<ProjectWatershed> projectWatersheds, List<int> projectWatershedIDList)
        {
            if(projectWatershedIDList.Any())
            {
                projectWatersheds.Where(x => projectWatershedIDList.Contains(x.ProjectWatershedID)).Delete();
            }
        }

        public static void DeleteProjectWatershed(this IQueryable<ProjectWatershed> projectWatersheds, ICollection<ProjectWatershed> projectWatershedsToDelete)
        {
            if(projectWatershedsToDelete.Any())
            {
                var projectWatershedIDList = projectWatershedsToDelete.Select(x => x.ProjectWatershedID).ToList();
                projectWatersheds.Where(x => projectWatershedIDList.Contains(x.ProjectWatershedID)).Delete();
            }
        }

        public static void DeleteProjectWatershed(this IQueryable<ProjectWatershed> projectWatersheds, int projectWatershedID)
        {
            DeleteProjectWatershed(projectWatersheds, new List<int> { projectWatershedID });
        }

        public static void DeleteProjectWatershed(this IQueryable<ProjectWatershed> projectWatersheds, ProjectWatershed projectWatershedToDelete)
        {
            DeleteProjectWatershed(projectWatersheds, new List<ProjectWatershed> { projectWatershedToDelete });
        }
    }
}