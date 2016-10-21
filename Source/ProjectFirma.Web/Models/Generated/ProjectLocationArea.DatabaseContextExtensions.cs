//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationArea]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteProjectLocationArea(this IQueryable<ProjectLocationArea> projectLocationAreas, List<int> projectLocationAreaIDList)
        {
            if(projectLocationAreaIDList.Any())
            {
                projectLocationAreas.Where(x => projectLocationAreaIDList.Contains(x.ProjectLocationAreaID)).Delete();
            }
        }

        public static void DeleteProjectLocationArea(this IQueryable<ProjectLocationArea> projectLocationAreas, ICollection<ProjectLocationArea> projectLocationAreasToDelete)
        {
            if(projectLocationAreasToDelete.Any())
            {
                var projectLocationAreaIDList = projectLocationAreasToDelete.Select(x => x.ProjectLocationAreaID).ToList();
                projectLocationAreas.Where(x => projectLocationAreaIDList.Contains(x.ProjectLocationAreaID)).Delete();
            }
        }

        public static void DeleteProjectLocationArea(this IQueryable<ProjectLocationArea> projectLocationAreas, int projectLocationAreaID)
        {
            DeleteProjectLocationArea(projectLocationAreas, new List<int> { projectLocationAreaID });
        }

        public static void DeleteProjectLocationArea(this IQueryable<ProjectLocationArea> projectLocationAreas, ProjectLocationArea projectLocationAreaToDelete)
        {
            DeleteProjectLocationArea(projectLocationAreas, new List<ProjectLocationArea> { projectLocationAreaToDelete });
        }
    }
}