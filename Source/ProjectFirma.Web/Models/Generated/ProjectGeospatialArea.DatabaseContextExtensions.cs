//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialArea]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectGeospatialArea GetProjectGeospatialArea(this IQueryable<ProjectGeospatialArea> projectGeospatialAreas, int projectGeospatialAreaID)
        {
            var projectGeospatialArea = projectGeospatialAreas.SingleOrDefault(x => x.ProjectGeospatialAreaID == projectGeospatialAreaID);
            Check.RequireNotNullThrowNotFound(projectGeospatialArea, "ProjectGeospatialArea", projectGeospatialAreaID);
            return projectGeospatialArea;
        }

        public static void DeleteProjectGeospatialArea(this List<int> projectGeospatialAreaIDList)
        {
            if(projectGeospatialAreaIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreas.Where(x => projectGeospatialAreaIDList.Contains(x.ProjectGeospatialAreaID)));
            }
        }

        public static void DeleteProjectGeospatialArea(this ICollection<ProjectGeospatialArea> projectGeospatialAreasToDelete)
        {
            if(projectGeospatialAreasToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.RemoveRange(projectGeospatialAreasToDelete);
            }
        }

        public static void DeleteProjectGeospatialArea(this int projectGeospatialAreaID)
        {
            DeleteProjectGeospatialArea(new List<int> { projectGeospatialAreaID });
        }

        public static void DeleteProjectGeospatialArea(this ProjectGeospatialArea projectGeospatialAreaToDelete)
        {
            DeleteProjectGeospatialArea(new List<ProjectGeospatialArea> { projectGeospatialAreaToDelete });
        }
    }
}