//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationArea]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationArea GetProjectLocationArea(this IQueryable<ProjectLocationArea> projectLocationAreas, int projectLocationAreaID)
        {
            var projectLocationArea = projectLocationAreas.SingleOrDefault(x => x.ProjectLocationAreaID == projectLocationAreaID);
            Check.RequireNotNullThrowNotFound(projectLocationArea, "ProjectLocationArea", projectLocationAreaID);
            return projectLocationArea;
        }

        public static void DeleteProjectLocationArea(this List<int> projectLocationAreaIDList)
        {
            if(projectLocationAreaIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationAreas.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.Where(x => projectLocationAreaIDList.Contains(x.ProjectLocationAreaID)));
            }
        }

        public static void DeleteProjectLocationArea(this ICollection<ProjectLocationArea> projectLocationAreasToDelete)
        {
            if(projectLocationAreasToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationAreas.RemoveRange(projectLocationAreasToDelete);
            }
        }

        public static void DeleteProjectLocationArea(this int projectLocationAreaID)
        {
            DeleteProjectLocationArea(new List<int> { projectLocationAreaID });
        }

        public static void DeleteProjectLocationArea(this ProjectLocationArea projectLocationAreaToDelete)
        {
            DeleteProjectLocationArea(new List<ProjectLocationArea> { projectLocationAreaToDelete });
        }
    }
}