//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoteUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectNoteUpdate GetProjectNoteUpdate(this IQueryable<ProjectNoteUpdate> projectNoteUpdates, int projectNoteUpdateID)
        {
            var projectNoteUpdate = projectNoteUpdates.SingleOrDefault(x => x.ProjectNoteUpdateID == projectNoteUpdateID);
            Check.RequireNotNullThrowNotFound(projectNoteUpdate, "ProjectNoteUpdate", projectNoteUpdateID);
            return projectNoteUpdate;
        }

        public static void DeleteProjectNoteUpdate(this List<int> projectNoteUpdateIDList)
        {
            if(projectNoteUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectNoteUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectNoteUpdates.Where(x => projectNoteUpdateIDList.Contains(x.ProjectNoteUpdateID)));
            }
        }

        public static void DeleteProjectNoteUpdate(this ICollection<ProjectNoteUpdate> projectNoteUpdatesToDelete)
        {
            if(projectNoteUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectNoteUpdates.RemoveRange(projectNoteUpdatesToDelete);
            }
        }

        public static void DeleteProjectNoteUpdate(this int projectNoteUpdateID)
        {
            DeleteProjectNoteUpdate(new List<int> { projectNoteUpdateID });
        }

        public static void DeleteProjectNoteUpdate(this ProjectNoteUpdate projectNoteUpdateToDelete)
        {
            DeleteProjectNoteUpdate(new List<ProjectNoteUpdate> { projectNoteUpdateToDelete });
        }
    }
}