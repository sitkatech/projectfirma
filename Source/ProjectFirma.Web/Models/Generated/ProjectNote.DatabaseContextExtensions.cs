//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNote]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteProjectNote(this IQueryable<ProjectNote> projectNotes, List<int> projectNoteIDList)
        {
            if(projectNoteIDList.Any())
            {
                projectNotes.Where(x => projectNoteIDList.Contains(x.ProjectNoteID)).Delete();
            }
        }

        public static void DeleteProjectNote(this IQueryable<ProjectNote> projectNotes, ICollection<ProjectNote> projectNotesToDelete)
        {
            if(projectNotesToDelete.Any())
            {
                var projectNoteIDList = projectNotesToDelete.Select(x => x.ProjectNoteID).ToList();
                projectNotes.Where(x => projectNoteIDList.Contains(x.ProjectNoteID)).Delete();
            }
        }

        public static void DeleteProjectNote(this IQueryable<ProjectNote> projectNotes, int projectNoteID)
        {
            DeleteProjectNote(projectNotes, new List<int> { projectNoteID });
        }

        public static void DeleteProjectNote(this IQueryable<ProjectNote> projectNotes, ProjectNote projectNoteToDelete)
        {
            DeleteProjectNote(projectNotes, new List<ProjectNote> { projectNoteToDelete });
        }
    }
}