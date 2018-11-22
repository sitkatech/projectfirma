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
        public static ProjectGeospatialAreaTypeNoteUpdate GetProjectGeospatialAreaTypeNoteUpdate(this IQueryable<ProjectGeospatialAreaTypeNoteUpdate> projectGeospatialAreaTypeNoteUpdates, int projectGeospatialAreaTypeNoteID)
        {
            var projectGeospatialAreaTypeNoteUpdate = projectGeospatialAreaTypeNoteUpdates.SingleOrDefault(x => x.ProjectGeospatialAreaTypeNoteID == projectGeospatialAreaTypeNoteID);
            Check.RequireNotNullThrowNotFound(projectGeospatialAreaTypeNoteUpdate, "ProjectGeospatialAreaTypeNoteUpdate", projectGeospatialAreaTypeNoteID);
            return projectGeospatialAreaTypeNoteUpdate;
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this List<int> projectGeospatialAreaTypeNoteIDList)
        {
            if(projectGeospatialAreaTypeNoteIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaTypeNoteUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreaTypeNoteUpdates.Where(x => projectGeospatialAreaTypeNoteIDList.Contains(x.ProjectGeospatialAreaTypeNoteID)));
            }
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this ICollection<ProjectGeospatialAreaTypeNoteUpdate> projectGeospatialAreaTypeNoteUpdatesToDelete)
        {
            if(projectGeospatialAreaTypeNoteUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaTypeNoteUpdates.RemoveRange(projectGeospatialAreaTypeNoteUpdatesToDelete);
            }
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this int projectGeospatialAreaTypeNoteID)
        {
            DeleteProjectGeospatialAreaTypeNoteUpdate(new List<int> { projectGeospatialAreaTypeNoteID });
        }

        public static void DeleteProjectGeospatialAreaTypeNoteUpdate(this ProjectGeospatialAreaTypeNoteUpdate projectGeospatialAreaTypeNoteUpdateToDelete)
        {
            DeleteProjectGeospatialAreaTypeNoteUpdate(new List<ProjectGeospatialAreaTypeNoteUpdate> { projectGeospatialAreaTypeNoteUpdateToDelete });
        }
    }
}