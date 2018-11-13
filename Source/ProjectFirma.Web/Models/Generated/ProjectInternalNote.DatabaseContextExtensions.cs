//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectInternalNote]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectInternalNote GetProjectInternalNote(this IQueryable<ProjectInternalNote> projectInternalNotes, int projectInternalNoteID)
        {
            var projectInternalNote = projectInternalNotes.SingleOrDefault(x => x.ProjectInternalNoteID == projectInternalNoteID);
            Check.RequireNotNullThrowNotFound(projectInternalNote, "ProjectInternalNote", projectInternalNoteID);
            return projectInternalNote;
        }

        public static void DeleteProjectInternalNote(this List<int> projectInternalNoteIDList)
        {
            if(projectInternalNoteIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectInternalNotes.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectInternalNotes.Where(x => projectInternalNoteIDList.Contains(x.ProjectInternalNoteID)));
            }
        }

        public static void DeleteProjectInternalNote(this ICollection<ProjectInternalNote> projectInternalNotesToDelete)
        {
            if(projectInternalNotesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectInternalNotes.RemoveRange(projectInternalNotesToDelete);
            }
        }

        public static void DeleteProjectInternalNote(this int projectInternalNoteID)
        {
            DeleteProjectInternalNote(new List<int> { projectInternalNoteID });
        }

        public static void DeleteProjectInternalNote(this ProjectInternalNote projectInternalNoteToDelete)
        {
            DeleteProjectInternalNote(new List<ProjectInternalNote> { projectInternalNoteToDelete });
        }
    }
}