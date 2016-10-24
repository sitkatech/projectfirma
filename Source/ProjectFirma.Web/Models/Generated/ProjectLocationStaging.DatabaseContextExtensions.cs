//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStaging]
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
        public static ProjectLocationStaging GetProjectLocationStaging(this IQueryable<ProjectLocationStaging> projectLocationStagings, int projectLocationStagingID)
        {
            var projectLocationStaging = projectLocationStagings.SingleOrDefault(x => x.ProjectLocationStagingID == projectLocationStagingID);
            Check.RequireNotNullThrowNotFound(projectLocationStaging, "ProjectLocationStaging", projectLocationStagingID);
            return projectLocationStaging;
        }

        public static void DeleteProjectLocationStaging(this IQueryable<ProjectLocationStaging> projectLocationStagings, List<int> projectLocationStagingIDList)
        {
            if(projectLocationStagingIDList.Any())
            {
                projectLocationStagings.Where(x => projectLocationStagingIDList.Contains(x.ProjectLocationStagingID)).Delete();
            }
        }

        public static void DeleteProjectLocationStaging(this IQueryable<ProjectLocationStaging> projectLocationStagings, ICollection<ProjectLocationStaging> projectLocationStagingsToDelete)
        {
            if(projectLocationStagingsToDelete.Any())
            {
                var projectLocationStagingIDList = projectLocationStagingsToDelete.Select(x => x.ProjectLocationStagingID).ToList();
                projectLocationStagings.Where(x => projectLocationStagingIDList.Contains(x.ProjectLocationStagingID)).Delete();
            }
        }

        public static void DeleteProjectLocationStaging(this IQueryable<ProjectLocationStaging> projectLocationStagings, int projectLocationStagingID)
        {
            DeleteProjectLocationStaging(projectLocationStagings, new List<int> { projectLocationStagingID });
        }

        public static void DeleteProjectLocationStaging(this IQueryable<ProjectLocationStaging> projectLocationStagings, ProjectLocationStaging projectLocationStagingToDelete)
        {
            DeleteProjectLocationStaging(projectLocationStagings, new List<ProjectLocationStaging> { projectLocationStagingToDelete });
        }
    }
}