//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNote]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectGeospatialAreaTypeNote GetProjectGeospatialAreaTypeNote(this IQueryable<ProjectGeospatialAreaTypeNote> projectGeospatialAreaTypeNotes, int projectGeospatialAreaTypeNoteID)
        {
            var projectGeospatialAreaTypeNote = projectGeospatialAreaTypeNotes.SingleOrDefault(x => x.ProjectGeospatialAreaTypeNoteID == projectGeospatialAreaTypeNoteID);
            Check.RequireNotNullThrowNotFound(projectGeospatialAreaTypeNote, "ProjectGeospatialAreaTypeNote", projectGeospatialAreaTypeNoteID);
            return projectGeospatialAreaTypeNote;
        }

        public static void DeleteProjectGeospatialAreaTypeNote(this List<int> projectGeospatialAreaTypeNoteIDList)
        {
            if(projectGeospatialAreaTypeNoteIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaTypeNotes.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreaTypeNotes.Where(x => projectGeospatialAreaTypeNoteIDList.Contains(x.ProjectGeospatialAreaTypeNoteID)));
            }
        }

        public static void DeleteProjectGeospatialAreaTypeNote(this ICollection<ProjectGeospatialAreaTypeNote> projectGeospatialAreaTypeNotesToDelete)
        {
            if(projectGeospatialAreaTypeNotesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreaTypeNotes.RemoveRange(projectGeospatialAreaTypeNotesToDelete);
            }
        }

        public static void DeleteProjectGeospatialAreaTypeNote(this int projectGeospatialAreaTypeNoteID)
        {
            DeleteProjectGeospatialAreaTypeNote(new List<int> { projectGeospatialAreaTypeNoteID });
        }

        public static void DeleteProjectGeospatialAreaTypeNote(this ProjectGeospatialAreaTypeNote projectGeospatialAreaTypeNoteToDelete)
        {
            DeleteProjectGeospatialAreaTypeNote(new List<ProjectGeospatialAreaTypeNote> { projectGeospatialAreaTypeNoteToDelete });
        }
    }
}