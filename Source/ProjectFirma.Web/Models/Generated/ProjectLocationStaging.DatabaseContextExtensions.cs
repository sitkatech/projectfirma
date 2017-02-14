//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStaging]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationStaging GetProjectLocationStaging(this IQueryable<ProjectLocationStaging> projectLocationStagings, int projectLocationStagingID)
        {
            var projectLocationStaging = projectLocationStagings.SingleOrDefault(x => x.ProjectLocationStagingID == projectLocationStagingID);
            Check.RequireNotNullThrowNotFound(projectLocationStaging, "ProjectLocationStaging", projectLocationStagingID);
            return projectLocationStaging;
        }

        public static void DeleteProjectLocationStaging(this List<int> projectLocationStagingIDList)
        {
            if(projectLocationStagingIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationStagings.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectLocationStagings.Where(x => projectLocationStagingIDList.Contains(x.ProjectLocationStagingID)));
            }
        }

        public static void DeleteProjectLocationStaging(this ICollection<ProjectLocationStaging> projectLocationStagingsToDelete)
        {
            if(projectLocationStagingsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationStagings.RemoveRange(projectLocationStagingsToDelete);
            }
        }

        public static void DeleteProjectLocationStaging(this int projectLocationStagingID)
        {
            DeleteProjectLocationStaging(new List<int> { projectLocationStagingID });
        }

        public static void DeleteProjectLocationStaging(this ProjectLocationStaging projectLocationStagingToDelete)
        {
            DeleteProjectLocationStaging(new List<ProjectLocationStaging> { projectLocationStagingToDelete });
        }
    }
}