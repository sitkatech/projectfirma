//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNoteUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectGeospatialAreaTypeNoteUpdate GetProjectGeospatialAreaTypeNoteUpdate(this IQueryable<ProjectGeospatialAreaTypeNoteUpdate> projectGeospatialAreaTypeNoteUpdates, int projectGeospatialAreaTypeNoteUpdateID)
        {
            var projectGeospatialAreaTypeNoteUpdate = projectGeospatialAreaTypeNoteUpdates.SingleOrDefault(x => x.ProjectGeospatialAreaTypeNoteUpdateID == projectGeospatialAreaTypeNoteUpdateID);
            Check.RequireNotNullThrowNotFound(projectGeospatialAreaTypeNoteUpdate, "ProjectGeospatialAreaTypeNoteUpdate", projectGeospatialAreaTypeNoteUpdateID);
            return projectGeospatialAreaTypeNoteUpdate;
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this List<int> projectGeospatialAreaTypeNoteUpdateIDList)
        {
            if(projectGeospatialAreaTypeNoteUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaTypeNoteUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreaTypeNoteUpdates.Where(x => projectGeospatialAreaTypeNoteUpdateIDList.Contains(x.ProjectGeospatialAreaTypeNoteUpdateID)));
            }
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this ICollection<ProjectGeospatialAreaTypeNoteUpdate> projectGeospatialAreaTypeNoteUpdatesToDelete)
        {
            if(projectGeospatialAreaTypeNoteUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaTypeNoteUpdates.RemoveRange(projectGeospatialAreaTypeNoteUpdatesToDelete);
            }
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this int projectGeospatialAreaTypeNoteUpdateID)
        {
            DeleteProjectGeospatialAreaTypeNoteUpdate(new List<int> { projectGeospatialAreaTypeNoteUpdateID });
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this ProjectGeospatialAreaTypeNoteUpdate projectGeospatialAreaTypeNoteUpdateToDelete)
        {
            DeleteProjectGeospatialAreaTypeNoteUpdate(new List<ProjectGeospatialAreaTypeNoteUpdate> { projectGeospatialAreaTypeNoteUpdateToDelete });
        }
    }
}