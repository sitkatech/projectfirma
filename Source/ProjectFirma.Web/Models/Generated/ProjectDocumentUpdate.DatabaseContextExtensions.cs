//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocumentUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectDocumentUpdate GetProjectDocumentUpdate(this IQueryable<ProjectDocumentUpdate> projectDocumentUpdates, int projectDocumentUpdateID)
        {
            var projectDocumentUpdate = projectDocumentUpdates.SingleOrDefault(x => x.ProjectDocumentUpdateID == projectDocumentUpdateID);
            Check.RequireNotNullThrowNotFound(projectDocumentUpdate, "ProjectDocumentUpdate", projectDocumentUpdateID);
            return projectDocumentUpdate;
        }

        public static void DeleteProjectDocumentUpdate(this List<int> projectDocumentUpdateIDList)
        {
            if(projectDocumentUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectDocumentUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectDocumentUpdates.Where(x => projectDocumentUpdateIDList.Contains(x.ProjectDocumentUpdateID)));
            }
        }

        public static void DeleteProjectDocumentUpdate(this ICollection<ProjectDocumentUpdate> projectDocumentUpdatesToDelete)
        {
            if(projectDocumentUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectDocumentUpdates.RemoveRange(projectDocumentUpdatesToDelete);
            }
        }

        public static void DeleteProjectDocumentUpdate(this int projectDocumentUpdateID)
        {
            DeleteProjectDocumentUpdate(new List<int> { projectDocumentUpdateID });
        }

        public static void DeleteProjectDocumentUpdate(this ProjectDocumentUpdate projectDocumentUpdateToDelete)
        {
            DeleteProjectDocumentUpdate(new List<ProjectDocumentUpdate> { projectDocumentUpdateToDelete });
        }
    }
}