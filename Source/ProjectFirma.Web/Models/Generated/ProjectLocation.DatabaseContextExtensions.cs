//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocation]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocation GetProjectLocation(this IQueryable<ProjectLocation> projectLocations, int projectLocationID)
        {
            var projectLocation = projectLocations.SingleOrDefault(x => x.ProjectLocationID == projectLocationID);
            Check.RequireNotNullThrowNotFound(projectLocation, "ProjectLocation", projectLocationID);
            return projectLocation;
        }

        public static void DeleteProjectLocation(this List<int> projectLocationIDList)
        {
            if(projectLocationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocations.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectLocations.Where(x => projectLocationIDList.Contains(x.ProjectLocationID)));
            }
        }

        public static void DeleteProjectLocation(this ICollection<ProjectLocation> projectLocationsToDelete)
        {
            if(projectLocationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocations.RemoveRange(projectLocationsToDelete);
            }
        }

        public static void DeleteProjectLocation(this int projectLocationID)
        {
            DeleteProjectLocation(new List<int> { projectLocationID });
        }

        public static void DeleteProjectLocation(this ProjectLocation projectLocationToDelete)
        {
            DeleteProjectLocation(new List<ProjectLocation> { projectLocationToDelete });
        }
    }
}