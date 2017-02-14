//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNote]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectNote GetProjectNote(this IQueryable<ProjectNote> projectNotes, int projectNoteID)
        {
            var projectNote = projectNotes.SingleOrDefault(x => x.ProjectNoteID == projectNoteID);
            Check.RequireNotNullThrowNotFound(projectNote, "ProjectNote", projectNoteID);
            return projectNote;
        }

        public static void DeleteProjectNote(this List<int> projectNoteIDList)
        {
            if(projectNoteIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectNotes.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectNotes.Where(x => projectNoteIDList.Contains(x.ProjectNoteID)));
            }
        }

        public static void DeleteProjectNote(this ICollection<ProjectNote> projectNotesToDelete)
        {
            if(projectNotesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectNotes.RemoveRange(projectNotesToDelete);
            }
        }

        public static void DeleteProjectNote(this int projectNoteID)
        {
            DeleteProjectNote(new List<int> { projectNoteID });
        }

        public static void DeleteProjectNote(this ProjectNote projectNoteToDelete)
        {
            DeleteProjectNote(new List<ProjectNote> { projectNoteToDelete });
        }
    }
}