//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganizationUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectOrganizationUpdate GetProjectOrganizationUpdate(this IQueryable<ProjectOrganizationUpdate> projectOrganizationUpdates, int projectOrganizationUpdateID)
        {
            var projectOrganizationUpdate = projectOrganizationUpdates.SingleOrDefault(x => x.ProjectOrganizationUpdateID == projectOrganizationUpdateID);
            Check.RequireNotNullThrowNotFound(projectOrganizationUpdate, "ProjectOrganizationUpdate", projectOrganizationUpdateID);
            return projectOrganizationUpdate;
        }

        public static void DeleteProjectOrganizationUpdate(this List<int> projectOrganizationUpdateIDList)
        {
            if(projectOrganizationUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectOrganizationUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectOrganizationUpdates.Where(x => projectOrganizationUpdateIDList.Contains(x.ProjectOrganizationUpdateID)));
            }
        }

        public static void DeleteProjectOrganizationUpdate(this ICollection<ProjectOrganizationUpdate> projectOrganizationUpdatesToDelete)
        {
            if(projectOrganizationUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectOrganizationUpdates.RemoveRange(projectOrganizationUpdatesToDelete);
            }
        }

        public static void DeleteProjectOrganizationUpdate(this int projectOrganizationUpdateID)
        {
            DeleteProjectOrganizationUpdate(new List<int> { projectOrganizationUpdateID });
        }

        public static void DeleteProjectOrganizationUpdate(this ProjectOrganizationUpdate projectOrganizationUpdateToDelete)
        {
            DeleteProjectOrganizationUpdate(new List<ProjectOrganizationUpdate> { projectOrganizationUpdateToDelete });
        }
    }
}