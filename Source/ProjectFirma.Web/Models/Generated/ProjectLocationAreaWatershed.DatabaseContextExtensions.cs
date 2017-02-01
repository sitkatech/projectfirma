//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaWatershed]
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
        public static ProjectLocationAreaWatershed GetProjectLocationAreaWatershed(this IQueryable<ProjectLocationAreaWatershed> projectLocationAreaWatersheds, int projectLocationAreaWatershedID)
        {
            var projectLocationAreaWatershed = projectLocationAreaWatersheds.SingleOrDefault(x => x.ProjectLocationAreaWatershedID == projectLocationAreaWatershedID);
            Check.RequireNotNullThrowNotFound(projectLocationAreaWatershed, "ProjectLocationAreaWatershed", projectLocationAreaWatershedID);
            return projectLocationAreaWatershed;
        }

        public static void DeleteProjectLocationAreaWatershed(this IQueryable<ProjectLocationAreaWatershed> projectLocationAreaWatersheds, List<int> projectLocationAreaWatershedIDList)
        {
            if(projectLocationAreaWatershedIDList.Any())
            {
                projectLocationAreaWatersheds.Where(x => projectLocationAreaWatershedIDList.Contains(x.ProjectLocationAreaWatershedID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaWatershed(this IQueryable<ProjectLocationAreaWatershed> projectLocationAreaWatersheds, ICollection<ProjectLocationAreaWatershed> projectLocationAreaWatershedsToDelete)
        {
            if(projectLocationAreaWatershedsToDelete.Any())
            {
                var projectLocationAreaWatershedIDList = projectLocationAreaWatershedsToDelete.Select(x => x.ProjectLocationAreaWatershedID).ToList();
                projectLocationAreaWatersheds.Where(x => projectLocationAreaWatershedIDList.Contains(x.ProjectLocationAreaWatershedID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaWatershed(this IQueryable<ProjectLocationAreaWatershed> projectLocationAreaWatersheds, int projectLocationAreaWatershedID)
        {
            DeleteProjectLocationAreaWatershed(projectLocationAreaWatersheds, new List<int> { projectLocationAreaWatershedID });
        }

        public static void DeleteProjectLocationAreaWatershed(this IQueryable<ProjectLocationAreaWatershed> projectLocationAreaWatersheds, ProjectLocationAreaWatershed projectLocationAreaWatershedToDelete)
        {
            DeleteProjectLocationAreaWatershed(projectLocationAreaWatersheds, new List<ProjectLocationAreaWatershed> { projectLocationAreaWatershedToDelete });
        }
    }
}