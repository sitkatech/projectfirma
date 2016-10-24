//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocation]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteProjectLocation(this IQueryable<ProjectLocation> projectLocations, List<int> projectLocationIDList)
        {
            if(projectLocationIDList.Any())
            {
                projectLocations.Where(x => projectLocationIDList.Contains(x.ProjectLocationID)).Delete();
            }
        }

        public static void DeleteProjectLocation(this IQueryable<ProjectLocation> projectLocations, ICollection<ProjectLocation> projectLocationsToDelete)
        {
            if(projectLocationsToDelete.Any())
            {
                var projectLocationIDList = projectLocationsToDelete.Select(x => x.ProjectLocationID).ToList();
                projectLocations.Where(x => projectLocationIDList.Contains(x.ProjectLocationID)).Delete();
            }
        }

        public static void DeleteProjectLocation(this IQueryable<ProjectLocation> projectLocations, int projectLocationID)
        {
            DeleteProjectLocation(projectLocations, new List<int> { projectLocationID });
        }

        public static void DeleteProjectLocation(this IQueryable<ProjectLocation> projectLocations, ProjectLocation projectLocationToDelete)
        {
            DeleteProjectLocation(projectLocations, new List<ProjectLocation> { projectLocationToDelete });
        }
    }
}