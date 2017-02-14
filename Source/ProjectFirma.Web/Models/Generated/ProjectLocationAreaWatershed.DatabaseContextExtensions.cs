//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaWatershed]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteProjectLocationAreaWatershed(this List<int> projectLocationAreaWatershedIDList)
        {
            if(projectLocationAreaWatershedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationAreaWatersheds.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectLocationAreaWatersheds.Where(x => projectLocationAreaWatershedIDList.Contains(x.ProjectLocationAreaWatershedID)));
            }
        }

        public static void DeleteProjectLocationAreaWatershed(this ICollection<ProjectLocationAreaWatershed> projectLocationAreaWatershedsToDelete)
        {
            if(projectLocationAreaWatershedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationAreaWatersheds.RemoveRange(projectLocationAreaWatershedsToDelete);
            }
        }

        public static void DeleteProjectLocationAreaWatershed(this int projectLocationAreaWatershedID)
        {
            DeleteProjectLocationAreaWatershed(new List<int> { projectLocationAreaWatershedID });
        }

        public static void DeleteProjectLocationAreaWatershed(this ProjectLocationAreaWatershed projectLocationAreaWatershedToDelete)
        {
            DeleteProjectLocationAreaWatershed(new List<ProjectLocationAreaWatershed> { projectLocationAreaWatershedToDelete });
        }
    }
}