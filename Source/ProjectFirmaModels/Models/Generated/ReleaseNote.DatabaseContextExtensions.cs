//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReleaseNote]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ReleaseNote GetReleaseNote(this IQueryable<ReleaseNote> releaseNotes, int releaseNoteID)
        {
            var releaseNote = releaseNotes.SingleOrDefault(x => x.ReleaseNoteID == releaseNoteID);
            Check.RequireNotNullThrowNotFound(releaseNote, "ReleaseNote", releaseNoteID);
            return releaseNote;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReleaseNote(this IQueryable<ReleaseNote> releaseNotes, List<int> releaseNoteIDList)
        {
            if(releaseNoteIDList.Any())
            {
                releaseNotes.Where(x => releaseNoteIDList.Contains(x.ReleaseNoteID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReleaseNote(this IQueryable<ReleaseNote> releaseNotes, ICollection<ReleaseNote> releaseNotesToDelete)
        {
            if(releaseNotesToDelete.Any())
            {
                var releaseNoteIDList = releaseNotesToDelete.Select(x => x.ReleaseNoteID).ToList();
                releaseNotes.Where(x => releaseNoteIDList.Contains(x.ReleaseNoteID)).Delete();
            }
        }

        public static void DeleteReleaseNote(this IQueryable<ReleaseNote> releaseNotes, int releaseNoteID)
        {
            DeleteReleaseNote(releaseNotes, new List<int> { releaseNoteID });
        }

        public static void DeleteReleaseNote(this IQueryable<ReleaseNote> releaseNotes, ReleaseNote releaseNoteToDelete)
        {
            DeleteReleaseNote(releaseNotes, new List<ReleaseNote> { releaseNoteToDelete });
        }
    }
}